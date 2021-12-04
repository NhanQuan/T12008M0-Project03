using System;
using System.Collections.Generic;

#nullable disable

namespace Airline_04_12.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            Orders = new HashSet<Order>();
        }

        public string TicketId { get; set; }
        public string Name { get; set; }
        public string TicketType { get; set; }
        public string AirlineImg { get; set; }
        public string DepartureDate { get; set; }
        public double? Price { get; set; }
        public int Status { get; set; }
        public string DepartureAddress { get; set; }
        public string ArrivalAddress { get; set; }
        public int? FlightTime { get; set; }
        public string FlightCode { get; set; }
        public string CreateAt { get; set; }
        public string CreateBy { get; set; }
        public string UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public string UserId { get; set; }

        public virtual Account User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
