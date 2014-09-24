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
                this.bt_del.Visible = false;


                LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("供应商[{0}]的联系人新增操作!", supplierD.SupplierName));
            }
            else
            {
                this.Text = "编辑";


                LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("供应商[{0}]的联系人[{1}]信息修改操作!", supplierD.SupplierName, supplierD.Name));
            }

            this.bindingSource.DataSource = this.supplierD;
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            SaveResult result = supplierD.Save();

            if (result.Code == CodeType.Error)
            {
                LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("供应商[{0}]的联系人[{1}]信息保存失败!", supplierD.SupplierName, supplierD.Name));
                
                MessageUtil.ShowError(result.Message);
                return;
            }

            if (result.Code == CodeType.Ok)
            {
                LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("供应商[{0}]的联系人[{1}]信息保存成功!", supplierD.SupplierName, supplierD.Name));
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
                    LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("供应商[{0}]的联系人[{1}]信息删除失败!", supplierD.SupplierName, supplierD.Name));
                    
                    MessageUtil.ShowError(result.Message);
                    return;
                }

                if (result.Code == CodeType.Ok)
                {
                    LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("供应商[{0}]的联系人[{1}]信息删除成功!", supplierD.SupplierName, supplierD.Name));

                    MessageUtil.ShowTips(result.Message);

                    Close();
                }
            }   
        }
    }
}
