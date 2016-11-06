using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class Currencies
    {
        public Currencies()
        {
            Boats = new HashSet<Boats>();
        }

        public int CurrencyId { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Boats> Boats { get; set; }
    }
}
