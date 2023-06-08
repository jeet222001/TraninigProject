using Magicbrics.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magicbrics.Services
{
    public interface ICountryService : IRepository<Country>
    {
    }


    public class CountryService:Repository<Country>,ICountryService
    {
        public CountryService(magicbrics2392jeetContext DbContext) : base(DbContext)
        {

        }
    }
}
