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
        private string m_form_name = string.Empty;
        private MainForm mf = null;
        public UCListViewItem(MainForm form)
        {
            this.mf = form;
            InitializeComponent();
        }

        public string ItemFormName
        {
            get { return m_form_name; }
            set { m_form_name = value; }
        }

        public string ItemCaption
        {
            get { return label_caption.Text; }
            set { label_caption.Text = value; }
        }

        public string ItemMemo
        {
            get { return label_memo.Text; }
            set { label_memo.Text = value; }
        }

        public Image ItemImage
        {
            set { pbx_main.Image = value; }
        }

        private void label_caption_Click(object sender, EventArgs e)
        {
            this.mf.OpenWindows(this.ItemFormName);
        }
    }
}
