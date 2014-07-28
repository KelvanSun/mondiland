using System;
using System.Collections;
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
    public class BLLLogin:BaseBLL
    {
        private ITable_UserInfo UserInfo_Dal = null;
        private ITable_GroupInfo GroupInfo_Dal = null;

        public BLLLogin()
        {
            UserInfo_Dal = Reflect<ITable_UserInfo>.Create("DAL_UserInfo", "Mondiland.DAL");
            GroupInfo_Dal = Reflect<ITable_GroupInfo>.Create("DAL_GroupInfo", "Mondiland.DAL");

        }

        /// <summary>
        /// 获取用户名称
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public string GetUserName(int id)
        {
            Table_UserInfo_Entity info = UserInfo_Dal.FindByID(id);

            return info.Name;
        }

        /// <summary>
        /// 获取用户所在组的名称
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public string GetGroupName(int id)
        {
            Table_UserInfo_Entity user = UserInfo_Dal.FindByID(id);
            Table_GroupInfo_Entity group = GroupInfo_Dal.FindByID(user.Group_Id);

            return group.Name;
        }

        /// <summary>
        /// 返回所有登陆用户名
        /// </summary>
        /// <returns>用户名类列</returns>
        public List<string> GetUserList()
        {
            IEnumerator<string> ator = UserInfo_Dal.GetItemString("name", true).GetEnumerator();

            List<string> list = new List<string>();

            while (ator.MoveNext())
            {

                list.Add(ator.Current.ToString());
            }

            return list;
        }

        /// <summary>
        /// 登陆验证
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>存在则返回<c>true</c>，否则为<c>false</c>。</returns>
        public bool Authentication(string name, string pwd)
        {
            string hs_pwd = string.Empty;
            Hashtable ht = new Hashtable();

            hs_pwd = UtilFun.GetMD5(pwd);

            ht.Add("name", name);
            ht.Add("pwd", hs_pwd);

            return UserInfo_Dal.IsExistKey(ht);
        }

        /// <summary>
        /// 查询用户ID号
        /// </summary>
        /// <param name="user_name">用户名</param>
        /// <returns>用户ID</returns>
        public int GetUserID(string user_name)
        {
            Hashtable ht = new Hashtable();

            ht.Add("name", user_name);

            return UserInfo_Dal.FindPrimaryKey(ht);
        }
    }
}
