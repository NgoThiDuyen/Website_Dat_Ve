using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web_Dat_Ve_Xem_Phim.Models;

namespace Website_Dat_Ve.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController()
        {
            _httpClient = new HttpClient();
            // Cấu hình các thông tin liên quan đến API như địa chỉ base URL, token xác thực, ...
            _httpClient.BaseAddress = new Uri("http://192.168.1.15:8086/");
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer YourAccessToken");
        }
        public async Task<ActionResult> Index()
        {
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}