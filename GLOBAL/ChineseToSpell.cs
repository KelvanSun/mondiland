using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Global
{
    /// <summary>  
    /// 汉字转拼音首字母  
    /// </summary>  
    public static class ChineseToSpell
    {
        /// <summary>  
        /// 返回字符串首个拼音字母  
        /// </summary>  
        /// <param name="strText">汉字字符串</param>  
        /// <returns>返回由strText中第一个字符的拼音首字母</returns>  
        public static string GetFistSpell(string strText)
        {
            int len = strText.Length;
            string myStr = "";
            if (len > 0)
            {
                myStr = getSpell(strText.Substring(0, 1));
            }
            return myStr;
        }

        /// <summary>  
        /// 返回汉字字符串拼音首字母  
        /// </summary>  
        /// <param name="strText">汉字字符串</param>  
        /// <returns>返回由strText中字符及汉字部分的拼音首字母构成的字符串</returns>  
        public static string GetChineseSpell(string strText)
        {
            if (string.IsNullOrEmpty(strText)) return string.Empty;
            
            int len = strText.Length;
            string myStr = "";
            for (int i = 0; i < len; i++)
            {
                myStr += getSpell(strText.Substring(i, 1));
            }
            return myStr.ToUpper();
        }

        /// <summary>  
        /// 返回一个汉字的拼音首字母  
        /// </summary>  
        /// <param name="cnChar"></param>  
        /// <returns></returns>  
        public static string getSpell(string cnChar)
        {
            byte[] arrCN = Encoding.Default.GetBytes(cnChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "*";
            }
            else
                return cnChar.ToUpper();
        }
    }
}
