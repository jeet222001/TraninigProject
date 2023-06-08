using System;
using System.Collections.Generic;

#nullable disable

namespace Magicbrics.Models
{
    public partial class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int? StateId { get; set; }

        public virtual State State { get; set; }
    }
}
