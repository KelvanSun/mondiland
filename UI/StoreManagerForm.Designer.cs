namespace Mondiland.UI
{
    partial class StoreManagerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreManagerForm));
            this.storeObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgv_main = new Mondiland.UCControl.UCDataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.managerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.managerPhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsb_all = new System.Windows.Forms.ToolStripButton();
            this.tsddb_store = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmi_add = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsb_view = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_export = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.favorites = new System.Windows.Forms.ToolStripButton();
            this.label_search_result = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.storeObjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_main)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // storeObjectBindingSource
            // 
            this.storeObjectBindingSource.DataSource = typeof(Mondiland.Obj.StoreObject);
            // 
            // dgv_main
            // 
            this.dgv_main.AllowUserToAddRows = false;
            this.dgv_main.AllowUserToDeleteRows = false;
            this.dgv_main.AllowUserToResizeRows = false;
            this.dgv_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_main.AutoGenerateColumns = false;
            this.dgv_main.BackgroundColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.managerDataGridViewTextBoxColumn,
            this.managerPhoneDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.memoDataGridViewTextBoxColumn});
            this.dgv_main.DataSource = this.storeObjectBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_main.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_main.Location = new System.Drawing.Point(0, 40);
            this.dgv_main.MultiSelect = false;
            this.dgv_main.Name = "dgv_main";
            this.dgv_main.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_main.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_main.RowHeadersWidth = 20;
            this.dgv_main.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_main.RowTemplate.Height = 23;
            this.dgv_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_main.Size = new System.Drawing.Size(936, 560);
            this.dgv_main.TabIndex = 1;
            this.dgv_main.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_main_CellDoubleClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            this.nameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.nameDataGridViewTextBoxColumn.HeaderText = "店名";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info;
            this.addressDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.addressDataGridViewTextBoxColumn.HeaderText = "地址";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            this.addressDataGridViewTextBoxColumn.Width = 400;
            // 
            // managerDataGridViewTextBoxColumn
            // 
            this.managerDataGridViewTextBoxColumn.DataPropertyName = "Manager";
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info;
            this.managerDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.managerDataGridViewTextBoxColumn.HeaderText = "店长";
            this.managerDataGridViewTextBoxColumn.Name = "managerDataGridViewTextBoxColumn";
            this.managerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // managerPhoneDataGridViewTextBoxColumn
            // 
            this.managerPhoneDataGridViewTextBoxColumn.DataPropertyName = "ManagerPhone";
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info;
            this.managerPhoneDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.managerPhoneDataGridViewTextBoxColumn.HeaderText = "店长手机";
            this.managerPhoneDataGridViewTextBoxColumn.Name = "managerPhoneDataGridViewTextBoxColumn";
            this.managerPhoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info;
            this.phoneDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.phoneDataGridViewTextBoxColumn.HeaderText = "店厅电话";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            this.phoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // memoDataGridViewTextBoxColumn
            // 
            this.memoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.memoDataGridViewTextBoxColumn.DataPropertyName = "Memo";
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info;
            this.memoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.memoDataGridViewTextBoxColumn.HeaderText = "备注信息";
            this.memoDataGridViewTextBoxColumn.Name = "memoDataGridViewTextBoxColumn";
            this.memoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_all,
            this.tsddb_store,
            this.tsb_view,
            this.toolStripSeparator1,
            this.tsb_export,
            this.toolStripSeparator2,
            this.favorites});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(936, 40);
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
            // tsddb_store
            // 
            this.tsddb_store.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_add,
            this.tsmi_edit});
            this.tsddb_store.Image = ((System.Drawing.Image)(resources.GetObject("tsddb_store.Image")));
            this.tsddb_store.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddb_store.Name = "tsddb_store";
            this.tsddb_store.Size = new System.Drawing.Size(45, 37);
            this.tsddb_store.Text = "店铺";
            this.tsddb_store.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsmi_add
            // 
            this.tsmi_add.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_add.Image")));
            this.tsmi_add.Name = "tsmi_add";
            this.tsmi_add.Size = new System.Drawing.Size(100, 22);
            this.tsmi_add.Text = "新增";
            this.tsmi_add.Click += new System.EventHandler(this.tsmi_add_Click);
            // 
            // tsmi_edit
            // 
            this.tsmi_edit.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_edit.Image")));
            this.tsmi_edit.Name = "tsmi_edit";
            this.tsmi_edit.Size = new System.Drawing.Size(100, 22);
            this.tsmi_edit.Text = "编辑";
            this.tsmi_edit.Click += new System.EventHandler(this.tsmi_edit_Click);
            // 
            // tsb_view
            // 
            this.tsb_view.Image = ((System.Drawing.Image)(resources.GetObject("tsb_view.Image")));
            this.tsb_view.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_view.Name = "tsb_view";
            this.tsb_view.Size = new System.Drawing.Size(60, 37);
            this.tsb_view.Text = "详细信息";
            this.tsb_view.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_view.Click += new System.EventHandler(this.tsb_view_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // tsb_export
            // 
            this.tsb_export.Image = ((System.Drawing.Image)(resources.GetObject("tsb_export.Image")));
            this.tsb_export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_export.Name = "tsb_export";
            this.tsb_export.Size = new System.Drawing.Size(45, 37);
            this.tsb_export.Text = "导出...";
            this.tsb_export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_export.Click += new System.EventHandler(this.tsb_export_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
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
            // label_search_result
            // 
            this.label_search_result.AutoSize = true;
            this.label_search_result.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_search_result.Location = new System.Drawing.Point(0, 605);
            this.label_search_result.Margin = new System.Windows.Forms.Padding(30, 20, 20, 20);
            this.label_search_result.Name = "label_search_result";
            this.label_search_result.Size = new System.Drawing.Size(83, 12);
            this.label_search_result.TabIndex = 4;
            this.label_search_result.Text = "共有 0 家店铺";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Excel 2007|*.xlsx";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar.Location = new System.Drawing.Point(332, 297);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(272, 23);
            this.progressBar.TabIndex = 5;
            this.progressBar.Visible = false;
            // 
            // StoreManagerForm
            // 
            this.ClientSize = new System.Drawing.Size(936, 617);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label_search_result);
            this.Controls.Add(this.dgv_main);
            this.Controls.Add(this.toolStrip);
            this.Name = "StoreManagerForm";
            this.Text = "全国店铺信息管理";
            this.Load += new System.EventHandler(this.StoreManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.storeObjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_main)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton favorites;
        private UCControl.UCDataGridView dgv_main;
        private System.Windows.Forms.BindingSource storeObjectBindingSource;
        private System.Windows.Forms.ToolStripDropDownButton tsddb_store;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_add;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit;
        private System.Windows.Forms.ToolStripButton tsb_all;
        private System.Windows.Forms.Label label_search_result;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn managerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn managerPhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton tsb_view;
        private System.Windows.Forms.ToolStripButton tsb_export;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}
