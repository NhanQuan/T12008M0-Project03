using System;
using System.Collections.Generic;

#nullable disable

namespace Airline_04_12.Models
{
    public partial class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreateAt { get; set; }
        public string CreateBy { get; set; }
        public string UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public string Status { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public string UserId { get; set; }

        public virtual Account User { get; set; }
    }
}
