using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web_Dat_Ve_Xem_Phim.Models;
using Website_Dat_Ve.Models;

namespace Website_Dat_Ve.Controllers
{
    public class HomeController : Controller
    {
       
        public async Task<ActionResult> Index()
        {
            var _httpClient = MyHttpClient.Instance;

            string apiUrl = _httpClient.BaseAddress + "api/Movie/GetMovieByCategory";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var movieResponse = await response.Content.ReadAsAsync<MovieResponse>();
                    return View(movieResponse.Data);
                }
                else
                {
                    // Xử lý khi gọi API không thành công
                    return View(new List<MovieVM>());
                }
            }
        }
    }
}