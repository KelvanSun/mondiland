using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Mondiland.BLL;
using Mondiland.BLLEntity;
using Mondiland.Global;

namespace Mondiland.UI
{
    public partial class ProductManagerForm : Mondiland.UI.BaseForm, IMenuFavorites
    {
        private bool m_favorites = false;
        private ProductObject product = null;
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

        private void ProductManagerForm_Load(object sender, EventArgs e)
        {
            cbx_dengji.DataSource = BLLFactory<BLLProductInfo>.Instance.GetDengjiList();
            cbx_dengji.DisplayMember = "Type";
            cbx_dengji.ValueMember = "Id";
            cbx_dengji.Text = string.Empty;
            cbx_dengji.SelectedValue = 0;

            cbx_madeplace.DataSource = BLLFactory<BLLProductInfo>.Instance.GetMadePlaceList();
            cbx_madeplace.DisplayMember = "Type";
            cbx_madeplace.ValueMember = "Id";
            cbx_madeplace.Text = string.Empty;
            cbx_madeplace.SelectedValue = 0;

            cbx_partname.DataSource = BLLFactory<BLLProductInfo>.Instance.GetPartNameList();
            cbx_partname.DisplayMember = "PartName";
            cbx_partname.ValueMember = "Id";
            cbx_partname.Text = string.Empty;
            cbx_partname.SelectedValue = 0;

            cbx_safedata.DataSource = BLLFactory<BLLProductInfo>.Instance.GetSafeDataList();
            cbx_safedata.DisplayMember = "Type";
            cbx_safedata.ValueMember = "Id";
            cbx_safedata.Text = string.Empty;
            cbx_safedata.SelectedValue = 0;

            cbx_standard.DataSource = BLLFactory<BLLProductInfo>.Instance.GetStandardDataList();
            cbx_standard.DisplayMember = "Type";
            cbx_standard.ValueMember = "Id";
            cbx_standard.Text = string.Empty;
            cbx_standard.SelectedValue = 0;
            
            
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            IEnumerator<string> ator = BLLFactory<BLLProductInfo>.Instance.GetHuoHaoList().GetEnumerator();

            while (ator.MoveNext())
            {
                acsc.Add(ator.Current.ToString());
            }

            txb_huohao.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txb_huohao.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txb_huohao.AutoCompleteCustomSource = acsc;
        }

        private void txb_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txb_price.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        /// <summary>
        /// 加载填充数据
        /// </summary>
        private void LoadDgvMaterialFill()
        {
            IEnumerator<BESizeDataList> size_ator = this.product.SizeDataList.GetEnumerator();

            this.dgv_material_fill.Columns.Clear();
            txb_fill.Text = string.Empty;

            while(size_ator.MoveNext())
            {
                DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();

                dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dc.HeaderText = string.Format("{0}--{1}",size_ator.Current.SizeName,size_ator.Current.SizeType);
                dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgv_material_fill.Columns.Add(dc);

            }

            int index = this.dgv_material_fill.Rows.Add();

            IEnumerator<BEMaterialFillData> fill_ator = this.product.MaterialFillData.m_material_fill_list.GetEnumerator();

            int cell_index = 0;

            while(fill_ator.MoveNext())
            {
                this.dgv_material_fill.Rows[index].Cells[cell_index++].Value = fill_ator.Current.Fill;
                txb_fill.Text = fill_ator.Current.Type;
            }

            this.dgv_material_fill.Rows[index].Selected = false;

        }

        private void txb_huohao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txb_huohao.Text.Trim() == string.Empty)
                    return;

                product = new ProductObject(txb_huohao.Text.Trim());

                //记录存在
                if(product.Id != 0)
                {
                    cbx_partname.SelectedValue = product.PartName_Id;
                    cbx_dengji.SelectedValue = product.DengJi_Id;
                    cbx_madeplace.SelectedValue = product.MadePlace_Id;
                    cbx_safedata.SelectedValue = product.SafeData_Id;
                    cbx_standard.SelectedValue = product.StandardData_Id;
                    txb_price.Text = product.Price.ToString();
                    txb_memo.Text = product.Memo;
                    chb_wash.Checked = product.Pwash;
                    dgv_material.DataSource = product.MaterialDataList;
                    dgv_material.Rows[0].Selected = false;
                    LoadDgvMaterialFill();
                }
               
            }
        }

        private void dgv_material_Leave(object sender, EventArgs e)
        {
            if(this.dgv_material.RowCount > 0)
            {
                this.dgv_material.Rows[this.dgv_material.CurrentRow.Index].Selected = false;
            }
        }

        private void dgv_material_fill_Leave(object sender, EventArgs e)
        {
            if (this.dgv_material_fill.RowCount > 0)
            {
                this.dgv_material_fill.Rows[this.dgv_material_fill.CurrentRow.Index].Selected = false;
            }
        }
    }
}
