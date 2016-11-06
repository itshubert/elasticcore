using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class BoatCategories
    {
        public int Id { get; set; }
        public int BoatId { get; set; }
        public int CategoryId { get; set; }

        public virtual Boats Boat { get; set; }
        public virtual Categories Category { get; set; }
    }
}
