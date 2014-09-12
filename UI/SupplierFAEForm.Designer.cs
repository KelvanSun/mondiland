namespace Mondiland.UI
{
    partial class SupplierFAEForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierFAEForm));
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txb_address = new Mondiland.UCControl.UCTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_contacts = new Mondiland.UCControl.UCTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_tel = new Mondiland.UCControl.UCTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_fax = new Mondiland.UCControl.UCTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_memo = new Mondiland.UCControl.UCTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bt_close = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_del = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Mondiland.Obj.SupplierObject.SupplierFObject);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工厂地址";
            // 
            // txb_address
            // 
            this.txb_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Address", true));
            this.txb_address.Location = new System.Drawing.Point(96, 25);
            this.txb_address.MaxLength = 100;
            this.txb_address.Multiline = true;
            this.txb_address.Name = "txb_address";
            this.txb_address.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txb_address.Size = new System.Drawing.Size(406, 61);
            this.txb_address.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "联系人";
            // 
            // txb_contacts
            // 
            this.txb_contacts.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Contacts", true));
            this.txb_contacts.Location = new System.Drawing.Point(96, 106);
            this.txb_contacts.MaxLength = 100;
            this.txb_contacts.Name = "txb_contacts";
            this.txb_contacts.Size = new System.Drawing.Size(406, 21);
            this.txb_contacts.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "电话";
            // 
            // txb_tel
            // 
            this.txb_tel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Tel", true));
            this.txb_tel.Location = new System.Drawing.Point(96, 148);
            this.txb_tel.MaxLength = 100;
            this.txb_tel.Name = "txb_tel";
            this.txb_tel.Size = new System.Drawing.Size(406, 21);
            this.txb_tel.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "传真";
            // 
            // txb_fax
            // 
            this.txb_fax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Fax", true));
            this.txb_fax.Location = new System.Drawing.Point(96, 190);
            this.txb_fax.MaxLength = 100;
            this.txb_fax.Name = "txb_fax";
            this.txb_fax.Size = new System.Drawing.Size(406, 21);
            this.txb_fax.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "备注信息";
            // 
            // txb_memo
            // 
            this.txb_memo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Memo", true));
            this.txb_memo.Location = new System.Drawing.Point(96, 232);
            this.txb_memo.Multiline = true;
            this.txb_memo.Name = "txb_memo";
            this.txb_memo.Size = new System.Drawing.Size(406, 110);
            this.txb_memo.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(1, 354);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(572, 10);
            this.groupBox2.TabIndex = 10;
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
            // bt_close
            // 
            this.bt_close.Image = ((System.Drawing.Image)(resources.GetObject("bt_close.Image")));
            this.bt_close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_close.Location = new System.Drawing.Point(470, 383);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(75, 23);
            this.bt_close.TabIndex = 6;
            this.bt_close.Text = "关闭  ";
            this.bt_close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // bt_save
            // 
            this.bt_save.Image = ((System.Drawing.Image)(resources.GetObject("bt_save.Image")));
            this.bt_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_save.Location = new System.Drawing.Point(375, 383);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 5;
            this.bt_save.Text = "保存  ";
            this.bt_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_del
            // 
            this.bt_del.Image = ((System.Drawing.Image)(resources.GetObject("bt_del.Image")));
            this.bt_del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_del.Location = new System.Drawing.Point(21, 383);
            this.bt_del.Name = "bt_del";
            this.bt_del.Size = new System.Drawing.Size(75, 23);
            this.bt_del.TabIndex = 16;
            this.bt_del.Text = "删除  ";
            this.bt_del.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_del.UseVisualStyleBackColor = true;
            this.bt_del.Click += new System.EventHandler(this.bt_del_Click);
            // 
            // SupplierFAEForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 426);
            this.Controls.Add(this.bt_del);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txb_memo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txb_fax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_tel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txb_contacts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txb_address);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplierFAEForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增";
            this.Load += new System.EventHandler(this.SupplierFAEForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Label label1;
        private UCControl.UCTextBox txb_address;
        private System.Windows.Forms.Label label2;
        private UCControl.UCTextBox txb_contacts;
        private System.Windows.Forms.Label label3;
        private UCControl.UCTextBox txb_tel;
        private System.Windows.Forms.Label label4;
        private UCControl.UCTextBox txb_fax;
        private System.Windows.Forms.Label label5;
        private UCControl.UCTextBox txb_memo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_del;
    }
}