﻿using System;
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
    public class OrderTicketController : Controller
    {
        // GET: OrderTicket
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> OrderPlan(int idSchedule)
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
            string apiUrl = _httpClient.BaseAddress + "api/Schedule/GetScheduleDetail?scheduleId=" + idSchedule.ToString();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);


                if (response.IsSuccessStatusCode)
                {
                    var movieResponse = await response.Content.ReadAsAsync<APIResponseDto<DetailScheduleVM>>();
                    return View(movieResponse.Data);
                }
                else
                {
                    // Xử lý khi gọi API không thành công
                    return View(new DetailScheduleVM());
                }


            }
        }
    }
}