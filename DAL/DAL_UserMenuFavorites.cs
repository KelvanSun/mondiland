﻿using System;
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
    public class DAL_UserMenuFavorites:BaseDal<Table_UserMenuFavorites_Entity>,ITable_UserMenuFavorites
    {
        public static DAL_UserMenuFavorites Instance
		{
			get
			{
				return new DAL_UserMenuFavorites();
			}
		}
        public DAL_UserMenuFavorites()
            : base("UserMenuFavorites", "id", string.Empty, OrderType.ASC)
		{ }

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Table_UserMenuFavorites_Entity DataReaderToEntity(IDataReader dataReader)
        {
            Table_UserMenuFavorites_Entity entity = new Table_UserMenuFavorites_Entity();
            SmartDataReader reader = new SmartDataReader(dataReader);

            entity.Id = reader.GetInt32("id");
            entity.UserId = reader.GetInt32("user_id");
            entity.MenuId = reader.GetInt32("menu_id");
            entity.LasTamp = reader.GetLong("lastamp");

            return entity;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值(用于插入或者更新操作)
        /// (提供了默认的反射机制获取信息，为了提高性能，建议重写该函数)
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Table_UserMenuFavorites_Entity obj)
        {
            Table_UserMenuFavorites_Entity info = obj as Table_UserMenuFavorites_Entity;
            Hashtable hash = new Hashtable();

            hash.Add("id", info.Id);
            hash.Add("user_id", info.UserId);
            hash.Add("menu_id", info.MenuId);
            hash.Add("lastamp", info.LasTamp);

            return hash;
        }
    }
}
