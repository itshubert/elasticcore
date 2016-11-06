using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class BoatImages
    {
        public int Id { get; set; }
        public int BoatId { get; set; }
        public string Filename { get; set; }
        public int SortOrder { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Boats Boat { get; set; }
        public virtual AspNetUsers CreatedByNavigation { get; set; }
        public virtual AspNetUsers UpdatedByNavigation { get; set; }
    }
}
