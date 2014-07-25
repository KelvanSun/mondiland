using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using Mondiland.BLL;
using Mondiland.BLLEntity;

using Seagull.BarTender.Print;

namespace Mondiland.UI
{
    public partial class PrintForm : Form
    {
        private int m_product_id = 0;
        private static Engine m_engine = new Engine(true);
        public PrintForm()
        {
            InitializeComponent();
            //m_engine = new Engine(true);
        }

        private void mtb_huohao_Click(object sender, EventArgs e)
        {
            txb_huohao.SelectionStart = txb_huohao.SelectionLength;
        }

        private void SelectProduct()
        {
            if (txb_huohao.Text.Trim() == string.Empty) return;

            m_product_id = BLLFactory<BLLProductInfo>.Instance.GetProductId(txb_huohao.Text);

            if (m_product_id == 0) //没有找到记录
            {
                MessageBox.Show("货号对应的产品没有找到");


                ProductAddEditForm form = new ProductAddEditForm();
                form.ShowDialog();

                BEProductDataAllInfo info = new BEProductDataAllInfo();

                bindingSource.DataSource = info;
                txb_huohao.Text = "";
                txb_huohao.Focus();
            }
            else
            {
                cbx_select.Items.Clear();

                BEProductDataAllInfo info = BLLFactory<BLLProductPrint>.Instance.GetProductInfoAll(m_product_id);

                bindingSource.DataSource = info;
                
                List<string> list = BLLFactory<BLLProductPrint>.Instance.GetSizeDataInfo(m_product_id);

                IEnumerator<string> ator = list.GetEnumerator();

                while (ator.MoveNext())
                {
                    cbx_select.Items.Add(ator.Current.ToString());
                }

                numericUpDown.Value = 1;

                lab_daoxiao.Text = BLLFactory<BLLProductPrint>.Instance.GetWashDaXiao(m_product_id);
            }
        }

        private void bt_print_Click(object sender, EventArgs e)
        {
            if (txb_huohao.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入货号");
                return;
            }

            if(m_product_id == 0)
            {
                MessageBox.Show("请重新输入货号");
                return;
            }

            if (cbx_select.Text == string.Empty)
            {
                MessageBox.Show("请选择打印的尺寸");
                return;
            }

            if(rb_tag.Checked)
            {
                if (txb_price.Text == "0.00")
                {
                    MessageBox.Show("产品价格不能为0,请输入价格，按回车保存价格!");
                    txb_price.ReadOnly = false;
                    txb_price.Focus();
                    bt_print.Enabled = false;
                    return;
                }                
                
                PrintTag();
            }
            else
            {
                PrintWash();
            }
        }

        private void PrintWash()
        {
            string str_wash_filename = string.Empty;

            BEProductDataAllInfo info = BLLFactory<BLLProductPrint>.Instance.GetProductInfoAll(m_product_id);


            str_wash_filename = string.Format("{0}\\{1}", ConfigurationManager.AppSettings["Template"],
                BLLFactory<BLLProductPrint>.Instance.GetWashPrintTemplateFileName(m_product_id));

            LabelFormatDocument format = m_engine.Documents.Open(str_wash_filename);

            format.SubStrings.SetSubString("HuoHao", info.HuoHao);
            format.SubStrings.SetSubString("GuiGe", cbx_select.Text.Substring(0, 2));
            format.SubStrings.SetSubString("XingHao", cbx_select.Text.Substring(5, cbx_select.Text.Length - 5));
            format.SubStrings.SetSubString("ChengFeng", BLLFactory<BLLProductPrint>.Instance.GetMaterialData(m_product_id, cbx_select.Text.Substring(0, 2)));

            format.PrintSetup.IdenticalCopiesOfLabel = Convert.ToInt32(numericUpDown.Value);

            format.Print();
        }
        private void PrintTag()
        {
            string str_tag_filename = string.Empty;

            BEProductDataAllInfo info = BLLFactory<BLLProductPrint>.Instance.GetProductInfoAll(m_product_id);

            str_tag_filename = string.Format("{0}\\{1}",ConfigurationManager.AppSettings["Template"], 
                BLLFactory<BLLProductPrint>.Instance.GetTagPrintTemplateFileName(m_product_id));

            LabelFormatDocument format = m_engine.Documents.Open(str_tag_filename);

            format.SubStrings.SetSubString("PinMin", info.PartName);
            format.SubStrings.SetSubString("HuoHao", info.HuoHao);
            format.SubStrings.SetSubString("GuiGe", cbx_select.Text.Substring(0, 2));
            format.SubStrings.SetSubString("XingHao", cbx_select.Text.Substring(5, cbx_select.Text.Length - 5));
            format.SubStrings.SetSubString("SafeData", info.SafeData);
            format.SubStrings.SetSubString("StandardData", info.StandardData);
            //format.SubStrings.SetSubString("JiaGe", string.Format("￥{0:F2}", info.Price));
            format.SubStrings.SetSubString("JiaGe", string.Format("￥{0:F2}", Convert.ToDecimal(txb_price.Text)));
            format.SubStrings.SetSubString("ChanDi", info.MadePlace);
            format.SubStrings.SetSubString("DengJi", info.DengJi);
            format.SubStrings.SetSubString("ChengFeng", BLLFactory<BLLProductPrint>.Instance.GetMaterialData(m_product_id, cbx_select.Text.Substring(0,2)));
            format.SubStrings.SetSubString("TiaoMa", BLLFactory<BLLProductPrint>.Instance.GetBarcode(m_product_id, cbx_select.Text.Substring(0, 2)));

            format.PrintSetup.IdenticalCopiesOfLabel = Convert.ToInt32(numericUpDown.Value);

            format.Print();
        }

        private void bt_select_Click(object sender, EventArgs e)
        {
            SelectProduct();
        }

        private void txb_huohao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectProduct();
            }
        }

        private void cbx_select_DropDownClosed(object sender, EventArgs e)
        {
            numericUpDown.Focus();
            numericUpDown.Select(0, numericUpDown.Value.ToString().Length);
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

        private void txb_price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txb_price.ReadOnly == false)
                {
                    if(MessageBox.Show("是否保存价格","提示",MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        BLLFactory<BLLProductPrint>.Instance.UpdatePrice(m_product_id, Convert.ToDecimal(txb_price.Text));
                    txb_price.ReadOnly = true;
                    bt_print.Enabled = true;
                }
            }
        }

    }
}
