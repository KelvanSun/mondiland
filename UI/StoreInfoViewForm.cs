using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mondiland.Obj;

namespace Mondiland.UI
{
    public partial class StoreInfoViewForm : Form
    {
        private StoreObject m_store = null;
        private Font bold_font = new Font("宋体", 12, FontStyle.Bold);
        private Font regular_font = new Font("宁体", 12, FontStyle.Regular);

        private int checkPrint = 0;
        private int iStart = 0;

        public StoreInfoViewForm(StoreObject obj)
        {
            this.m_store = obj;

            InitializeComponent();
        }

        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            checkPrint = 0;
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            checkPrint = richTextBox.Print(checkPrint, richTextBox.TextLength, e);

            // Check for more pages
            if (checkPrint < richTextBox.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void tsb_print_Click(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDocument.Print();
        }

        private void StoreInfoViewForm_Load(object sender, EventArgs e)
        {
            string str_title = m_store.Name + "\n\n";

            richTextBox.AppendText(str_title);
            richTextBox.Select(0, str_title.Length);    //选中文章标题  
            richTextBox.SelectionFont = new Font("宋体", 14, FontStyle.Bold);  //设置标题格式，titleFont是对应于文章标题的Font对象  
            richTextBox.SelectionAlignment = HorizontalAlignment.Center;
            iStart = richTextBox.Text.Length;

            //AppendText("店名:", bold_font);
            //AppendText(m_store.Name + "\n", regular_font);

            AppendText("地址:", bold_font);
            AppendText(m_store.Address + "\n", regular_font);

            if(!string.IsNullOrEmpty(m_store.Phone))
            {
                AppendText("店厅电话:", bold_font);
                AppendText(m_store.Phone + "\n", regular_font);
            }

            if (!string.IsNullOrEmpty(m_store.Manager))
            {
                AppendText("店长:", bold_font);
                AppendText(m_store.Manager + "\n", regular_font);
            }

            if (!string.IsNullOrEmpty(m_store.ManagerPhone))
            {
                AppendText("店长手机:", bold_font);
                AppendText(m_store.ManagerPhone + "\n", regular_font);
            }

            if (!string.IsNullOrEmpty(m_store.Memo))
            {
                AppendText("备注信息:", bold_font);
                AppendText(m_store.Memo + "\n", regular_font);
            }

        }

        private void AppendText(string str_text, Font font)
        {
            richTextBox.AppendText(str_text);
            richTextBox.Select(iStart, str_text.Length);
            richTextBox.SelectionFont = font;
            iStart = richTextBox.Text.Length;
        }
    }
}
