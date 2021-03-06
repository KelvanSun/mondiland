﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Mondiland.Obj;
using Mondiland.Global;
using Microsoft.Reporting.WinForms;

namespace Mondiland.UI
{
    public partial class SupplierManagerForm : Mondiland.UI.BaseForm,IMenuFavorites
    {
        private bool m_favorites = false;
        
        public SupplierManagerForm()
        {
            InitializeComponent();
            
            
            UpdateFavoritesMenu();                       

        }

        /// <summary>
        /// 更新收藏菜单状态
        /// </summary>
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

        private void add_Click(object sender, EventArgs e)
        {
            SupplierObject ob = new SupplierObject();
            
            SupplierAEForm form = new SupplierAEForm(ob);
            form.ShowDialog();
        }

        private void SupplierManagerForm_Load(object sender, EventArgs e)
        {
            this.cbx_query_type.Text = "公司简称";

            this.tscb_class.ComboBox.DataSource = SupplierClassManager.SupplierClassList;
            this.tscb_class.ComboBox.DisplayMember = "Name";
            this.tscb_class.ComboBox.ValueMember = "Id";
            this.tscb_class.ComboBox.Text = string.Empty;
            this.tscb_class.ComboBox.SelectedValue = 0;
           
        }

        private void cbx_query_type_DropDownClosed(object sender, EventArgs e)
        {
             this.txb_query_text.Focus();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txb_query_text.Text)) return;

            if(cbx_query_type.Text == "拼音码")
            {
                this.bindingSource_query.DataSource = SupplierManager.QuerySupplierMByPym(this.txb_query_text.Text.Trim());
               
            }

            if(cbx_query_type.Text == "公司简称")
            {
                
                this.bindingSource_query.DataSource = SupplierManager.QuerySupplierMByName(this.txb_query_text.Text.Trim());
          
            }

            if(cbx_query_type.Text == "公司全称")
            {

                this.bindingSource_query.DataSource = SupplierManager.QuerySupplierMByIntactName(this.txb_query_text.Text.Trim());
            }

            if (cbx_query_type.Text == "联系人简称")
            {

                this.bindingSource_query.DataSource = SupplierManager.QueryContactsByPym(this.txb_query_text.Text.Trim());
            }

            if (cbx_query_type.Text == "联系人姓名")
            {

                this.bindingSource_query.DataSource = SupplierManager.QueryContactsByName(this.txb_query_text.Text.Trim());
            }


            this.label_search_result.Text = string.Format("共查询到 {0} 条记录", this.bindingSource_query.Count);

            this.dgv_main.Focus();

            LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("查询条件[{0}] 查询内容[{1}] 共查询到[{2}]条记录", cbx_query_type.Text, this.txb_query_text.Text.Trim(), this.bindingSource_query.Count));

        }

        private void txb_query_text_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button_search_Click(sender, e);
            }
        }

        private void dgv_main_SelectionChanged(object sender, EventArgs e)
        {
            if (this.bindingSource_query.Current == null)
            {
                this.bindingSource_main.DataSource = new SupplierObject();
                return;
            }
            this.bindingSource_main.DataSource = this.bindingSource_query.Current as SupplierObject;

            this.bindingSource_factory.DataSource = (this.bindingSource_query.Current as SupplierObject).SupplierFList;

            this.bindingSource_contract.DataSource = (this.bindingSource_query.Current as SupplierObject).SupplierDList;
        }

        private void tsmi_supplier_add_Click(object sender, EventArgs e)
        {
            SupplierObject ob = new SupplierObject();

            SupplierAEForm form = new SupplierAEForm(ob);
            form.ShowDialog();

            this.bindingSource_factory.Clear();
            this.bindingSource_contract.Clear();
        }

        private void tsmi_supplier_edit_Click(object sender, EventArgs e)
        {
            if(this.bindingSource_query.Current == null)
            {
                MessageUtil.ShowWarning("先查询到记录再编辑!");
                return;
            }

            SupplierAEForm form = new SupplierAEForm(this.bindingSource_query.Current as SupplierObject);
            form.ShowDialog();

        }

        private void tsmi_supplierf_add_Click(object sender, EventArgs e)
        {
            if(this.bindingSource_query.Current == null)
            {
                MessageUtil.ShowWarning("先查询到供应商后再[新增]操作!");
                return;
            }

            SupplierObject obj = (this.bindingSource_query.Current as SupplierObject);


            SupplierObject.SupplierFObject supplierF = new SupplierObject.SupplierFObject(obj.Id,obj.Intact_Name);

            SupplierFAEForm form = new SupplierFAEForm(supplierF);
            form.ShowDialog();

        }

        private void tsmi_supplierf_edit_Click(object sender, EventArgs e)
        {
            if(this.bindingSource_factory.Current == null)
            {
                MessageUtil.ShowWarning("先查询到记录再编辑!");
                return;
            }

            SupplierFAEForm form = new SupplierFAEForm(this.bindingSource_factory.Current as SupplierObject.SupplierFObject);
            form.ShowDialog();

        }

        private void tsmi_supplierd_edit_Click(object sender, EventArgs e)
        {
            if (this.bindingSource_contract.Current == null)
            {
                MessageUtil.ShowWarning("先查询到记录再编辑!");
                return;
            }

            SupplierObject.SupplierDObject obj = (this.bindingSource_contract.Current as SupplierObject.SupplierDObject);

            SupplierObject supplier = (this.bindingSource_query.Current as SupplierObject);

            obj.SupplierName = supplier.Intact_Name;


            SupplierDAEForm form = new SupplierDAEForm(obj);
            form.ShowDialog();

        }

        private void tsmi_supplierd_add_Click(object sender, EventArgs e)
        {
            if (this.bindingSource_query.Current == null)
            {
                MessageUtil.ShowWarning("先查询到供应商后再[新增]操作!");
                return;
            }

            SupplierObject obj = (this.bindingSource_query.Current as SupplierObject);

            SupplierObject.SupplierDObject supplierD = new SupplierObject.SupplierDObject(obj.Id,obj.Intact_Name);

            SupplierDAEForm form = new SupplierDAEForm(supplierD);
            form.ShowDialog();

        }

        private void tscb_class_DropDownClosed(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.tscb_class.ComboBox.SelectedValue);
            
            if (id == 0) return;

            this.bindingSource_query.DataSource = SupplierManager.QuerySupplierMByClassId(id);

            this.label_search_result.Text = string.Format("共查询到 {0} 条记录", this.bindingSource_query.Count);

            this.dgv_main.Focus();

            LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("大类[{0}]方式查询 共查询到[{1}]条记录", this.tscb_class.ComboBox.Text, this.bindingSource_query.Count));
        }

        private void tsddb_supplier_view_Click(object sender, EventArgs e)
        {
            if (this.bindingSource_query.Current == null)
            {
                MessageUtil.ShowWarning("先查询到供应商后操作!");
                return;
            }

            SupplierAllViewForm form = new SupplierAllViewForm(this.bindingSource_query.Current as SupplierObject);
            form.ShowDialog();
        }

        private void dgv_main_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsddb_supplier_view_Click(sender, e);
        }

        private void tsb_all_Click(object sender, EventArgs e)
        {
            this.bindingSource_query.DataSource = SupplierManager.GetAllInfoList();

            this.label_search_result.Text = string.Format("共查询到 {0} 条记录", this.bindingSource_query.Count);

            LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("查询全部记录共[{0}]条记录",  this.bindingSource_query.Count));
        }
      
    }
}
