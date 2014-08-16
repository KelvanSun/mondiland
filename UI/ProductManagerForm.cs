﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Mondiland.BLL;
using Mondiland.Global;

namespace Mondiland.UI
{
    public partial class ProductManagerForm : Mondiland.UI.BaseForm, IMenuFavorites
    {
        private bool m_favorites = false;
        public ProductManagerForm()
        {
            InitializeComponent();

            UpdateFavoritesMenu();  
        }

        /// <summary>
        /// 更新收藏菜单状态
        /// </summary>
        private void UpdateFavoritesMenu()
        {
            m_favorites = BLLFactory<BLLMenuInfo>.Instance.IsUserMenuFavorites(Program.main_form.UserId,
                                                                               this.Name);

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
            if (BLLFactory<BLLMenuInfo>.Instance.UnFavorites(Program.main_form.UserId, this.Name))
                MessageUtil.ShowWarning("成功取消快捷方式!");
            else
                MessageUtil.ShowWarning("取消快捷方式失败!");

        }

        public void SetFavorites()
        {
            if (BLLFactory<BLLMenuInfo>.Instance.SetFavorites(Program.main_form.UserId, this.Name))
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
    }
}