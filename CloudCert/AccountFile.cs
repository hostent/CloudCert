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
            string apiPath = "opencloud/api/file/create.json";

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
            if(dict.ContainsKey("file_id"))
            {
                return dict["file_id"];
            }

            return "";
            // {"file_id":"2016127"}
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="fileId"></param>
        /// <param name="bFile">这个byte，不能从文件中读取，要从post过来的字节流中读取</param>
        /// <returns></returns>
        public string FileUpload(string fileId, byte[] bFile,long index)
        {


            string apiPath = "opencloud/api/file/upload.json";

            Dictionary<string, string> par = new Dictionary<string, string>();

            par["app_key"] = AppHelp.key;
            par["file_id"] = fileId;
            par["index"] = index.ToString(); 

            string str = AppHelp.postFile(apiPath, par, bFile, fileId);

            return str;


        }

        /// <summary>
        /// 获取已上传的文件
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public long GetFileLength(string fileId)
        {
            string apiPath = "opencloud/api/file/length.json";

            Dictionary<string, string> par = new Dictionary<string, string>();

            par["app_key"] = AppHelp.key;
            par["file_id"] = fileId;


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
        /// <param name="fileId"></param>
        /// <returns></returns>
        public string Stamp(string fileId, List<StampUserAgreement> stampUserAgreements)
        {
            string apiPath = "opencloud/api/file/stamp.json";

            string str = "";

            stampUserAgreements.ForEach(q =>
            {
                str = str + "|" + q.toString();
            });

            str = str.Trim('|');

            Dictionary<string, string> par = new Dictionary<string, string>();

            par["app_key"] = AppHelp.key;
            par["file_id"] = fileId;

            par["param"] = str; // todo


            string strRep = AppHelp.post(apiPath, par);

            return strRep;
        }

    }
}
