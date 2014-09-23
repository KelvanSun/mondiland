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
    public partial class StoreManagerForm : Mondiland.UI.BaseForm,IMenuFavorites
    {
        private bool m_favorites = false;
        
        public StoreManagerForm()
        {
            InitializeComponent();

            UpdateFavoritesMenu();                   
        }

        /// <summary>
        /// 更新收藏菜单状态
        /// </summary>
        private void UpdateFavoritesMenu()
        {
            m_favorites = Program.permission.LoginUser.IsUserMenuFavorites(this.Name);

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
            if (Program.permission.LoginUser.UnFavorites(this.Name))
                MessageUtil.ShowWarning("成功取消快捷方式!");
            else
                MessageUtil.ShowWarning("取消快捷方式失败!");

        }

        public void SetFavorites()
        {
            if (Program.permission.LoginUser.SetFavorites(this.Name))
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

        private void tsmi_add_Click(object sender, EventArgs e)
        {
            StoreObject obj = new StoreObject();
            StoreAEForm form = new StoreAEForm(obj);

            form.ShowDialog();

            tsb_all_Click(sender, e);
        }

        private void tsmi_edit_Click(object sender, EventArgs e)
        {
            if (this.storeObjectBindingSource.Current == null)
            {
                MessageUtil.ShowWarning("先查询到记录再编辑!");
                return;
            }

            StoreAEForm form = new StoreAEForm(this.storeObjectBindingSource.Current as StoreObject);
            form.ShowDialog();

            tsb_all_Click(sender, e);
        }

        private void tsb_all_Click(object sender, EventArgs e)
        {
            this.storeObjectBindingSource.DataSource = StoresManager.GetLogAllList();

            this.label_search_result.Text = string.Format("共有 {0} 家店铺", this.storeObjectBindingSource.Count);
        }

        private void StoreManagerForm_Load(object sender, EventArgs e)
        {
            tsb_all_Click(sender, e);
        }
    }
}
