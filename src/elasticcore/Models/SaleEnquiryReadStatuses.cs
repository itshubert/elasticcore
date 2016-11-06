using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class SaleEnquiryReadStatuses
    {
        public int SaleEnquiryReadStatusId { get; set; }
        public int SaleEnquiryId { get; set; }
        public DateTime ReadDate { get; set; }
        public string UserId { get; set; }

        public virtual SaleEnquiries SaleEnquiry { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
