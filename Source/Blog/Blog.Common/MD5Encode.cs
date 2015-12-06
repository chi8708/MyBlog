using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Blog.Common
{
    public class MD5Encode
    {
       public static string MD5(string str)
       {
           byte[] b =Encoding.UTF8.GetBytes(str);
           b= new MD5CryptoServiceProvider().ComputeHash(b);
           string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');

            return ret.ToUpper();
       }
    }
}
