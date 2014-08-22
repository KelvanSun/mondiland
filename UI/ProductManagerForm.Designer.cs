﻿namespace Mondiland.UI
{
    partial class ProductManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductManagerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.add = new System.Windows.Forms.ToolStripButton();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.menu_print_tag = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_print_wash = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.favorites = new System.Windows.Forms.ToolStripButton();
            this.panel_top = new System.Windows.Forms.Panel();
            this.chb_bad = new System.Windows.Forms.CheckBox();
            this.chb_wash = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txb_memo = new System.Windows.Forms.TextBox();
            this.cbx_standard = new Mondiland.UCControl.MultiColumnComboBoxEx();
            this.cbx_safedata = new Mondiland.UCControl.MultiColumnComboBoxEx();
            this.cbx_partname = new Mondiland.UCControl.MultiColumnComboBoxEx();
            this.cbx_madeplace = new Mondiland.UCControl.MultiColumnComboBoxEx();
            this.cbx_dengji = new Mondiland.UCControl.MultiColumnComboBoxEx();
            this.txb_price = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txb_huohao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txb_fill = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgv_material_fill = new Mondiland.UCControl.UCDataGridView();
            this.panel_center = new System.Windows.Forms.Panel();
            this.bt_add = new System.Windows.Forms.Button();
            this.bt_del = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dgv_material = new Mondiland.UCControl.UCDataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource_material = new System.Windows.Forms.BindingSource(this.components);
            this.saveas = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.panel_top.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_material_fill)).BeginInit();
            this.panel_center.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_material)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_material)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.add,
            this.save,
            this.saveas,
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.favorites});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(970, 40);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip";
            // 
            // add
            // 
            this.add.Image = ((System.Drawing.Image)(resources.GetObject("add.Image")));
            this.add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(36, 37);
            this.add.Text = "新增";
            this.add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // save
            // 
            this.save.Image = ((System.Drawing.Image)(resources.GetObject("save.Image")));
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(36, 37);
            this.save.Text = "保存";
            this.save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_print_tag,
            this.menu_print_wash});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(45, 37);
            this.toolStripDropDownButton1.Text = "打印";
            this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menu_print_tag
            // 
            this.menu_print_tag.Name = "menu_print_tag";
            this.menu_print_tag.Size = new System.Drawing.Size(124, 22);
            this.menu_print_tag.Text = "打印吊牌";
            this.menu_print_tag.Click += new System.EventHandler(this.menu_print_tag_Click);
            // 
            // menu_print_wash
            // 
            this.menu_print_wash.Name = "menu_print_wash";
            this.menu_print_wash.Size = new System.Drawing.Size(124, 22);
            this.menu_print_wash.Text = "打印洗唛";
            this.menu_print_wash.Click += new System.EventHandler(this.menu_print_wash_Click);
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
            this.favorites.ToolTipText = "添加快捷方式";
            this.favorites.Click += new System.EventHandler(this.favorites_Click);
            // 
            // panel_top
            // 
            this.panel_top.BackColor = System.Drawing.SystemColors.Control;
            this.panel_top.Controls.Add(this.chb_bad);
            this.panel_top.Controls.Add(this.chb_wash);
            this.panel_top.Controls.Add(this.groupBox2);
            this.panel_top.Controls.Add(this.label11);
            this.panel_top.Controls.Add(this.txb_memo);
            this.panel_top.Controls.Add(this.cbx_standard);
            this.panel_top.Controls.Add(this.cbx_safedata);
            this.panel_top.Controls.Add(this.cbx_partname);
            this.panel_top.Controls.Add(this.cbx_madeplace);
            this.panel_top.Controls.Add(this.cbx_dengji);
            this.panel_top.Controls.Add(this.txb_price);
            this.panel_top.Controls.Add(this.label7);
            this.panel_top.Controls.Add(this.label6);
            this.panel_top.Controls.Add(this.label5);
            this.panel_top.Controls.Add(this.label4);
            this.panel_top.Controls.Add(this.label3);
            this.panel_top.Controls.Add(this.label2);
            this.panel_top.Controls.Add(this.groupBox1);
            this.panel_top.Controls.Add(this.txb_huohao);
            this.panel_top.Controls.Add(this.label1);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 40);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(970, 328);
            this.panel_top.TabIndex = 1;
            // 
            // chb_bad
            // 
            this.chb_bad.AutoSize = true;
            this.chb_bad.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chb_bad.Location = new System.Drawing.Point(514, 117);
            this.chb_bad.Name = "chb_bad";
            this.chb_bad.Size = new System.Drawing.Size(204, 16);
            this.chb_bad.TabIndex = 42;
            this.chb_bad.Text = "[安全类别]替换为[有害物质限量]";
            this.chb_bad.UseVisualStyleBackColor = true;
            this.chb_bad.CheckedChanged += new System.EventHandler(this.chb_bad_CheckedChanged);
            this.chb_bad.Click += new System.EventHandler(this.chb_bad_Click);
            // 
            // chb_wash
            // 
            this.chb_wash.AutoSize = true;
            this.chb_wash.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chb_wash.Location = new System.Drawing.Point(744, 117);
            this.chb_wash.Name = "chb_wash";
            this.chb_wash.Size = new System.Drawing.Size(132, 16);
            this.chb_wash.TabIndex = 41;
            this.chb_wash.Text = "打印[水洗产品]字样";
            this.chb_wash.UseVisualStyleBackColor = true;
            this.chb_wash.CheckedChanged += new System.EventHandler(this.chb_wash_CheckedChanged);
            this.chb_wash.Click += new System.EventHandler(this.chb_wash_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(0, 318);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(967, 10);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 40;
            this.label11.Text = "备注信息";
            // 
            // txb_memo
            // 
            this.txb_memo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_memo.Location = new System.Drawing.Point(98, 192);
            this.txb_memo.MaxLength = 400;
            this.txb_memo.Multiline = true;
            this.txb_memo.Name = "txb_memo";
            this.txb_memo.Size = new System.Drawing.Size(828, 118);
            this.txb_memo.TabIndex = 39;
            this.txb_memo.TextChanged += new System.EventHandler(this.txb_memo_TextChanged);
            // 
            // cbx_standard
            // 
            this.cbx_standard.ComboBoxHeight = 14;
            this.cbx_standard.DropDownHeight = 114;
            this.cbx_standard.DropDownWidth = 121;
            this.cbx_standard.FormattingEnabled = true;
            this.cbx_standard.ItemDropDownHeight = 14;
            this.cbx_standard.Location = new System.Drawing.Point(98, 154);
            this.cbx_standard.Name = "cbx_standard";
            this.cbx_standard.Size = new System.Drawing.Size(348, 20);
            this.cbx_standard.TabIndex = 38;
            this.cbx_standard.DropDownClosed += new System.EventHandler(this.cbx_standard_DropDownClosed);
            // 
            // cbx_safedata
            // 
            this.cbx_safedata.ComboBoxHeight = 14;
            this.cbx_safedata.DropDownHeight = 114;
            this.cbx_safedata.DropDownWidth = 121;
            this.cbx_safedata.FormattingEnabled = true;
            this.cbx_safedata.ItemDropDownHeight = 14;
            this.cbx_safedata.Location = new System.Drawing.Point(98, 113);
            this.cbx_safedata.Name = "cbx_safedata";
            this.cbx_safedata.Size = new System.Drawing.Size(348, 20);
            this.cbx_safedata.TabIndex = 37;
            this.cbx_safedata.DropDownClosed += new System.EventHandler(this.cbx_safedata_DropDownClosed);
            // 
            // cbx_partname
            // 
            this.cbx_partname.ComboBoxHeight = 14;
            this.cbx_partname.DropDownHeight = 114;
            this.cbx_partname.DropDownWidth = 121;
            this.cbx_partname.FormattingEnabled = true;
            this.cbx_partname.ItemDropDownHeight = 14;
            this.cbx_partname.Location = new System.Drawing.Point(98, 72);
            this.cbx_partname.Name = "cbx_partname";
            this.cbx_partname.Size = new System.Drawing.Size(100, 20);
            this.cbx_partname.TabIndex = 36;
            this.cbx_partname.DropDownClosed += new System.EventHandler(this.cbx_partname_DropDownClosed);
            // 
            // cbx_madeplace
            // 
            this.cbx_madeplace.ComboBoxHeight = 14;
            this.cbx_madeplace.DropDownHeight = 114;
            this.cbx_madeplace.DropDownWidth = 121;
            this.cbx_madeplace.FormattingEnabled = true;
            this.cbx_madeplace.ItemDropDownHeight = 14;
            this.cbx_madeplace.Location = new System.Drawing.Point(579, 71);
            this.cbx_madeplace.Name = "cbx_madeplace";
            this.cbx_madeplace.Size = new System.Drawing.Size(121, 20);
            this.cbx_madeplace.TabIndex = 35;
            this.cbx_madeplace.DropDownClosed += new System.EventHandler(this.cbx_madeplace_DropDownClosed);
            // 
            // cbx_dengji
            // 
            this.cbx_dengji.ComboBoxHeight = 14;
            this.cbx_dengji.DisplayMember = "Id";
            this.cbx_dengji.DropDownHeight = 114;
            this.cbx_dengji.DropDownWidth = 121;
            this.cbx_dengji.FormattingEnabled = true;
            this.cbx_dengji.ItemDropDownHeight = 14;
            this.cbx_dengji.Location = new System.Drawing.Point(325, 71);
            this.cbx_dengji.Name = "cbx_dengji";
            this.cbx_dengji.Size = new System.Drawing.Size(121, 20);
            this.cbx_dengji.TabIndex = 34;
            this.cbx_dengji.ValueMember = "Id";
            this.cbx_dengji.DropDownClosed += new System.EventHandler(this.cbx_dengji_DropDownClosed);
            // 
            // txb_price
            // 
            this.txb_price.Location = new System.Drawing.Point(805, 71);
            this.txb_price.Name = "txb_price";
            this.txb_price.Size = new System.Drawing.Size(121, 21);
            this.txb_price.TabIndex = 29;
            this.txb_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txb_price.TextChanged += new System.EventHandler(this.txb_price_TextChanged);
            this.txb_price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_price_KeyPress);
            this.txb_price.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txb_price_MouseDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(745, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 33;
            this.label7.Text = "产品价格";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(516, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "产品产地";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 31;
            this.label5.Text = "产品等级";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "执行标准";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "安全类别";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "产品种类";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(3, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(967, 10);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // txb_huohao
            // 
            this.txb_huohao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txb_huohao.Location = new System.Drawing.Point(98, 14);
            this.txb_huohao.Name = "txb_huohao";
            this.txb_huohao.Size = new System.Drawing.Size(100, 21);
            this.txb_huohao.TabIndex = 3;
            this.txb_huohao.TextChanged += new System.EventHandler(this.txb_huohao_TextChanged);
            this.txb_huohao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_huohao_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "产品货号";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.txb_fill);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 544);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 115);
            this.panel1.TabIndex = 2;
            // 
            // txb_fill
            // 
            this.txb_fill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_fill.Location = new System.Drawing.Point(231, 5);
            this.txb_fill.Name = "txb_fill";
            this.txb_fill.Size = new System.Drawing.Size(727, 21);
            this.txb_fill.TabIndex = 6;
            this.txb_fill.TextChanged += new System.EventHandler(this.txb_fill_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(174, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "填充面料";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "按规则填充信息设定";
            // 
            // dgv_material_fill
            // 
            this.dgv_material_fill.AllowUserToAddRows = false;
            this.dgv_material_fill.AllowUserToDeleteRows = false;
            this.dgv_material_fill.AllowUserToResizeRows = false;
            this.dgv_material_fill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_material_fill.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_material_fill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgv_material_fill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_material_fill.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgv_material_fill.Location = new System.Drawing.Point(0, 574);
            this.dgv_material_fill.MultiSelect = false;
            this.dgv_material_fill.Name = "dgv_material_fill";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_material_fill.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgv_material_fill.RowHeadersWidth = 20;
            this.dgv_material_fill.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_material_fill.RowTemplate.Height = 23;
            this.dgv_material_fill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_material_fill.Size = new System.Drawing.Size(970, 85);
            this.dgv_material_fill.TabIndex = 1;
            this.dgv_material_fill.TabStop = false;
            this.dgv_material_fill.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_material_fill_CellValueChanged);
            this.dgv_material_fill.Leave += new System.EventHandler(this.dgv_material_fill_Leave);
            // 
            // panel_center
            // 
            this.panel_center.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_center.BackColor = System.Drawing.SystemColors.Control;
            this.panel_center.Controls.Add(this.bt_add);
            this.panel_center.Controls.Add(this.bt_del);
            this.panel_center.Controls.Add(this.label10);
            this.panel_center.Controls.Add(this.dgv_material);
            this.panel_center.Location = new System.Drawing.Point(0, 369);
            this.panel_center.Name = "panel_center";
            this.panel_center.Size = new System.Drawing.Size(970, 174);
            this.panel_center.TabIndex = 3;
            // 
            // bt_add
            // 
            this.bt_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_add.Image = ((System.Drawing.Image)(resources.GetObject("bt_add.Image")));
            this.bt_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_add.Location = new System.Drawing.Point(770, 5);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 23);
            this.bt_add.TabIndex = 43;
            this.bt_add.Text = "添加行";
            this.bt_add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // bt_del
            // 
            this.bt_del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_del.Image = ((System.Drawing.Image)(resources.GetObject("bt_del.Image")));
            this.bt_del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_del.Location = new System.Drawing.Point(862, 5);
            this.bt_del.Name = "bt_del";
            this.bt_del.Size = new System.Drawing.Size(75, 23);
            this.bt_del.TabIndex = 42;
            this.bt_del.Text = "删除行";
            this.bt_del.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_del.UseVisualStyleBackColor = true;
            this.bt_del.Click += new System.EventHandler(this.bt_del_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "面料成份信息设定";
            // 
            // dgv_material
            // 
            this.dgv_material.AllowUserToAddRows = false;
            this.dgv_material.AllowUserToDeleteRows = false;
            this.dgv_material.AllowUserToResizeRows = false;
            this.dgv_material.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_material.AutoGenerateColumns = false;
            this.dgv_material.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_material.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgv_material.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_material.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.Type});
            this.dgv_material.DataSource = this.bindingSource_material;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_material.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgv_material.Location = new System.Drawing.Point(0, 31);
            this.dgv_material.MultiSelect = false;
            this.dgv_material.Name = "dgv_material";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_material.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dgv_material.RowHeadersWidth = 20;
            this.dgv_material.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_material.RowTemplate.Height = 23;
            this.dgv_material.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_material.Size = new System.Drawing.Size(970, 142);
            this.dgv_material.TabIndex = 4;
            this.dgv_material.TabStop = false;
            this.dgv_material.Leave += new System.EventHandler(this.dgv_material_Leave);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "成份内容";
            this.Type.Name = "Type";
            // 
            // bindingSource_material
            // 
            this.bindingSource_material.DataSource = typeof(Mondiland.BLLEntity.BEMaterialDataInfo);
            // 
            // saveas
            // 
            this.saveas.Image = ((System.Drawing.Image)(resources.GetObject("saveas.Image")));
            this.saveas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveas.Name = "saveas";
            this.saveas.Size = new System.Drawing.Size(36, 37);
            this.saveas.Text = "另存";
            this.saveas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.saveas.Click += new System.EventHandler(this.saveas_Click);
            // 
            // ProductManagerForm
            // 
            this.ClientSize = new System.Drawing.Size(970, 659);
            this.Controls.Add(this.panel_center);
            this.Controls.Add(this.dgv_material_fill);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.toolStrip);
            this.Name = "ProductManagerForm";
            this.Text = "产品信息管理";
            this.Load += new System.EventHandler(this.ProductManagerForm_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_material_fill)).EndInit();
            this.panel_center.ResumeLayout(false);
            this.panel_center.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_material)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_material)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton favorites;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txb_huohao;
        private System.Windows.Forms.Label label1;
        private UCControl.UCDataGridView dgv_material_fill;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txb_fill;
        private System.Windows.Forms.Panel panel_center;
        private UCControl.UCDataGridView dgv_material;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private UCControl.MultiColumnComboBoxEx cbx_standard;
        private UCControl.MultiColumnComboBoxEx cbx_safedata;
        private UCControl.MultiColumnComboBoxEx cbx_partname;
        private UCControl.MultiColumnComboBoxEx cbx_madeplace;
        private UCControl.MultiColumnComboBoxEx cbx_dengji;
        private System.Windows.Forms.TextBox txb_price;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txb_memo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chb_wash;
        private System.Windows.Forms.ToolStripButton add;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem menu_print_tag;
        private System.Windows.Forms.ToolStripMenuItem menu_print_wash;
        private System.Windows.Forms.Button bt_del;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.BindingSource bindingSource_material;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.CheckBox chb_bad;
        private System.Windows.Forms.ToolStripButton saveas;
    }
}
