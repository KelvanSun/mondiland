using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mondiland.UCControl
{
    public class UCDataGridView : System.Windows.Forms.DataGridView
    {
        public UCDataGridView()
        {
            this.RowHeadersWidth = 20;
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.AllowUserToResizeRows = false;
            this.RowHeadersWidth = 20;
            this.AutoGenerateColumns = false;
        }
    }
}
