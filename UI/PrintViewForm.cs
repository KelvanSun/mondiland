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
    public partial class PrintViewForm : Form
    {
        public PrintViewForm()
        {
            InitializeComponent();
        }

        private void PrintViewForm_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();
        }
    }
}
