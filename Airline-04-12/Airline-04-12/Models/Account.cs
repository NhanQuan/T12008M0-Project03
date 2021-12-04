using System;
using System.Collections.Generic;

#nullable disable

namespace Airline_04_12.Models
{
    public partial class Account
    {
        public Account()
        {
            News = new HashSet<News>();
            Orders = new HashSet<Order>();
            Tickets = new HashSet<Ticket>();
        }

        public string UserId { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public int Role { get; set; }
        public string CreateAt { get; set; }
        public string CreateBy { get; set; }
        public string UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public int Status { get; set; }
        public string Passport { get; set; }
        public string Birthday { get; set; }

        public virtual Role RoleNavigation { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
