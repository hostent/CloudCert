using CloudCert.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCert
{
    public class AppHelp
    {

        static string basrUrl
        {
            get
            {
                return "https://www.cunnar.com:15443/";
            }
        }

        static string secret
        {
            get
            {
                return "02ed0805389a4b57ba0cc465693b9ff6";
            }
        }

        public static string key
        {
            get
            {
                return "201710120001";
            }
        }

        public static string post(string apiPath, Dictionary<string, string> par)
        {
            return HttpClientHelp.Post(AppHelp.basrUrl + apiPath, fillSign(par));
        }

        public static string get(string apiPath, Dictionary<string, string> par)
        {
            return HttpClientHelp.Get(AppHelp.basrUrl + apiPath, fillSign(par));
        }

        public static string postFile(string apiPath, Dictionary<string, string> par,byte[] bFile,string fileName)
        {
            par = fillSign(par);
            string parUrl = "";

            foreach (var item in par)
            {
                parUrl = parUrl + item.Key + "=" + MyEncoding.UrlEncode(item.Value) + "&";
            }
            parUrl = parUrl.TrimEnd('&');
            
            if(parUrl!="")
            {
                parUrl = "?" + parUrl;
            }            

            return HttpClientHelp.PostFile(AppHelp.basrUrl + apiPath+ parUrl, bFile, fileName);
        }

        static Dictionary<string, string> fillSign(Dictionary<string, string> dict)
        {
            Dictionary<string, string> result = dict;

            string str = "";
            foreach (var item in result.OrderBy(q => q.Key))
            {
                if (item.Key == "sign_type")
                {
                    continue;
                }
                if (item.Key == "sign")
                {
                    continue;
                }

                //str = str + item.Key + "=" + MyEncoding.UrlEncode(item.Value) + "&";
                str = str + item.Key + "=" + item.Value + "&";

            }

            str = str.Trim('&');

            str = str + secret;
            string sign = MD5Helper.Encrypt_MD5(str);

            result["sign_type"] = "MD5";
            result["sign"] = sign;

            return result;
        }
    }
}
