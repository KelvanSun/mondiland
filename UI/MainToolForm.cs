using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Mondiland.BLL;
using Mondiland.BLLEntity;
using Mondiland.Obj;
using UtilityLibrary.WinControls;

namespace Mondiland.UI
{
    public partial class MainToolForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public MainToolForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 根据user_id加载菜单项
        /// </summary>
        /// <param name="user_id">登陆的用户ID</param>
        public void LoadMenuInfo()
        {
            foreach(PermissionObject.User.MenuParent parent in Program.main_form.UserObj.MenuParentList)
            {
                OutlookBarBand outlookShortcutsBand = new OutlookBarBand(parent.MenuName);
                outlookShortcutsBand.LargeImageList = Program.main_form.imageList;
                outlookShortcutsBand.SmallImageList = Program.main_form.imageList;
                outlookShortcutsBand.Background = Color.White;

                foreach(PermissionObject.User.MenuParent.MenuChild child in parent.MenuChildList)
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
            Program.main_form.OpenWindows(item.Tag as string);
        }   
    }
}
