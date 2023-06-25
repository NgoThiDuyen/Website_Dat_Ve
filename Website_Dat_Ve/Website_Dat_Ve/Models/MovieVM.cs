using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Dat_Ve_Xem_Phim.Models
{
    public class MovieResponse
    {
        public string Code { get; set; }
        public string Des { get; set; }
        public string Message { get; set; }
        public List<MovieVM> Data { get; set; }
    }
    public class MovieVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Cast { get; set; }
        public int MovieType { get; set; }
        public int Time { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int NumberBooking { get; set; }
        public int NumberView { get; set; }
    }
}