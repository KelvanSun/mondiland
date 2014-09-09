namespace Mondiland.UI
{
    partial class SupplierDAEForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierDAEForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txb_name = new Mondiland.UCControl.UCTextBox();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txb_phone = new Mondiland.UCControl.UCTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_fax = new Mondiland.UCControl.UCTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_email = new Mondiland.UCControl.UCTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_qq = new Mondiland.UCControl.UCTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_address = new Mondiland.UCControl.UCTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_memo = new Mondiland.UCControl.UCTextBox();
            this.bt_close = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.bt_del = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "联系人姓名";
            // 
            // txb_name
            // 
            this.txb_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Name", true));
            this.txb_name.Location = new System.Drawing.Point(113, 20);
            this.txb_name.MaxLength = 50;
            this.txb_name.Name = "txb_name";
            this.txb_name.Size = new System.Drawing.Size(173, 21);
            this.txb_name.TabIndex = 0;
            this.txb_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_name_KeyDown);
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Mondiland.Obj.SupplierObject.SupplierDObject);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "联系电话";
            // 
            // txb_phone
            // 
            this.txb_phone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Phone", true));
            this.txb_phone.Location = new System.Drawing.Point(113, 64);
            this.txb_phone.MaxLength = 50;
            this.txb_phone.Name = "txb_phone";
            this.txb_phone.Size = new System.Drawing.Size(434, 21);
            this.txb_phone.TabIndex = 1;
            this.txb_phone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_phone_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "传真";
            // 
            // txb_fax
            // 
            this.txb_fax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Fax", true));
            this.txb_fax.Location = new System.Drawing.Point(113, 108);
            this.txb_fax.MaxLength = 50;
            this.txb_fax.Name = "txb_fax";
            this.txb_fax.Size = new System.Drawing.Size(434, 21);
            this.txb_fax.TabIndex = 2;
            this.txb_fax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_fax_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "电子邮件";
            // 
            // txb_email
            // 
            this.txb_email.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Email", true));
            this.txb_email.Location = new System.Drawing.Point(113, 152);
            this.txb_email.MaxLength = 50;
            this.txb_email.Name = "txb_email";
            this.txb_email.Size = new System.Drawing.Size(201, 21);
            this.txb_email.TabIndex = 3;
            this.txb_email.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_email_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "QQ号";
            // 
            // txb_qq
            // 
            this.txb_qq.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "QQ", true));
            this.txb_qq.Location = new System.Drawing.Point(374, 152);
            this.txb_qq.MaxLength = 50;
            this.txb_qq.Name = "txb_qq";
            this.txb_qq.Size = new System.Drawing.Size(173, 21);
            this.txb_qq.TabIndex = 4;
            this.txb_qq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_qq_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "联系人地址";
            // 
            // txb_address
            // 
            this.txb_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Address", true));
            this.txb_address.Location = new System.Drawing.Point(113, 196);
            this.txb_address.MaxLength = 50;
            this.txb_address.Name = "txb_address";
            this.txb_address.Size = new System.Drawing.Size(434, 21);
            this.txb_address.TabIndex = 5;
            this.txb_address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_address_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "备注信息";
            // 
            // txb_memo
            // 
            this.txb_memo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Memo", true));
            this.txb_memo.Location = new System.Drawing.Point(113, 240);
            this.txb_memo.MaxLength = 50;
            this.txb_memo.Multiline = true;
            this.txb_memo.Name = "txb_memo";
            this.txb_memo.Size = new System.Drawing.Size(434, 81);
            this.txb_memo.TabIndex = 6;
            // 
            // bt_close
            // 
            this.bt_close.Image = ((System.Drawing.Image)(resources.GetObject("bt_close.Image")));
            this.bt_close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_close.Location = new System.Drawing.Point(472, 368);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(75, 23);
            this.bt_close.TabIndex = 8;
            this.bt_close.Text = "关闭  ";
            this.bt_close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // bt_save
            // 
            this.bt_save.Image = ((System.Drawing.Image)(resources.GetObject("bt_save.Image")));
            this.bt_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_save.Location = new System.Drawing.Point(377, 368);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 7;
            this.bt_save.Text = "保存  ";
            this.bt_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(3, 338);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(645, 10);
            this.groupBox2.TabIndex = 14;
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
            // bt_del
            // 
            this.bt_del.Image = ((System.Drawing.Image)(resources.GetObject("bt_del.Image")));
            this.bt_del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_del.Location = new System.Drawing.Point(16, 368);
            this.bt_del.Name = "bt_del";
            this.bt_del.Size = new System.Drawing.Size(75, 23);
            this.bt_del.TabIndex = 15;
            this.bt_del.Text = "删除  ";
            this.bt_del.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_del.UseVisualStyleBackColor = true;
            this.bt_del.Click += new System.EventHandler(this.bt_del_Click);
            // 
            // SupplierDAEForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 409);
            this.Controls.Add(this.bt_del);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txb_memo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txb_address);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_qq);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txb_email);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_fax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txb_phone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txb_name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplierDAEForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增";
            this.Load += new System.EventHandler(this.SupplierDAEForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UCControl.UCTextBox txb_name;
        private System.Windows.Forms.Label label2;
        private UCControl.UCTextBox txb_phone;
        private System.Windows.Forms.Label label3;
        private UCControl.UCTextBox txb_fax;
        private System.Windows.Forms.Label label4;
        private UCControl.UCTextBox txb_email;
        private System.Windows.Forms.Label label5;
        private UCControl.UCTextBox txb_qq;
        private System.Windows.Forms.Label label6;
        private UCControl.UCTextBox txb_address;
        private System.Windows.Forms.Label label7;
        private UCControl.UCTextBox txb_memo;
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Button bt_del;
    }
}