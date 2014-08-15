using System;
using System.IO;
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
using Mondiland.Global;

using Seagull.BarTender.Print;

namespace Mondiland.UI
{
    public partial class PrintForm : Form
    {
        private ProductObject product = null;
        
        private static Engine m_engine = new Engine(true);
        public PrintForm()
        {
            InitializeComponent();
        }

        private void mtb_huohao_Click(object sender, EventArgs e)
        {
            txb_huohao.SelectionStart = txb_huohao.SelectionLength;
        }

        private void SelectProduct()
        {
            if (txb_huohao.Text.Trim() == string.Empty) return;

            product = new ProductObject(txb_huohao.Text.Trim());
            
            if (product.Id == 0) //没有找到记录
            {
                MessageUtil.ShowTips("货号对应的产品没有找到");


                ProductAddEditForm form = new ProductAddEditForm();
                form.ShowDialog();

                bindingSource.DataSource = product;
                txb_huohao.Text = "";
                txb_huohao.Focus();
            }
            else
            {
                           
                bindingSource.DataSource = product;

                cbx_select.DataSource = product.SizeDataList;
                cbx_select.DisplayMember = "SizeName";
                cbx_select.ValueMember = "Id";
                
                
                numericUpDown.Value = 1;

            }
        }

        private void bt_print_Click(object sender, EventArgs e)
        {
            if (product == null)
            {
                MessageUtil.ShowTips("请先选择产品再打印!");
                return;
            }

            if(product.Id == 0)
            {
                MessageUtil.ShowTips("请先选择产品再打印!");
                return;
            }

            //if (cbx_select.SelectedValue == 0)
            //{
            //    MessageUtil.ShowTips("请选择打印的尺寸");
            //    return;
            //}

            if(rb_tag.Checked)
            {
                if (txb_price.Text == "0.00")
                {
                    MessageUtil.ShowTips("产品价格不能为0,请输入价格!");
                    return;
                }

                product.Print(m_engine, ProductObject.PrintType.Tag, Convert.ToInt32(cbx_select.SelectedValue), Convert.ToInt32(numericUpDown.Value));
            }
            else
            {
                product.Print(m_engine, ProductObject.PrintType.Wash, Convert.ToInt32(cbx_select.SelectedValue), Convert.ToInt32(numericUpDown.Value));
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            LabelFormatDocument format = m_engine.Documents.Open("d:\\Template\\tmp.btw");
            
            
            StreamReader sr = new StreamReader("C:\\data.txt", Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] aa = System.Text.RegularExpressions.Regex.Split(line, @"\s+");

                format.SubStrings.SetSubString("HuoHao", aa[0]);
                format.SubStrings.SetSubString("ChengFeng", string.Format("面料:{0}", aa[1]));
                format.SubStrings.SetSubString("JiaGe", string.Format("￥{0:F2}", Convert.ToDecimal(aa[2])));

                format.PrintSetup.IdenticalCopiesOfLabel = 1;

                format.Print();

                MessageBox.Show("继续");
            }
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
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
    }
}
