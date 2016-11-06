using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class ContactEnquiries
    {
        public int ContactEnquiryId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
