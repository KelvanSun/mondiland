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
    public class DAL_UserInfo:BaseDal<Table_UserInfo_Entity>,ITable_UserInfo
    {
         public static DAL_UserInfo Instance
		{
			get
			{
				return new DAL_UserInfo();
			}
		}
         public DAL_UserInfo()
            : base("UserInfo", "id", "name", OrderType.ASC)
		{ }

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Table_UserInfo_Entity DataReaderToEntity(IDataReader dataReader)
        {
            Table_UserInfo_Entity entity = new Table_UserInfo_Entity();
            SmartDataReader reader = new SmartDataReader(dataReader);

            entity.Id = reader.GetInt32("id");
            entity.Name = reader.GetString("name");
            entity.Pwd = reader.GetString("pwd");
            entity.Group_Id = reader.GetInt32("group_id");
            entity.LasTamp = reader.GetLong("lastamp");

            return entity;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值(用于插入或者更新操作)
        /// (提供了默认的反射机制获取信息，为了提高性能，建议重写该函数)
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Table_UserInfo_Entity obj)
        {
            Table_UserInfo_Entity info = obj as Table_UserInfo_Entity;
            Hashtable hash = new Hashtable();

            hash.Add("id", info.Id);
            hash.Add("name", info.Name);
            hash.Add("pwd", info.Pwd);
            hash.Add("lastamp", info.LasTamp);
            hash.Add("group_id", info.Group_Id);

            return hash;
        }
    }
}
