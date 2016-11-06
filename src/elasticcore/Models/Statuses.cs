using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class Statuses
    {
        public Statuses()
        {
            Boats = new HashSet<Boats>();
        }

        public int StatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Boats> Boats { get; set; }
    }
}
