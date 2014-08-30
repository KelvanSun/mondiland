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
    public class DAL_ProductData:BaseDal<Table_ProductData_Entity>,ITable_ProductData
    {
        public static DAL_ProductData Instance
		{
			get
			{
				return new DAL_ProductData();
			}
		}
        public DAL_ProductData()
            : base("ProductData", "id", string.Empty, OrderType.ASC)
		{ }

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Table_ProductData_Entity DataReaderToEntity(IDataReader dataReader)
        {
            Table_ProductData_Entity entity = new Table_ProductData_Entity();
            SmartDataReader reader = new SmartDataReader(dataReader);

            entity.Id = reader.GetInt32("id");
            entity.HuoHao = reader.GetString("huohao");
            entity.PartName_Id = reader.GetInt32("partname_id");
            entity.SafeData_Id = reader.GetInt32("safedata_id");
            entity.StandardData_Id = reader.GetInt32("standarddata_id");
            entity.Price = reader.GetDecimal("price");
            entity.MadePlace_Id = reader.GetInt32("madeplace_id");
            entity.Dengji_Id = reader.GetInt32("dengji_id");
            entity.Tag_Id = reader.GetInt32("tag_id");
            entity.Wash_Id = reader.GetInt32("wash_id");
            entity.Memo = reader.GetString("memo");
            entity.Pwash = reader.GetInt32("pwash");
            entity.Pbad = reader.GetInt32("pbad");
            entity.LasTamp = reader.GetString("lastamp");

            return entity;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值(用于插入或者更新操作)
        /// (提供了默认的反射机制获取信息，为了提高性能，建议重写该函数)
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Table_ProductData_Entity obj)
        {
            Table_ProductData_Entity info = obj as Table_ProductData_Entity;
            Hashtable hash = new Hashtable();

            hash.Add("id", info.Id);
            hash.Add("huohao", info.HuoHao);
            hash.Add("partname_id", info.PartName_Id);
            hash.Add("safedata_id", info.SafeData_Id);
            hash.Add("standarddata_id", info.StandardData_Id);
            hash.Add("price", info.Price);
            hash.Add("madeplace_id", info.MadePlace_Id);
            hash.Add("dengji_id", info.Dengji_Id);
            hash.Add("tag_id", info.Tag_Id);
            hash.Add("wash_id", info.Wash_Id);
            hash.Add("memo", info.Memo);
            hash.Add("pwash", info.Pwash);
            hash.Add("pbad", info.Pbad);
            hash.Add("lastamp", info.LasTamp);

            return hash;
        }
    }
}
