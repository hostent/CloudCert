using CloudCert.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCert
{
    class Program
    {
        static void Main(string[] args)
        {
            //var result = new UserAuth().AccountExist("15860794941");

            //var result = new UserAuth().AaccessToken("5290049");

            //"{\"user_id\":\"5290049\"}"

            // var result = new AccountFile().FileCreate("3a439c1f-8ba8-4fba-97ba-797a074e6976",
            //     "2017101616331900004", "测试文件01", 8, "128d70ki78j38d9", "测试文件01-beizhu");

            string userId = "5290049";

            string accessToken = "935d8fce-36df-4b15-acfd-3dfc46e17fd4";




            byte[] b = File.ReadAllBytes(@"G:\test01-stamp.pdf");

            string hash = Sha1Help.Encrypt_Sha1_16(b);

            var fileId = new AccountFile().FileCreate(accessToken, "2017101816331900001", "测试file03",
                b.Length, hash, "testfile-common");

            long fileLength = new AccountFile().GetFileLength(fileId);


            if (b.Length - fileLength > 0)
            {
                var result = new AccountFile().FileUpload(fileId, b, fileLength);
            }





            //var accesstoken = new Folw().GetAccessToken("15860794941",out userId);

            // var result = new UserAuth().GetAccountVerify(accesstoken);
            //{"file_id":"2016127"}

            //UserAuth ua = new UserAuth();

            //var accessToken = ua.AccessToken(userId);

            //new Folw().StampVerify(accessToken, "李坤龙", "350628198506302037", "6217923876763525", null, "2");

            //签章
            //string newFileId =  new Folw().Stamp(fileId, new StampUserAgreement()
            //  {
            //      pageIndex = 1,
            //      userId = userId,
            //      xPos = 50,
            //      yPos = 50,
            //      width = 50,
            //      height = 50
            //  });

            //2100835

            //"{\"contract_id\":\"1675367\"}"

            //byte[] bbb=   new AccountFile().DownloadFile("1675367");

            //FileStream pFileStream =  File.Create(@"G:\test01-stamp.pdf");

            //pFileStream.Write(bbb, 0, bbb.Length);

            //pFileStream.Flush();

        }
    }

}
