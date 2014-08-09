using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;

using Mondiland.Entity;
using Mondiland.IDal;
using Mondiland.BLLEntity;
using Mondiland.Global;

namespace Mondiland.BLL
{
    public class BLLMenuInfo:BaseBLL
    {
        private ITable_MenuInfo MenuInfo_Dal = null;
        private ITable_GroupMenu GroupMenu_Dal = null;
        private ITable_UserInfo UserInfo_Dal = null;

        public BLLMenuInfo()
        {
            MenuInfo_Dal = Reflect<ITable_MenuInfo>.Create("DAL_MenuInfo", "Mondiland.DAL");
            GroupMenu_Dal = Reflect<ITable_GroupMenu>.Create("DAL_GroupMenu", "Mondiland.DAL");
            UserInfo_Dal = Reflect<ITable_UserInfo>.Create("DAL_UserInfo", "Mondiland.DAL");
        }

        /// <summary>
        /// 得到系统父级菜单信息
        /// </summary>
        /// <param name="user_id">用户ID</param>
        /// <returns>父级菜单信息</returns>
        public List<BEParentMenuInfo> GetParentMenuInfo(int user_id)
        {
            List<BEParentMenuInfo> list = new List<BEParentMenuInfo>();

            //得到用户所属的group_id
            Table_UserInfo_Entity user_info = UserInfo_Dal.FindByID(user_id);
            int group_id = user_info.Group_Id;

            Hashtable group_menu_hash = new Hashtable();

            group_menu_hash.Add("group_id", group_id);

            IEnumerator<Table_GroupMenu_Entity> group_menu_ator = GroupMenu_Dal.Find(group_menu_hash, SqlOperator.And, true).GetEnumerator();

            while(group_menu_ator.MoveNext())
            {
                Table_MenuInfo_Entity menu_info = MenuInfo_Dal.FindByID(group_menu_ator.Current.MenuId);

                if(menu_info.MenuParent == 0)
                {
                    BEParentMenuInfo info = new BEParentMenuInfo();
                    info.Menu_id = menu_info.Id;
                    info.Menu_name = menu_info.MenuName;

                    list.Add(info);
                }
            }

            return list;
        }

        /// <summary>
        /// 得到子菜单信息
        /// </summary>
        /// <param name="parent_menu_id">父菜单ID</param>
        /// <returns>子菜单信息</returns>
        public List<BEChildMenuInfo> GetChildMenuInfo(int parent_menu_id)
        {
            List<BEChildMenuInfo> list = new List<BEChildMenuInfo>();

            Hashtable menu_info_hash = new Hashtable();

            menu_info_hash.Add("menu_parent",parent_menu_id);

            IEnumerator<Table_MenuInfo_Entity> menu_info_ator = MenuInfo_Dal.Find(menu_info_hash, SqlOperator.And, true).GetEnumerator();

            while(menu_info_ator.MoveNext())
            {
                Hashtable group_menu_hash = new Hashtable();

                group_menu_hash.Add("menu_id",menu_info_ator.Current.Id);

                int cout = GroupMenu_Dal.FindPrimaryKey(group_menu_hash);

                if(cout > 0)
                {
                    BEChildMenuInfo info = new BEChildMenuInfo();

                    info.Id = menu_info_ator.Current.Id;
                    info.MenuBmp = menu_info_ator.Current.MenuBmp;
                    info.MenuName = menu_info_ator.Current.MenuName;
                    info.MenuWindow = menu_info_ator.Current.MenuWindow;
                    info.MenuMemo = menu_info_ator.Current.MenuMemo;

                    list.Add(info);
                }

            }

            return list;
        }

    }
}
