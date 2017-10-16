using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CloudCert.Tools
{
    class MyEncoding
    {
        public static string UrlEncode(string context)
        {
            return HttpUtility.UrlEncode(context);

        }

        public static string UrlDecode(string context)
        {
            return HttpUtility.UrlDecode(context);
        }

        public static string HtmlEncode(string context)
        {
            return System.Net.WebUtility.HtmlEncode(context);
        }

        public static string HtmlDecode(string context)
        {
            return System.Net.WebUtility.HtmlDecode(context);
        }
    }
}
