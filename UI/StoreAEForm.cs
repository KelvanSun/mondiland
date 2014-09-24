using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mondiland.Global;
using Mondiland.Obj;

namespace Mondiland.UI
{
    public partial class StoreAEForm : Form
    {
        private StoreObject store = null;

        public StoreAEForm(StoreObject obj)
        {
            this.store = obj;

            InitializeComponent();

            this.bindingSource.DataSource = this.store;
        }

        private void StoreAEForm_Load(object sender, EventArgs e)
        {
            if (this.store.Id == 0)
            {
                this.Text = "新增";

                this.bt_del.Visible = false;

                LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("店铺新增操作!"));
            }
            else
            {
                this.Text = "编辑";
                LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("店铺[{0}]编辑操作!", this.store.Name));
            }
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            SaveResult result = store.Save();

            if (result.Code == CodeType.Error)
            {
                LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("店铺[{0}]信息保存失败!", store.Name));

                MessageUtil.ShowError(result.Message);
                return;
            }

            if (result.Code == CodeType.Ok)
            {
                LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("店铺[{0}]信息保存成功!", store.Name));
                MessageUtil.ShowTips(result.Message);

                Close();
            }
        }

        private void bt_del_Click(object sender, EventArgs e)
        {
            if (MessageUtil.ShowYesNoAndTips("确定删除吗？") == System.Windows.Forms.DialogResult.Yes)
            {
                SaveResult result = store.Del();

                if (result.Code == CodeType.Error)
                {
                    LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("店铺[{0}]信息删除失败!", store.Name));

                    MessageUtil.ShowError(result.Message);
                    return;
                }

                if (result.Code == CodeType.Ok)
                {
                    LogInfoManager.LogWrite(AuthorManager.LoginUser.Id, string.Format("店铺[{0}]信息删除成功!", store.Name));

                    MessageUtil.ShowTips(result.Message);

                    Close();
                }
            }   
        }
    }
}
