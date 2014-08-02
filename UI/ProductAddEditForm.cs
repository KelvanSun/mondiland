using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mondiland.BLL;
using Mondiland.BLLEntity;
using Mondiland.Global;

namespace Mondiland.UI
{
    public partial class ProductAddEditForm : Form
    {
        private Mode m_mode = Mode.Add;
        private bool m_iSaved = false;
        public ProductAddEditForm()
        {
           
            InitializeComponent();
        }

        private void ProductAddEditForm_Load(object sender, EventArgs e)
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

            cbx_wash.DataSource = BLLFactory<BLLProductInfo>.Instance.GetWashPrintTemplateList();
            cbx_wash.DisplayMember = "Type";
            cbx_wash.ValueMember = "Id";
            cbx_wash.Text = string.Empty;
            cbx_wash.SelectedValue = 0;


            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            IEnumerator<string> ator = BLLFactory<BLLProductInfo>.Instance.GetHuoHaoList().GetEnumerator();
  
            while(ator.MoveNext())
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

        private void Material_CountToTagName()
        {
            if (bindingSource_material.Count == 0) return;
            if (checkBox.Checked)
            {
                if (chb_wash.Checked)
                    tb_tag.Text = BLLFactory<BLLProductInfo>.Instance.GetTagName(true, bindingSource_material.Count + 1);
                else
                    tb_tag.Text = BLLFactory<BLLProductInfo>.Instance.GetTagName(false, bindingSource_material.Count + 1);
            }
            else
            {
                if(chb_wash.Checked)
                    tb_tag.Text = BLLFactory<BLLProductInfo>.Instance.GetTagName(true,bindingSource_material.Count);
                else
                    tb_tag.Text = BLLFactory<BLLProductInfo>.Instance.GetTagName(false, bindingSource_material.Count);
            }
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            bindingSource_material.AddNew();
            Material_CountToTagName();
        }

        private void bt_del_Click(object sender, EventArgs e)
        {
            if (bindingSource_material.Count != 0)
            {
                bindingSource_material.RemoveCurrent();
                Material_CountToTagName();
            }

        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox.Checked)
            {
                txb_fill.Enabled = true;
                dgv_fill.Enabled = true;

                if (chb_wash.Checked)
                {
                    tb_tag.Text = BLLFactory<BLLProductInfo>.Instance.GetTagName(true, bindingSource_material.Count + 1);
                }
                else
                {
                    tb_tag.Text = BLLFactory<BLLProductInfo>.Instance.GetTagName(false, bindingSource_material.Count + 1);
                }
            }
        }

        private void tsb_add_Click(object sender, EventArgs e)
        {
            if(txb_huohao.Text != string.Empty && m_mode == Mode.Add)
            {
                if(this.m_iSaved == false)
                {
                    if(MessageUtil.ShowYesNoAndTips("数据未保存,是否先保存数据?") == System.Windows.Forms.DialogResult.No)
                    {
                        this.ClearData();
                        this.m_mode = Mode.Add;
                        this.txb_huohao.Focus();
                        this.txb_huohao.ReadOnly = false;
                    }
                }
            }
            else
            {
                this.ClearData();
                this.m_mode = Mode.Add;
                this.m_iSaved = false;
                this.txb_huohao.Focus();
                this.txb_huohao.ReadOnly = false;
            }
            
        }

        private void tsb_save_Click(object sender, EventArgs e)
        {
            if (m_mode == Mode.Add)
                AddSave();
            else
                EditSave();
        }

