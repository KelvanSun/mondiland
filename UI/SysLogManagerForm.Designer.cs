namespace Mondiland.UI
{
    partial class SysLogManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysLogManagerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsb_all = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.favorites = new System.Windows.Forms.ToolStripButton();
            this.ucDataGridView = new Mondiland.UCControl.UCDataGridView();
            this.logInfoObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logInfoObjectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_all,
            this.toolStripSeparator1,
            this.favorites});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(970, 40);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip";
            // 
            // tsb_all
            // 
            this.tsb_all.Image = ((System.Drawing.Image)(resources.GetObject("tsb_all.Image")));
            this.tsb_all.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_all.Name = "tsb_all";
            this.tsb_all.Size = new System.Drawing.Size(60, 37);
            this.tsb_all.Text = "显示全部";
            this.tsb_all.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_all.Click += new System.EventHandler(this.tsb_all_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
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
            // ucDataGridView
            // 
            this.ucDataGridView.AllowUserToAddRows = false;
            this.ucDataGridView.AllowUserToDeleteRows = false;
            this.ucDataGridView.AllowUserToResizeRows = false;
            this.ucDataGridView.AutoGenerateColumns = false;
            this.ucDataGridView.BackgroundColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ucDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ucDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ucDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dtDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.logInfoDataGridViewTextBoxColumn});
            this.ucDataGridView.DataSource = this.logInfoObjectBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ucDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.ucDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDataGridView.Location = new System.Drawing.Point(0, 40);
            this.ucDataGridView.MultiSelect = false;
            this.ucDataGridView.Name = "ucDataGridView";
            this.ucDataGridView.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ucDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.ucDataGridView.RowHeadersWidth = 20;
            this.ucDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ucDataGridView.RowTemplate.Height = 23;
            this.ucDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ucDataGridView.Size = new System.Drawing.Size(970, 538);
            this.ucDataGridView.TabIndex = 1;
            // 
            // logInfoObjectBindingSource
            // 
            this.logInfoObjectBindingSource.DataSource = typeof(Mondiland.Obj.LogInfoManager.LogInfoObject);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // dtDataGridViewTextBoxColumn
            // 
            this.dtDataGridViewTextBoxColumn.DataPropertyName = "Dt";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            this.dtDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtDataGridViewTextBoxColumn.HeaderText = "日期时间";
            this.dtDataGridViewTextBoxColumn.Name = "dtDataGridViewTextBoxColumn";
            this.dtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info;
            this.userNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.userNameDataGridViewTextBoxColumn.HeaderText = "操作员";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // logInfoDataGridViewTextBoxColumn
            // 
            this.logInfoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.logInfoDataGridViewTextBoxColumn.DataPropertyName = "LogInfo";
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info;
            this.logInfoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.logInfoDataGridViewTextBoxColumn.HeaderText = "日志内容";
            this.logInfoDataGridViewTextBoxColumn.Name = "logInfoDataGridViewTextBoxColumn";
            this.logInfoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // SysLogManagerForm
            // 
            this.ClientSize = new System.Drawing.Size(970, 578);
            this.Controls.Add(this.ucDataGridView);
            this.Controls.Add(this.toolStrip);
            this.Name = "SysLogManagerForm";
            this.Text = "日志信息查询";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logInfoObjectBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton favorites;
        private UCControl.UCDataGridView ucDataGridView;
        private System.Windows.Forms.BindingSource logInfoObjectBindingSource;
        private System.Windows.Forms.ToolStripButton tsb_all;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logInfoDataGridViewTextBoxColumn;
    }
}
