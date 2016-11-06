using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class EnquiryReadStatuses
    {
        public int EnquiryReadStatusId { get; set; }
        public int EnquiryId { get; set; }
        public DateTime ReadDate { get; set; }
        public string UserId { get; set; }

        public virtual Enquiries Enquiry { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
