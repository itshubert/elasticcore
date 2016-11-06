using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class Categories
    {
        public Categories()
        {
            BoatCategories = new HashSet<BoatCategories>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool NewType { get; set; }
        public int SortOrder { get; set; }
        public bool Active { get; set; }
        public string Url { get; set; }

        public virtual ICollection<BoatCategories> BoatCategories { get; set; }
    }
}
