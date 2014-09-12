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
    public partial class SupplierAllViewForm : Form
    {
        private SupplierObject m_supplier = null;
        private Font bold_font = new Font("宋体", 12, FontStyle.Bold);
        private Font regular_font = new Font("宁体", 12, FontStyle.Regular);

        private int checkPrint = 0;
        private int iStart = 0;

        public SupplierAllViewForm(SupplierObject obj)
        {
            this.m_supplier = obj;

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

        private void SupplierAllViewForm_Load(object sender, EventArgs e)
        {
            string str_title = "供应商详细信息\n\n";

            richTextBox.AppendText(str_title);
            richTextBox.Select(0, str_title.Length);    //选中文章标题  
            richTextBox.SelectionFont = new Font("宋体",14,FontStyle.Bold);  //设置标题格式，titleFont是对应于文章标题的Font对象  
            richTextBox.SelectionAlignment = HorizontalAlignment.Center;
            iStart = richTextBox.Text.Length;

            //单位全称
            AppendText("供应商全称:", bold_font);
            AppendText(m_supplier.Intact_Name + "\n", regular_font);
            

            if(!string.IsNullOrEmpty(m_supplier.Phone))
            {
                AppendText("供应商电话:", bold_font);
                AppendText(m_supplier.Phone + "\n", regular_font);
            }

            if(!string.IsNullOrEmpty(m_supplier.Fax))
            {
                AppendText("供应商传真:", bold_font);
                AppendText(m_supplier.Fax + "\n", regular_font);
            }

            if(!string.IsNullOrEmpty(m_supplier.Bank_Name))
            {
                AppendText("供应商开户行:", bold_font);
                AppendText(m_supplier.Bank_Name + "\n", regular_font);
            }

            if (!string.IsNullOrEmpty(m_supplier.Account))
            {
                AppendText("供应商银行帐号:", bold_font);
                AppendText(m_supplier.Account + "\n", regular_font);
            }

            if (!string.IsNullOrEmpty(m_supplier.Address))
            {
                AppendText("供应商地址:", bold_font);
                AppendText(m_supplier.Address + "\n", regular_font);
            }

            if(m_supplier.SupplierFList.Count > 0)
            {
                AppendText("工厂信息:\n", bold_font);
                
                foreach(var obj in m_supplier.SupplierFList)
                {
                    AppendText("\t工厂地址:", regular_font);
                    AppendText(obj.Address + "\n", regular_font);

                    if (!string.IsNullOrEmpty(obj.Contacts))
                    {
                        AppendText("\t工厂联系人:", regular_font);
                        AppendText(obj.Contacts + "\n", regular_font);
                    }

                    if (!string.IsNullOrEmpty(obj.Tel))
                    {
                        AppendText("\t工厂联系人电话:", regular_font);
                        AppendText(obj.Tel + "\n", regular_font);
                    }

                    if (!string.IsNullOrEmpty(obj.Fax))
                    {
                        AppendText("\t工厂联系人传真:", regular_font);
                        AppendText(obj.Fax + "\n", regular_font);
                    }

                    AppendText("\t--------------------------\n", bold_font);
                }
            }

            if(m_supplier.SupplierDList.Count > 0)
            {
                AppendText("相关联系人:\n", bold_font);

                foreach(var obj in m_supplier.SupplierDList)
                {
                    AppendText("\t名称:", regular_font);
                    AppendText(obj.Name + "\n", regular_font);

                    if(!string.IsNullOrEmpty(obj.Phone))
                    {
                        AppendText("\t电话:", regular_font);
                        AppendText(obj.Phone + "\n", regular_font);
                    }

                    if(!string.IsNullOrEmpty(obj.Fax))
                    {
                        AppendText("\t传真:", regular_font);
                        AppendText(obj.Fax + "\n", regular_font);
                    }

                    if(!string.IsNullOrEmpty(obj.Email))
                    {
                        AppendText("\tEmail:", regular_font);
                        AppendText(obj.Email + "\n", regular_font);
                    }

                    if (!string.IsNullOrEmpty(obj.QQ))
                    {
                        AppendText("\tQQ号:", regular_font);
                        AppendText(obj.QQ + "\n", regular_font);
                    }

                    if(!string.IsNullOrEmpty(obj.Address))
                    {
                        AppendText("\t地址:", regular_font);
                        AppendText(obj.Address + "\n", regular_font);
                    }

                    AppendText("\t--------------------------\n", bold_font);
                }

            }

            if(!string.IsNullOrEmpty(m_supplier.Memo))
            {
                AppendText("供应商备注信息:\n", bold_font);

                AppendText(m_supplier.Memo, regular_font);
            }

            richTextBox.Select(0, 0);

        }

        private void AppendText(string str_text,Font font)
        {
            richTextBox.AppendText(str_text);
            richTextBox.Select(iStart, str_text.Length);
            richTextBox.SelectionFont = font;
            iStart = richTextBox.Text.Length;
        }


    }
}
