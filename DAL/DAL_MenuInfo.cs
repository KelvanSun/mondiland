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
    public class DAL_MenuInfo:BaseDal<Table_MenuInfo_Entity>
    {
        public static DAL_MenuInfo Instance
        {
            get
            {
                return new DAL_MenuInfo();
            }
        }
        public DAL_MenuInfo()
            : base("MenuInfo", "id", string.Empty, OrderType.ASC)
        { }

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <returns>实体类对象</returns>
        protected override Table_MenuInfo_Entity DataReaderToEntity(IDataReader dataReader)
        {
            Table_MenuInfo_Entity entity = new Table_MenuInfo_Entity();
            SmartDataReader reader = new SmartDataReader(dataReader);

            entity.Id = reader.GetInt32("id");
            entity.MenuName = reader.GetString("menu_name");
            entity.MenuBmp = reader.GetInt32("menu_bmp");
            entity.MenuWindow = reader.GetString("menu_window");
            entity.MenuMemo = reader.GetString("menu_memo");

            return entity;
        }

        /// <summary>
        /// 将实体对象的属性值转化为Hashtable对应的键值(用于插入或者更新操作)
        /// (提供了默认的反射机制获取信息，为了提高性能，建议重写该函数)
        /// </summary>
        /// <param name="obj">有效的实体对象</param>
        /// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Table_MenuInfo_Entity obj)
        {
            Table_MenuInfo_Entity info = obj as Table_MenuInfo_Entity;
            Hashtable hash = new Hashtable();

            hash.Add("id", info.Id);
            hash.Add("menu_name", info.MenuName);
            hash.Add("menu_bmp", info.MenuBmp);
            hash.Add("menu_window", info.MenuWindow);
            hash.Add("menu_memo", info.MenuMemo);

            return hash;
        }
    }
}
