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
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm login = new LoginForm();
            login.ShowDialog();

            if (login.DialogResult == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }
        }
    }
}
