using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class Users
    {
        public Users()
        {
            WebpagesUsersInRoles = new HashSet<WebpagesUsersInRoles>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public virtual ICollection<WebpagesUsersInRoles> WebpagesUsersInRoles { get; set; }
    }
}
