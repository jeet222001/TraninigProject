using Magicbrics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magicbrics.Services
{
    public interface IApplicationObjectTypeService : IRepository<ApplicationObjectType>
    {
        public new string Add(ApplicationObjectType applicationObjectType);
        public string Update(int id, ApplicationObjectType applicationObjectType);
        public string Remove(int id);
    }

    public class ApplicationObjectTypeService:Repository<ApplicationObjectType>,IApplicationObjectTypeService
    {
        public ApplicationObjectTypeService(magicbrics2392jeetContext dbContext) : base(dbContext)
        {

        }

        public new string Add(ApplicationObjectType applicationObjectType)
        {
            base.Add(applicationObjectType);
            return $"Object Type With ID : {applicationObjectType.TypeId} Added Successfully";
        }

        public string Update(int id,ApplicationObjectType applicationObjectType)
        {
            var appobj = base.GetById(id);
            if (appobj == null) return $"Not Found With Given ID : {id}";

            base.Update(applicationObjectType,id);
            return $"Object Type With ID : {applicationObjectType.TypeId} Added Successfully";
        }

        public string Remove(int id)
        {
            var applicationObjectType = base.GetById(id);
            if (applicationObjectType == null) return $"Not Found With Given ID : {id}";
            base.Remove(applicationObjectType);
            return $"Object Type With ID : {applicationObjectType.TypeId} Deleted Successfully";
        }
    }
}
