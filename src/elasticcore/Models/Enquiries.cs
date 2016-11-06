using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class Enquiries
    {
        public Enquiries()
        {
            EnquiryReadStatuses = new HashSet<EnquiryReadStatuses>();
        }

        public int Id { get; set; }
        public int BoatId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string Location { get; set; }

        public virtual ICollection<EnquiryReadStatuses> EnquiryReadStatuses { get; set; }
        public virtual Boats Boat { get; set; }
    }
}
