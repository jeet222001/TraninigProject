using System;
using System.Collections.Generic;

#nullable disable

namespace Magicbrics.Models
{
    public partial class VwPropertyDetail
    {
        public int PropertyId { get; set; }
        public int? BrsId { get; set; }
        public string PropertyDescription { get; set; }
        public int? PropertyTypeId { get; set; }
        public int? UserId { get; set; }
        public string AgeOfConstruction { get; set; }
        public string AvailableFrom { get; set; }
        public int? Balconies { get; set; }
        public int? Bathrooms { get; set; }
        public int? Bedrooms { get; set; }
        public int? BgcId { get; set; }
        public int? FloorNo { get; set; }
        public string FurnishedStatus { get; set; }
        public string PossessionStatus { get; set; }
        public decimal? Price { get; set; }
        public int? CarpetArea { get; set; }
        public int? SuperArea { get; set; }
        public decimal? TokenAmount { get; set; }
        public int? TotalFloors { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int? Pincode { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public string Imagename { get; set; }
        public long? DenseRank { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }
}
