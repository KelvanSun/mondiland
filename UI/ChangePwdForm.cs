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
    public partial class ChangePwdForm : Form
    {
        public ChangePwdForm()
        {
            InitializeComponent();
        }

        private void txb_old_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txb_new.Focus();
            }
        }

        private void txb_new_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txb_agen.Focus();
            }
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if(txb_old.Text.Trim() == string.Empty)
            {
                MessageUtil.ShowWarning("请输入[原先密码]");
                txb_old.Focus();
                return;
            }

            if (txb_new.Text.Trim() == string.Empty)
            {
                MessageUtil.ShowWarning("请输入[新的密码]");
                txb_new.Focus();
                return;
            }

            if (txb_agen.Text.Trim() == string.Empty)
            {
                MessageUtil.ShowWarning("请输入[确认密码]");
                txb_agen.Focus();
                return;
            }

            if(!txb_new.Text.Equals(txb_agen.Text))
            {
                MessageUtil.ShowWarning("[新的密码]与[确认密码]不同,请重新输入");
                
                return;
            }

            SaveResult result = AuthorManager.LoginUser.ChangePwd(txb_old.Text, txb_new.Text);

            if(result.Code == CodeType.Error)
            {
                MessageUtil.ShowWarning(result.Message);
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
