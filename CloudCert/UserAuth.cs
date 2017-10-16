using CloudCert.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCert
{
    public class UserAuth
    {
        /// <summary>
        /// 判断账号是否存在
        /// </summary>
        /// <param name="outId"></param>
        /// <returns></returns>
        public Dictionary<string,bool> AccountExist(string outId)
        {
            string apiPath = "opencloud/api/account/exist.json";

            Dictionary<string, string> par = new Dictionary<string, string>();

            par["app_key"] = AppHelp.key;
            par["out_id"] = outId;



            string str = AppHelp.get(apiPath, par);

           return Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, bool>>(str);

        }

        /// <summary>
        /// 创建账号
        /// </summary>
        /// <param name="outId"></param>
        /// <returns></returns>
        public string CreateAccount(string outId)
        {
            string apiPath = "opencloud/api/account/create.json";

            Dictionary<string, string> par = new Dictionary<string, string>();

            par["app_key"] = AppHelp.key;
            par["out_id"] = outId;



            string str = AppHelp.post(apiPath, par);

            return str;
            // "{\"user_id\":\"5290049\"}"
        }

        /// <summary>
        /// 授权
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string AaccessToken(string userId)
        {
            string apiPath = "opencloud/api/account/access_token.json";

            Dictionary<string, string> par = new Dictionary<string, string>();

            par["app_key"] = AppHelp.key;
            par["user_id"] = userId;



            string str = AppHelp.get(apiPath, par);

            return str;

        }

        /// <summary>
        /// 判断是否实名认证
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public string GetAccountVerify(string accessToken)
        {
            string apiPath = "opencloud/api/account/verify.json";

            Dictionary<string, string> par = new Dictionary<string, string>();

            par["access_token"] = accessToken;        


            string str = AppHelp.get(apiPath, par);

            return str;

            //{"verify":false}

        }

        /// <summary>
        /// 实名认证
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="realName"></param>
        /// <param name="card"></param>
        /// <param name="bank"></param>
        /// <returns></returns>
        public string CreateAccountVerify(string accessToken,string realName, string card ,string bank)
        {
            string apiPath = "opencloud/api/account/verify.json";

            Dictionary<string, string> par = new Dictionary<string, string>();

            par["access_token"] = accessToken;
            par["real_name"] = realName;
            par["card"] = card;
            par["bank"] = bank;
           



            string str = AppHelp.post(apiPath, par);

            return str;

            //{"verify":true}

        }



        /// <summary>
        /// 获取账号电子签章状态
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public string GetAccountStamp(string accessToken)
        {
            string apiPath = "opencloud/api/account/stamp.json";

            Dictionary<string, string> par = new Dictionary<string, string>();

            par["access_token"] = accessToken;



            string str = AppHelp.get(apiPath, par);

            return str;

            //{"stamp":":false}
        }


        /// <summary>
        /// 完善账号信息，生成电子签章
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="realName"></param>
        /// <param name="card"></param>
        /// <param name="stamp"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string CreateAccountStamp(string accessToken, string realName, string card, string stamp, string type)
        {


            string apiPath = "opencloud/api/account/stamp.json";

            Dictionary<string, string> par = new Dictionary<string, string>();

            par["access_token"] = accessToken;
            par["real_name"] = realName;
            par["card"] = card;
            par["stamp"] = stamp;
            par["type"] = type;



            string str = AppHelp.post(apiPath, par);

            return str;

            //{"stamp":":true}
        }



        /// <summary>
        /// 账号申请第三方证书
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public string AccountCertItrus(string accessToken)
        {
            string apiPath = "opencloud/api/account/cert/itrus.json";

            Dictionary<string, string> par = new Dictionary<string, string>();

            par["access_token"] = accessToken;


            string str = AppHelp.post(apiPath, par);

            return str;


            //{"cert_install":true}
        }


    }
}
