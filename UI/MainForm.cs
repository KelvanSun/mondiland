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
using Mondiland.Obj;
using WeifenLuo.WinFormsUI.Docking;
using Mondiland.Global;


namespace Mondiland.UI
{
    public partial class MainForm : Form
    {
        public PermissionObject.User UserObj = null;

        public int UserId = 1;

        private MainToolForm m_mainToolForm = null;
        private DefaultForm m_defaultForm = null;

        public MainForm()
        {
            InitializeComponent();

            m_defaultForm = new DefaultForm();
            m_mainToolForm = new MainToolForm();
            
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm(this);
            this.Visible = false;
            form.ShowDialog();
            
            if(this.UserObj == null)
            {
                Close();

                return;
            }

            statusStrip.Items["username"].Text = string.Format("用户名:{0}", this.UserObj.Name);
            statusStrip.Items["groupname"].Text = string.Format("用户组:{0}", this.UserObj.GroupName);

            try
            {
                statusStrip.Items["version"].Text = string.Format("系统版本:{0}", 
                                     ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString());
            }
            catch 
            {
                statusStrip.Items["version"].Text = "系统版本:(未知)";
            }

            m_mainToolForm.LoadMenuInfo();
            m_defaultForm.LoadFavoritesMenu();

            m_mainToolForm.Show(this.dockPanel, DockState.DockLeft);
            m_defaultForm.Show(this.dockPanel);
            this.Visible = true;
        }

        /// <summary>
        /// 打开指定窗口
        /// </summary>
        /// <param name="name">窗口名称</param>
        public void OpenWindows(string form_name)
        {
            try
            {
                foreach (Form childrenForm in this.MdiChildren)
                {
                    if (childrenForm.Name == form_name)
                    {
                        childrenForm.Activate();
                        return;
                    }
                }
                                
                BaseForm form = (BaseForm)Activator.CreateInstance(Type.GetType("Mondiland.UI." + form_name));
                form.Show(this.dockPanel);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowError(ex.Message);
            }
        }
    }
}
