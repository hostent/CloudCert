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
        public string FileCreate(string accessToken,string fileId,string fileName, long length,string hash,string comment)
        {
            string apiPath = "opencloud/api/account/file/create.json";

            Dictionary<string, string> par = new Dictionary<string, string>();

            par["access_token"] = accessToken;
            par["id"] = fileId;
            par["length"] = length.ToString();
            par["hash"] = hash;
            par["comment"] = comment;
            par["name"] = fileName;



            string str = AppHelp.post(apiPath, par);

            return str;
            // {"file_id":"2016127"}
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="fileId"></param>
        /// <param name="bFile"></param>
        /// <returns></returns>
        public string FileUpload(string accessToken, string fileId, byte[] bFile)
        {
            string apiPath = "opencloud/api/account/file/upload.json";

            Dictionary<string, string> par = new Dictionary<string, string>();

            par["access_token"] = accessToken;
            par["file_id"] = fileId;
            par["index"] = bFile.Length.ToString();

            string str = AppHelp.postFile(apiPath, par, bFile);

            return str;

            //{ "error":"10202","error_code":"文件不存在或不完整。"}

        }

        /// <summary>
        /// 合同签章
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public string Stamp(string fileId)
        {
            string apiPath = "opencloud/api/file/stamp.json";

            Dictionary<string, string> par = new Dictionary<string, string>();

            par["app_key"] = AppHelp.key;
            par["file_id"] = fileId;

            par["param"] = ""; // todo


            string str = AppHelp.post(apiPath, par);

            return str;
        }

    }
}
