using System;
using System.Collections.Generic;

#nullable disable

namespace Magicbrics.Models
{
    public partial class ContactOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public int? Otpno { get; set; }
        public int? PrpertyId { get; set; }

        public virtual Property Prperty { get; set; }
    }
}
