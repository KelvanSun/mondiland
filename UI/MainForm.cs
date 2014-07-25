using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mondiland.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

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
            //if(ConfigurationManager.AppSettings["Template"] == string.Empty)
            //{
            //    if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //        AppSettingsSection app = config.AppSettings;
            //        app.Settings["Template"].Value = folderBrowserDialog.SelectedPath;
            //        config.Save();
            //    }
            //    else
            //    {
            //        MessageBox.Show("打印模板文件目录必需选择!");
            //        Close();
            //    }
            //}
        }

    }
}
