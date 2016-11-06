using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class Regions
    {
        public Regions()
        {
            Boats = new HashSet<Boats>();
            SaleEnquiriesCustomerRegion = new HashSet<SaleEnquiries>();
            SaleEnquiriesVesselRegion = new HashSet<SaleEnquiries>();
        }

        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public string Abbr { get; set; }

        public virtual ICollection<Boats> Boats { get; set; }
        public virtual ICollection<SaleEnquiries> SaleEnquiriesCustomerRegion { get; set; }
        public virtual ICollection<SaleEnquiries> SaleEnquiriesVesselRegion { get; set; }
    }
}
