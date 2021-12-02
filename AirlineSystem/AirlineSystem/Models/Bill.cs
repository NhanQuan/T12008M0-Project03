using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineSystem.Models
{
    public partial class Bill
    {
        public int Id { get; set; }
        public int? TotalPirce { get; set; }
        public int? TotalCount { get; set; }
        public int? Oderer { get; set; }
        public DateTime CreateBillDate { get; set; }

        public virtual Account OdererNavigation { get; set; }
    }
}
