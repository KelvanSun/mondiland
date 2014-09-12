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
    public partial class SupplierFAEForm : Form
    {
        private SupplierObject.SupplierFObject supplierF = null;

        public SupplierFAEForm(SupplierObject.SupplierFObject factory)
        {
            this.supplierF = factory;
            
            InitializeComponent();
        }

        private void SupplierFAEForm_Load(object sender, EventArgs e)
        {
            if (supplierF.Id == 0)
            {
                this.Text = "新增";
            }
            else
            {
                this.Text = "编辑";
            }

            this.bindingSource.DataSource = this.supplierF;
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            SaveResult result = supplierF.Save();

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

        private void bt_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_del_Click(object sender, EventArgs e)
        {
            if (MessageUtil.ShowYesNoAndTips("确定删除吗？") == System.Windows.Forms.DialogResult.Yes)
            {
                SaveResult result = supplierF.Del();

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
