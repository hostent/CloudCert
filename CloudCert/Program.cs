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


            /*          

                      byte[] b = File.ReadAllBytes(@"G:\test01.pdf");

                      string hash = Sha1Help.Encrypt_Sha1_16(b);

                      var fileId = new AccountFile().FileCreate("3a439c1f-8ba8-4fba-97ba-797a074e6976", "2017101716331900006", "测试file02",
                          b.Length, hash, "testfile-common");

                      long fileLength =  new AccountFile().GetFileLength(fileId);


                      if (b.Length - fileLength > 0)
                      {
                          var result = new AccountFile().FileUpload("3a439c1f-8ba8-4fba-97ba-797a074e6976", fileId, b, fileLength);
                      }

               */

            string userId = "";

            var accesstoken = new Folw().GetAccessToken("15860794941",out userId);

            var result = new UserAuth().GetAccountVerify(accesstoken);

            



        }
    }
 
}
