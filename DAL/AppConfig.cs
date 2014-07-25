using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace Mondiland.DAL
{
    /// <summary>
    /// 生成连接数据库的字符串
    /// </summary>
    class AppConfig
    {
        public static string BuildConnectionString
        {
            get
            {
                SqlConnectionStringBuilder build = new SqlConnectionStringBuilder();

                build.DataSource = GetAppConfig("DataSource");
                build.InitialCatalog = GetAppConfig("InitialCatalog");
                build.IntegratedSecurity = false;
                build.UserID = "mondiland";
                build.Password = "mondiland163";
                build.ConnectTimeout = Convert.ToInt32(GetAppConfig("ConnectTimeout"));

                return build.ConnectionString;
            }
        }
        /// <summary>
        /// 根据给定的项目名称得到该项目的值
        /// </summary>
        /// <param name="strKey">要查找的项目名称</param>
        /// <returns>项目值</returns>
        private static string GetAppConfig(string strKey)
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == strKey)
                {
                    return ConfigurationManager.AppSettings[strKey];
                }
            }

            return "none";
        }

        private AppConfig()
        {
        }
    }
}
