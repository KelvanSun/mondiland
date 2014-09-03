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
using Mondiland.Obj;

using Seagull.BarTender.Print;

namespace Mondiland.UI
{
    public partial class PrintForm : Form
    {
        private ProductObject m_product = null;
        private ProductObject.PrintType m_type;
        
        private static Engine m_engine = new Engine(true);

     
        public PrintForm(ProductObject product,ProductObject.PrintType type)
        {
            this.m_product = product;
            this.m_type = type;
            
            InitializeComponent();

            if(this.m_type == ProductObject.PrintType.Wash)
                this.Text = string.Format("{0}({1})", this.Text, this.m_product.WashSize);
        }

        private void bt_print_Click(object sender, EventArgs e)
        {
            m_product.Print(m_engine,
                            this.cbo_prints.SelectedItem.ToString(), 
                            this.m_type,
                            Convert.ToInt32(cbx_select.SelectedValue), 
                            Convert.ToInt32(numericUpDown.Value));
          
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
    }
}
