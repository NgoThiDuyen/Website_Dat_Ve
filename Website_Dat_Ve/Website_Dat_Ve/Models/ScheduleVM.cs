using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Dat_Ve.Models
{
    public class ScheduleVM
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public DateTime PlaySchedule { get; set; }
        public string PlayScheduleString { get;set; }
        public string TimePlayString { get; set; }
        public bool IsCanBook { get; set; }

    }
    public class DetailScheduleVM : ScheduleVM
    {
        public string SeatHaveBeenBookedList { get; set; }
        public string MovieName { get; set; }
        public string Author { get; set; }
        public string Cast { get; set; }
        public string MovieDescription { get; set; }
        public int MovieType { get; set; }
        public int MovieTime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Image { get; set; }
        public string CinemaName { get; set; }
    }
}