        private void EditSave()
        {
            if (cbx_partname.SelectedValue == null)
            {
                MessageUtil.ShowTips("请选择[产品种类]信息");
                cbx_partname.Focus();
                return;
            }

            if (cbx_dengji.SelectedValue == null)
            {
                MessageUtil.ShowTips("请选择[产品等级]信息");
                cbx_dengji.Focus();
                return;
            }

            if (cbx_madeplace.SelectedValue == null)
            {
                MessageUtil.ShowTips("请输入[产品产地]信息");
                cbx_madeplace.Focus();
                return;
            }

            if (cbx_safedata.SelectedValue == null)
            {
                MessageUtil.ShowTips("请输入[安全类别]信息");
                cbx_safedata.Focus();
                return;
            }

            if (cbx_standard.SelectedValue == null)
            {
                MessageUtil.ShowTips("请输入[执行标准]信息");
                cbx_safedata.Focus();
                return;
            }

            if (cbx_wash.SelectedValue == null)
            {
                MessageUtil.ShowTips("请选择[洗唛模板]");
                cbx_wash.Focus();
                return;
            }

            if (bindingSource_material.Count == 0)
            {
                MessageUtil.ShowTips("[产品成份明细]不能为空!");
                return;
            }


            if (checkBox.Checked)
            {
                if (txb_fill.Text == string.Empty)
                {
                    MessageUtil.ShowTips("请输入[填充成份内容]");
                    return;
                }
            }

            BEProductDataInfo info = new BEProductDataInfo();

            info.PartName_Id = Convert.ToInt32(cbx_partname.SelectedValue);
            info.HuoHao = txb_huohao.Text;
            info.SafeData_Id = Convert.ToInt32(cbx_safedata.SelectedValue);
            info.StandardData_Id = Convert.ToInt32(cbx_standard.SelectedValue);
            
            if (txb_price.Text == string.Empty)
            {
                info.Price = 0;
            }
            else
            {
                info.Price = Convert.ToDecimal(txb_price.Text);
            }
            info.MadePlace_Id = Convert.ToInt32(cbx_madeplace.SelectedValue);
            info.Dengji_Id = Convert.ToInt32(cbx_dengji.SelectedValue);
            info.Tag_Id = BLLFactory<BLLProductInfo>.Instance.GetTagTemplateId(tb_tag.Text);
            info.Wash_Id = Convert.ToInt32(cbx_wash.SelectedValue);
            info.Memo = txb_memo.Text;
            info.LasTamp = Convert.ToInt64(txb_huohao.Tag);
            if (chb_wash.Checked)
                info.Pwash = 1;
            else
                info.Pwash = 0;

            int product_id = BLLFactory<BLLProductInfo>.Instance.GetProductId(txb_huohao.Text);

            if(BLLFactory<BLLProductInfo>.Instance.UpdateProductInfo(info,product_id,info.LasTamp))
            {
                BLLFactory<BLLProductInfo>.Instance.DeleteMaterialInfo(product_id);

                for (int index = 0; index < dgv_material.RowCount; index++)
                {
                    string str = dgv_material.Rows[index].Cells["type"].Value.ToString();
                    BLLFactory<BLLProductInfo>.Instance.AddMaterialInfo(product_id, str, index);
                }

                MessageUtil.ShowTips("保存成功");

                ClearData();
                m_iSaved = true;
                txb_huohao.Focus();
                txb_huohao.ReadOnly = false;
                m_mode = Mode.Add;
            }
            else
            {
                MessageUtil.ShowTips("保存失败");
            }

           
        }

        private void AddSave()
        {
                       
            if (cbx_partname.SelectedValue == null)
            {
                MessageUtil.ShowTips("请选择[产品种类]信息");
                cbx_partname.Focus();
                return;
            }

            if (cbx_dengji.SelectedValue == null)
            {
                MessageUtil.ShowTips("请选择[产品等级]信息");
                cbx_dengji.Focus();
                return;
            }

            if (txb_huohao.Text.Trim() == string.Empty)
            {
                MessageUtil.ShowTips("请输入[产品货号]信息");
                txb_huohao.Focus();
                return;
            }

            //if (txb_price.Text == string.Empty)
            //{
            //    MessageBox.Show("请输入[产品价格]信息");
            //    txb_price.Focus();
            //    return;
            //}

            if (cbx_madeplace.SelectedValue == null)
            {
                MessageUtil.ShowTips("请输入[产品产地]信息");
                cbx_madeplace.Focus();
                return;
            }

            if (cbx_safedata.SelectedValue == null)
            {
                MessageUtil.ShowTips("请输入[安全类别]信息");
                cbx_safedata.Focus();
                return;
            }

            if (cbx_standard.SelectedValue == null)
            {
                MessageUtil.ShowTips("请输入[执行标准]信息");
                cbx_safedata.Focus();
                return;
            }

            if (cbx_wash.SelectedValue == null)
            {
                MessageUtil.ShowTips("请选择[洗唛模板]");
                cbx_wash.Focus();
                return;
            }

            if (bindingSource_material.Count == 0)
            {
                MessageUtil.ShowTips("[产品成份明细]不能为空!");
                return;
            }


            if (BLLFactory<BLLProductInfo>.Instance.CheckProductDataIsExist(txb_huohao.Text))
            {
                MessageUtil.ShowTips("记录已存在无法保存");
                return;
            }

            if (checkBox.Checked)
            {
                if (txb_fill.Text == string.Empty)
                {
                    MessageUtil.ShowTips("请输入[填充成份内容]");
                    return;
                }
            }

            BEProductDataInfo info = new BEProductDataInfo();

            info.PartName_Id = Convert.ToInt32(cbx_partname.SelectedValue);
            info.HuoHao = txb_huohao.Text;
            info.SafeData_Id = Convert.ToInt32(cbx_safedata.SelectedValue);
            info.StandardData_Id = Convert.ToInt32(cbx_standard.SelectedValue);
            if (txb_price.Text == string.Empty)
            {
                info.Price = 0;
            }
            else
            {
                info.Price = Convert.ToDecimal(txb_price.Text);
            }
            info.MadePlace_Id = Convert.ToInt32(cbx_madeplace.SelectedValue);
            info.Dengji_Id = Convert.ToInt32(cbx_dengji.SelectedValue);
            info.Tag_Id = BLLFactory<BLLProductInfo>.Instance.GetTagTemplateId(tb_tag.Text);
            info.Wash_Id = Convert.ToInt32(cbx_wash.SelectedValue);
            info.Memo = txb_memo.Text;
            if (chb_wash.Checked)
                info.Pwash = 1;
            else
                info.Pwash = 0;


            if (BLLFactory<BLLProductInfo>.Instance.AddProductInfo(info))
            {
                int product_id = BLLFactory<BLLProductInfo>.Instance.GetProductId(txb_huohao.Text);

                for (int index = 0; index < dgv_material.RowCount; index++)
                {
                    string str = dgv_material.Rows[index].Cells["type"].Value.ToString();
                    BLLFactory<BLLProductInfo>.Instance.AddMaterialInfo(product_id, str, index);
                }

                if (checkBox.Checked)
                {
                    for (int index = 0; index < dgv_fill.RowCount; index++)
                    {
                        string str_size_name = dgv_fill.Rows[index].Cells["size_name"].Value.ToString();
                        string str_fill = dgv_fill.Rows[index].Cells["info"].Value.ToString();

                        BLLFactory<BLLProductInfo>.Instance.AddMaterialFillInfo(product_id, str_size_name, txb_fill.Text, str_fill);
                    }
                }

                MessageUtil.ShowTips("保存成功");

                ClearData();
                m_iSaved = true;
                txb_huohao.Focus();
            }
            else
            {
                MessageUtil.ShowTips("当前编辑的数据可能已被修改,无法保存!");
            }
        }
        /// <summary>
        /// 清除输入的数据
        /// </summary>
        private void ClearData()
        {

            txb_huohao.Text = string.Empty;
            txb_huohao.Tag = string.Empty;

            cbx_dengji.Text = string.Empty;
            cbx_dengji.SelectedValue = 0;

            cbx_madeplace.Text = string.Empty;
            cbx_madeplace.SelectedValue = 0;

            cbx_partname.Text = string.Empty;
            cbx_partname.SelectedValue = 0;

            cbx_safedata.Text = string.Empty;
            cbx_safedata.SelectedValue = 0;

            cbx_standard.Text = string.Empty;
            cbx_standard.SelectedValue = 0;

            cbx_wash.Text = string.Empty;
            cbx_wash.SelectedValue = 0;

            txb_price.Text = string.Empty;
            tb_tag.Text = string.Empty;
            txb_memo.Text = string.Empty;
            dgv_material.Rows.Clear();
            checkBox.Checked = false;
            txb_fill.Text = string.Empty;
            dgv_fill.Rows.Clear();
            txb_fill.Enabled = false;
            dgv_fill.Enabled = false;
            chb_wash.Checked = false;
        }

