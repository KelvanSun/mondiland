using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mondiland.BLL;

namespace Mondiland.UI
{
    public partial class MainForm : Form
    {
        private int m_user_id = 0;

        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 登陆成功后获得ID
        /// </summary>
        /// <param name="id"></param>
        public void SetUserId(int id)
        {
            m_user_id = id;
        }

        private void menu_base_safe_Click(object sender, EventArgs e)
        {
            SafeDataForm form = new SafeDataForm();
            form.ShowDialog();
        }

        private void menu_base_standard_Click(object sender, EventArgs e)
        {
            StandardDataForm form = new StandardDataForm();
            form.ShowDialog();
        }

        private void menu_base_madeplace_Click(object sender, EventArgs e)
        {
            MadePlaceForm form = new MadePlaceForm();
            form.ShowDialog();
        }


        private void menu_product_add_Click(object sender, EventArgs e)
        {
            ProductAddEditForm form = new ProductAddEditForm();
            form.ShowDialog();
        }

        private void menu_print_Click(object sender, EventArgs e)
        {
            PrintForm form = new PrintForm();
            form.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm(this);
            this.Visible = false;
            form.ShowDialog();
            
            if(m_user_id == 0)
            {
                Close();

                return;
            }

            statusStrip.Items["username"].Text = string.Format("用户名:{0}", BLLFactory<BLLLogin>.Instance.GetUserName(m_user_id));
            statusStrip.Items["groupname"].Text = string.Format("用户组:{0}", BLLFactory<BLLLogin>.Instance.GetGroupName(m_user_id));

            this.Visible = true;
        }

    }
}
