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
    public class DAL_MaterialFill:BaseDal<Table_MaterialFill_Entity>,ITable_MaterialFill
    {
        public static DAL_MaterialFill Instance
		{
			get
			{
				return new DAL_MaterialFill();
			}
		}
        public DAL_MaterialFill()
            : base("MaterialFill", "id", string.Empty, OrderType.ASC)
		{ }

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Table_MaterialFill_Entity DataReaderToEntity(IDataReader dataReader)
        {
            Table_MaterialFill_Entity entity = new Table_MaterialFill_Entity();
            SmartDataReader reader = new SmartDataReader(dataReader);

            entity.Id = reader.GetInt32("id");
            entity.Product_Id = reader.GetInt32("product_id");
            entity.Type = reader.GetString("type");
            entity.Size_Name = reader.GetString("size_name");
            entity.Fill = reader.GetString("fill");

            return entity;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值(用于插入或者更新操作)
        /// (提供了默认的反射机制获取信息，为了提高性能，建议重写该函数)
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Table_MaterialFill_Entity obj)
        {
            Table_MaterialFill_Entity info = obj as Table_MaterialFill_Entity;
            Hashtable hash = new Hashtable();

            hash.Add("id", info.Id);
            hash.Add("type", info.Type);
            hash.Add("product_id", info.Product_Id);
            hash.Add("size_name", info.Size_Name);
            hash.Add("fill", info.Fill);

            return hash;
        }
    }
}
