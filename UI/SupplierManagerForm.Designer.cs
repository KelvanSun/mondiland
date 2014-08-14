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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierManagerForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.favorites = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip.SuspendLayout();
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
            // SupplierManagerForm
            // 
            this.ClientSize = new System.Drawing.Size(611, 355);
            this.Controls.Add(this.toolStrip);
            this.Name = "SupplierManagerForm";
            this.Text = "供应商信息管理";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton favorites;
        private System.Windows.Forms.Timer timer1;

    }
}
