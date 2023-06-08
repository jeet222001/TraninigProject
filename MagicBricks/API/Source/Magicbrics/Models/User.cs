using System;
using System.Collections.Generic;

#nullable disable

namespace Magicbrics.Models
{
    public partial class User
    {
        public User()
        {
            Properties = new HashSet<Property>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? DateReg { get; set; }
        public string PhoneNo { get; set; }
        public int? UserTypeId { get; set; }
        public string Otpno { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual ApplicationObjectType UserType { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}
