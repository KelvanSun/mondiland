using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Mondiland.BLL;
using Mondiland.BLLEntity;

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

        }
    }
}
