using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mondiland.BLL;
using Mondiland.Global;

namespace Mondiland.UI
{
    public partial class SupplierAEForm : Form
    {
        public SupplierAEForm()
        {
            InitializeComponent();
        }

        private void SupplierAEForm_Load(object sender, EventArgs e)
        {
            this.cbx_class.DataSource = BLLFactory<BLLSupplierInfo>.Instance.GetSupplierClassList();
            this.cbx_class.DisplayMember = "Name";
            this.cbx_class.ValueMember = "Id";
            this.cbx_class.Text = string.Empty;
            this.cbx_class.SelectedValue = 0;
        }
    }
}
