using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mondiland.UI
{
    public partial class SupplierManagerForm : Mondiland.UI.BaseForm,IMergeToolStrip
    {
        public SupplierManagerForm()
        {
            InitializeComponent();
            this.toolStrip.Visible = false;
        }

        public ToolStrip MergeToolStrip
        {
            get { return this.toolStrip; }
        }
    }
}
