using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Mondiland.BLL;
using Mondiland.Obj;
using Mondiland.BLLEntity;

namespace Mondiland.UI
{
    public partial class DefaultForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private MainForm mf = null;

        public DefaultForm(MainForm form)
        {
            this.mf = form;
            InitializeComponent();
        }

        public void LoadFavoritesMenu()
        {
            this.flowLayoutPanel.Controls.Clear();

            foreach (PermissionObject.User.FavoritesMenu menu in Program.permission.LoginUser.FavoritesMenuList)
            {
                UCListViewItem item = new UCListViewItem(this.mf);

                item.ItemCaption = menu.MenuName;
                item.ItemImage = mf.imageList.Images[menu.MenuBmp];
                item.ItemMemo = menu.MenuMemo;
                item.ItemFormName = menu.MenuWindow;

                this.flowLayoutPanel.Controls.Add(item);
            }

        }
    }
}
