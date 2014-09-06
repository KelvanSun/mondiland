namespace Mondiland.UI
{
    partial class ChangePwdForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePwdForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txb_old = new Mondiland.UCControl.UCTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_new = new Mondiland.UCControl.UCTextBox();
            this.txb_agen = new Mondiland.UCControl.UCTextBox();
            this.bt_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "原先密码";
            // 
            // txb_old
            // 
            this.txb_old.Location = new System.Drawing.Point(83, 20);
            this.txb_old.Name = "txb_old";
            this.txb_old.PasswordChar = '*';
            this.txb_old.Size = new System.Drawing.Size(196, 21);
            this.txb_old.TabIndex = 0;
            this.txb_old.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_old_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "新的密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "确认密码";
            // 
            // txb_new
            // 
            this.txb_new.Location = new System.Drawing.Point(83, 65);
            this.txb_new.Name = "txb_new";
            this.txb_new.PasswordChar = '*';
            this.txb_new.Size = new System.Drawing.Size(196, 21);
            this.txb_new.TabIndex = 1;
            this.txb_new.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_new_KeyDown);
            // 
            // txb_agen
            // 
            this.txb_agen.Location = new System.Drawing.Point(83, 110);
            this.txb_agen.Name = "txb_agen";
            this.txb_agen.PasswordChar = '*';
            this.txb_agen.Size = new System.Drawing.Size(196, 21);
            this.txb_agen.TabIndex = 2;
            // 
            // bt_save
            // 
            this.bt_save.Image = ((System.Drawing.Image)(resources.GetObject("bt_save.Image")));
            this.bt_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_save.Location = new System.Drawing.Point(204, 158);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 10;
            this.bt_save.Text = "确定  ";
            this.bt_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // ChangePwdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 195);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.txb_agen);
            this.Controls.Add(this.txb_new);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txb_old);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePwdForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UCControl.UCTextBox txb_old;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private UCControl.UCTextBox txb_new;
        private UCControl.UCTextBox txb_agen;
        private System.Windows.Forms.Button bt_save;
    }
}