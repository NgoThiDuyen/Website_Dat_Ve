﻿using System.Web;
using System.Web.Mvc;

namespace Website_Dat_Ve
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
