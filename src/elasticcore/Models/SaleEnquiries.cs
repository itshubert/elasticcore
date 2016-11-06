using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class SaleEnquiries
    {
        public SaleEnquiries()
        {
            SaleEnquiryReadStatuses = new HashSet<SaleEnquiryReadStatuses>();
        }

        public int SaleEnquiryId { get; set; }
        public string Ipaddress { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int CustomerRegionId { get; set; }
        public string BoatType { get; set; }
        public string HullType { get; set; }
        public int Year { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Draft { get; set; }
        public string Engine { get; set; }
        public bool CommercialSurvey { get; set; }
        public string Location { get; set; }
        public int VesselRegionId { get; set; }
        public string Details { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<SaleEnquiryReadStatuses> SaleEnquiryReadStatuses { get; set; }
        public virtual Regions CustomerRegion { get; set; }
        public virtual Regions VesselRegion { get; set; }
    }
}
