using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Mondiland.BLL;
using Mondiland.BLLEntity;
using UtilityLibrary.WinControls;

namespace Mondiland.UI
{
    public partial class MainToolForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private MainForm m_mainForm = null;
        public MainToolForm(MainForm main)
        {
            m_mainForm = main;
            InitializeComponent();
        }

        /// <summary>
        /// 根据user_id加载菜单项
        /// </summary>
        /// <param name="user_id">登陆的用户ID</param>
        public void LoadMenuInfo(int user_id)
        {
            IEnumerator<BEParentMenuInfo> parent_ator = BLLFactory<BLLMenuInfo>.Instance.GetParentMenuInfo(user_id).GetEnumerator();

            while(parent_ator.MoveNext())
            {
                OutlookBarBand outlookShortcutsBand = new OutlookBarBand(parent_ator.Current.Menu_name);
                outlookShortcutsBand.LargeImageList = m_mainForm.imageList;
                outlookShortcutsBand.SmallImageList = m_mainForm.imageList;
                outlookShortcutsBand.Background = Color.White;

                IEnumerator<BEChildMenuInfo> child_ator = BLLFactory<BLLMenuInfo>.Instance.GetChildMenuInfo(parent_ator.Current.Menu_id).GetEnumerator();

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
            m_mainForm.OpenWindows(item.Tag as string);
        }   
    }
}
