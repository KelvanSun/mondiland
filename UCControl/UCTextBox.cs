using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mondiland.UCControl
{
    public class UCTextBox : TextBox
    {
        protected override void OnLeave(EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 255, 255);

            base.OnLeave(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 255, 255);
            base.OnLeave(e);
        }
    }
}
