using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mondiland.Global;


namespace Mondiland.UI
{
    public partial class SupplierAEForm : Form
    {
        public SupplierAEForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageUtil.ShowTips(ChineseToSpell.GetChineseSpell("S中华人民共和国k"));
        }
    }
}
