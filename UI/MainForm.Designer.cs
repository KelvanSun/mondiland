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
            this.components = new System.ComponentModel.Container();
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin2 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin2 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient4 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient8 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin2 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient9 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient5 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient10 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient11 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient12 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient6 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient13 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient14 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menu_base = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_base_safe = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_base_standard = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_base_madeplace = new System.Windows.Forms.ToolStripMenuItem();
            this.系统功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_product_add = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_print = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.username = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupname = new System.Windows.Forms.ToolStripStatusLabel();
            this.version = new System.Windows.Forms.ToolStripStatusLabel();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
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
            this.menu_product_add.Size = new System.Drawing.Size(148, 22);
            this.menu_product_add.Text = "产品信息管理";
            this.menu_product_add.Click += new System.EventHandler(this.menu_product_add_Click);
            // 
            // menu_print
            // 
            this.menu_print.Name = "menu_print";
            this.menu_print.Size = new System.Drawing.Size(148, 22);
            this.menu_print.Text = "产品标签打印";
            this.menu_print.Click += new System.EventHandler(this.menu_print_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.username,
            this.groupname,
            this.version});
            this.statusStrip.Location = new System.Drawing.Point(0, 324);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(650, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // username
            // 
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(44, 17);
            this.username.Text = "用户名";
            // 
            // groupname
            // 
            this.groupname.Name = "groupname";
            this.groupname.Size = new System.Drawing.Size(535, 17);
            this.groupname.Spring = true;
            this.groupname.Text = "用户组";
            // 
            // version
            // 
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(56, 17);
            this.version.Text = "系统版本";
            // 
            // dockPanel
            // 
            this.dockPanel.ActiveAutoHideContent = null;
            this.dockPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(220)))));
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DockBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dockPanel.DockLeftPortion = 0.1D;
            this.dockPanel.Location = new System.Drawing.Point(0, 25);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.RightToLeftLayout = true;
            this.dockPanel.Size = new System.Drawing.Size(650, 299);
            dockPanelGradient4.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient4.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin2.DockStripGradient = dockPanelGradient4;
            tabGradient8.EndColor = System.Drawing.SystemColors.Control;
            tabGradient8.StartColor = System.Drawing.SystemColors.Control;
            tabGradient8.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin2.TabGradient = tabGradient8;
            dockPanelSkin2.AutoHideStripSkin = autoHideStripSkin2;
            tabGradient9.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient9.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient9.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient2.ActiveTabGradient = tabGradient9;
            dockPanelGradient5.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient5.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient2.DockStripGradient = dockPanelGradient5;
            tabGradient10.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient10.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient10.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient2.InactiveTabGradient = tabGradient10;
            dockPaneStripSkin2.DocumentGradient = dockPaneStripGradient2;
            tabGradient11.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient11.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient11.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient11.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient2.ActiveCaptionGradient = tabGradient11;
            tabGradient12.EndColor = System.Drawing.SystemColors.Control;
            tabGradient12.StartColor = System.Drawing.SystemColors.Control;
            tabGradient12.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient2.ActiveTabGradient = tabGradient12;
            dockPanelGradient6.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient6.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient2.DockStripGradient = dockPanelGradient6;
            tabGradient13.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient13.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient13.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient13.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient2.InactiveCaptionGradient = tabGradient13;
            tabGradient14.EndColor = System.Drawing.Color.Transparent;
            tabGradient14.StartColor = System.Drawing.Color.Transparent;
            tabGradient14.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient2.InactiveTabGradient = tabGradient14;
            dockPaneStripSkin2.ToolWindowGradient = dockPaneStripToolWindowGradient2;
            dockPanelSkin2.DockPaneStripSkin = dockPaneStripSkin2;
            this.dockPanel.Skin = dockPanelSkin2;
            this.dockPanel.TabIndex = 5;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "0.png");
            this.imageList.Images.SetKeyName(1, "1.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 346);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "宁波麦迪茉莱登商品管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel username;
        private System.Windows.Forms.ToolStripStatusLabel groupname;
        private System.Windows.Forms.ToolStripStatusLabel version;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        public System.Windows.Forms.ImageList imageList;
    }
}