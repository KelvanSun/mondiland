using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Mondiland.Obj;
using UtilityLibrary.WinControls;

namespace Mondiland.UI
{
    public partial class MainToolForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private MainForm mf = null;
        
        public MainToolForm(MainForm form)
        {
            this.mf = form;
            InitializeComponent();
        }

        /// <summary>
        /// 根据user_id加载菜单项
        /// </summary>
        /// <param name="user_id">登陆的用户ID</param>
        public void LoadMenuInfo()
        {
            foreach(PermissionManager.User.MenuParent parent in Program.permission.LoginUser.MenuParentList)
            {
                OutlookBarBand outlookShortcutsBand = new OutlookBarBand(parent.MenuName);
                outlookShortcutsBand.LargeImageList = this.mf.imageList;
                outlookShortcutsBand.SmallImageList = this.mf.imageList;
                outlookShortcutsBand.Background = Color.White;

                foreach(PermissionManager.User.MenuParent.MenuChild child in parent.MenuChildList)
                {
                    OutlookBarItem item = new OutlookBarItem();

                    item.Text = child.MenuName;
                    item.Tag = child.MenuWindow;
                    item.ImageIndex = child.MenuBmp;

                    outlookShortcutsBand.Items.Add(item);
                }

                this.outlookBar.Bands.Add(outlookShortcutsBand);
            }
        }

        private void outlookBar_ItemClicked(OutlookBarBand band, OutlookBarItem item)
        {
            this.mf.OpenWindows(item.Tag as string);
        }   
    }
}
