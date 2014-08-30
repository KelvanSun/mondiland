using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Mondiland.Global
{
    public class UtilFun
    {
        public static string GetMD5(string in_str)
        {
            byte[] result = Encoding.Default.GetBytes(in_str.Trim());    //tbPass为输入密码的文本框  
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            
            return BitConverter.ToString(output).Replace("-", "");  //tbMd5pass为输出加密文
        }
    }
}
