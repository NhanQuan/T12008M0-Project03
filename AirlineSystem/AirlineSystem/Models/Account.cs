using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineSystem.Models
{
    public partial class Account
    {
        public Account()
        {
            Bills = new HashSet<Bill>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public int? AccountRole { get; set; }
        public string DisplayName { get; set; }

        public virtual Role AccountRoleNavigation { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
