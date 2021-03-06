﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Mondiland.Obj;
using Mondiland.Global;

namespace Mondiland.UI
{
    public partial class ProductManagerForm : Mondiland.UI.BaseForm, IMenuFavorites
    {
        private bool m_favorites = false;
        private string m_huohao_saveas = string.Empty;
        private ProductObject product = new ProductObject();

        public ProductManagerForm()
        {
            InitializeComponent();

     
            UpdateFavoritesMenu();  
        }

        public string HuohaoSaveAs
        {
            set { m_huohao_saveas = value; }
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

        private void ProductManagerForm_Load(object sender, EventArgs e)
        {
            cbx_dengji.DataSource = DengjiManager.DengjiList;
            cbx_dengji.DisplayMember = "Type";
            cbx_dengji.ValueMember = "Id";
            cbx_dengji.Text = string.Empty;
            cbx_dengji.SelectedValue = 0;

            cbx_madeplace.DataSource = MadePlaceManager.MadePlaceList;
            cbx_madeplace.DisplayMember = "Type";
            cbx_madeplace.ValueMember = "Id";
            cbx_madeplace.Text = string.Empty;
            cbx_madeplace.SelectedValue = 0;

            cbx_partname.DataSource = PartNameManager.PartNameList;
            cbx_partname.DisplayMember = "PartName";
            cbx_partname.ValueMember = "Id";
            cbx_partname.Text = string.Empty;
            cbx_partname.SelectedValue = 0;

            cbx_safedata.DataSource = SafeDataManager.SafeDataList;
            cbx_safedata.DisplayMember = "Type";
            cbx_safedata.ValueMember = "Id";
            cbx_safedata.Text = string.Empty;
            cbx_safedata.SelectedValue = 0;

            cbx_standard.DataSource = StandardDataManager.StandardDataList;
            cbx_standard.DisplayMember = "Type";
            cbx_standard.ValueMember = "Id";
            cbx_standard.Text = string.Empty;
            cbx_standard.SelectedValue = 0;

            cbx_color.DataSource = ColorDataManager.ColorDataList;
            cbx_color.DisplayMember = "Type";
            cbx_color.ValueMember = "Id";
            cbx_color.Text = string.Empty;
            cbx_color.SelectedValue = 0;


            txb_huohao.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txb_huohao.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txb_huohao.AutoCompleteCustomSource = this.GetAutoCompleteCustomSource();


            this.bindingSource_material.DataSource = product.MaterialDataList;
        }

        private AutoCompleteStringCollection GetAutoCompleteCustomSource()
        {
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();

            foreach (string str in ProductObject.HuoHaoList)
            {
                acsc.Add(str);
            }

            return acsc;
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
            this.dgv_material_fill.Columns.Clear();
            txb_fill.Text = this.product.MaterialFillInfo.material_type;

            foreach (ProductObject.SizeDataList size in this.product.SizeDataListInfo)
            {
                DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();

                dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dc.HeaderText = string.Format("{0}--{1}", size.SizeName, size.SizeType);
                dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgv_material_fill.Columns.Add(dc);
            }

            if (this.dgv_material_fill.Columns.Count == 0) return;

            int index = this.dgv_material_fill.Rows.Add();

            int cell_index = 0;

            foreach (ProductObject.MaterialFillInfoObject.MaterialFillData fill in this.product.MaterialFillInfo.m_material_fill_list)
            {
                this.dgv_material_fill.Rows[index].Cells[cell_index++].Value = fill.Fill;
            }

            this.dgv_material_fill.Rows[this.dgv_material_fill.CurrentRow.Index].Selected = false;

        }

        private void txb_huohao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txb_huohao.Tag = txb_huohao.Text;
                if (txb_huohao.Text.Trim() == string.Empty)
                    return;

                if (!CheckHuoHao(this.txb_huohao.Text.Trim()))
                {
                    this.txb_huohao.Text = string.Empty;
                }

                product = new ProductObject(txb_huohao.Text.Trim());

                if (product.Id != 0)
                {
                    LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("产品信息[{0}]信息载入!", product.HuoHao));
                    
                }
                
                cbx_partname.SelectedValue = product.PartName_Id;
                cbx_dengji.SelectedValue = product.DengJi_Id;
                cbx_madeplace.SelectedValue = product.MadePlace_Id;
                cbx_safedata.SelectedValue = product.SafeData_Id;
                cbx_standard.SelectedValue = product.StandardData_Id;
                txb_price.Text = product.Price.ToString();
                txb_memo.Text = product.Memo;
                chb_wash.Checked = product.Pwash;
                chb_bad.Checked = product.Pbad;

                chb_template.Checked = product.Ptemplate;
                txb_template.Text = product.TemplateData;

