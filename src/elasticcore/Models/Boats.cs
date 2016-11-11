using Nest;
using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    [ElasticsearchType(IdProperty = "Id", Name = "boats")]
    public partial class Boats
    {
        public Boats()
        {
            BoatCategories = new HashSet<BoatCategories>();
            BoatImages = new HashSet<BoatImages>();
            BoatViews = new HashSet<BoatViews>();
            Enquiries = new HashSet<Enquiries>();
            Pdfs = new HashSet<Pdfs>();
            Videos = new HashSet<Videos>();
        }

        public int Id { get; set; }
        public string Ref { get; set; }
        public string MakeModel { get; set; }
        [Object(Store = false)]
        public int? CurrencyId { get; set; }
        public decimal? Price { get; set; }
        public int? Year { get; set; }
        public string Description { get; set; }
        public string VesselName { get; set; }
        [Object(Store = false)]
        public string Length { get; set; }
        [Object(Store = false)]
        public int UnitId { get; set; }
        public string Designer { get; set; }
        public string Builder { get; set; }
        public string HullMaterial { get; set; }
        public string DecksMaterial { get; set; }
        public string Beam { get; set; }
        public string Draft { get; set; }
        public string Weight { get; set; }
        public string Keel { get; set; }
        public string Dinghy { get; set; }
        public string Engine { get; set; }
        public string EngineHours { get; set; }
        public string GenSet { get; set; }
        public string Fuel { get; set; }
        public string Water { get; set; }
        public string Outboard { get; set; }
        public string Covers { get; set; }
        public string Shower { get; set; }
        public string Toilet { get; set; }
        public string Accommodation { get; set; }
        public string Galley { get; set; }
        public string Refrigeration { get; set; }
        public string GroundTackle { get; set; }
        public string SafetyGear { get; set; }
        public string Electrics { get; set; }
        public string Electronics { get; set; }
        public string SailInventory { get; set; }
        public string Rigging { get; set; }
        public string DeckGear { get; set; }
        public string EngineRoom { get; set; }
        public string Survey { get; set; }
        public string Remarks { get; set; }
        [Object(Store = false)]
        public int RegionId { get; set; }
        [Object(Store = false)]
        public bool Visible { get; set; }
        [Object(Store = false)]
        public DateTime CreatedDate { get; set; }
        [Object(Store = false)]
        public DateTime UpdatedDate { get; set; }
        public string Location { get; set; }
        [Object(Store = false)]
        public int StatusId { get; set; }
        [Object(Store = false)]
        public int? PriceCommentId { get; set; }
        [Object(Store = false)]
        public bool Deleted { get; set; }
        [Object(Store = false)]
        public bool Tweeted { get; set; }
        [Object(Store = false)]
        public bool Facebook { get; set; }
        [Object(Store = false)]
        public int? Bdid { get; set; }
        public string BdstockNumber { get; set; }
        [Object(Store = false)]
        public string CreatedBy { get; set; }
        [Object(Store = false)]
        public string UpdatedBy { get; set; }

        [Object(Ignore = true)]
        public virtual ICollection<BoatCategories> BoatCategories { get; set; }
        [Object(Ignore = true)]
        public virtual ICollection<BoatImages> BoatImages { get; set; }
        [Object(Ignore = true)]
        public virtual ICollection<BoatViews> BoatViews { get; set; }
        [Object(Ignore = true)]
        public virtual ICollection<Enquiries> Enquiries { get; set; }
        [Object(Ignore = true)]
        public virtual ICollection<Pdfs> Pdfs { get; set; }
        [Object(Ignore = true)]
        public virtual ICollection<Videos> Videos { get; set; }
        [Object(Ignore = true)]
        public virtual AspNetUsers CreatedByNavigation { get; set; }
        [Object(Ignore = true)]
        public virtual Currencies Currency { get; set; }
        [Object(Ignore = true)]
        public virtual PriceComments PriceComment { get; set; }
        [Object(Ignore = true)]
        public virtual Regions Region { get; set; }
        [Object(Ignore = true)]
        public virtual Statuses Status { get; set; }
        [Object(Ignore = true)]
        public virtual Units Unit { get; set; }
        [Object(Ignore = true)]
        public virtual AspNetUsers UpdatedByNavigation { get; set; }
    }
}
