﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Magicbrics.Models
{
    public partial class Country
    {
        public Country()
        {
            States = new HashSet<State>();
        }

        public int CountryId { get; set; }
        public string Shortname { get; set; }
        public string Name { get; set; }
        public int? Phonecode { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
