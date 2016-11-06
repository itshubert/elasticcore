using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class NewsItems
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string NewsText { get; set; }
        public bool Publish { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime PublishDate { get; set; }
        public string ImageFilename { get; set; }
        public bool Twitter { get; set; }
        public bool Facebook { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual AspNetUsers CreatedByNavigation { get; set; }
        public virtual AspNetUsers UpdatedByNavigation { get; set; }
    }
}
