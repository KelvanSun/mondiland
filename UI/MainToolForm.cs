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
            IEnumerator<PermissionObject.User.MenuParent> parent_ator = Program.main_form.UserObj.MenuParentList.GetEnumerator();

            int index = 0;

            while(parent_ator.MoveNext())
            {
                OutlookBarBand outlookShortcutsBand = new OutlookBarBand(parent_ator.Current.MenuName);
                outlookShortcutsBand.LargeImageList = Program.main_form.imageList;
                outlookShortcutsBand.SmallImageList = Program.main_form.imageList;
                outlookShortcutsBand.Background = Color.White;

                IEnumerator<PermissionObject.User.MenuParent.MenuChild> child_ator = Program.main_form.UserObj.MenuParentList[index++].MenuChildList.GetEnumerator();

                while(child_ator.MoveNext())
                {
                    OutlookBarItem item = new OutlookBarItem();

                    item.Text = child_ator.Current.MenuName;
                    item.Tag = child_ator.Current.MenuWindow;
                    item.ImageIndex = child_ator.Current.MenuBmp;

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
