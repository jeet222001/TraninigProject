using System;
using System.Collections.Generic;

#nullable disable

namespace Magicbrics.Models
{
    public partial class PropertyFacility
    {
        public int FacilityId { get; set; }
        public int? PropertyId { get; set; }
        public bool? Food { get; set; }
        public bool? Ac { get; set; }
        public bool? Wifi { get; set; }
        public bool? SundayMeal { get; set; }
        public bool? Laundry { get; set; }
        public bool? ElectricCharge { get; set; }
        public bool? PowerBackup { get; set; }
        public bool? Lift { get; set; }
        public int? NoticePeriodMonth { get; set; }
        public int? SharingId { get; set; }
        public int? BgcId { get; set; }
        public int? PreferredTenants { get; set; }
        public int? Bedrooms { get; set; }
        public int? Balconies { get; set; }
        public int? FloorNo { get; set; }
        public int? TotalFloors { get; set; }
        public string FurnishedStatus { get; set; }
        public int? Bathrooms { get; set; }
        public int? CarpetArea { get; set; }
        public int? SuperArea { get; set; }
        public string PossessionStatus { get; set; }
        public string AvailableFrom { get; set; }
        public string AgeOfConstruction { get; set; }
        public decimal? Price { get; set; }
        public decimal? TokenAmount { get; set; }

        public virtual ApplicationObjectType Bgc { get; set; }
        public virtual ApplicationObjectType PreferredTenantsNavigation { get; set; }
        public virtual Property Property { get; set; }
        public virtual ApplicationObjectType Sharing { get; set; }
    }
}
