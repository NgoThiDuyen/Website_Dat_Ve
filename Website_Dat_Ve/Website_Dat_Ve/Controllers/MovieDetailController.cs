using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Website_Dat_Ve.Core;
using Website_Dat_Ve.Models;

namespace Website_Dat_Ve.Controllers
{
    public class MovieDetailController : Controller
    {
        // GET: MovieDetail
        public async Task<ActionResult> Index(int id)
        {
            var _httpClient = MyHttpClient.Instance;

            string apiUrl = _httpClient.BaseAddress + "api/Movie/GetMovieDetail?movieId=" + id.ToString();
            string apiScheduleUrl = _httpClient.BaseAddress + "api/Schedule/GetScheduleListByMovieId?movieId=" + id.ToString();
            string apiMovieOther = _httpClient.BaseAddress + "api/Movie/GetMovieSuggest?sugguestType=" + id.ToString();
            string apiTest = "http://192.168.1.14:8086/api/Schedule/GetScheduleListByMovieId?movieId=" + id.ToString();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                HttpResponseMessage scheduleResponse = await client.GetAsync(apiScheduleUrl);
                HttpResponseMessage otherMovieResponse = await client.GetAsync(apiMovieOther);
                if (scheduleResponse.IsSuccessStatusCode)
                {
                    var scheResponse = await scheduleResponse.Content.ReadAsAsync<APIResponseDto<List<ScheduleVM>>>();
                    ViewBag.Schedule = scheResponse.Data;

                }
                else
                {
                    ViewBag.Schedule = null;
                }


                if (otherMovieResponse.IsSuccessStatusCode)
                {
                    var otherResponse = await otherMovieResponse.Content.ReadAsAsync<APIResponseDto<List<MovieVM>>>();
                    ViewBag.OtherMovie = otherResponse.Data;

                }
                else
                {
                    ViewBag.OtherMovie = null;
                }

                if (response.IsSuccessStatusCode)
                {
                    var movieResponse = await response.Content.ReadAsAsync<APIResponseDto<MovieVM>>();
                    return View(movieResponse.Data);
                }
                else
                {
                    // Xử lý khi gọi API không thành công
                    return View(new MovieVM());
                }

                
            }

        }

        public async Task<ActionResult> GetSchedule(int idMovie)
        {
            var _httpClient = MyHttpClient.Instance;

            string apiUrl = _httpClient.BaseAddress + "api/Schedule/GetScheduleListByMovieId?movieId=" + idMovie.ToString();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var movieResponse = await response.Content.ReadAsAsync<APIResponseDto<ScheduleVM>>();
                    return PartialView(movieResponse.Data);
                }
                else
                {
                    // Xử lý khi gọi API không thành công
                    return PartialView(new List<ScheduleVM>());
                }
            }
        }

    }
}