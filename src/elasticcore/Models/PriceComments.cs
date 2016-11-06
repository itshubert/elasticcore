using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class PriceComments
    {
        public PriceComments()
        {
            Boats = new HashSet<Boats>();
        }

        public int PriceCommentId { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<Boats> Boats { get; set; }
    }
}
