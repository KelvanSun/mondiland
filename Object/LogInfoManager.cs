using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.Entity;

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

        public static BindingList<LogInfoObject> GetLogCustomQueryInfo(DateTime dt_begin,DateTime dt_end,string str_username,string str_log)
        {
            BindingList<LogInfoObject> list = new BindingList<LogInfoObject>();

            
            using (ProductContext ctx = new ProductContext())
            {
                IQueryable<LogInfo> loginfos = null;     
          

                if(!string.IsNullOrEmpty(str_username) && !string.IsNullOrEmpty(str_log))
                {
                    loginfos = from entity in ctx.LogInfo
                                   where (DbFunctions.TruncateTime(entity.date_time) >= dt_begin && DbFunctions.TruncateTime(entity.date_time) <= dt_end)
                                           && entity.UserInfo.name.IndexOf(str_username) >= 0 && entity.log_info.IndexOf(str_log) >= 0
                                   select entity;
                }
                else if (!string.IsNullOrEmpty(str_username) && string.IsNullOrEmpty(str_log))
                {
                    loginfos = from entity in ctx.LogInfo
                               where (DbFunctions.TruncateTime(entity.date_time) >= dt_begin && DbFunctions.TruncateTime(entity.date_time) <= dt_end)
                                       && entity.UserInfo.name.IndexOf(str_username) >= 0
                               select entity;
                }
                else if (string.IsNullOrEmpty(str_username) && !string.IsNullOrEmpty(str_log))
                {
                    loginfos = from entity in ctx.LogInfo
                               where (DbFunctions.TruncateTime(entity.date_time) >= dt_begin && DbFunctions.TruncateTime(entity.date_time) <= dt_end)
                                       && entity.log_info.IndexOf(str_log) >= 0
                               select entity;
                }
                else
                {
                    loginfos = from entity in ctx.LogInfo
                               where DbFunctions.TruncateTime(entity.date_time) >= dt_begin && DbFunctions.TruncateTime(entity.date_time) <= dt_end
                               select entity;
                }
                
                foreach (var loginfo in loginfos)
                {
                    LogInfoObject obj = new LogInfoObject();
                    obj.Id = loginfo.id;
                    obj.Dt = loginfo.date_time;
                    obj.UserName = loginfo.UserInfo.name;
                    obj.LogInfo = loginfo.log_info;

                    list.Add(obj);
                }
            }
   
            return list;
        }

        public static BindingList<LogInfoObject> GetLogTodayInfo()
        {
            BindingList<LogInfoObject> list = new BindingList<LogInfoObject>();

            using (ProductContext ctx = new ProductContext())
            {
                var loginfos = from entity in ctx.LogInfo
                               where DbFunctions.TruncateTime(entity.date_time) == System.DateTime.Today
                               select entity;

                foreach (var loginfo in loginfos)
                {
                    LogInfoObject obj = new LogInfoObject();
                    obj.Id = loginfo.id;
                    obj.Dt = loginfo.date_time;
                    obj.UserName = loginfo.UserInfo.name;
                    obj.LogInfo = loginfo.log_info;

                    list.Add(obj);
                }

            }

            return list;
        }


        public static BindingList<LogInfoObject> GetLogAllInfo()
        {
            BindingList<LogInfoObject> list = new BindingList<LogInfoObject>();

            using (ProductContext ctx = new ProductContext())
            {
                var loginfos = from entity in ctx.LogInfo
                               select entity;

                foreach(var loginfo in loginfos)
                {
                    LogInfoObject obj = new LogInfoObject();
                    obj.Id = loginfo.id;
                    obj.Dt = loginfo.date_time;
                    obj.UserName = loginfo.UserInfo.name;
                    obj.LogInfo = loginfo.log_info;

                    list.Add(obj);
                }
            }


            return list;
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
