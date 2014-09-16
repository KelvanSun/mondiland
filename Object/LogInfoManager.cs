using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mondiland.EFModule;

namespace Mondiland.Obj
{
    public class LogInfoManager
    {
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="user_id">用户ID</param>
        /// <param name="str_log">日志内容</param>
        public static void LogWrite(int user_id,string str_log)
        {
            LogInfo info = new LogInfo();
            info.date_time = System.DateTime.Now;
            info.user_id = user_id;
            info.log_info = str_log;

            using(ProductContext ctx = new ProductContext())
            {
                ctx.LogInfo.Add(info);

                ctx.SaveChanges();
            }

        }
    }
}
