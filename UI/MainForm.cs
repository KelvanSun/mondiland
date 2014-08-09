using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Deployment.Application;

using Mondiland.BLL;
using WeifenLuo.WinFormsUI.Docking;

namespace Mondiland.UI
{
    public partial class MainForm : Form
    {
        private int m_user_id = 0;

        private MainToolForm m_mainToolForm = null;
        private DefaultForm m_defaultForm = null;

        public MainForm()
        {
            InitializeComponent();

            m_defaultForm = new DefaultForm();
            m_mainToolForm = new MainToolForm();

            m_mainToolForm.Show(this.dockPanel, DockState.DockLeft);
            m_defaultForm.Show(this.dockPanel);
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

            try
            {
                statusStrip.Items["version"].Text = string.Format("系统版本:{0}", 
                                     ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString());
            }
            catch 
            {
                statusStrip.Items["version"].Text = "系统版本:(未知)";
            }
                  



            this.Visible = true;
        }

    }
}
