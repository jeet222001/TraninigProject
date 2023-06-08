using Magicbrics.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Magicbrics.Services
{
    public interface IImageService : IRepository<Image>
    {
        string AddImages(List<IFormFile> files);
    }
    public class ImageService:Repository<Image>,IImageService
    {
        public ImageService(magicbrics2392jeetContext dbContext) : base(dbContext)
        {

        }

        public string AddImages(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                var fileName = string.Format("../Files", file.FileName);
                var fileStream = new FileStream(fileName, FileMode.Append);
                file.CopyTo(fileStream);
                fileStream.Close();
            }
            return "";
          
        }
    }
}
