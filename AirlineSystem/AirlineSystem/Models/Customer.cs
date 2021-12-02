using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineSystem.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public int? Age { get; set; }
        public int? AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
