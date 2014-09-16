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

        public class LogInfoObject
        {
            private int m_id = 0;
            private DateTime m_dt = DateTime.Now;
            private string m_user_name = string.Empty;
            private string m_log_info = string.Empty;

            public int Id
            {
                get {return m_id;}
                set {m_id = value;}
            }

            public DateTime Dt
            {
                get { return m_dt; }
                set { m_dt = value; }
            }

            public string UserName
            {
                get { return m_user_name; }
                set { m_user_name = value; }
            }

            public string LogInfo
            {
                get { return m_log_info; }
                set { m_log_info = value; }
            }

        }
    }
}
