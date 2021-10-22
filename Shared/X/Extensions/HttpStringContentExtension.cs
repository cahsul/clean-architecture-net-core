using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Shared.X.Extensions
{
    public static class HttpStringContentExtension
    {

        public static StringContent HttpStringContentJson(this string data)
        {
            return new StringContent(data, Encoding.UTF8, "application/json");
        }
    }
}
