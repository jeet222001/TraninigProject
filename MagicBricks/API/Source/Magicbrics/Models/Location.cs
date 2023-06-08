using System;
using System.Collections.Generic;

#nullable disable

namespace Magicbrics.Models
{
    public partial class Location
    {
        public int LocationId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int? CityId { get; set; }
        public int? Pincode { get; set; }
        public int? PropertyId { get; set; }

        public virtual Property Property { get; set; }
    }
}
