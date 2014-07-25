namespace Mondiland.UI
{
    partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menu_base = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_base_safe = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_base_standard = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_base_madeplace = new System.Windows.Forms.ToolStripMenuItem();
            this.系统功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_product_add = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_print = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_base,
            this.系统功能ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(650, 25);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menu_base
            // 
            this.menu_base.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_base_safe,
            this.menu_base_standard,
            this.menu_base_madeplace});
            this.menu_base.Name = "menu_base";
            this.menu_base.Size = new System.Drawing.Size(68, 21);
            this.menu_base.Text = "基础信息";
            // 
            // menu_base_safe
            // 
            this.menu_base_safe.Name = "menu_base_safe";
            this.menu_base_safe.Size = new System.Drawing.Size(124, 22);
            this.menu_base_safe.Text = "安全类别";
            this.menu_base_safe.Click += new System.EventHandler(this.menu_base_safe_Click);
            // 
            // menu_base_standard
            // 
            this.menu_base_standard.Name = "menu_base_standard";
            this.menu_base_standard.Size = new System.Drawing.Size(124, 22);
            this.menu_base_standard.Text = "执行标准";
            this.menu_base_standard.Click += new System.EventHandler(this.menu_base_standard_Click);
            // 
            // menu_base_madeplace
            // 
            this.menu_base_madeplace.Name = "menu_base_madeplace";
            this.menu_base_madeplace.Size = new System.Drawing.Size(124, 22);
            this.menu_base_madeplace.Text = "产品产地";
            this.menu_base_madeplace.Click += new System.EventHandler(this.menu_base_madeplace_Click);
            // 
            // 系统功能ToolStripMenuItem
            // 
            this.系统功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_product_add,
            this.menu_print});
            this.系统功能ToolStripMenuItem.Name = "系统功能ToolStripMenuItem";
            this.系统功能ToolStripMenuItem.Size = new System.Drawing.Size(72, 21);
            this.系统功能ToolStripMenuItem.Text = " 系统功能";
            // 
            // menu_product_add
            // 
            this.menu_product_add.Name = "menu_product_add";
            this.menu_product_add.Size = new System.Drawing.Size(152, 22);
            this.menu_product_add.Text = "产品信息管理";
            this.menu_product_add.Click += new System.EventHandler(this.menu_product_add_Click);
            // 
            // menu_print
            // 
            this.menu_print.Name = "menu_print";
            this.menu_print.Size = new System.Drawing.Size(152, 22);
            this.menu_print.Text = "产品标签打印";
            this.menu_print.Click += new System.EventHandler(this.menu_print_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 346);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "产品标签打印管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menu_base;
        private System.Windows.Forms.ToolStripMenuItem menu_base_safe;
        private System.Windows.Forms.ToolStripMenuItem menu_base_standard;
        private System.Windows.Forms.ToolStripMenuItem menu_base_madeplace;
        private System.Windows.Forms.ToolStripMenuItem 系统功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_product_add;
        private System.Windows.Forms.ToolStripMenuItem menu_print;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}