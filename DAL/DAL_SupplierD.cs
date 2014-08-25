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
    public class DAL_SupplierD:BaseDal<Table_SupplierD_Entity>,ITable_SupplierD
    {
        public static DAL_SupplierD Instance
		{
			get
			{
				return new DAL_SupplierD();
			}
		}
        public DAL_SupplierD()
            : base("SupplierD", "id", string.Empty, OrderType.ASC)
		{ }

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Table_SupplierD_Entity DataReaderToEntity(IDataReader dataReader)
        {
            Table_SupplierD_Entity entity = new Table_SupplierD_Entity();
            SmartDataReader reader = new SmartDataReader(dataReader);

            entity.Id = reader.GetInt32("id");
            entity.Supplier_Id = reader.GetInt32("supplier_id");
            entity.Pym = reader.GetString("pym");
            entity.Name = reader.GetString("name");
            entity.Phone = reader.GetString("phone");
            entity.Fax = reader.GetString("fax");
            entity.Email = reader.GetString("email");
            entity.QQ = reader.GetString("qq");
            entity.Memo = reader.GetString("memo");
            entity.Address = reader.GetString("address");
            entity.LasTamp = reader.GetLong("lastamp");

            return entity;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值(用于插入或者更新操作)
        /// (提供了默认的反射机制获取信息，为了提高性能，建议重写该函数)
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Table_SupplierD_Entity obj)
        {
            Table_SupplierD_Entity info = obj as Table_SupplierD_Entity;
            Hashtable hash = new Hashtable();

            hash.Add("id", info.Id);
            hash.Add("pym", info.Pym);
            hash.Add("supplier_id", info.Supplier_Id);
            hash.Add("name", info.Name);
            hash.Add("email", info.Email);
            hash.Add("qq", info.QQ);
            hash.Add("phone", info.Phone);
            hash.Add("fax", info.Fax);
            hash.Add("memo", info.Memo);
            hash.Add("address", info.Address);
            hash.Add("lastamp", info.LasTamp);

            return hash;
        }
    }
}