                if(product.EAN13DataListInfo.Count >0)
                {
                    menu_print_tag.Checked = false;                    
                    tsmi_tag2_print.Checked = true;
                }
                else
                {
                    menu_print_tag.Checked = true;
                    tsmi_tag2_print.Checked = false;
                }
                

                if(product.Id !=0 )
                {
                    lb_memo.Text = PartNameManager.PartNameList[cbx_partname.SelectedIndex].Memo;
                }

                this.bindingSource_material.DataSource = product.MaterialDataList;
                

                if(dgv_material.RowCount > 0)   dgv_material.Rows[0].Selected = false;
                LoadDgvMaterialFill();

                if(product.PartName_Id == 21)
                {
                    dateTimePicker.Enabled = true;
                    cbx_color.Enabled = true;

                    cbx_color.SelectedValue = product.Color_Id;
                    dateTimePicker.Value = new DateTime(Convert.ToInt32(product.Gyear),Convert.ToInt32(product.Gmonth),1);
                }
                else
                {
                    dateTimePicker.Enabled = false;
                    cbx_color.Enabled = false;
                }

            }

            if(e.KeyCode == Keys.Escape)
            {
                this.txb_huohao.Text = txb_huohao.Tag as string;
            }

        }

        private void dgv_material_Leave(object sender, EventArgs e)
        {
            try
            {
                dgv_material.EndEdit();

                if (this.dgv_material.RowCount > 0)
                {
                    for (int index = 0; index < this.dgv_material.RowCount; ++index)
                    {
                        if ((this.dgv_material.Rows[index].Cells["Type"].Value as String).Trim() == string.Empty)
                            bindingSource_material.RemoveAt(index);
                    }

                    this.dgv_material.Rows[this.dgv_material.CurrentRow.Index].Selected = false;
                }
            }
            catch { }
        }

        private void dgv_material_fill_Leave(object sender, EventArgs e)
        {
            if (this.dgv_material_fill.RowCount > 0)
            {
                this.dgv_material_fill.Rows[this.dgv_material_fill.CurrentRow.Index].Selected = false;
            }
        }

        private void cbx_partname_DropDownClosed(object sender, EventArgs e)
        {
            if (this.cbx_partname.SelectedValue == null) return;
            
            this.product.PartName_Id = Convert.ToInt32(this.cbx_partname.SelectedValue);

            lb_memo.Text = PartNameManager.PartNameList[cbx_partname.SelectedIndex].Memo;

            PartNameManager.OptimizeInfo opt = new PartNameManager().GetOptimizeInfo(this.product.PartName_Id);

            if (opt.Safe_Id > 0)
            {
                cbx_safedata.SelectedValue = opt.Safe_Id;
            }
            else
            {
                cbx_safedata.Text = string.Empty;
                cbx_safedata.SelectedValue = 0;
            }
            
            if (opt.Standard_Id > 0)
            {
                cbx_standard.SelectedValue = opt.Standard_Id;
            }
            else
            {
                cbx_standard.Text = string.Empty;
                cbx_standard.SelectedValue = 0;
            }

            if (opt.Dengji_Id > 0)
            {
                cbx_dengji.SelectedValue = opt.Dengji_Id;
            }
            else
            {
                cbx_dengji.Text = string.Empty;
                cbx_dengji.SelectedValue = 0;
            }

            if (Convert.ToInt32(this.cbx_partname.SelectedValue) == 21)
            {
                this.dateTimePicker.Enabled = true;
                this.cbx_color.Enabled = true;

                this.product.Gyear = dateTimePicker.Value.Year.ToString();
                this.product.Gmonth = dateTimePicker.Value.Month.ToString();
            }
            else
            {
                this.dateTimePicker.Enabled = false;
                this.cbx_color.Enabled = false;
            }

            cbx_madeplace.SelectedValue = 1;

            //选择了休闲裤，打印水洗产品
            chb_wash.Checked = opt.Pwash;
            chb_bad.Checked = opt.Pbad;

            cbx_madeplace_DropDownClosed(sender, e);
            cbx_dengji_DropDownClosed(sender, e);
            cbx_safedata_DropDownClosed(sender, e);
            cbx_standard_DropDownClosed(sender, e);
            chb_wash_CheckedChanged(sender, e);

            
            LoadDgvMaterialFill();

        }

        private void cbx_dengji_DropDownClosed(object sender, EventArgs e)
        {
            this.product.DengJi_Id = Convert.ToInt32(this.cbx_dengji.SelectedValue);
        }

        private void cbx_madeplace_DropDownClosed(object sender, EventArgs e)
        {
            this.product.MadePlace_Id = Convert.ToInt32(this.cbx_madeplace.SelectedValue);
        }

        private void txb_price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.product.Price = Convert.ToDecimal(this.txb_price.Text);
            }
            catch
            {
                this.product.Price = 0;
            }
        }

        private void cbx_safedata_DropDownClosed(object sender, EventArgs e)
        {
            this.product.SafeData_Id = Convert.ToInt32(this.cbx_safedata.SelectedValue);
        }

        private void cbx_standard_DropDownClosed(object sender, EventArgs e)
        {
            this.product.StandardData_Id = Convert.ToInt32(this.cbx_standard.SelectedValue);
        }

        private void chb_wash_CheckedChanged(object sender, EventArgs e)
        {
            this.product.Pwash = this.chb_wash.Checked;
        }

        private void txb_memo_TextChanged(object sender, EventArgs e)
        {
            this.product.Memo = this.txb_memo.Text;
        }

        private bool CheckHuoHao(string str)
        {
            Regex reg = new Regex("[a-zA-Z]");

            return reg.IsMatch(str);
        }

        private void txb_huohao_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txb_huohao.Text.Trim())) return;

            if (CheckHuoHao(this.txb_huohao.Text.Trim()))
                this.product.HuoHao = this.txb_huohao.Text;
            else
            {
                this.txb_huohao.Text = string.Empty;
                this.product.HuoHao = string.Empty;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (MessageUtil.ShowYesNoAndTips("确定[新增]吗?") == System.Windows.Forms.DialogResult.No) return;

            LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, "产品信息新增操作!");              

            this.product = new ProductObject();

            txb_huohao.Text = product.HuoHao;
            cbx_partname.SelectedValue = product.PartName_Id;
            cbx_dengji.SelectedValue = product.DengJi_Id;
            cbx_madeplace.SelectedValue = product.MadePlace_Id;
            cbx_safedata.SelectedValue = product.SafeData_Id;
            cbx_standard.SelectedValue = product.StandardData_Id;
            txb_price.Text = product.Price.ToString();
            txb_memo.Text = product.Memo;
            chb_wash.Checked = product.Pwash;
            chb_bad.Checked = product.Pbad;

            chb_template.Checked = product.Ptemplate;
            txb_template.Text = product.TemplateData;

            this.bindingSource_material.DataSource = product.MaterialDataList;
            if (dgv_material.RowCount > 0) dgv_material.Rows[0].Selected = false;
            LoadDgvMaterialFill();
        }

        
        private void save_Click(object sender, EventArgs e)
        {
            dgv_material.EndEdit();
            dgv_material_fill.EndEdit();
            
            SaveResult result = product.Save();

            if (result.Code == CodeType.Error)
            {
                LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("货号为[{0}]信息保存失败!", product.HuoHao));              
                
                MessageUtil.ShowError(result.Message);

                return;
            }

            if (result.Code == CodeType.Ok)
            {
                LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("货号为[{0}]信息保存成功!", product.HuoHao));              

                MessageUtil.ShowTips(result.Message);

                this.product = new ProductObject();

                txb_huohao.Text = product.HuoHao;
                cbx_partname.SelectedValue = product.PartName_Id;
                cbx_dengji.SelectedValue = product.DengJi_Id;
                cbx_madeplace.SelectedValue = product.MadePlace_Id;
                cbx_safedata.SelectedValue = product.SafeData_Id;
                cbx_standard.SelectedValue = product.StandardData_Id;
                txb_price.Text = product.Price.ToString();
                txb_memo.Text = product.Memo;
                chb_wash.Checked = product.Pwash;
                chb_bad.Checked = product.Pbad;
                chb_template.Checked = product.Ptemplate;
                txb_template.Text = product.TemplateData;
                this.bindingSource_material.DataSource = product.MaterialDataList;
                if (dgv_material.RowCount > 0) dgv_material.Rows[0].Selected = false;
                LoadDgvMaterialFill();

                txb_huohao.AutoCompleteCustomSource = this.GetAutoCompleteCustomSource();
            }
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            if(this.txb_fill.Text.Trim() != string.Empty)
            {
                if(this.dgv_material.RowCount <= 5)
                    this.bindingSource_material.AddNew();
            }
            else
            {
                if (this.dgv_material.RowCount <= 6)
                    this.bindingSource_material.AddNew();
            }            
        }

        private void bt_del_Click(object sender, EventArgs e)
        {
            if (bindingSource_material.Count != 0)
            {
                bindingSource_material.RemoveCurrent();
            }
        }

        private void txb_fill_TextChanged(object sender, EventArgs e)
        {
            this.product.MaterialFillInfo.material_type = this.txb_fill.Text.Trim();
        }

        private void menu_print_tag_Click(object sender, EventArgs e)
        {
            if(this.product.Id == 0)
            {
                MessageUtil.ShowWarning("无法打印当前记录!");
                return;
            }

            dgv_material.EndEdit();
            dgv_material_fill.EndEdit();

            ProductPrintForm print = new ProductPrintForm(this.product, ProductObject.PrintType.TagCODE93);
            print.ShowDialog();
        }

        private void menu_print_wash_Click(object sender, EventArgs e)
        {

            if (this.product.Id == 0)
            {
                MessageUtil.ShowWarning("无法打印当前记录!");
                return;
            }

            dgv_material.EndEdit();
            dgv_material_fill.EndEdit();

            ProductPrintForm print = new ProductPrintForm(this.product, ProductObject.PrintType.Wash);
            print.ShowDialog();

        }

        private void txb_price_MouseDown(object sender, MouseEventArgs e)
        {
            this.txb_price.Select(0, this.txb_price.Text.Length);
        }

        private void chb_bad_CheckedChanged(object sender, EventArgs e)
        {
            this.product.Pbad = this.chb_bad.Checked;
        }

        private void chb_bad_Click(object sender, EventArgs e)
        {
            if (chb_bad.Checked)
                chb_wash.Checked = false;
        }

        private void chb_wash_Click(object sender, EventArgs e)
        {
            if (chb_wash.Checked)
                chb_bad.Checked = false;
        }

        private void dgv_material_fill_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            product.UpdataMaterialFillList(this.dgv_material_fill.Columns[e.ColumnIndex].HeaderText.Substring(0, 2),
                                            this.dgv_material_fill.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        }

        private void saveas_Click(object sender, EventArgs e)
        {
            if(product.Id == 0)
            {
                MessageUtil.ShowWarning("当前记录为空,无法[另存]操作!");
                return;
            }

            ProductSaveAsForm form = new ProductSaveAsForm(this);
            form.ShowDialog();

            if(m_huohao_saveas != string.Empty)
            {
                ProductObject save_as = this.product.Clone() as ProductObject;

                save_as.Id = 0;
                save_as.HuoHao = this.m_huohao_saveas;

                SaveResult result = save_as.Save();

                if(result.Code == CodeType.Error)
                {
                    LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("另存货号为[{0}]操作保存失败!", save_as.HuoHao));                    
                    
                    MessageUtil.ShowError(result.Message);
                    this.m_huohao_saveas = string.Empty;

                    return;
                }

                if(result.Code == CodeType.Ok)
                {
                    LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("另存货号为[{0}]操作保存成功!", save_as.HuoHao));              
                    
                    MessageUtil.ShowTips(result.Message);

                    this.m_huohao_saveas = string.Empty;

                    product = new ProductObject(save_as.HuoHao);

                    txb_huohao.Text = product.HuoHao;
                    cbx_partname.SelectedValue = product.PartName_Id;
                    cbx_dengji.SelectedValue = product.DengJi_Id;
                    cbx_madeplace.SelectedValue = product.MadePlace_Id;
                    cbx_safedata.SelectedValue = product.SafeData_Id;
                    cbx_standard.SelectedValue = product.StandardData_Id;
                    txb_price.Text = product.Price.ToString();
                    txb_memo.Text = product.Memo;
                    chb_wash.Checked = product.Pwash;
                    chb_bad.Checked = product.Pbad;

                    chb_template.Checked = product.Ptemplate;
                    txb_template.Text = product.TemplateData;

                    this.bindingSource_material.DataSource = product.MaterialDataList;
                    if (dgv_material.RowCount > 0) dgv_material.Rows[0].Selected = false;
                    LoadDgvMaterialFill();

                    txb_huohao.AutoCompleteCustomSource = this.GetAutoCompleteCustomSource();
                }
            }
        }

        private void cbx_color_DropDownClosed(object sender, EventArgs e)
        {
            this.product.Color_Id = Convert.ToInt32(this.cbx_color.SelectedValue);
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.product.Gyear = dateTimePicker.Value.Year.ToString();
            this.product.Gmonth = dateTimePicker.Value.Month.ToString();
        }

        private void txb_template_TextChanged(object sender, EventArgs e)
        {
            this.product.TemplateData = txb_template.Text;
        }

        private void chb_template_CheckedChanged(object sender, EventArgs e)
        {
            this.product.Ptemplate = this.chb_template.Checked;
        }

        private void toolStripButtonBarcode_Click(object sender, EventArgs e)
        {
            if (this.product.Id == 0)
            {
                MessageUtil.ShowWarning("先保存数据然后再操作!");
                return;
            }
            
            BarcodeManagerForm form = new BarcodeManagerForm(this.product);
            form.ShowDialog();
        }

        private void tsmi_tag2_print_Click(object sender, EventArgs e)
        {
            if (this.product.Id == 0)
            {
                MessageUtil.ShowWarning("无法打印当前记录!");
                return;
            }

            dgv_material.EndEdit();
            dgv_material_fill.EndEdit();

            ProductPrintForm print = new ProductPrintForm(this.product, ProductObject.PrintType.TagEAN13);
            print.ShowDialog();
        }

    }
}
