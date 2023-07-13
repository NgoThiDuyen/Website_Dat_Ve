using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Dat_Ve.Models
{
    public class PaymentVM
    {
        public int ScheduleId { get; set; }
        public string NumberPhone { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SeatList { get; set; }

    }
}