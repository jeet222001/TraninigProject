using Magicbrics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magicbrics.Services
{
    public interface IApplicationObjectService: IRepository<ApplicationObject>
    {
        public new string Add(ApplicationObject applicationObject);
        public string Update(int id, ApplicationObject applicationObject);
        public string Remove(int id);
    }
    public class ApplicationObjectService:Repository<ApplicationObject>,IApplicationObjectService
    {
        public ApplicationObjectService(magicbrics2392jeetContext dbContext) : base(dbContext)
        {

        }

        public new string Add(ApplicationObject applicationObject)
        {
            base.Add(applicationObject);
            return $"Application Object Name Added Successfully ID is: {applicationObject.AppObjid}";
        }
        public string Update(int id,ApplicationObject applicationObject)
        {
            var appobj = base.GetById(id);
            if (appobj == null) return $"Not Found With This ID {id}";
            base.Update(applicationObject,id);
            return $"Application Object Name Updated Successfully ID is: {applicationObject.AppObjid}";
        }
        public string Remove(int id)
        {
            var appobj = base.GetById(id);
            if (appobj == null) return $"Not Found With This ID {id}";
            base.Remove(appobj);
            return $"Application Object Name Deleted Successfully ID is: {appobj.AppObjid}";
        }
    }
}
