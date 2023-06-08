using Magicbrics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magicbrics.Services
{
   public interface ICityService:IRepository<City>
    {
    }

    public class CityService : Repository<City>, ICityService 
    {
        public CityService(magicbrics2392jeetContext DbContext) : base(DbContext)
        {

        }
    }
}
