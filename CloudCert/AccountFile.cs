using CloudCert.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCert
{
    public class AccountFile
    {

        /// <summary>
        /// 创建文件ID
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="fileId"></param>
        /// <param name="fileName"></param>
        /// <param name="length"></param>
        /// <param name="hash"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public string FileCreate(string accessToken, string fileId, string fileName, long length, string hash, string comment)
        {
            string apiPath = "opencloud/api/contract/create.json";

            Dictionary<string, string> par = new Dictionary<string, string>();

            par["app_key"] = AppHelp.key;

            par["access_token"] = accessToken;
            par["id"] = fileId;
            par["length"] = length.ToString();
            par["hash"] = hash;
            par["comment"] = comment;
            par["name"] = fileName;


            string str = AppHelp.post(apiPath, par);

            var dict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(str);
            if(dict.ContainsKey("contract_id"))
            {
                return dict["contract_id"];
            }

            return "";
            // {"contract_id":"2016127"}
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="fileId"></param>
        /// <param name="bFile">这个byte，不能从文件中读取，要从post过来的字节流中读取</param>
        /// <returns></returns>
        public string FileUpload(string contract_id, byte[] bFile,long index)
        {


            string apiPath = "opencloud/api/contract/upload.json";

            Dictionary<string, string> par = new Dictionary<string, string>();

            par["app_key"] = AppHelp.key;
            par["contract_id"] = contract_id;
            par["index"] = index.ToString(); 

            string str = AppHelp.postFile(apiPath, par, bFile, contract_id);

            return str;


        }

        /// <summary>
        /// 获取已上传的文件
        /// </summary>
        /// <param name="contract_id"></param>
        /// <returns></returns>
        public long GetFileLength(string contract_id)
        {
            string apiPath = "opencloud/api/contract/length.json";

            Dictionary<string, string> par = new Dictionary<string, string>();

            par["app_key"] = AppHelp.key;
            par["contract_id"] = contract_id;


            string str = AppHelp.get(apiPath, par);

            var dict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, long>>(str);
            if (dict.ContainsKey("upload_length"))
            {
                return dict["upload_length"];
            }

            return 0;


        }

        /// <summary>
        /// 合同签章
        /// </summary>
        /// <param name="contract_id"></param>
        /// <returns>文件ID</returns>
        public string Stamp(string contract_id, int status, StampUserAgreement stampUserAgreements)
        {
            string apiPath = "opencloud/api/contract/stamp.json";

            string str = stampUserAgreements.toString();


            Dictionary<string, string> par = new Dictionary<string, string>();

            par["app_key"] = AppHelp.key;
            par["contract_id"] = contract_id;

            par["status"] = status.ToString();

            par["param"] = str;  


            string strRep = AppHelp.post(apiPath, par);

            //return strRep;

            var dict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(strRep);

            return dict["stamps"][0]["file_id"];

           // Dictionary < string, List<Dictionary<string,string>>>

            //{"stamps":[{"user_id":"5290049","file_id":"2100835"}]}
        }


        public byte[] DownloadFile(string contract_id)
        {
            string apiPath = "opencloud/api/contract/download.json";

            Dictionary<string, string> par = new Dictionary<string, string>();

            par["app_key"] = AppHelp.key;
            par["contract_id"] = contract_id;

            byte[] b = AppHelp.getFile(apiPath, par);

            return b;

        }

    }
}
