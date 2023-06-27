using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Web_Dat_Ve_Xem_Phim.Models;

namespace Website_Dat_Ve.Models
{
    public class UserResponse
    {
        public string Code { get; set; }
        public string Des { get; set; }
        public string Message { get; set; }
        public DataLogin Data { get; set; }
    }
    public class DataLogin
    {
        public string Token { get; set; }
        public string Role { get; set; }
        public UserVM User { get; set; }
    }
    public class UserVM
    {
        public int Id { get; set; }
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }
        [Display(Name = "Số điện thoại")]
        public string NumberPhone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}