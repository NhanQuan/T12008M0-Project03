using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineSystem.Models
{
    public partial class AirTicket
    {
        public int AirTicketId { get; set; }
        public double? Price { get; set; }
        public int? Discount { get; set; }
        public string StatusTicket { get; set; }
        public string ChairId { get; set; }
        public string TicketCateogry { get; set; }
        public int? FlightId { get; set; }

        public virtual Flight Flight { get; set; }
    }
}
