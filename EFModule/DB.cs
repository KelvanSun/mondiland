using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Mondiland.EFModule
{
    public class DB
    {
        public static string GetConnectString()
        {
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.DataSource = "192.168.1.3";
            sqlBuilder.InitialCatalog = "Product";
            sqlBuilder.UserID = "Mondiland";
            sqlBuilder.Password = "mondiland163";
            sqlBuilder.MultipleActiveResultSets = true;
            sqlBuilder.ApplicationName = "EntityFramework";
  
           
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();

            entityBuilder.Provider = "System.Data.SqlClient";
            entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
            entityBuilder.Metadata = "res://*/ProductModule.csdl|res://*/ProductModule.ssdl|res://*/ProductModule.msl";

            return entityBuilder.ToString();
        }
    }
}
