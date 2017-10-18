using CloudCert.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCert
{
    public class Folw
    {
        /// <summary>
        /// 1. 用户授权，并返回用户ID，这个用户ID，要存储起来；授权会过期，可以考虑存储一天
        /// </summary>
        /// <param name="outId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetAccessToken(string outId, out string userId)
        {
            UserAuth ua = new UserAuth();

            //string outId = "15860794941";
            //var dict = new UserAuth().AccountExist(outId);
            //if(dict["account_exist"]==true)
            //{

            //}



            userId = ua.CreateAccount(outId);

            var accessToken = ua.AccessToken(userId);

            return accessToken;
        }

        /// <summary>
        /// 2. 上传文件 返回 fileId，这个ID也要存储起来
        /// </summary>
        /// <param name="fileByte"></param>
        /// <param name="fileUserId"></param>
        /// <param name="fileName"></param>
        /// <param name="fileCommen"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public string FileUpload(byte[] fileByte, string fileUserId, string fileName, string fileCommen, string accessToken)
        {

            //byte[] b = File.ReadAllBytes(@"G:\test01.pdf");

            AccountFile af = new AccountFile();

            string hash = Sha1Help.Encrypt_Sha1_16(fileByte);

            var fileId = af.FileCreate(accessToken, fileUserId, fileName,
                fileByte.Length, hash, fileCommen);

            long fileLength = af.GetFileLength(fileId);


            if (fileByte.Length - fileLength > 0)
            {
                var result = af.FileUpload(fileId, fileByte, fileLength);
            }

            return fileId;
        }

        /// <summary>
        /// 3. 签章前的认证
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="realName"></param>
        /// <param name="card"></param>
        /// <param name="bank"></param>
        /// <param name="stamp"></param>
        /// <param name="stampType"></param>
        public void StampVerify(string accessToken,string realName,string card,string bank,string stamp,string stampType)
        {
            //实名认证

            UserAuth ua = new UserAuth();

            if (!ua.GetAccountVerify(accessToken))
            {
               var averify = ua.CreateAccountVerify(accessToken, realName, card, bank);
            }

            //生成签章
            if(!ua.GetAccountStamp(accessToken))
            {
                var astamp =  ua.CreateAccountStamp(accessToken, realName, card, stamp, stampType);

                var certItrus =  ua.AccountCertItrus(accessToken);
            }

           

        }


        /// <summary>
        /// 4. 签章，一个个签
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="stampUserAgreements"></param>
        public string Stamp(string fileId,StampUserAgreement stampUserAgreements)
        {
            AccountFile af = new AccountFile();

            var result = af.Stamp(fileId, 0,stampUserAgreements);

            return result;
        }

        /// <summary>
        /// 5. 下载文件
        /// </summary>
        /// <param name="contract_id">合同号，之前上传文件的时候，创建的合同</param>
        /// <returns></returns>
        public byte[] DownloadFile(string contract_id)
        {
            return new AccountFile().DownloadFile(contract_id);
        }
    }
}
