using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mondiland.UI
{
    public partial class UCListViewItem : UserControl
    {
        private MainForm mainform = null; 
        public UCListViewItem(MainForm main)
        {
            mainform = main;
            InitializeComponent();
        }
    }
}
