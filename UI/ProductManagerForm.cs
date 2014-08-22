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
            txb_huohao.AutoCompleteCustomSource = this.GetAutoCompleteCustomSource();


            this.bindingSource_material.DataSource = product.MaterialDataList;
        }

        private AutoCompleteStringCollection GetAutoCompleteCustomSource()
        {
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();

            IEnumerator<string> ator = BLLFactory<BLLProductInfo>.Instance.GetHuoHaoList().GetEnumerator();

            while (ator.MoveNext())
            {
                acsc.Add(ator.Current.ToString());
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
            IEnumerator<BESizeDataList> size_ator = this.product.SizeDataList.GetEnumerator();

            this.dgv_material_fill.Columns.Clear();
            txb_fill.Text = this.product.MaterialFillData.material_type;

            while(size_ator.MoveNext())
            {
                DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();

                dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dc.SortMode = DataGridViewColumnSortMode.NotSortable;
                dc.HeaderText = string.Format("{0}--{1}",size_ator.Current.SizeName,size_ator.Current.SizeType);
                dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dgv_material_fill.Columns.Add(dc);

            }

            if (this.dgv_material_fill.ColumnCount <= 0) return;

            int index = this.dgv_material_fill.Rows.Add();

            IEnumerator<BEMaterialFillData> fill_ator = this.product.MaterialFillData.m_material_fill_list.GetEnumerator();

            int cell_index = 0;

            while(fill_ator.MoveNext())
            {
                this.dgv_material_fill.Rows[index].Cells[cell_index++].Value = fill_ator.Current.Fill;
        
            }

            this.dgv_material_fill.Rows[index].Selected = false;

        }

        private void txb_huohao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txb_huohao.Tag = txb_huohao.Text;
                if (txb_huohao.Text.Trim() == string.Empty)
                    return;

                product = new ProductObject(txb_huohao.Text.Trim());

                
                cbx_partname.SelectedValue = product.PartName_Id;
                cbx_dengji.SelectedValue = product.DengJi_Id;
                cbx_madeplace.SelectedValue = product.MadePlace_Id;
                cbx_safedata.SelectedValue = product.SafeData_Id;
                cbx_standard.SelectedValue = product.StandardData_Id;
                txb_price.Text = product.Price.ToString();
                txb_memo.Text = product.Memo;
                chb_wash.Checked = product.Pwash;
                chb_bad.Checked = product.Pbad;
                this.bindingSource_material.DataSource = product.MaterialDataList;
                if(dgv_material.RowCount > 0)   dgv_material.Rows[0].Selected = false;
                LoadDgvMaterialFill();
              
               
            }

            if(e.KeyCode == Keys.Escape)
            {
                this.txb_huohao.Text = txb_huohao.Tag as string;
            }

        }

        private void dgv_material_Leave(object sender, EventArgs e)
        {
            dgv_material.EndEdit();            
            
            if(this.dgv_material.RowCount > 0)
            {
                for (int index = 0; index < this.dgv_material.RowCount; ++index)
                {
                    if ((this.dgv_material.Rows[index].Cells["Type"].Value as String).Trim() == string.Empty)
                        bindingSource_material.RemoveAt(index);       
                }
                      
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

        private void cbx_partname_DropDownClosed(object sender, EventArgs e)
        {
            this.product.PartName_Id = Convert.ToInt32(this.cbx_partname.SelectedValue);

            int safe_id = BLLFactory<BLLProductInfo>.Instance.GetOptimizeSafeId(Convert.ToInt32(cbx_partname.SelectedValue));
            int standard_id = BLLFactory<BLLProductInfo>.Instance.GetOptimizeStandardId(Convert.ToInt32(cbx_partname.SelectedValue));
            
            if (safe_id > 0)
            {
                cbx_safedata.SelectedValue = safe_id;
            }
            else
            {
                cbx_safedata.Text = string.Empty;
                cbx_safedata.SelectedValue = 0;
            }
            if (standard_id > 0)
            {
                cbx_standard.SelectedValue = standard_id;
            }
            else
            {
                cbx_standard.Text = string.Empty;
                cbx_standard.SelectedValue = 0;
            }

            //选择了休闲裤，打印水洗产品
            chb_wash.Checked = BLLFactory<BLLProductInfo>.Instance.GetOptimizePwash(Convert.ToInt32(cbx_partname.SelectedValue));
            chb_bad.Checked = BLLFactory<BLLProductInfo>.Instance.GetOptimizePbad(Convert.ToInt32(cbx_partname.SelectedValue));

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
            this.product.Price = Convert.ToDecimal(this.txb_price.Text);
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

        private void txb_huohao_TextChanged(object sender, EventArgs e)
        {
            this.product.HuoHao = this.txb_huohao.Text;
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (MessageUtil.ShowYesNoAndTips("确定[新增]吗?") == System.Windows.Forms.DialogResult.No) return;
                                    
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
            this.bindingSource_material.DataSource = product.MaterialDataList;
            if (dgv_material.RowCount > 0) dgv_material.Rows[0].Selected = false;
            LoadDgvMaterialFill();
        }

        
        private void save_Click(object sender, EventArgs e)
        {
            ProductObject.SaveResult result = product.Save();

            if (result.Code == ProductObject.CodeType.Error)
            {
                MessageUtil.ShowError(result.Message);

                return;
            }

            if (result.Code == ProductObject.CodeType.Ok)
            {
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
            this.product.MaterialFillData.material_type = this.txb_fill.Text.Trim();
        }

        private void menu_print_tag_Click(object sender, EventArgs e)
        {
            if(this.product.Id == 0)
            {
                MessageUtil.ShowWarning("无法打印当前记录!");
                return;
            }

            PrintForm print = new PrintForm(this.product, ProductObject.PrintType.Tag);
            print.ShowDialog();
        }

        private void menu_print_wash_Click(object sender, EventArgs e)
        {

            if (this.product.Id == 0)
            {
                MessageUtil.ShowWarning("无法打印当前记录!");
                return;
            }

            PrintForm print = new PrintForm(this.product, ProductObject.PrintType.Wash);
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

                ProductObject.SaveResult result = save_as.Save();

                if(result.Code == ProductObject.CodeType.Error)
                {
                    MessageUtil.ShowError(result.Message);

                    return;
                }

                if(result.Code == ProductObject.CodeType.Ok)
                {
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
                    this.bindingSource_material.DataSource = product.MaterialDataList;
                    if (dgv_material.RowCount > 0) dgv_material.Rows[0].Selected = false;
                    LoadDgvMaterialFill();

                    txb_huohao.AutoCompleteCustomSource = this.GetAutoCompleteCustomSource();
                }
            }
        }
    }
}
