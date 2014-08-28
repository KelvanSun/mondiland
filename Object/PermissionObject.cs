using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Mondiland.BLL;
using Mondiland.BLLEntity;
using Mondiland.Global;

namespace Mondiland.Obj
{
    public class PermissionObject
    {
        public List<User> UserList = new List<User>();

        public PermissionObject()
        {
            IEnumerator<int> ator = BLLFactory<BLLPermissionInfo>.Instance.GetALlUserList().GetEnumerator();

            while(ator.MoveNext())
            {
                User user = new User(ator.Current);

                UserList.Add(user);
            }
        }

        /// <summary>
        /// 登陆窗口的用户列表
        /// </summary>
        /// <returns></returns>
        public BindingList<LoginUserInfo> GetLoginUserList()
        {
            BindingList<LoginUserInfo> list = new BindingList<LoginUserInfo>();

            IEnumerator<User> ator = UserList.GetEnumerator();

            int index = 0;

            while(ator.MoveNext())
            {
                LoginUserInfo info = new LoginUserInfo();

                info.Index = index++;
                info.UserName = ator.Current.Name;
                info.GroupName = ator.Current.GroupName;

                list.Add(info);
            }

            return list;
        }


        public class LoginUserInfo
        {
            private int m_index = 0;
            private string m_username = string.Empty;
            private string m_groupname = string.Empty;
            
            public int Index
            {
                get { return m_index; }
                set { m_index = value; }
            }

            public string UserName
            {
                get { return m_username; }
                set { m_username = value; }
            }

            public string GroupName
            {
                get { return m_groupname; }
                set { m_groupname = value; }
            }
        }

        public class User
        {
            private int m_id = 0;
            private string m_name = string.Empty;
            private string m_pwd = string.Empty;
            private int m_group_id = 0;
            private string m_group_name = string.Empty;

            //public class MenuParent
            //{
            //    private int m_id = 0;
            //    private string m_menu_name = string.Empty;

            //}
            public User(int id)
            {
                this.m_id = id;
                this.m_name = BLLFactory<BLLPermissionInfo>.Instance.GetUserName(id);
                this.m_pwd = BLLFactory<BLLPermissionInfo>.Instance.GetUserPwd(id);
                this.m_group_id = BLLFactory<BLLPermissionInfo>.Instance.GetGroupId(id);
                this.m_group_name = BLLFactory<BLLPermissionInfo>.Instance.GetGroupName(this.m_group_id);
            }

            public int Id
            {
                get { return m_id; }
            }

            public string Name
            {
                get { return m_name; }
            }
            public string GroupName
            {
                get { return m_group_name; }
            }

            /// <summary>
            /// 验证用户密码
            /// </summary>
            /// <param name="pwd">密码</param>
            /// <returns>成功返回true</returns>
            public bool Authentication(string pwd)
            {
                return UtilFun.GetMD5(pwd) == this.m_pwd;
            }
        }

    }
}
