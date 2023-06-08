using System;
using System.Collections.Generic;

#nullable disable

namespace Magicbrics.Models
{
    public partial class ApplicationObjectType
    {
        public ApplicationObjectType()
        {
            Images = new HashSet<Image>();
            PropertyBrs = new HashSet<Property>();
            PropertyFacilityBgcs = new HashSet<PropertyFacility>();
            PropertyFacilityPreferredTenantsNavigations = new HashSet<PropertyFacility>();
            PropertyFacilitySharings = new HashSet<PropertyFacility>();
            PropertyPropertyTypes = new HashSet<Property>();
            Users = new HashSet<User>();
        }

        public int TypeId { get; set; }
        public int? AppObjid { get; set; }
        public string TypeName { get; set; }

        public virtual ApplicationObject AppObj { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Property> PropertyBrs { get; set; }
        public virtual ICollection<PropertyFacility> PropertyFacilityBgcs { get; set; }
        public virtual ICollection<PropertyFacility> PropertyFacilityPreferredTenantsNavigations { get; set; }
        public virtual ICollection<PropertyFacility> PropertyFacilitySharings { get; set; }
        public virtual ICollection<Property> PropertyPropertyTypes { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