        private void tsb_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProductAddEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (m_mode == Mode.Edit) return;
            if (txb_huohao.Text != string.Empty)
            {
                if (this.m_iSaved == false)
                {
                    if (MessageUtil.ShowYesNoAndTips("数据未保存,是否先保存数据?") == System.Windows.Forms.DialogResult.No)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void txb_huohao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txb_huohao.Text.Trim() == string.Empty)
                    return;

                if (BLLFactory<BLLProductInfo>.Instance.CheckProductDataIsExist(txb_huohao.Text))
                {
                    MessageUtil.ShowTips("找到存在的记录,自动进入编辑模式!");
                    //找到记录，自动转到编辑模式！
                    m_mode = Mode.Edit;
                    txb_huohao.ReadOnly = true;

                    BEProductDataReadProduct info = BLLFactory<BLLProductInfo>.Instance.ReadProductData(txb_huohao.Text);

                    cbx_partname.SelectedValue = info.PartName_Id;
                    cbx_dengji.SelectedValue = info.Dengji_Id;
                    cbx_madeplace.SelectedValue = info.MadePlace_Id;
                    txb_price.Text = info.Price.ToString();
                    cbx_safedata.SelectedValue = info.SafeData_Id;
                    cbx_standard.SelectedValue = info.StandardData_Id;
                    tb_tag.Text = info.Tag;
                    cbx_wash.SelectedValue = info.Wash_Id;
                    txb_memo.Text = info.Memo;
                    txb_huohao.Tag = info.LasTamp;

                    if (info.Pwash == 0)
                        chb_wash.Checked = false;
                    else
                        chb_wash.Checked = true;

                    bindingSource_material.DataSource = BLLFactory<BLLProductInfo>.Instance.GetMaterialDataList(info.Id);

                }
            }
        }

        private void chb_wash_CheckedChanged(object sender, EventArgs e)
        {
            Material_CountToTagName();
        }

        private void cbx_partname_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgv_fill.Rows.Clear();

            List<string> list = BLLFactory<BLLProductInfo>.Instance.GetFillSizeList(Convert.ToInt32(cbx_partname.SelectedValue));

            IEnumerator<string> ator = list.GetEnumerator();

            while (ator.MoveNext())
            {
                int index = dgv_fill.Rows.Add();

                dgv_fill.Rows[index].Cells["size_name"].Value = ator.Current.ToString();
            }
        }
    }
}
