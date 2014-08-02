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
    public class DAL_PartName:BaseDal<Table_PartName_Entity>,ITable_PartName
    {
        public static DAL_PartName Instance
		{
			get
			{
				return new DAL_PartName();
			}
		}
        public DAL_PartName()
            : base("PartName", "id", string.Empty, OrderType.ASC)
		{ }

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Table_PartName_Entity DataReaderToEntity(IDataReader dataReader)
        {
            Table_PartName_Entity entity = new Table_PartName_Entity();
            SmartDataReader reader = new SmartDataReader(dataReader);

            entity.Id = reader.GetInt32("id");
            entity.Name = reader.GetString("name");
            entity.Barcode = reader.GetString("barcode");
            entity.SizeClass_id = reader.GetInt32("size_class_id");
            entity.Safe_Id = reader.GetInt32("safe_id");
            entity.Standard_Id = reader.GetInt32("standard_id");
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
        protected override Hashtable GetHashByEntity(Table_PartName_Entity obj)
        {
            Table_PartName_Entity info = obj as Table_PartName_Entity;
            Hashtable hash = new Hashtable();

            hash.Add("id", info.Id);
            hash.Add("name", info.Name);
            hash.Add("barcode", info.Barcode);
            hash.Add("size_class_id", info.SizeClass_id);
            hash.Add("safe_id", info.Safe_Id);
            hash.Add("standard_id", info.Standard_Id);
            hash.Add("memo", info.Memo);
            hash.Add("lastamp", info.LasTamp);

            return hash;
        }
    }
}
