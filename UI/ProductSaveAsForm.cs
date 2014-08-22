﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Mondiland.BLL;
using Mondiland.BLLEntity;
using Mondiland.Global;

namespace Mondiland.UI
{
    public partial class ProductSaveAsForm : Form
    {
        private ProductManagerForm form = null;
        public ProductSaveAsForm(ProductManagerForm form)
        {
            this.form = form;

            InitializeComponent();
        }

        private void ProductSaveAsForm_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();

            IEnumerator<string> ator = BLLFactory<BLLProductInfo>.Instance.GetHuoHaoList().GetEnumerator();

            while (ator.MoveNext())
            {
                acsc.Add(ator.Current.ToString());
            }

            txb_huohao.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txb_huohao.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txb_huohao.AutoCompleteCustomSource = acsc;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (this.txb_huohao.Text.Trim() == string.Empty)
            {
                MessageUtil.ShowWarning("请输入[产品货号]信息!");
                txb_huohao.Focus();

                return;
            }

            if (BLLFactory<BLLProductInfo>.Instance.CheckProductHuoHaoIsExist(this.txb_huohao.Text.Trim()))
            {
                MessageUtil.ShowWarning("[产品货号]已经存在!");
                txb_huohao.Focus();

                return;
            }

            form.HuohaoSaveAs = this.txb_huohao.Text.Trim();

            Close();
        }
    }
}