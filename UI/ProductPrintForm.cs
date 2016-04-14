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
using System.Text.RegularExpressions;

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
                case ProductObject.PrintType.TagCODE93:
                    this.Text = string.Format("{0}Code93吊牌", this.Text);
                    break;
                case ProductObject.PrintType.TagEAN13:
                    this.Text = string.Format("{0}EAN13吊牌", this.Text);
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

            string str_type = string.Empty;

            switch(this.m_type)
            {
                case ProductObject.PrintType.TagCODE93:
                    str_type = "Code93吊牌";
                    break;
                case ProductObject.PrintType.TagEAN13:
                    str_type = "EAN13吊牌";
                    break;
                case ProductObject.PrintType.Wash:
                    str_type = "洗水唛";
                    break;
            }


            LogInfoManager.LogWrite(AuthorManager.LoginUser.Id,
                string.Format("打印货号为[{0}] {1} 码的{2} {3}张", m_product.HuoHao, cbx_select.Text, str_type, numericUpDown.Value));              
          
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
            //m_product.PrintDh(m_engine);

            string line = string.Empty;
            int iSelect = 0;


            System.IO.StreamReader file =
                new System.IO.StreamReader("c:\\11.txt", System.Text.Encoding.Default);

            while ((line = file.ReadLine()) != null)
            {
                string[] sArray = Regex.Split(line, "\t", RegexOptions.IgnoreCase);


                ProductObject product = new ProductObject(sArray[0]);

                foreach (var size in product.SizeDataListInfo)
                {
                    if (size.SizeName == sArray[1])
                    {
                        iSelect = size.Id;
                        break;
                    }
                }


                product.Print(m_engine,
                                this.cbo_prints.SelectedItem.ToString(),
                                this.m_type,
                                iSelect,
                                int.Parse(sArray[2]));

                if (cb_blank.Checked == true)
                {
                    product.PrintBlank(m_engine, this.cbo_prints.SelectedItem.ToString());
                }

            }


            file.Close();

        }
    }
}
