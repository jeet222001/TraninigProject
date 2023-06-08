using Magicbrics.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Magicbrics.Services
{
    public interface IPropertyService:IRepository<Property>
    {
        public Property AddProperty(Property property);
        public string UpdateProperty(int id, Property property);
        public object DeleteProperty(int id);
    }
    public class PropertyService:Repository<Property>,IPropertyService
    {
        public IWebHostEnvironment WebHost { get; set; }
        public PropertyService(magicbrics2392jeetContext dbContext,IWebHostEnvironment webHost) : base(dbContext)
        {
            WebHost = webHost;
        }
     
         
      
        public  Property AddProperty(Property property)
        {
            string rootpath = WebHost.WebRootPath + "\\Images\\";
            foreach(var b in property.Images.ToArray())
            {
                if (b.File != null)
                {

                    var fileName = string.Concat(rootpath, b.Imagename);
                    byte[] myarr = Convert.FromBase64String(b.File);
                    File.WriteAllBytes(fileName, myarr);
                }
                else
                {
                    continue;
                }
                
            }
            foreach(var img in property.Images.ToArray())
            {
                img.File = null;
            }
            base.Add(property);
            return property;
        }

        public string UpdateProperty(int id,Property property)
        {
            var Property = base.GetById(id);
            if (Property == null) return $"Property Not Exists with This ID: {id}";
            base.Update(property,id);
            return $"Property with id {id} Updated Successfully";
        }
        public object DeleteProperty(int id)
        {
            var Property = base.GetById(id);
            if (Property == null) return new Response() { Status = 404, Message = "Property Not Found" };
            base.Remove(Property);
            return new Response() { Status = 200, Message = "Property Deleted Successfully" };

        }
    }
}