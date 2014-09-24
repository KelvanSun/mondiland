using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Mondiland.Global;
using Mondiland.Obj;

namespace Mondiland.UI
{
    public partial class SysLogManagerForm : Mondiland.UI.BaseForm, IMenuFavorites
    {
        public class CustomQuery
        {
            public DateTime dt_begin = DateTime.Now;
            public DateTime dt_end = DateTime.Now;
            public string str_username = string.Empty;
            public string str_log = string.Empty;
        }
          
        private bool m_favorites = false;
        
        public SysLogManagerForm()
        {
            InitializeComponent();

            UpdateFavoritesMenu();  
        }

        private void UpdateFavoritesMenu()
        {
            m_favorites = AuthorManager.LoginUser.IsUserMenuFavorites(this.Name);

            if (m_favorites)
            {
                this.toolStrip.Items["favorites"].Text = "取消收藏";
                this.toolStrip.Items["favorites"].ToolTipText = "取消收藏";
            }
            else
            {
                this.toolStrip.Items["favorites"].Text = "收藏";
                this.toolStrip.Items["favorites"].ToolTipText = "收藏";
            }
        }

        public void UnFavorites()
        {
            if (AuthorManager.LoginUser.UnFavorites(this.Name))
                MessageUtil.ShowWarning("成功取消快捷方式!");
            else
                MessageUtil.ShowWarning("取消快捷方式失败!");

        }

        public void SetFavorites()
        {
            if (AuthorManager.LoginUser.SetFavorites(this.Name))
                MessageUtil.ShowWarning("成功收藏快捷方式!");
            else
                MessageUtil.ShowWarning("收藏快捷方式失败!");
        }

        private void favorites_Click(object sender, EventArgs e)
        {
            if (m_favorites)
                UnFavorites();
            else
                SetFavorites();

            UpdateFavoritesMenu();
        }

        private void tsb_all_Click(object sender, EventArgs e)
        {
            this.logInfoObjectBindingSource.DataSource = LogInfoManager.GetLogAllInfo();
        }

        private void tsb_today_Click(object sender, EventArgs e)
        {
            this.logInfoObjectBindingSource.DataSource = LogInfoManager.GetLogTodayInfo();
        }

        private void tsb_custom_Click(object sender, EventArgs e)
        {
            CustomQuery query = new CustomQuery();
            
            LogCustomQueryForm form = new LogCustomQueryForm(query);
            form.ShowDialog();

            if(form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.logInfoObjectBindingSource.DataSource = LogInfoManager.GetLogCustomQueryInfo(query.dt_begin, query.dt_end, query.str_username, query.str_log);
            }
        }
    }
}
