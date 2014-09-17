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
    public partial class LogCustomQueryForm : Form
    {
        public SysLogManagerForm.CustomQuery query = null;
        
        public LogCustomQueryForm(SysLogManagerForm.CustomQuery obj)
        {
            this.query = obj;
            
            InitializeComponent();
        }

        private void bt_query_Click(object sender, EventArgs e)
        {
            if(dtp_begin.Value.Date > dtp_end.Value.Date)
            {
                MessageUtil.ShowTips("结束日期比开始日期早!");

                return;
            }

            query.dt_begin = dtp_begin.Value.Date;
            query.dt_end = dtp_end.Value.Date;
            query.str_username = txb_username.Text.Trim();
            query.str_log = txb_log.Text.Trim();

            this.DialogResult = DialogResult.OK;
            Close();

        }
    }
}
