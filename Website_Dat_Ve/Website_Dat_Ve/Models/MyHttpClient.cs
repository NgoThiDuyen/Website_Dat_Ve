﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Website_Dat_Ve.Models
{
    public static class MyHttpClient
    {
        private static HttpClient _httpClient;

        static MyHttpClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://apirapphimdvh.bsite.net/");
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer YourAccessToken");
        }

        public static HttpClient Instance => _httpClient;
    }

}