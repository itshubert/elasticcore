using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class Pdfs
    {
        public int PdfId { get; set; }
        public int BoatId { get; set; }
        public string Filename { get; set; }
        public bool Deleted { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Boats Boat { get; set; }
    }
}
