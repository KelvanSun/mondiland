namespace Mondiland.UI
{
    partial class SupplierManagerForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierManagerForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.favorites = new System.Windows.Forms.ToolStripButton();
            this.panel_top = new System.Windows.Forms.Panel();
            this.FunctionName = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            this.panel_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.favorites});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(611, 40);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip";
            // 
            // favorites
            // 
            this.favorites.Image = ((System.Drawing.Image)(resources.GetObject("favorites.Image")));
            this.favorites.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.favorites.Name = "favorites";
            this.favorites.Size = new System.Drawing.Size(36, 37);
            this.favorites.Text = "收藏";
            this.favorites.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.favorites.Click += new System.EventHandler(this.favorites_Click);
            // 
            // panel_top
            // 
            this.panel_top.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(149)))), ((int)(((byte)(193)))));
            this.panel_top.Controls.Add(this.FunctionName);
            this.panel_top.Location = new System.Drawing.Point(0, 43);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(611, 42);
            this.panel_top.TabIndex = 1;
            // 
            // FunctionName
            // 
            this.FunctionName.AutoSize = true;
            this.FunctionName.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FunctionName.Location = new System.Drawing.Point(10, 7);
            this.FunctionName.Name = "FunctionName";
            this.FunctionName.Size = new System.Drawing.Size(265, 28);
            this.FunctionName.TabIndex = 2;
            this.FunctionName.Text = "[供应商]---供应商信息管理";
            // 
            // SupplierManagerForm
            // 
            this.ClientSize = new System.Drawing.Size(611, 355);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.toolStrip);
            this.Name = "SupplierManagerForm";
            this.Text = "供应商信息管理";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton favorites;
        private System.Windows.Forms.Panel panel_top;
        protected System.Windows.Forms.Label FunctionName;

    }
}
