namespace Mondiland.UI
{
    partial class SupplierAEForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierAEForm));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_name = new Mondiland.UCControl.UCTextBox();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbx_class = new Mondiland.UCControl.MultiColumnComboBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_intact_name = new Mondiland.UCControl.UCTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_bank_name = new Mondiland.UCControl.UCTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_account = new Mondiland.UCControl.UCTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_phone = new Mondiland.UCControl.UCTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_fax = new Mondiland.UCControl.UCTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txb_memo = new Mondiland.UCControl.UCTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_close = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txb_address = new Mondiland.UCControl.UCTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "供应商分类";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 10);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "供应商简称";
            // 
            // txb_name
            // 
            this.txb_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Name", true));
            this.txb_name.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.txb_name.Location = new System.Drawing.Point(98, 71);
            this.txb_name.MaxLength = 100;
            this.txb_name.Name = "txb_name";
            this.txb_name.Size = new System.Drawing.Size(172, 21);
            this.txb_name.TabIndex = 0;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Mondiland.Obj.SupplierObject);
            // 
            // cbx_class
            // 
            this.cbx_class.ComboBoxHeight = 14;
            this.cbx_class.DisplayColumnNames = "Name,Memo";
            this.cbx_class.DropDownHeight = 114;
            this.cbx_class.DropDownWidth = 121;
            this.cbx_class.FormattingEnabled = true;
            this.cbx_class.ItemDropDownHeight = 14;
            this.cbx_class.Location = new System.Drawing.Point(98, 18);
            this.cbx_class.Name = "cbx_class";
            this.cbx_class.Size = new System.Drawing.Size(279, 20);
            this.cbx_class.TabIndex = 0;
            this.cbx_class.DropDownClosed += new System.EventHandler(this.cbx_class_DropDownClosed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "供应商全称";
            // 
            // txb_intact_name
            // 
            this.txb_intact_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Intact_Name", true));
            this.txb_intact_name.Location = new System.Drawing.Point(98, 102);
            this.txb_intact_name.MaxLength = 100;
            this.txb_intact_name.Name = "txb_intact_name";
            this.txb_intact_name.Size = new System.Drawing.Size(498, 21);
            this.txb_intact_name.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "供应商开户行";
            // 
            // txb_bank_name
            // 
            this.txb_bank_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Bank_Name", true));
            this.txb_bank_name.Location = new System.Drawing.Point(98, 195);
            this.txb_bank_name.MaxLength = 400;
            this.txb_bank_name.Multiline = true;
            this.txb_bank_name.Name = "txb_bank_name";
            this.txb_bank_name.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txb_bank_name.Size = new System.Drawing.Size(498, 50);
            this.txb_bank_name.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "供应商帐号";
            // 
            // txb_account
            // 
            this.txb_account.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Account", true));
            this.txb_account.Location = new System.Drawing.Point(98, 255);
            this.txb_account.MaxLength = 400;
            this.txb_account.Multiline = true;
            this.txb_account.Name = "txb_account";
            this.txb_account.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txb_account.Size = new System.Drawing.Size(498, 50);
            this.txb_account.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "供应商电话";
            // 
            // txb_phone
            // 
            this.txb_phone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Phone", true));
            this.txb_phone.Location = new System.Drawing.Point(98, 133);
            this.txb_phone.MaxLength = 100;
            this.txb_phone.Name = "txb_phone";
            this.txb_phone.Size = new System.Drawing.Size(498, 21);
            this.txb_phone.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "供应商传真";
            // 
            // txb_fax
            // 
            this.txb_fax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Fax", true));
            this.txb_fax.Location = new System.Drawing.Point(98, 164);
            this.txb_fax.MaxLength = 100;
            this.txb_fax.Name = "txb_fax";
            this.txb_fax.Size = new System.Drawing.Size(498, 21);
            this.txb_fax.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 381);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "备注信息";
            // 
            // txb_memo
            // 
            this.txb_memo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Memo", true));
            this.txb_memo.Location = new System.Drawing.Point(98, 377);
            this.txb_memo.Multiline = true;
            this.txb_memo.Name = "txb_memo";
            this.txb_memo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txb_memo.Size = new System.Drawing.Size(498, 196);
            this.txb_memo.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(0, 581);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(645, 10);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // bt_save
            // 
            this.bt_save.Image = ((System.Drawing.Image)(resources.GetObject("bt_save.Image")));
            this.bt_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_save.Location = new System.Drawing.Point(426, 602);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 8;
            this.bt_save.Text = "保存  ";
            this.bt_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_close
            // 
            this.bt_close.Image = ((System.Drawing.Image)(resources.GetObject("bt_close.Image")));
            this.bt_close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_close.Location = new System.Drawing.Point(521, 602);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(75, 23);
            this.bt_close.TabIndex = 9;
            this.bt_close.Text = "关闭  ";
            this.bt_close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 318);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "供应商地址";
            // 
            // txb_address
            // 
            this.txb_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Address", true));
            this.txb_address.Location = new System.Drawing.Point(98, 315);
            this.txb_address.MaxLength = 400;
            this.txb_address.Multiline = true;
            this.txb_address.Name = "txb_address";
            this.txb_address.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txb_address.Size = new System.Drawing.Size(498, 50);
            this.txb_address.TabIndex = 6;
            // 
            // SupplierAEForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 638);
            this.Controls.Add(this.txb_address);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txb_memo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txb_fax);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txb_phone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_account);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txb_bank_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_intact_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txb_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbx_class);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplierAEForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增";
            this.Load += new System.EventHandler(this.SupplierAEForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UCControl.MultiColumnComboBoxEx cbx_class;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private UCControl.UCTextBox txb_name;
        private System.Windows.Forms.Label label3;
        private UCControl.UCTextBox txb_intact_name;
        private System.Windows.Forms.Label label4;
        private UCControl.UCTextBox txb_bank_name;
        private System.Windows.Forms.Label label5;
        private UCControl.UCTextBox txb_account;
        private System.Windows.Forms.Label label6;
        private UCControl.UCTextBox txb_phone;
        private System.Windows.Forms.Label label7;
        private UCControl.UCTextBox txb_fax;
        private System.Windows.Forms.Label label8;
        private UCControl.UCTextBox txb_memo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.Label label9;
        private UCControl.UCTextBox txb_address;
        private System.Windows.Forms.BindingSource bindingSource;

    }
}