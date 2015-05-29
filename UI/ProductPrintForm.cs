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

using Mondiland.Obj;

using Seagull.BarTender.Print;

namespace Mondiland.UI
{
    public partial class ProductPrintForm : Form
    {
        private ProductObject m_product = null;
        private ProductObject.PrintType m_type;
        
        private static Engine m_engine = new Engine(true);

     
        public ProductPrintForm(ProductObject product,ProductObject.PrintType type)
        {
            this.m_product = product;
            this.m_type = type;
            
            InitializeComponent();

            switch(this.m_type)
            {
                case ProductObject.PrintType.Tag:
                    this.Text = string.Format("{0}自编吊牌", this.Text);
                    break;
                case ProductObject.PrintType.Tag2:
                    this.Text = string.Format("{0}国际吊牌", this.Text);
                    break;
                case ProductObject.PrintType.Wash:
                    this.Text = string.Format("{0}洗唛({1})", this.Text, this.m_product.WashSize);
                    break;
            }
                
        }

        private void bt_print_Click(object sender, EventArgs e)
        {
            m_product.Print(m_engine,
                            this.cbo_prints.SelectedItem.ToString(), 
                            this.m_type,
                            Convert.ToInt32(cbx_select.SelectedValue), 
                            Convert.ToInt32(numericUpDown.Value));

            LogInfoManager.LogWrite(AuthorManager.LoginUser.Id,
                string.Format("打印货号为[{0}] {1} 码的{2} {3}张", m_product.HuoHao, cbx_select.Text, this.m_type == ProductObject.PrintType.Tag ? "吊牌" : "洗水唛", numericUpDown.Value));              
          
        }
        private void PrintForm_Load(object sender, EventArgs e)
        {
            Printers printers = new Printers();
            foreach (Printer printer in printers)
            {
                this.cbo_prints.Items.Add(printer.PrinterName);
            }

            cbo_prints.SelectedItem = printers.Default.PrinterName;

            this.cbx_select.DataSource = this.m_product.SizeDataListInfo;
            this.cbx_select.DisplayMember = "SizeName";
            this.cbx_select.ValueMember = "Id";
        }

        private void cbx_select_DropDownClosed(object sender, EventArgs e)
        {
            numericUpDown.Focus();
            numericUpDown.Select(0, numericUpDown.Value.ToString().Length);
        }

        private void numericUpDown_Enter(object sender, EventArgs e)
        {
            numericUpDown.Select(0, numericUpDown.Value.ToString().Length);
        }

        private void bt_print_dh_Click(object sender, EventArgs e)
        {
            m_product.PrintDh(m_engine);
        }
    }
}
