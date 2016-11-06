using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class Videos
    {
        public int VideoId { get; set; }
        public int BoatId { get; set; }
        public string Url { get; set; }

        public virtual Boats Boat { get; set; }
    }
}
