using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineSystem.Models
{
    public partial class BillDeTail
    {
        public int Id { get; set; }
        public int? FlightId { get; set; }
        public int? AirlineId { get; set; }
        public string FlightDate { get; set; }
        public int? Price { get; set; }
        public string Status { get; set; }
        public int? Discount { get; set; }

        public virtual AirLine Airline { get; set; }
        public virtual Flight Flight { get; set; }
    }
}
