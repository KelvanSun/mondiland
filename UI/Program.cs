using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Mondiland.Obj;

namespace Mondiland.UI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        public static PermissionObject permission = new PermissionObject();
        public static MainForm main_form = null;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm login = new LoginForm();
            login.ShowDialog();

            if (login.DialogResult == DialogResult.OK)
            {
                main_form = new MainForm();

                Application.Run(main_form);
            }
        }
    }
}
