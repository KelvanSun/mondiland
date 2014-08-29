using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;

using Mondiland.Entity;
using Mondiland.IDal;
using Mondiland.BLLEntity;
using Mondiland.Global;

namespace Mondiland.BLL
{
    public class BLLPermissionInfo:BaseBLL
    {
        private ITable_UserInfo UserInfo_Dal = null;
        private ITable_GroupInfo GroupInfo_Dal = null;
        private ITable_MenuInfo MenuInfo_Dal = null;
        private ITable_GroupMenu GroupMenu_Dal = null;
        private ITable_UserMenuFavorites UserMenuFavorites_Dal = null;

        public BLLPermissionInfo()
        {
            UserInfo_Dal = Reflect<ITable_UserInfo>.Create("DAL_UserInfo", "Mondiland.DAL");
            GroupInfo_Dal = Reflect<ITable_GroupInfo>.Create("DAL_GroupInfo", "Mondiland.DAL");
            MenuInfo_Dal = Reflect<ITable_MenuInfo>.Create("DAL_MenuInfo", "Mondiland.DAL");
            GroupMenu_Dal = Reflect<ITable_GroupMenu>.Create("DAL_GroupMenu", "Mondiland.DAL");
            UserMenuFavorites_Dal = Reflect<ITable_UserMenuFavorites>.Create("DAL_UserMenuFavorites", "Mondiland.DAL");
        }

        /// <summary>
        /// 根据用户ID返回用户名
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>用户名</returns>
        public string GetUserName(int id)
        {
            Table_UserInfo_Entity entity = UserInfo_Dal.FindByID(id);
            return entity.Name;
        }

        /// <summary>
        /// 根据用户ID返回密码
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>密码</returns>
        public string GetUserPwd(int id)
        {
            Table_UserInfo_Entity entity = UserInfo_Dal.FindByID(id);
            return entity.Pwd;
        }

        /// <summary>
        /// 根据用户ID返回group_id
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>group_id</returns>
        public int GetGroupId(int id)
        {
            Table_UserInfo_Entity entity = UserInfo_Dal.FindByID(id);

            return entity.Group_Id;
        }

        /// <summary>
        /// 得到group_name
        /// </summary>
        /// <param name="group_id">group_id</param>
        /// <returns>group_name</returns>
        public string GetGroupName(int group_id)
        {
            Table_GroupInfo_Entity entity = GroupInfo_Dal.FindByID(group_id);

            return entity.Name;
        }

        /// <summary>
        /// 返回近有用户的ID列表
        /// </summary>
        /// <returns>ID列表</returns>
        public List<int> GetALlUserList()
        {
            List<int> list = new List<int>();

            IEnumerator<Table_UserInfo_Entity> ator = UserInfo_Dal.GetAll(false).GetEnumerator();

            while(ator.MoveNext())
            {
                list.Add(ator.Current.Id);
            }

            return list;
        }

        /// <summary>
        /// 返回所有的父级菜单
        /// </summary>
        /// <returns></returns>
        public List<int> GetParentMenuList()
        {
            List<int> list = new List<int>();

            Hashtable hash = new Hashtable();
            hash.Add("menu_parent", 0);

            IEnumerator<Table_MenuInfo_Entity> ator = MenuInfo_Dal.Find(hash, SqlOperator.And, true).GetEnumerator();

            while(ator.MoveNext())
            {
                list.Add(ator.Current.Id);
            }

            return list;
        }

        /// <summary>
        /// 返回子菜单列表
        /// </summary>
        /// <param name="parent_id"></param>
        /// <returns></returns>
        public List<int> GetChildMenuList(int parent_id)
        {
            List<int> list = new List<int>();

            Hashtable hash = new Hashtable();
            hash.Add("menu_parent", parent_id);

            IEnumerator<Table_MenuInfo_Entity> ator = MenuInfo_Dal.Find(hash, SqlOperator.And, true).GetEnumerator();

            while (ator.MoveNext())
            {
                list.Add(ator.Current.Id);
            }

            return list;

        }

        public List<int> GetFavoritesMenuList(int user_id)
        {
            List<int> list = new List<int>();

            Hashtable hash = new Hashtable();

            hash.Add("user_id", user_id);

            IEnumerator<Table_UserMenuFavorites_Entity> ator = UserMenuFavorites_Dal.Find(hash, SqlOperator.And, false).GetEnumerator();

            while(ator.MoveNext())
            {
                list.Add(ator.Current.MenuId);
            }

            return list;
        }

        /// <summary>
        /// 返回菜单名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetMenuName(int id)
        {
            Table_MenuInfo_Entity entity = MenuInfo_Dal.FindByID(id);

            return entity.MenuName;
        }

        public int GetMenuBmp(int id)
        {
            Table_MenuInfo_Entity entity = MenuInfo_Dal.FindByID(id);

            return entity.MenuBmp;
        }

        public string GetMenuWindow(int id)
        {
            Table_MenuInfo_Entity entity = MenuInfo_Dal.FindByID(id);

            return entity.MenuWindow;
        }

        public string GetMenuMemo(int id)
        {
            Table_MenuInfo_Entity entity = MenuInfo_Dal.FindByID(id);

            return entity.MenuMemo;
        }

        /// <summary>
        /// 取消收藏
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <param name="form_name">窗口名称</param>
        /// <returns>成功返回true</returns>
        public bool UnFavorites(int user_id, string form_name)
        {
            Hashtable menu_info_hash = new Hashtable();

            menu_info_hash.Add("menu_window", form_name);

            Table_MenuInfo_Entity menu_info = MenuInfo_Dal.Find(menu_info_hash);

            Hashtable hash = new Hashtable();

            hash.Add("user_id", user_id);
            hash.Add("menu_id", menu_info.Id);

            return UserMenuFavorites_Dal.Delete(hash);
        }

        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="user_id">用户Id</param>
        /// <param name="form_name">窗口名称</param>
        /// <returns>成功返回true</returns>
        public bool SetFavorites(int user_id, string form_name)
        {
            Hashtable menu_info_hash = new Hashtable();

            menu_info_hash.Add("menu_window", form_name);

            Table_MenuInfo_Entity menu_info = MenuInfo_Dal.Find(menu_info_hash);

            Table_UserMenuFavorites_Entity entity = new Table_UserMenuFavorites_Entity();

            entity.UserId = user_id;
            entity.MenuId = menu_info.Id;
            entity.LasTamp = UtilFun.GetTimeSLasTamp();

            return UserMenuFavorites_Dal.Insert(entity);
        }

         /// <summary>
        /// 根据用户ID与窗口名称查询是否已经收藏
        /// </summary>
        /// <param name="user_id">用户ID</param>
        /// <param name="form_name">窗口名称</param>
        /// <returns>true为已经收藏</returns>
        public bool IsUserMenuFavorites(int user_id,string form_name)
        {
            Hashtable menu_info_hash = new Hashtable();

            menu_info_hash.Add("menu_window", form_name);

            Table_MenuInfo_Entity menu_info = MenuInfo_Dal.Find(menu_info_hash);

            Hashtable menu_favorites_hash = new Hashtable();
            menu_favorites_hash.Add("user_id", user_id);
            menu_favorites_hash.Add("menu_id", menu_info.Id);

            return UserMenuFavorites_Dal.FindPrimaryKey(menu_favorites_hash) > 0 ? true:false;
        }
    }
}
