using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mondiland.BLL;
using Mondiland.BLLEntity;

namespace Mondiland.UI
{
    public partial class SafeDataForm : Form
    {
        private BindingList<BESafeDataInfo> list = null;
        //private int select_id = 0;

        public SafeDataForm()
        {
            InitializeComponent();

            LoadAllInfo();
        }
        private void LoadAllInfo()
        {
            list = BLLFactory<BLLSafeData>.Instance.GetAllInfo();

            this.dataGridView.DataSource = list;
            this.dataGridView.Focus();
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            
        }
    }
}
