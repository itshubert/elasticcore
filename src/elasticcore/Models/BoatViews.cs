using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class BoatViews
    {
        public int Id { get; set; }
        public int BoatId { get; set; }
        public string Ipaddress { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Boats Boat { get; set; }
    }
}
