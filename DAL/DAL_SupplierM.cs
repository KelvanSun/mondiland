using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

using Mondiland.Entity;
using Mondiland.IDal;
using Mondiland.Global;

namespace Mondiland.DAL
{
    public class DAL_SupplierM:BaseDal<Table_SupplierM_Entity>,ITable_SupplierM
    {
        public static DAL_SupplierM Instance
		{
			get
			{
				return new DAL_SupplierM();
			}
		}
        public DAL_SupplierM()
            : base("SupplierM", "id", string.Empty, OrderType.ASC)
		{ }

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Table_SupplierM_Entity DataReaderToEntity(IDataReader dataReader)
        {
            Table_SupplierM_Entity entity = new Table_SupplierM_Entity();
            SmartDataReader reader = new SmartDataReader(dataReader);

            entity.Id = reader.GetInt32("id");
            entity.Class_Id = reader.GetInt32("class_id");
            entity.Name = reader.GetString("name");
            entity.Intact_Name = reader.GetString("intact_name");
            entity.Bank_Name = reader.GetString("bank_name");
            entity.Account = reader.GetString("account");
            entity.Phone = reader.GetString("phone");
            entity.Fax = reader.GetString("fax");
            entity.Memo = reader.GetString("memo");
            entity.LasTamp = reader.GetLong("lastamp");

            return entity;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值(用于插入或者更新操作)
        /// (提供了默认的反射机制获取信息，为了提高性能，建议重写该函数)
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Table_SupplierM_Entity obj)
        {
            Table_SupplierM_Entity info = obj as Table_SupplierM_Entity;
            Hashtable hash = new Hashtable();

            hash.Add("id", info.Id);
            hash.Add("class_id", info.Class_Id);
            hash.Add("name", info.Name);
            hash.Add("intact_name", info.Intact_Name);
            hash.Add("bank_name", info.Bank_Name);
            hash.Add("account", info.Account);
            hash.Add("phone", info.Phone);
            hash.Add("fax", info.Fax);
            hash.Add("memo", info.Memo);
            hash.Add("lastamp", info.LasTamp);

            return hash;
        }
    }
}
