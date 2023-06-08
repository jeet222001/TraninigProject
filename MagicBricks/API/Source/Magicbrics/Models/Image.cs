using System;
using System.Collections.Generic;

#nullable disable

namespace Magicbrics.Models
{
    public partial class Image
    {
        public int ImageId { get; set; }
        public string Imagename { get; set; }
        public int? PropertyId { get; set; }
        public int? ImageTypeId { get; set; }
        public string File { get; set; }

        public virtual ApplicationObjectType ImageType { get; set; }
        public virtual Property Property { get; set; }
    }
}
