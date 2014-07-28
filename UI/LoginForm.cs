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
    public partial class LoginForm : Form
    {
        private MainForm m_mainForm = null;
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

            if (!BLLFactory<BLLLogin>.Instance.Authentication(cbx_username.Text, tb_pwd.Text))
            {
                MessageUtil.ShowWarning("用户验证失败");
                tb_pwd.Focus();
                return;
            }

            m_mainForm.SetUserId(BLLFactory<BLLLogin>.Instance.GetUserID(cbx_username.Text));
            this.Close();


        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            List<string> list = BLLFactory<BLLLogin>.Instance.GetUserList();

            IEnumerator<string> ator = list.GetEnumerator();

            while (ator.MoveNext())
            {
                this.cbx_username.Items.Add(ator.Current.ToString());
            }

            this.cbx_username.SelectedIndex = 0;
           
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
