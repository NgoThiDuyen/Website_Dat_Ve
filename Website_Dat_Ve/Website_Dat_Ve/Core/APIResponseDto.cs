using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Dat_Ve.Core
{
    public class APIResponseDto<T> where T : class
    {
        public string Code { get; set; }
        public string Des { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

    }
}