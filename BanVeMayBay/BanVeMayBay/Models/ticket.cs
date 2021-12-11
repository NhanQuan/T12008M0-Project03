namespace BanVeMayBay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ticket")]
    public partial class ticket
    {
       
         [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Ticket is not blank")]
        public string name { get; set; }
        [Required(ErrorMessage = "Description is not blank")]
        public string description { get; set; }
        public string flightCode { get; set; }
        
        public string airline { get; set; }
        [Required(ErrorMessage = "Airport is not blank")]
        public string airport { get; set; }
        public string ticketType { get; set; }
        public string img { get; set; }      
        public string departure_address { get; set; }
        public string arrival_address { get; set; }
        public DateTime departure_date { get; set; }
        [Required(ErrorMessage = "Seats is not blank"), Range(50, int.MaxValue, ErrorMessage = "Please enter a value bigger than {50}")]
        public int? guestTotal { get; set; }
        [Required(ErrorMessage = "Price is not blank"), Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public double price { get; set; }
        public double priceSale { get; set; }
        public int sold { get; set; }

        public DateTime created_at { get; set; }
        public int created_by { get; set; }

        public DateTime updated_at { get; set; }
        public int updated_by { get; set; }
        public int status { get; set; }
        public TimeSpan departure_time { get; set; }
        public TimeSpan arrival_time { get; set; }
    }
}
