﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CloudCert.Tools
{
    public class HttpClientHelp 
    {
        public static string  Get(string url, IDictionary<string, string> par, IDictionary<string, string> head = null)
        {

            string ret = string.Empty;
            try
            {
                String str = "";

                foreach(var item in par)
                {
                    str = str+ item.Key + "=" +MyEncoding.UrlEncode(item.Value) + "&";
                }
                str = str.TrimEnd('&');

                url = url + "?" + str;

                if (url.ToLower().StartsWith("https://"))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                }


                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(url));
                 
                webReq.Method = "GET";
                webReq.ContentType = "text/html;charset=UTF-8";
                webReq.ProtocolVersion = HttpVersion.Version10;

                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ret;
        }

        public static string Post(string url, string body, IDictionary<string, string> head = null)
        {
            string ret = string.Empty;
            try
            {

                if (url.ToLower().StartsWith("https://"))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(url));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";

                byte[] bytes = Encoding.UTF8.GetBytes(body); //转化
                var text = Convert.ToBase64String(bytes);

                //text = MyEncoding.UrlEncode(text);
               // text = "data=" + text;
                //bytes = Encoding.UTF8.GetBytes(text);

                webReq.ContentLength = bytes.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);//写入参数
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
            }
            catch (Exception ex)
            {
                 
                throw ex;
            }
            return ret;
        }

        public static string Post(string url, IDictionary<string, string> body, IDictionary<string, string> head = null)
        {
            string ret = string.Empty;
            try
            {
                var parStr = "";

                foreach (var item in body)
                {
                    parStr = parStr + "&" + item.Key + "=" + item.Value;
                }
                parStr = parStr.Trim('&');

                if (url.ToLower().StartsWith("https://"))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(url));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";

                if (head != null)
                {//不为null
                    foreach (var item in head)
                    {
                        webReq.Headers.Add(item.Key, item.Value);
                    }
                }

                byte[] bytes = Encoding.UTF8.GetBytes(parStr); //转化

                webReq.ContentLength = bytes.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);//写入参数
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return ret;
        }

        public static string PostJson(string url, string json)
        {
            try
            {
                HttpWebRequest request = null;
                HttpWebResponse response = null;

                if (url.ToLower().StartsWith("https://"))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json;charset=UTF-8";
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                //向请求添加表单数据
                byte[] postdatabyte = Encoding.UTF8.GetBytes(json);
                request.ContentLength = postdatabyte.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(postdatabyte, 0, postdatabyte.Length); //设置请求主体的内容
                stream.Close();

                response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader responseReader = new StreamReader(responseStream);
                return responseReader.ReadToEnd();
            }
            catch (Exception e)
            {
                
                return "";
            }
        }


        public static string PostFile(string url, byte[] bFile)
        {

            try
            {
                HttpWebRequest request = null;
                HttpWebResponse response = null;

                if (url.ToLower().StartsWith("https://"))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                }

                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "multipart/form-data";
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                //向请求添加表单数据
                byte[] postdatabyte = bFile;
                request.ContentLength = postdatabyte.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(postdatabyte, 0, postdatabyte.Length); //设置请求主体的内容
                stream.Close();

                response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader responseReader = new StreamReader(responseStream);
                return responseReader.ReadToEnd();
            }
            catch (Exception e)
            {

                return "";
            }
        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            //直接确认，否则打不开    
            return true;
        }
    }
}