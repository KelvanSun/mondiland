using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

using Mondiland.Obj;
using Mondiland.Global;



namespace Mondiland.UI
{
    public partial class LoginForm : Form
    {
       
        public LoginForm()
        {
            InitializeComponent();

        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string GetMacPhysicalAddress()
        {
            string address = string.Empty;
            
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface ni in interfaces)
            {
                if (ni.OperationalStatus == OperationalStatus.Up)
                {
                    if (ni.Name == "本地连接")
                    {
                        address = ni.GetPhysicalAddress().ToString();

                        break;
                    }
                }
            }

            return address;
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            
            if (tb_pwd.Text.Trim() == string.Empty)
            {
                MessageUtil.ShowTips("请输入密码!");
                tb_pwd.Focus();

                return;
            }
            
            int select = Convert.ToInt32(cbx_usrename.SelectedValue);

            if (!AuthorManager.Authentication(select ,tb_pwd.Text.Trim()))
            {
                MessageUtil.ShowWarning("用户验证失败");
                tb_pwd.Focus();

                LogInfoManager.LogWrite(select, string.Format("[{0}]用户验证失败!", cbx_usrename.Text));

                return;
            }

            AuthorManager.RecordLoginUserSelect(select, GetMacPhysicalAddress());

            LogInfoManager.LogWrite(select, string.Format("[{0}]用户登陆成功!", cbx_usrename.Text));

            this.DialogResult = DialogResult.OK;

            this.Close();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.cbx_usrename.DataSource = AuthorManager.LoginUserList;
            this.cbx_usrename.DisplayMember = "UserName";
            this.cbx_usrename.ValueMember = "Id";

            int select = AuthorManager.ReadLoginUserSelect(GetMacPhysicalAddress());

            if (select == 0) return;

            this.cbx_usrename.SelectedValue = select;
           
        }

        private void tb_pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) bt_login_Click(sender, e);
        }

        private void cbx_usrename_DropDownClosed(object sender, EventArgs e)
        {
            tb_pwd.Focus();
        }

    }
}
