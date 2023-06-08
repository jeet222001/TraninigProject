using System;
using System.Collections.Generic;

#nullable disable

namespace Magicbrics.Models
{
    public partial class Property
    {
        public Property()
        {
            ContactOwners = new HashSet<ContactOwner>();
            Images = new HashSet<Image>();
            Locations = new HashSet<Location>();
            PropertyFacilities = new HashSet<PropertyFacility>();
        }

        public int PropertyId { get; set; }
        public int? PropertyTypeId { get; set; }
        public string PropertyDescription { get; set; }
        public int? BrsId { get; set; }
        public int? UserId { get; set; }

        public virtual ApplicationObjectType Brs { get; set; }
        public virtual ApplicationObjectType PropertyType { get; set; }
        public virtual ICollection<ContactOwner> ContactOwners { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<PropertyFacility> PropertyFacilities { get; set; }
    }
}
