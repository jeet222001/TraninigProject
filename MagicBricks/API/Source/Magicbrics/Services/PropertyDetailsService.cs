using Magicbrics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magicbrics.Services
{
    public interface IPropertyDetailsService : IRepository<VwgpropertyDetail> 
    {
    }

    public class PropertyDetailsService : Repository<VwgpropertyDetail>, IPropertyDetailsService
    {
      public PropertyDetailsService(magicbrics2392jeetContext dbContext) : base(dbContext)
        {

        }
    }
}
