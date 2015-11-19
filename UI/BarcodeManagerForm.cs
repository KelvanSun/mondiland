﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mondiland.Obj;
using Mondiland.Global;

namespace Mondiland.UI
{
    public partial class BarcodeManagerForm : Form
    {
        private ProductObject m_product = null;

        public BarcodeManagerForm(ProductObject product)
        {
            this.m_product = product;
            
            InitializeComponent();

        }

        private void BarcodeManagerForm_Load(object sender, EventArgs e)
        {
            int insert_index = 0;
            string ean13 = string.Empty;

            foreach(var obj in this.m_product.SizeDataListInfo)
            {
                insert_index = this.ucDataGridView.Rows.Add();
                this.ucDataGridView.Rows[insert_index].Cells["SizeName"].Value = obj.SizeName;

                foreach(var obj2 in this.m_product.EAN13DataListInfo)
                {
                    if(obj2.SizeName == obj.SizeName)
                    {
                        ean13 = obj2.BarcodeType;
                        break;
                    }
                }

                this.ucDataGridView.Rows[insert_index].Cells["ean13"].Value = ean13;
            }
        }

        private void tsb_save_Click(object sender, EventArgs e)
        {
            string m_sizename = string.Empty;
            string m_ena13 = string.Empty;
            string m_memo = string.Empty;
            
            ucDataGridView.EndEdit();
            
            if (ucDataGridView.Rows.Count == 0) return;

            int index = 0;

            for(index=0;index < ucDataGridView.Rows.Count;index++)
            {
                m_sizename = ucDataGridView.Rows[index].Cells["SizeName"].Value.ToString();
                m_ena13 = ucDataGridView.Rows[index].Cells["ean13"].Value.ToString();
                
                if(ucDataGridView.Rows[index].Cells["Memo"].Value != null)
                    m_memo = ucDataGridView.Rows[index].Cells["Memo"].Value.ToString();

                this.m_product.UpdateEAN13Info(m_sizename, m_ena13, m_memo);
            }

            this.m_product.SaveEAN13Info();

            MessageUtil.ShowTips("保存成功!");

            Close();
        }

        private void ucDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) return;

            Clipboard.SetText(ucDataGridView.CurrentRow.Cells["ean13"].Value.ToString());
        }
    }
}
