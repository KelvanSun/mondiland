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
    public partial class SupplierDAEForm : Form
    {
        private SupplierObject.SupplierDObject supplierD = null;
        public SupplierDAEForm(SupplierObject.SupplierDObject contract)
        {
            this.supplierD = contract;
            
            InitializeComponent();
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SupplierDAEForm_Load(object sender, EventArgs e)
        {
            if (supplierD.Id == 0)
            {
                this.Text = "新增";
            }
            else
            {
                this.Text = "编辑";
            }

            this.bindingSource.DataSource = this.supplierD;
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            SaveResult result = supplierD.Save();

            if (result.Code == CodeType.Error)
            {
                MessageUtil.ShowError(result.Message);
                return;
            }

            if (result.Code == CodeType.Ok)
            {
                MessageUtil.ShowTips(result.Message);

                Close();
            }
        }

        private void bt_del_Click(object sender, EventArgs e)
        {
            if (MessageUtil.ShowYesNoAndTips("确定删除吗？") == System.Windows.Forms.DialogResult.Yes)
            {
                SaveResult result = supplierD.Del();

                if (result.Code == CodeType.Error)
                {
                    MessageUtil.ShowError(result.Message);
                    return;
                }

                if (result.Code == CodeType.Ok)
                {
                    MessageUtil.ShowTips(result.Message);

                    Close();
                }
            }   
        }
    }
}
