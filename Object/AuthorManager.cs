using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Mondiland.EFModule;
using Mondiland.Global;

namespace Mondiland.Obj
{
    public class AuthorManager
    {
        private static User m_login_user = null;
        public static User LoginUser
        {
            get { return m_login_user; }
        }

        public class LoginUserInfo
        {
            private int m_id = 0;
            private string m_username = string.Empty;
            private string m_groupname = string.Empty;

            public int Id
            {
                get { return m_id; }
                set { m_id = value; }
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


        public static BindingList<LoginUserInfo> LoginUserList
        {
            get
            {
                BindingList<LoginUserInfo> list = new BindingList<LoginUserInfo>();

                using (ProductContext ctx = new ProductContext())
                {
                    var users = from user in ctx.UserInfo
                                select user;


                    foreach (var user in users)
                    {
                        LoginUserInfo info = new LoginUserInfo();
                        info.Id = user.id;
                        info.UserName = user.name;
                        info.GroupName = user.GroupInfo.name;

                        list.Add(info);
                    }

                }

                return list;
            }
        }

        public static void RecordLoginUserSelect(int user_id, string address)
        {
            using (ProductContext ctx = new ProductContext())
            {
                var del_ob = (from entity in ctx.LoginUserSelect
                              where entity.mac_address == address
                              select entity).FirstOrDefault();

                if (del_ob != null)
                {
                    ctx.LoginUserSelect.Remove(del_ob);
                    ctx.SaveChanges();
                }
            }

            LoginUserSelect new_obj = new LoginUserSelect();
            new_obj.user_id = user_id;
            new_obj.mac_address = address;

            using (ProductContext ctx = new ProductContext())
            {
                ctx.LoginUserSelect.Add(new_obj);
                ctx.SaveChanges();
            }

        }

        public static int ReadLoginUserSelect(string address)
        {
            using (ProductContext ctx = new ProductContext())
            {
                int sel_id = (from entity in ctx.LoginUserSelect
                              where entity.mac_address == address
                              select entity.user_id).FirstOrDefault();

                return sel_id;
            }
        }

        public static bool Authentication(int user_id,string str_pwd)
        {
            string str_md5 = UtilFun.GetMD5(str_pwd);
   
            using(ProductContext ctx = new ProductContext())
            {
                string pwd = (from entity in ctx.UserInfo
                              where entity.id == user_id
                              select entity.pwd).FirstOrDefault();

                if (pwd == str_md5)
                {
                    m_login_user = new User(user_id);
                    return true;
                }
                else
                    return false;

            }
        }

        public class User
        {
            private int m_id = 0;
            private int m_group_id = 0;
            private string m_name = string.Empty;
            private string m_pwd = string.Empty;
            private string m_group_name = string.Empty;

            public List<MenuParent> MenuParentList = new List<MenuParent>();
            public List<FavoritesMenu> FavoritesMenuList = new List<FavoritesMenu>();


            public SaveResult ChangePwd(string old_pwd, string new_pwd)
            {
                SaveResult result = new SaveResult();

                if (UtilFun.GetMD5(old_pwd) != this.m_pwd)
                {
                    result.Code = CodeType.Error;
                    result.Message = "旧密码验证失败";

                    return result;
                }

                using (ProductContext ctx = new ProductContext())
                {
                    var user = (from entity in ctx.UserInfo
                                where entity.id == this.m_id
                                select entity).FirstOrDefault();

                    user.pwd = UtilFun.GetMD5(new_pwd);

                    if (ctx.SaveChanges() == 0)
                    {
                        result.Code = CodeType.Error;
                        result.Message = "密码修改失败";

                        return result;
                    }
                    else
                    {
                        result.Code = CodeType.Ok;
                        result.Message = "密码修改成功";

                        return result;
                    }
                }

            }

            public bool SetFavorites(string form_name)
            {
                using (ProductContext ctx = new ProductContext())
                {
                    UserMenuFavorites favorites = new UserMenuFavorites();
                    favorites.user_id = this.m_id;
                    favorites.menu_id = (from m in ctx.MenuInfo
                                         where m.menu_window == form_name
                                         select m.id).FirstOrDefault();
                    favorites.lastamp = System.Guid.NewGuid();

                    ctx.UserMenuFavorites.Add(favorites);
                    return ctx.SaveChanges() > 0 ? true : false;
                }

            }
            public bool UnFavorites(string form_name)
            {
                using (ProductContext ctx = new ProductContext())
                {
                    int menu_id = (from m in ctx.MenuInfo
                                   where m.menu_window == form_name
                                   select m.id).FirstOrDefault();

                    UserMenuFavorites obj = (from fav in ctx.UserMenuFavorites
                                             where fav.user_id == this.m_id && fav.menu_id == menu_id
                                             select fav).FirstOrDefault();

                    ctx.UserMenuFavorites.Remove(obj);

                    return ctx.SaveChanges() > 0 ? true : false;
                }
            }

            public bool IsUserMenuFavorites(string form_name)
            {
                using (ProductContext ctx = new ProductContext())
                {

                    int menu_id = (from m in ctx.MenuInfo
                                   where m.menu_window == form_name
                                   select m.id).FirstOrDefault();

                    UserMenuFavorites obj = (from fav in ctx.UserMenuFavorites
                                             where fav.user_id == this.m_id && fav.menu_id == menu_id
                                             select fav).FirstOrDefault();

                    return obj == null ? false : true;
                }
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
                    using (ProductContext ctx = new ProductContext())
                    {

                        MenuInfo info = (from menu in ctx.MenuInfo
                                         where menu.id == id
                                         select menu).FirstOrDefault();

                        this.m_id = id;
                        this.m_menu_name = info.menu_name;
                        this.m_menu_bmp = info.menu_bmp;
                        this.m_menu_window = info.menu_window;
                        this.m_menu_memo = info.menu_memo;
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
                private int m_group_id = 0;
                private string m_menu_name = string.Empty;

                public List<MenuChild> MenuChildList = new List<MenuChild>();

                public MenuParent(int id,int group_id)
                {
                    using (ProductContext ctx = new ProductContext())
                    {
                        this.m_id = id;
                        this.m_group_id = group_id;
                        this.m_menu_name = (from menu in ctx.MenuInfo
                                            where menu.id == this.m_id
                                            select menu).FirstOrDefault().menu_name;

                        var childs = from menu in ctx.MenuInfo
                                     where menu.menu_parent == this.m_id
                                     orderby menu.menu_order
                                     select menu;

                        foreach (var child in childs)
                        {
                            int count = (from entity in ctx.GroupMenu
                                         where entity.group_id == this.m_group_id && entity.menu_id == child.id
                                         select entity).Count();

                            if (count > 0)
                            {
                                MenuChild info = new MenuChild(child.id);
                                this.MenuChildList.Add(info);
                            }
                        }

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
                        using (ProductContext ctx = new ProductContext())
                        {
                            MenuInfo menu = (from m in ctx.MenuInfo
                                             where m.id == id
                                             select m).FirstOrDefault();

                            this.m_id = id;
                            this.m_menu_name = menu.menu_name;
                            this.m_menu_bmp = menu.menu_bmp;
                            this.m_menu_window = menu.menu_window;
                            this.m_menu_memo = menu.menu_memo;
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
                using (ProductContext ctx = new ProductContext())
                {
                    UserInfo info = (from u in ctx.UserInfo
                                     where u.id == id
                                     select u).FirstOrDefault();

                    this.m_id = info.id;
                    this.m_name = info.name;
                    this.m_pwd = info.pwd;
                    this.m_group_name = info.GroupInfo.name;
                    this.m_group_id = info.group_id;


                    var parents = from m in ctx.MenuInfo
                                  where m.menu_parent == 0
                                  orderby m.menu_order
                                  select m;

                    foreach (var parent in parents)
                    {
                        int count = (from entity in ctx.GroupMenu
                                     where entity.group_id == this.m_group_id && entity.menu_id == parent.id
                                     select entity).Count();

                        if (count > 0)
                        {
                            MenuParent menu = new MenuParent(parent.id,m_group_id);
                            this.MenuParentList.Add(menu);
                        }
                    }


                    var favs = from m in ctx.UserMenuFavorites
                               where m.user_id == this.m_id
                               select m.menu_id;

                    foreach (var fav in favs)
                    {
                        FavoritesMenu menu = new FavoritesMenu(fav);
                        FavoritesMenuList.Add(menu);
                    }


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

            public int GroupId
            {
                get { return m_group_id; }
            }
        }
    }
}
