using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mondiland.Global;
using Mondiland.Obj;

namespace Mondiland.UI
{
    public partial class StoreAEForm : Form
    {
        private StoreObject store = null;

        public StoreAEForm(StoreObject obj)
        {
            this.store = obj;

            InitializeComponent();

            this.bindingSource.DataSource = this.store;
        }

        private void StoreAEForm_Load(object sender, EventArgs e)
        {
            if (this.store.Id == 0)
            {
                this.Text = "新增";

                LogInfoManager.LogWrite(Program.permission.LoginUser.Id, string.Format("店铺新增操作!"));
            }
            else
            {
                this.Text = "编辑";
                LogInfoManager.LogWrite(Program.permission.LoginUser.Id, string.Format("店铺[{0}]编辑操作!", this.store.Name));
            }
        }
    }
}
