using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

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

    }
}
