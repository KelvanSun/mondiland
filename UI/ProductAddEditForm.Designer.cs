namespace Mondiland.UI
{
    partial class ProductAddEditForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductAddEditForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_price = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chb_wash = new System.Windows.Forms.CheckBox();
            this.bt_del = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.dgv_material = new Mondiland.UCControl.UCDataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.txb_fill = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dgv_fill = new Mondiland.UCControl.UCDataGridView();
            this.size_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbx_wash = new Mondiland.UCControl.MultiColumnComboBoxEx();
            this.tb_tag = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txb_memo = new System.Windows.Forms.TextBox();
            this.txb_huohao = new System.Windows.Forms.TextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsb_add = new System.Windows.Forms.ToolStripButton();
            this.tsb_save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_close = new System.Windows.Forms.ToolStripButton();
            this.cbx_dengji = new Mondiland.UCControl.MultiColumnComboBoxEx();
            this.cbx_madeplace = new Mondiland.UCControl.MultiColumnComboBoxEx();
            this.cbx_partname = new Mondiland.UCControl.MultiColumnComboBoxEx();
            this.cbx_safedata = new Mondiland.UCControl.MultiColumnComboBoxEx();
            this.cbx_standard = new Mondiland.UCControl.MultiColumnComboBoxEx();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource_material = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_material)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_fill)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_material)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "产品货号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "产品种类";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "安全类别";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "执行标准";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "产品等级";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(211, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "产品产地";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(421, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "产品价格";
            // 
            // txb_price
            // 
            this.txb_price.Location = new System.Drawing.Point(481, 44);
            this.txb_price.Name = "txb_price";
            this.txb_price.Size = new System.Drawing.Size(121, 21);
            this.txb_price.TabIndex = 6;
            this.txb_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txb_price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_price_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "标价模板";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chb_wash);
            this.groupBox1.Controls.Add(this.bt_del);
            this.groupBox1.Controls.Add(this.bt_add);
            this.groupBox1.Controls.Add(this.dgv_material);
            this.groupBox1.Location = new System.Drawing.Point(31, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 202);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "产品成份明细";
            // 
            // chb_wash
            // 
            this.chb_wash.AutoSize = true;
            this.chb_wash.Location = new System.Drawing.Point(94, -1);
            this.chb_wash.Name = "chb_wash";
            this.chb_wash.Size = new System.Drawing.Size(120, 16);
            this.chb_wash.TabIndex = 3;
            this.chb_wash.Text = "打印\"(水洗产品)\"";
            this.chb_wash.UseVisualStyleBackColor = true;
            this.chb_wash.CheckedChanged += new System.EventHandler(this.chb_wash_CheckedChanged);
            // 
            // bt_del
            // 
            this.bt_del.Location = new System.Drawing.Point(94, 170);
            this.bt_del.Name = "bt_del";
            this.bt_del.Size = new System.Drawing.Size(75, 23);
            this.bt_del.TabIndex = 2;
            this.bt_del.Text = "删除";
            this.bt_del.UseVisualStyleBackColor = true;
            this.bt_del.Click += new System.EventHandler(this.bt_del_Click);
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(13, 170);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 23);
            this.bt_add.TabIndex = 1;
            this.bt_add.Text = "添加";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // dgv_material
            // 
            this.dgv_material.AllowUserToAddRows = false;
            this.dgv_material.AllowUserToDeleteRows = false;
            this.dgv_material.AllowUserToResizeRows = false;
            this.dgv_material.AutoGenerateColumns = false;
            this.dgv_material.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_material.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.type});
            this.dgv_material.DataSource = this.bindingSource_material;
            this.dgv_material.Location = new System.Drawing.Point(13, 23);
            this.dgv_material.MultiSelect = false;
            this.dgv_material.Name = "dgv_material";
            this.dgv_material.RowHeadersWidth = 20;
            this.dgv_material.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_material.RowTemplate.Height = 23;
            this.dgv_material.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_material.Size = new System.Drawing.Size(362, 142);
            this.dgv_material.TabIndex = 0;
            this.dgv_material.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox);
            this.groupBox4.Controls.Add(this.txb_fill);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.dgv_fill);
            this.groupBox4.Location = new System.Drawing.Point(433, 189);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(179, 280);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(6, 19);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(72, 16);
            this.checkBox.TabIndex = 0;
            this.checkBox.Text = "填充成份";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // txb_fill
            // 
            this.txb_fill.Enabled = false;
            this.txb_fill.Location = new System.Drawing.Point(69, 37);
            this.txb_fill.Name = "txb_fill";
            this.txb_fill.Size = new System.Drawing.Size(101, 21);
            this.txb_fill.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "成分内容";
            // 
            // dgv_fill
            // 
            this.dgv_fill.AllowUserToAddRows = false;
            this.dgv_fill.AllowUserToDeleteRows = false;
            this.dgv_fill.AllowUserToOrderColumns = true;
            this.dgv_fill.AllowUserToResizeRows = false;
            this.dgv_fill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_fill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.size_name,
            this.info});
            this.dgv_fill.Enabled = false;
            this.dgv_fill.Location = new System.Drawing.Point(8, 64);
            this.dgv_fill.Name = "dgv_fill";
            this.dgv_fill.RowHeadersWidth = 20;
            this.dgv_fill.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_fill.RowTemplate.Height = 23;
            this.dgv_fill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_fill.Size = new System.Drawing.Size(162, 209);
            this.dgv_fill.TabIndex = 1;
            this.dgv_fill.TabStop = false;
            // 
            // size_name
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.size_name.DefaultCellStyle = dataGridViewCellStyle2;
            this.size_name.HeaderText = "规格";
            this.size_name.Name = "size_name";
            this.size_name.ReadOnly = true;
            this.size_name.Width = 40;
            // 
            // info
            // 
            this.info.HeaderText = "内容";
            this.info.Name = "info";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbx_wash);
            this.groupBox2.Controls.Add(this.tb_tag);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(412, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "打印模板";
            // 
            // cbx_wash
            // 
            this.cbx_wash.ComboBoxHeight = 14;
            this.cbx_wash.DropDownHeight = 114;
            this.cbx_wash.DropDownWidth = 121;
            this.cbx_wash.FormattingEnabled = true;
            this.cbx_wash.ItemDropDownHeight = 14;
            this.cbx_wash.Location = new System.Drawing.Point(69, 64);
            this.cbx_wash.Name = "cbx_wash";
            this.cbx_wash.Size = new System.Drawing.Size(121, 20);
            this.cbx_wash.TabIndex = 20;
            // 
            // tb_tag
            // 
            this.tb_tag.Location = new System.Drawing.Point(69, 26);
            this.tb_tag.Name = "tb_tag";
            this.tb_tag.ReadOnly = true;
            this.tb_tag.Size = new System.Drawing.Size(121, 21);
            this.tb_tag.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "洗唛模板";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txb_memo);
            this.groupBox3.Location = new System.Drawing.Point(31, 399);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(387, 74);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "备注信息";
            // 
            // txb_memo
            // 
            this.txb_memo.Location = new System.Drawing.Point(12, 20);
            this.txb_memo.MaxLength = 400;
            this.txb_memo.Multiline = true;
            this.txb_memo.Name = "txb_memo";
            this.txb_memo.Size = new System.Drawing.Size(365, 44);
            this.txb_memo.TabIndex = 0;
            // 
            // txb_huohao
            // 
            this.txb_huohao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txb_huohao.Location = new System.Drawing.Point(88, 44);
            this.txb_huohao.Name = "txb_huohao";
            this.txb_huohao.Size = new System.Drawing.Size(100, 21);
            this.txb_huohao.TabIndex = 0;
            this.txb_huohao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_huohao_KeyDown);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_add,
            this.tsb_save,
            this.toolStripSeparator1,
            this.tsb_close});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(646, 40);
            this.toolStrip.TabIndex = 21;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsb_add
            // 
            this.tsb_add.Image = ((System.Drawing.Image)(resources.GetObject("tsb_add.Image")));
            this.tsb_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_add.Name = "tsb_add";
            this.tsb_add.Size = new System.Drawing.Size(36, 37);
            this.tsb_add.Text = "新增";
            this.tsb_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_add.Click += new System.EventHandler(this.tsb_add_Click);
            // 
            // tsb_save
            // 
            this.tsb_save.Image = ((System.Drawing.Image)(resources.GetObject("tsb_save.Image")));
            this.tsb_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_save.Name = "tsb_save";
            this.tsb_save.Size = new System.Drawing.Size(36, 37);
            this.tsb_save.Text = "保存";
            this.tsb_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_save.Click += new System.EventHandler(this.tsb_save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // tsb_close
            // 
            this.tsb_close.Image = ((System.Drawing.Image)(resources.GetObject("tsb_close.Image")));
            this.tsb_close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_close.Name = "tsb_close";
            this.tsb_close.Size = new System.Drawing.Size(36, 37);
            this.tsb_close.Text = "关闭";
            this.tsb_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_close.Click += new System.EventHandler(this.tsb_close_Click);
            // 
            // cbx_dengji
            // 
            this.cbx_dengji.ComboBoxHeight = 14;
            this.cbx_dengji.DisplayMember = "Id";
            this.cbx_dengji.DropDownHeight = 114;
            this.cbx_dengji.DropDownWidth = 121;
            this.cbx_dengji.FormattingEnabled = true;
            this.cbx_dengji.ItemDropDownHeight = 14;
            this.cbx_dengji.Location = new System.Drawing.Point(274, 43);
            this.cbx_dengji.Name = "cbx_dengji";
            this.cbx_dengji.Size = new System.Drawing.Size(121, 20);
            this.cbx_dengji.TabIndex = 22;
            this.cbx_dengji.ValueMember = "Id";
            // 
            // cbx_madeplace
            // 
            this.cbx_madeplace.ComboBoxHeight = 14;
            this.cbx_madeplace.DropDownHeight = 114;
            this.cbx_madeplace.DropDownWidth = 121;
            this.cbx_madeplace.FormattingEnabled = true;
            this.cbx_madeplace.ItemDropDownHeight = 14;
            this.cbx_madeplace.Location = new System.Drawing.Point(274, 81);
            this.cbx_madeplace.Name = "cbx_madeplace";
            this.cbx_madeplace.Size = new System.Drawing.Size(121, 20);
            this.cbx_madeplace.TabIndex = 23;
            // 
            // cbx_partname
            // 
            this.cbx_partname.ComboBoxHeight = 14;
            this.cbx_partname.DropDownHeight = 114;
            this.cbx_partname.DropDownWidth = 121;
            this.cbx_partname.FormattingEnabled = true;
            this.cbx_partname.ItemDropDownHeight = 14;
            this.cbx_partname.Location = new System.Drawing.Point(88, 81);
            this.cbx_partname.Name = "cbx_partname";
            this.cbx_partname.Size = new System.Drawing.Size(100, 20);
            this.cbx_partname.TabIndex = 24;
            // 
            // cbx_safedata
            // 
            this.cbx_safedata.ComboBoxHeight = 14;
            this.cbx_safedata.DropDownHeight = 114;
            this.cbx_safedata.DropDownWidth = 121;
            this.cbx_safedata.FormattingEnabled = true;
            this.cbx_safedata.ItemDropDownHeight = 14;
            this.cbx_safedata.Location = new System.Drawing.Point(88, 116);
            this.cbx_safedata.Name = "cbx_safedata";
            this.cbx_safedata.Size = new System.Drawing.Size(307, 20);
            this.cbx_safedata.TabIndex = 25;
            // 
            // cbx_standard
            // 
            this.cbx_standard.ComboBoxHeight = 14;
            this.cbx_standard.DropDownHeight = 114;
            this.cbx_standard.DropDownWidth = 121;
            this.cbx_standard.FormattingEnabled = true;
            this.cbx_standard.ItemDropDownHeight = 14;
            this.cbx_standard.Location = new System.Drawing.Point(88, 153);
            this.cbx_standard.Name = "cbx_standard";
            this.cbx_standard.Size = new System.Drawing.Size(307, 20);
            this.cbx_standard.TabIndex = 26;
            // 
            // id
            // 
            this.id.DataPropertyName = "Id";
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // type
            // 
            this.type.DataPropertyName = "Type";
            this.type.HeaderText = "成份内容";
            this.type.MaxInputLength = 50;
            this.type.Name = "type";
            this.type.Width = 350;
            // 
            // bindingSource_material
            // 
            this.bindingSource_material.DataSource = typeof(Mondiland.BLLEntity.BEMaterialDataInfo);
            // 
            // ProductAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 486);
            this.Controls.Add(this.cbx_standard);
            this.Controls.Add(this.cbx_safedata);
            this.Controls.Add(this.cbx_partname);
            this.Controls.Add(this.cbx_madeplace);
            this.Controls.Add(this.cbx_dengji);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.txb_huohao);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txb_price);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductAddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产品信息管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductAddEditForm_FormClosing);
            this.Load += new System.EventHandler(this.ProductAddEditForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_material)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_fill)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_material)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txb_price;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private UCControl.UCDataGridView dgv_material;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txb_memo;
        private System.Windows.Forms.Button bt_del;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.TextBox tb_tag;
        private System.Windows.Forms.GroupBox groupBox4;
        private UCControl.UCDataGridView dgv_fill;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txb_fill;
        private System.Windows.Forms.BindingSource bindingSource_material;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn size_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn info;
        private System.Windows.Forms.TextBox txb_huohao;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsb_add;
        private System.Windows.Forms.ToolStripButton tsb_save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_close;
        private System.Windows.Forms.CheckBox chb_wash;
        private UCControl.MultiColumnComboBoxEx cbx_dengji;
        private UCControl.MultiColumnComboBoxEx cbx_madeplace;
        private UCControl.MultiColumnComboBoxEx cbx_partname;
        private UCControl.MultiColumnComboBoxEx cbx_safedata;
        private UCControl.MultiColumnComboBoxEx cbx_standard;
        private UCControl.MultiColumnComboBoxEx cbx_wash;
    }
}