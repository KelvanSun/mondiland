using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.International.Converters.PinYinConverter;

namespace Mondiland.Global
{
    /// <summary>  
    /// 汉字转拼音首字母  
    /// </summary>  
    public static class ChineseToSpell
    {
        /// <summary>  
        /// 返回汉字字符串拼音首字母  
        /// </summary>  
        /// <param name="strText">汉字字符串</param>  
        /// <returns>返回由strText中字符及汉字部分的拼音首字母构成的字符串</returns>  
        public static string GetChineseSpell(string strText)
        {
            string r = string.Empty;
            foreach (char obj in strText)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, 1);
                }
                catch
                {
                    r += obj.ToString();
                }
            }
            return r;
        }
      
    }
}
