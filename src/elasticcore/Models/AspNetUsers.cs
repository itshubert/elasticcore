using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            BoatImagesCreatedByNavigation = new HashSet<BoatImages>();
            BoatImagesUpdatedByNavigation = new HashSet<BoatImages>();
            BoatsCreatedByNavigation = new HashSet<Boats>();
            BoatsUpdatedByNavigation = new HashSet<Boats>();
            EnquiryReadStatuses = new HashSet<EnquiryReadStatuses>();
            NewsItemsCreatedByNavigation = new HashSet<NewsItems>();
            NewsItemsUpdatedByNavigation = new HashSet<NewsItems>();
            SaleEnquiryReadStatuses = new HashSet<SaleEnquiryReadStatuses>();
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<BoatImages> BoatImagesCreatedByNavigation { get; set; }
        public virtual ICollection<BoatImages> BoatImagesUpdatedByNavigation { get; set; }
        public virtual ICollection<Boats> BoatsCreatedByNavigation { get; set; }
        public virtual ICollection<Boats> BoatsUpdatedByNavigation { get; set; }
        public virtual ICollection<EnquiryReadStatuses> EnquiryReadStatuses { get; set; }
        public virtual ICollection<NewsItems> NewsItemsCreatedByNavigation { get; set; }
        public virtual ICollection<NewsItems> NewsItemsUpdatedByNavigation { get; set; }
        public virtual ICollection<SaleEnquiryReadStatuses> SaleEnquiryReadStatuses { get; set; }
    }
}
