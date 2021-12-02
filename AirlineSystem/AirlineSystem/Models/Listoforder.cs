using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineSystem.Models
{
    public partial class Listoforder
    {
        public int Id { get; set; }
        public int? AirTicketId { get; set; }
        public double? Price { get; set; }
        public string ChairId { get; set; }
        public string TicketCategory { get; set; }
        public int? FlightId { get; set; }
        public string FlightDate { get; set; }
        public string ReturnDate { get; set; }
        public string FlightCategory { get; set; }
        public string EmployUser { get; set; }
        public string StatusOrder { get; set; }
        public string StartingPoint { get; set; }
        public string FinalDestination { get; set; }
        public string AirLineName { get; set; }
        public int? Discount { get; set; }
        public string CustomerName { get; set; }
        public int? TransactionId { get; set; }
        public DateTime? TimeOrder { get; set; }
    }
}
