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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierAEForm));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_name = new Mondiland.UCControl.UCTextBox();
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
            this.label2.Location = new System.Drawing.Point(23, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "供应商简称";
            // 
            // txb_name
            // 
            this.txb_name.Location = new System.Drawing.Point(98, 85);
            this.txb_name.MaxLength = 50;
            this.txb_name.Name = "txb_name";
            this.txb_name.Size = new System.Drawing.Size(172, 21);
            this.txb_name.TabIndex = 0;
            this.txb_name.TextChanged += new System.EventHandler(this.txb_name_TextChanged);
            this.txb_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_name_KeyDown);
            // 
            // cbx_class
            // 
            this.cbx_class.ComboBoxHeight = 14;
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
            this.label3.Location = new System.Drawing.Point(23, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "供应商全称";
            // 
            // txb_intact_name
            // 
            this.txb_intact_name.Location = new System.Drawing.Point(98, 127);
            this.txb_intact_name.MaxLength = 50;
            this.txb_intact_name.Name = "txb_intact_name";
            this.txb_intact_name.Size = new System.Drawing.Size(498, 21);
            this.txb_intact_name.TabIndex = 1;
            this.txb_intact_name.TextChanged += new System.EventHandler(this.txb_intact_name_TextChanged);
            this.txb_intact_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_intact_name_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "供应商开户行";
            // 
            // txb_bank_name
            // 
            this.txb_bank_name.Location = new System.Drawing.Point(98, 253);
            this.txb_bank_name.MaxLength = 50;
            this.txb_bank_name.Name = "txb_bank_name";
            this.txb_bank_name.Size = new System.Drawing.Size(498, 21);
            this.txb_bank_name.TabIndex = 4;
            this.txb_bank_name.TextChanged += new System.EventHandler(this.txb_bank_name_TextChanged);
            this.txb_bank_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_bank_name_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "供应商帐号";
            // 
            // txb_account
            // 
            this.txb_account.Location = new System.Drawing.Point(98, 295);
            this.txb_account.MaxLength = 50;
            this.txb_account.Name = "txb_account";
            this.txb_account.Size = new System.Drawing.Size(498, 21);
            this.txb_account.TabIndex = 5;
            this.txb_account.TextChanged += new System.EventHandler(this.txb_account_TextChanged);
            this.txb_account.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_account_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "供应商电话";
            // 
            // txb_phone
            // 
            this.txb_phone.Location = new System.Drawing.Point(98, 169);
            this.txb_phone.MaxLength = 50;
            this.txb_phone.Name = "txb_phone";
            this.txb_phone.Size = new System.Drawing.Size(498, 21);
            this.txb_phone.TabIndex = 2;
            this.txb_phone.TextChanged += new System.EventHandler(this.txb_phone_TextChanged);
            this.txb_phone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_phone_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "供应商传真";
            // 
            // txb_fax
            // 
            this.txb_fax.Location = new System.Drawing.Point(98, 211);
            this.txb_fax.MaxLength = 50;
            this.txb_fax.Name = "txb_fax";
            this.txb_fax.Size = new System.Drawing.Size(498, 21);
            this.txb_fax.TabIndex = 3;
            this.txb_fax.TextChanged += new System.EventHandler(this.txb_fax_TextChanged);
            this.txb_fax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_fax_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "备注信息";
            // 
            // txb_memo
            // 
            this.txb_memo.Location = new System.Drawing.Point(98, 382);
            this.txb_memo.MaxLength = 400;
            this.txb_memo.Multiline = true;
            this.txb_memo.Name = "txb_memo";
            this.txb_memo.Size = new System.Drawing.Size(498, 113);
            this.txb_memo.TabIndex = 7;
            this.txb_memo.TextChanged += new System.EventHandler(this.txb_memo_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(0, 513);
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
            this.bt_save.Location = new System.Drawing.Point(426, 538);
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
            this.bt_close.Location = new System.Drawing.Point(521, 538);
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
            this.label9.Location = new System.Drawing.Point(24, 344);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "供应商地址";
            // 
            // txb_address
            // 
            this.txb_address.Location = new System.Drawing.Point(98, 339);
            this.txb_address.MaxLength = 50;
            this.txb_address.Name = "txb_address";
            this.txb_address.Size = new System.Drawing.Size(498, 21);
            this.txb_address.TabIndex = 6;
            this.txb_address.TextChanged += new System.EventHandler(this.txb_address_TextChanged);
            this.txb_address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_address_KeyDown);
            // 
            // SupplierAEForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 579);
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

    }
}