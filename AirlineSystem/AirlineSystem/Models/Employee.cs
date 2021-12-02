using System;
using System.Collections.Generic;

#nullable disable

namespace AirlineSystem.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public int? Age { get; set; }
        public int? AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
