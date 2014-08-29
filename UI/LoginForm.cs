using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mondiland.BLL;
using Mondiland.Obj;
using Mondiland.Global;


namespace Mondiland.UI
{
    public partial class LoginForm : Form
    {
        private MainForm m_mainForm = null;
        private PermissionObject m_permission = new PermissionObject();

        public LoginForm(MainForm mainForm)
        {
            InitializeComponent();

            m_mainForm = mainForm;
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            if (tb_pwd.Text.Trim() == string.Empty)
            {
                MessageUtil.ShowTips("请输入密码!");
                tb_pwd.Focus();

                return;
            }

            PermissionObject.User user = m_permission.UserList[Convert.ToInt32(cbx_usrename.SelectedValue)];

            if(!user.Authentication(tb_pwd.Text.Trim()))
            {
                MessageUtil.ShowWarning("用户验证失败");
                tb_pwd.Focus();
                return;
            }

            m_mainForm.UserObj = user;
            this.Close();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.cbx_usrename.DataSource = this.m_permission.GetLoginUserList();
            this.cbx_usrename.DisplayMember = "UserName";
            this.cbx_usrename.ValueMember = "Index";
      
           
           
        }

        private void tb_pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) bt_login_Click(sender, e);
        }

        private void cbx_username_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_pwd.Text = string.Empty;
            tb_pwd.Focus();
    
        }

    }
}
