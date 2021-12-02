using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineSystem.Models
{
    public partial class AirLine
    {
        public AirLine()
        {
            BillDeTails = new HashSet<BillDeTail>();
            Flights = new HashSet<Flight>();
        }

        public int AirLineId { get; set; }
        public string AirLineName { get; set; }
        public string AirLineStatus { get; set; }

        public virtual ICollection<BillDeTail> BillDeTails { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
