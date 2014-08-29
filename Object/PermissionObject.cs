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
            foreach(int id in BLLFactory<BLLPermissionInfo>.Instance.GetALlUserList())
            {
                User user = new User(id);

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

            int index = 0;

            foreach (User user in UserList)
            {
                LoginUserInfo info = new LoginUserInfo();

                info.Index = index++;
                info.UserName = user.Name;
                info.GroupName = user.GroupName;

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

            public List<MenuParent> MenuParentList = new List<MenuParent>();
            public List<FavoritesMenu> FavoritesMenuList = new List<FavoritesMenu>();

            public bool SetFavorites(string form_name)
            {
                return BLLFactory<BLLPermissionInfo>.Instance.SetFavorites(this.m_id, form_name);
            }
            public bool UnFavorites(string form_name)
            {
                return BLLFactory<BLLPermissionInfo>.Instance.UnFavorites(this.m_id, form_name);
            }

            public bool IsUserMenuFavorites(string form_name)
            {
                return BLLFactory<BLLPermissionInfo>.Instance.IsUserMenuFavorites(this.m_id, form_name);
            }

            public class FavoritesMenu
            {
                private int m_id = 0;
                private string m_menu_name = string.Empty;
                private int m_menu_bmp = 0;
                private string m_menu_window = string.Empty;
                private string m_menu_memo = string.Empty;

                public FavoritesMenu(int id)
                {
                    this.m_id = id;
                    this.m_menu_name = BLLFactory<BLLPermissionInfo>.Instance.GetMenuName(m_id);
                    this.m_menu_bmp = BLLFactory<BLLPermissionInfo>.Instance.GetMenuBmp(m_id);
                    this.m_menu_window = BLLFactory<BLLPermissionInfo>.Instance.GetMenuWindow(m_id);
                    this.m_menu_memo = BLLFactory<BLLPermissionInfo>.Instance.GetMenuMemo(m_id);
                }

                public int Id
                {
                    get { return m_id; }
                    set { m_id = value; }
                }

                public string MenuName
                {
                    get { return m_menu_name; }
                    set { m_menu_name = value; }
                }

                public int MenuBmp
                {
                    get { return m_menu_bmp; }
                    set { m_menu_bmp = value; }
                }

                public string MenuWindow
                {
                    get { return m_menu_window; }
                    set { m_menu_window = value; }
                }

                public string MenuMemo
                {
                    get { return m_menu_memo; }
                    set { m_menu_memo = value; }
                }
            }
            /// <summary>
            /// 父菜单类
            /// </summary>
            public class MenuParent
            {
                private int m_id = 0;
                private string m_menu_name = string.Empty;

                public List<MenuChild> MenuChildList = new List<MenuChild>();

                public MenuParent(int id)
                {
                    this.m_id = id;
                    this.m_menu_name = BLLFactory<BLLPermissionInfo>.Instance.GetMenuName(m_id);


                    foreach (int child_id in BLLFactory<BLLPermissionInfo>.Instance.GetChildMenuList(this.m_id))
                    {
                        MenuChild child = new MenuChild(child_id);
                        this.MenuChildList.Add(child);
                    }

                }

                public int Id
                {
                    get { return m_id; }
                    set { m_id = value; }
                }

                public string MenuName
                {
                    get { return m_menu_name; }
                    set { m_menu_name = value; }
                }

                /// <summary>
                /// 子菜单类
                /// </summary>
                public class MenuChild
                {
                    private int m_id = 0;
                    private string m_menu_name = string.Empty;
                    private int m_menu_bmp = 0;
                    private string m_menu_window = string.Empty;
                    private string m_menu_memo = string.Empty;

                    public MenuChild(int id)
                    {
                        this.m_id = id;
                        this.m_menu_name = BLLFactory<BLLPermissionInfo>.Instance.GetMenuName(m_id);
                        this.m_menu_bmp = BLLFactory<BLLPermissionInfo>.Instance.GetMenuBmp(m_id);
                        this.m_menu_window = BLLFactory<BLLPermissionInfo>.Instance.GetMenuWindow(m_id);
                        this.m_menu_memo = BLLFactory<BLLPermissionInfo>.Instance.GetMenuMemo(m_id);
                    }

                    public int Id
                    {
                        get { return m_id; }
                        set { m_id = value; }
                    }

                    public string MenuName
                    {
                        get { return m_menu_name; }
                        set { m_menu_name = value; }
                    }

                    public int MenuBmp
                    {
                        get { return m_menu_bmp; }
                        set { m_menu_bmp = value; }
                    }

                    public string MenuWindow
                    {
                        get { return m_menu_window; }
                        set { m_menu_window = value; }
                    }

                    public string MenuMemo
                    {
                        get { return m_menu_memo; }
                        set { m_menu_memo = value; }
                    }
                }

            }

            public User(int id)
            {
                this.m_id = id;
                this.m_name = BLLFactory<BLLPermissionInfo>.Instance.GetUserName(id);
                this.m_pwd = BLLFactory<BLLPermissionInfo>.Instance.GetUserPwd(id);
                this.m_group_id = BLLFactory<BLLPermissionInfo>.Instance.GetGroupId(id);
                this.m_group_name = BLLFactory<BLLPermissionInfo>.Instance.GetGroupName(this.m_group_id);

                foreach (int parent_id in BLLFactory<BLLPermissionInfo>.Instance.GetParentMenuList())
                {
                    MenuParent parent = new MenuParent(parent_id);

                    this.MenuParentList.Add(parent);
                }
                
                foreach(int fav_id in BLLFactory<BLLPermissionInfo>.Instance.GetFavoritesMenuList(this.Id))
                {
                    FavoritesMenu menu = new FavoritesMenu(fav_id);
                    FavoritesMenuList.Add(menu);
                }
                
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
