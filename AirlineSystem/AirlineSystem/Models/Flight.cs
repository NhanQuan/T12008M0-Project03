using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineSystem.Models
{
    public partial class Flight
    {
        public Flight()
        {
            AirTickets = new HashSet<AirTicket>();
            BillDeTails = new HashSet<BillDeTail>();
        }

        public int FlightId { get; set; }
        public string FlightDate { get; set; }
        public string ReturnDate { get; set; }
        public string StartingPoint { get; set; }
        public string FinalDestination { get; set; }
        public string CategoryFlight { get; set; }
        public string StatusFlight { get; set; }
        public int? AirLineId { get; set; }

        public virtual AirLine AirLine { get; set; }
        public virtual ICollection<AirTicket> AirTickets { get; set; }
        public virtual ICollection<BillDeTail> BillDeTails { get; set; }
    }
}
