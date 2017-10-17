using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CloudCert.Tools
{
    public class Sha1Help
    {
        /// <summary>
        /// Sha1 标准算法，uft8
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string Encrypt_Sha1(string strSource)
        {
            byte[] bytes_sha1_in = UTF8Encoding.UTF8.GetBytes(strSource);

            var provide = SHA1.Create();

            var outSha1 = provide.ComputeHash(bytes_sha1_in);

            return UTF8Encoding.UTF8.GetString(outSha1).Replace("-", "").ToLower();


        }


        public static string Encrypt_Sha1_16(byte[] bfs)
        {
            String hashSHA1 = String.Empty;

            System.Security.Cryptography.SHA1 calculator = System.Security.Cryptography.SHA1.Create();
            Byte[] buffer = calculator.ComputeHash(bfs);
            calculator.Clear();
            //将字节数组转换成十六进制的字符串形式
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                stringBuilder.Append(buffer[i].ToString("x2"));
            }
            hashSHA1 = stringBuilder.ToString();

            return hashSHA1;

        }
    }
}
