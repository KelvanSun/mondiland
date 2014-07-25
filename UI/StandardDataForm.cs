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
    public partial class StandardDataForm : Form
    {
        private BindingList<BEStandardDataInfo> list = null;
        //private int select_id = 0;
                
        public StandardDataForm()
        {
            InitializeComponent();

            LoadAllInfo();
        }
        private void LoadAllInfo()
        {
            list = BLLFactory<BLLStandardData>.Instance.GetAllInfo();

            this.dataGridView.DataSource = list;
            this.dataGridView.Focus();
        }
    }
}
