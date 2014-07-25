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
    public class DAL_StandardData : BaseDal<Table_StardardData_Entity>,ITable_StandardData 
    {

        public static DAL_StandardData Instance
        {
            get
            {
                return new DAL_StandardData();
            }
        }
        public DAL_StandardData()
            : base("StandardData", "id", "type", OrderType.ASC)
		{ }

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Table_StardardData_Entity DataReaderToEntity(IDataReader dataReader)
        {
            Table_StardardData_Entity entity = new Table_StardardData_Entity();
            SmartDataReader reader = new SmartDataReader(dataReader);

            entity.Id = reader.GetInt32("id");
            entity.Type = reader.GetString("type");
            entity.Memo = reader.GetString("memo");

            return entity;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值(用于插入或者更新操作)
        /// (提供了默认的反射机制获取信息，为了提高性能，建议重写该函数)
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Table_StardardData_Entity obj)
        {
            Table_StardardData_Entity info = obj as Table_StardardData_Entity;
            Hashtable hash = new Hashtable();

            hash.Add("id", info.Id);
            hash.Add("type", info.Type);
            hash.Add("memo", info.Memo);

            return hash;
        }
    }
}
