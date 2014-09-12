using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mondiland.Obj;
using Mondiland.Global;


namespace Mondiland.UI
{
    public partial class SupplierAEForm : Form
    {
        private SupplierObject supplier = null;

        public SupplierAEForm(SupplierObject ob)
        {
            supplier = ob;

            InitializeComponent();

            this.bindingSource.DataSource = supplier;

            this.cbx_class.DataSource = SupplierClassManager.SupplierClassList;
            this.cbx_class.DisplayMember = "Name";
            this.cbx_class.ValueMember = "Id";
            this.cbx_class.SelectedValue = 0;
            this.cbx_class.Text = string.Empty;
          
        }

        private void SupplierAEForm_Load(object sender, EventArgs e)
        {
            if(supplier.Id == 0)
            {
                this.Text = "新增";
            }
            else
            {
                this.Text = "编辑";
            }

            this.cbx_class.SelectedValue = supplier.Class_Id;

        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbx_class_DropDownClosed(object sender, EventArgs e)
        {
            supplier.Class_Id = Convert.ToInt32(this.cbx_class.SelectedValue);
            txb_name.Focus();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            SaveResult result = supplier.Save();

            if(result.Code == CodeType.Error)
            {
                MessageUtil.ShowError(result.Message);
                return;
            }

            if(result.Code == CodeType.Ok)
            {
                MessageUtil.ShowTips(result.Message);

                Close();
            }
        }
    }
}
