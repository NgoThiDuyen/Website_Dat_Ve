using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Dat_Ve.Models
{
    public class OrderHistoryVM
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int scheduleId { get; set; }
        public string Name { get; set; }
        public string NumberPhone { get; set; }
        public string Email { get; set; }
        public string SeatList { get; set; }
        public string TotalPrice { get; set;}
        public string OrderDateString { get; set;}
        public string MovieName { get; set; }
        public string Image { get; set;}
        public string PlayScheduleString { get; set;}

    }
}