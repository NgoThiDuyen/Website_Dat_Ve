using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Website_Dat_Ve.Core;
using Website_Dat_Ve.Models;

namespace Website_Dat_Ve.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public async Task<ActionResult> Index(int scheduleId, string selectedSeats)
        {
            var _httpClient = MyHttpClient.Instance;

            string apiUrl = _httpClient.BaseAddress + "api/Schedule/GetScheduleDetail?scheduleId=" + scheduleId.ToString();
            ViewBag.ScheduleId = scheduleId;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);


                if (response.IsSuccessStatusCode)
                {
                    var movieResponse = await response.Content.ReadAsAsync<APIResponseDto<DetailScheduleVM>>();
                    ViewBag.DataSchedule = movieResponse.Data;
                    return View(movieResponse.Data);
                }
                else
                {
                    // Xử lý khi gọi API không thành công
                    ViewBag.DataSchedule = null;
                }
            }
            ViewBag.ListSeat = "F1,F2,F3";

            return View(new DetailScheduleVM());
        }


        [HttpPost]
        public async Task<ActionResult> Index(PaymentVM model)
        {
            var _httpClient = MyHttpClient.Instance;
            string token;
            if (Session["Token"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                token = Session["Token"].ToString();
            }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string apiUrl = _httpClient.BaseAddress + "api/OrderTicket/CompleteBookTicket";
            var paymentRequest = new
            {
                scheduleId = model.ScheduleId,
                numberPhone = model.NumberPhone,
                name = model.Name,
                email = model.Email,
                seatList = "F1, F2, F3",
            };
            var response = await _httpClient.PostAsJsonAsync(apiUrl, paymentRequest);
            if (response.IsSuccessStatusCode)
            {
                var paymentResponse = await response.Content.ReadAsAsync<APIResponseDto<PaymentVM>>();
                if (paymentResponse != null && paymentResponse.Code == "Oke")
                {
                    ViewBag.SuccessOrder = "Đặt vé thành công!";
                    return RedirectToAction("OrderHistory", "Payment") ;
                }
            }
            return View(new DetailScheduleVM());
        }

        [HttpGet]
        public async Task<ActionResult> OrderHistory()
        {
            var _httpClient = MyHttpClient.Instance;
            string token;
            if (Session["Token"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                token = Session["Token"].ToString();
            }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string apiUrl = _httpClient.BaseAddress + "api/OrderTicket/OrderHistory";
            var response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var paymentResponse = await response.Content.ReadAsAsync<APIResponseDto<List<OrderHistoryVM>>>();
                if (paymentResponse != null && paymentResponse.Code == "Oke")
                {
                    return View(paymentResponse.Data);
                }
            }
            return View(new List<OrderHistoryVM>());
        }
    }
}