using System;
using System.Collections.Generic;

#nullable disable

namespace Magicbrics.Models
{
    public partial class ApplicationObject
    {
        public ApplicationObject()
        {
            ApplicationObjectTypes = new HashSet<ApplicationObjectType>();
        }

        public int AppObjid { get; set; }
        public string ObjectName { get; set; }

        public virtual ICollection<ApplicationObjectType> ApplicationObjectTypes { get; set; }
    }
}
