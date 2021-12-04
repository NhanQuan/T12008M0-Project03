using System;
using System.Collections.Generic;

#nullable disable

namespace Airline_04_12.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public string TicketId { get; set; }
        public int? Quantity { get; set; }
        public string UserId { get; set; }
        public double? Total { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual Account User { get; set; }
    }
}
