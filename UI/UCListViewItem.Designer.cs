namespace Mondiland.UI
{
    partial class UCListViewItem
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label_memo = new System.Windows.Forms.Label();
            this.label_caption = new System.Windows.Forms.Label();
            this.pbx_main = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_main)).BeginInit();
            this.SuspendLayout();
            // 
            // label_memo
            // 
            this.label_memo.Location = new System.Drawing.Point(66, 29);
            this.label_memo.Name = "label_memo";
            this.label_memo.Size = new System.Drawing.Size(171, 29);
            this.label_memo.TabIndex = 5;
            this.label_memo.Text = "label2";
            // 
            // label_caption
            // 
            this.label_caption.AutoSize = true;
            this.label_caption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_caption.Font = new System.Drawing.Font("宋体", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_caption.Location = new System.Drawing.Point(66, 10);
            this.label_caption.Name = "label_caption";
            this.label_caption.Size = new System.Drawing.Size(47, 12);
            this.label_caption.TabIndex = 4;
            this.label_caption.Text = "label1";
            this.label_caption.Click += new System.EventHandler(this.label_caption_Click);
            // 
            // pbx_main
            // 
            this.pbx_main.Location = new System.Drawing.Point(11, 7);
            this.pbx_main.Name = "pbx_main";
            this.pbx_main.Size = new System.Drawing.Size(48, 48);
            this.pbx_main.TabIndex = 3;
            this.pbx_main.TabStop = false;
            // 
            // UCListViewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_memo);
            this.Controls.Add(this.label_caption);
            this.Controls.Add(this.pbx_main);
            this.Name = "UCListViewItem";
            this.Size = new System.Drawing.Size(249, 64);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_memo;
        private System.Windows.Forms.Label label_caption;
        private System.Windows.Forms.PictureBox pbx_main;
    }
}
