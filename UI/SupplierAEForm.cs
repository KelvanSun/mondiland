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
        private SupplierObject supplier = null;

        public SupplierAEForm(SupplierObject ob)
        {
            supplier = ob;

            InitializeComponent();
        }

        private void SupplierAEForm_Load(object sender, EventArgs e)
        {
            this.cbx_class.DataSource = BLLFactory<BLLSupplierInfo>.Instance.GetSupplierClassList();
            this.cbx_class.DisplayMember = "Name";
            this.cbx_class.ValueMember = "Id";
            this.cbx_class.Text = string.Empty;

            this.cbx_class.SelectedValue = supplier.Class_Id;
            this.txb_name.Text = supplier.Name;
            this.txb_intact_name.Text = supplier.Intact_Name;
            this.txb_phone.Text = supplier.Phone;
            this.txb_fax.Text = supplier.Fax;
            this.txb_bank_name.Text = supplier.Bank_Name;
            this.txb_account.Text = supplier.Account;
            this.txb_address.Text = supplier.Address;
            this.txb_memo.Text = supplier.Memo; 

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

        private void txb_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txb_intact_name.Focus();
        }

        private void txb_intact_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txb_phone.Focus();
        }

        private void txb_phone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txb_fax.Focus();
        }

        private void txb_fax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txb_bank_name.Focus();
        }

        private void txb_bank_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txb_account.Focus();
        }

        private void txb_account_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txb_address.Focus();
        }

        private void txb_address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txb_memo.Focus();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            SupplierObject.SaveResult result = supplier.Save();

            if(result.Code == SupplierObject.CodeType.Error)
            {
                MessageUtil.ShowError(result.Message);
                return;
            }

            if(result.Code == SupplierObject.CodeType.Ok)
            {
                MessageUtil.ShowTips(result.Message);

                Close();
            }
        }

        private void txb_name_TextChanged(object sender, EventArgs e)
        {
            supplier.Name = this.txb_name.Text;
        }

        private void txb_intact_name_TextChanged(object sender, EventArgs e)
        {
            supplier.Intact_Name = this.txb_intact_name.Text;
        }

        private void txb_phone_TextChanged(object sender, EventArgs e)
        {
            supplier.Phone = this.txb_phone.Text;
        }

        private void txb_fax_TextChanged(object sender, EventArgs e)
        {
            supplier.Fax = this.txb_fax.Text;
        }

        private void txb_bank_name_TextChanged(object sender, EventArgs e)
        {
            supplier.Bank_Name = this.txb_bank_name.Text;
        }

        private void txb_account_TextChanged(object sender, EventArgs e)
        {
            supplier.Account = this.txb_account.Text;
        }

        private void txb_address_TextChanged(object sender, EventArgs e)
        {
            supplier.Address = this.txb_address.Text;
        }

        private void txb_memo_TextChanged(object sender, EventArgs e)
        {
            supplier.Memo = this.txb_memo.Text;
        }
    }
}
