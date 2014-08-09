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
                outlookShortcutsBand.Background = Color.White;

                this.outlookBar.Bands.Add(outlookShortcutsBand);
            }

        }
    }
}
