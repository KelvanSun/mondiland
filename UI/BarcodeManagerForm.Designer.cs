namespace Mondiland.UI
{
    partial class BarcodeManagerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarcodeManagerForm));
            this.ucDataGridView = new Mondiland.UCControl.UCDataGridView();
            this.SizeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ean13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsb_save = new System.Windows.Forms.ToolStripButton();
            this.tsb_import = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.ucDataGridView)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucDataGridView
            // 
            this.ucDataGridView.AllowUserToAddRows = false;
            this.ucDataGridView.AllowUserToDeleteRows = false;
            this.ucDataGridView.AllowUserToResizeColumns = false;
            this.ucDataGridView.AllowUserToResizeRows = false;
            this.ucDataGridView.BackgroundColor = System.Drawing.SystemColors.Info;
            this.ucDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ucDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SizeName,
            this.ean13,
            this.Memo});
            this.ucDataGridView.Location = new System.Drawing.Point(0, 28);
            this.ucDataGridView.MultiSelect = false;
            this.ucDataGridView.Name = "ucDataGridView";
            this.ucDataGridView.RowHeadersWidth = 20;
            this.ucDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ucDataGridView.RowTemplate.Height = 23;
            this.ucDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ucDataGridView.Size = new System.Drawing.Size(639, 370);
            this.ucDataGridView.TabIndex = 1;
            this.ucDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucDataGridView_MouseDown);
            // 
            // SizeName
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SizeName.DefaultCellStyle = dataGridViewCellStyle3;
            this.SizeName.HeaderText = "号型";
            this.SizeName.Name = "SizeName";
            this.SizeName.ReadOnly = true;
            // 
            // ean13
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ean13.DefaultCellStyle = dataGridViewCellStyle4;
            this.ean13.HeaderText = "EAN13条码";
            this.ean13.Name = "ean13";
            this.ean13.Width = 150;
            // 
            // Memo
            // 
            this.Memo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Memo.HeaderText = "备注信息";
            this.Memo.Name = "Memo";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_save,
            this.tsb_import});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(639, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsb_save
            // 
            this.tsb_save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_save.Image = ((System.Drawing.Image)(resources.GetObject("tsb_save.Image")));
            this.tsb_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_save.Name = "tsb_save";
            this.tsb_save.Size = new System.Drawing.Size(23, 22);
            this.tsb_save.Text = "保存";
            this.tsb_save.Click += new System.EventHandler(this.tsb_save_Click);
            // 
            // tsb_import
            // 
            this.tsb_import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_import.Image = ((System.Drawing.Image)(resources.GetObject("tsb_import.Image")));
            this.tsb_import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_import.Name = "tsb_import";
            this.tsb_import.Size = new System.Drawing.Size(23, 22);
            this.tsb_import.Text = "导入";
            this.tsb_import.Click += new System.EventHandler(this.tsb_import_Click);
            // 
            // BarcodeManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 398);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.ucDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BarcodeManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "条码信息管理";
            this.Load += new System.EventHandler(this.BarcodeManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ucDataGridView)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UCControl.UCDataGridView ucDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ean13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memo;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsb_save;
        private System.Windows.Forms.ToolStripButton tsb_import;
    }
}