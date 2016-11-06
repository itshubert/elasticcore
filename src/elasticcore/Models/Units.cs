using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class Units
    {
        public Units()
        {
            Boats = new HashSet<Boats>();
        }

        public int UnitId { get; set; }
        public string Description { get; set; }
        public string Abbreviation { get; set; }

        public virtual ICollection<Boats> Boats { get; set; }
    }
}
