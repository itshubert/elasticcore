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
        public int? CurrencyId { get; set; }
        public decimal? Price { get; set; }
        public int? Year { get; set; }
        public string Description { get; set; }
        public string VesselName { get; set; }
        public string Length { get; set; }
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
        public int RegionId { get; set; }
        public bool Visible { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Location { get; set; }
        public int StatusId { get; set; }
        public int? PriceCommentId { get; set; }
        public bool Deleted { get; set; }
        public bool Tweeted { get; set; }
        public bool Facebook { get; set; }
        public int? Bdid { get; set; }
        public string BdstockNumber { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<BoatCategories> BoatCategories { get; set; }
        public virtual ICollection<BoatImages> BoatImages { get; set; }
        public virtual ICollection<BoatViews> BoatViews { get; set; }
        public virtual ICollection<Enquiries> Enquiries { get; set; }
        public virtual ICollection<Pdfs> Pdfs { get; set; }
        public virtual ICollection<Videos> Videos { get; set; }
        public virtual AspNetUsers CreatedByNavigation { get; set; }
        public virtual Currencies Currency { get; set; }
        public virtual PriceComments PriceComment { get; set; }
        public virtual Regions Region { get; set; }
        public virtual Statuses Status { get; set; }
        public virtual Units Unit { get; set; }
        public virtual AspNetUsers UpdatedByNavigation { get; set; }
    }
}
