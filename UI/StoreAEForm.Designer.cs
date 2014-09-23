namespace Mondiland.UI
{
    partial class StoreAEForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreAEForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txb_name = new Mondiland.UCControl.UCTextBox();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txb_address = new Mondiland.UCControl.UCTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_manager = new Mondiland.UCControl.UCTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_manager_phone = new Mondiland.UCControl.UCTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_phone = new Mondiland.UCControl.UCTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_memo = new Mondiland.UCControl.UCTextBox();
            this.bt_del = new System.Windows.Forms.Button();
            this.bt_close = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "店名";
            // 
            // txb_name
            // 
            this.txb_name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Name", true));
            this.txb_name.Location = new System.Drawing.Point(83, 27);
            this.txb_name.MaxLength = 100;
            this.txb_name.Name = "txb_name";
            this.txb_name.Size = new System.Drawing.Size(165, 21);
            this.txb_name.TabIndex = 0;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Mondiland.Obj.StoreObject);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "地址";
            // 
            // txb_address
            // 
            this.txb_address.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Address", true));
            this.txb_address.Location = new System.Drawing.Point(83, 72);
            this.txb_address.MaxLength = 400;
            this.txb_address.Multiline = true;
            this.txb_address.Name = "txb_address";
            this.txb_address.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txb_address.Size = new System.Drawing.Size(516, 87);
            this.txb_address.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "店长";
            // 
            // txb_manager
            // 
            this.txb_manager.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Manager", true));
            this.txb_manager.Location = new System.Drawing.Point(83, 228);
            this.txb_manager.MaxLength = 100;
            this.txb_manager.Name = "txb_manager";
            this.txb_manager.Size = new System.Drawing.Size(210, 21);
            this.txb_manager.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(325, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "店长手机";
            // 
            // txb_manager_phone
            // 
            this.txb_manager_phone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ManagerPhone", true));
            this.txb_manager_phone.Location = new System.Drawing.Point(389, 228);
            this.txb_manager_phone.MaxLength = 100;
            this.txb_manager_phone.Name = "txb_manager_phone";
            this.txb_manager_phone.Size = new System.Drawing.Size(210, 21);
            this.txb_manager_phone.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "店厅电话";
            // 
            // txb_phone
            // 
            this.txb_phone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Phone", true));
            this.txb_phone.Location = new System.Drawing.Point(83, 183);
            this.txb_phone.MaxLength = 100;
            this.txb_phone.Name = "txb_phone";
            this.txb_phone.Size = new System.Drawing.Size(210, 21);
            this.txb_phone.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "备注信息";
            // 
            // txb_memo
            // 
            this.txb_memo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Memo", true));
            this.txb_memo.Location = new System.Drawing.Point(83, 273);
            this.txb_memo.Multiline = true;
            this.txb_memo.Name = "txb_memo";
            this.txb_memo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txb_memo.Size = new System.Drawing.Size(516, 138);
            this.txb_memo.TabIndex = 5;
            // 
            // bt_del
            // 
            this.bt_del.Image = ((System.Drawing.Image)(resources.GetObject("bt_del.Image")));
            this.bt_del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_del.Location = new System.Drawing.Point(24, 439);
            this.bt_del.Name = "bt_del";
            this.bt_del.Size = new System.Drawing.Size(75, 23);
            this.bt_del.TabIndex = 18;
            this.bt_del.Text = "删除  ";
            this.bt_del.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_del.UseVisualStyleBackColor = true;
            this.bt_del.Click += new System.EventHandler(this.bt_del_Click);
            // 
            // bt_close
            // 
            this.bt_close.Image = ((System.Drawing.Image)(resources.GetObject("bt_close.Image")));
            this.bt_close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_close.Location = new System.Drawing.Point(524, 439);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(75, 23);
            this.bt_close.TabIndex = 17;
            this.bt_close.Text = "关闭  ";
            this.bt_close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // bt_save
            // 
            this.bt_save.Image = ((System.Drawing.Image)(resources.GetObject("bt_save.Image")));
            this.bt_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_save.Location = new System.Drawing.Point(429, 439);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 16;
            this.bt_save.Text = "保存  ";
            this.bt_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // StoreAEForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 485);
            this.Controls.Add(this.bt_del);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.txb_memo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_phone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txb_manager_phone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_manager);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txb_address);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txb_name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StoreAEForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增";
            this.Load += new System.EventHandler(this.StoreAEForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Label label1;
        private UCControl.UCTextBox txb_name;
        private System.Windows.Forms.Label label2;
        private UCControl.UCTextBox txb_address;
        private System.Windows.Forms.Label label3;
        private UCControl.UCTextBox txb_manager;
        private System.Windows.Forms.Label label4;
        private UCControl.UCTextBox txb_manager_phone;
        private System.Windows.Forms.Label label5;
        private UCControl.UCTextBox txb_phone;
        private System.Windows.Forms.Label label6;
        private UCControl.UCTextBox txb_memo;
        private System.Windows.Forms.Button bt_del;
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.Button bt_save;
    }
}