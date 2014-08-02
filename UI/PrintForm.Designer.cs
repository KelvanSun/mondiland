namespace Mondiland.UI
{
    partial class PrintForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_select = new System.Windows.Forms.ComboBox();
            this.rb_tag = new System.Windows.Forms.RadioButton();
            this.rb_wash = new System.Windows.Forms.RadioButton();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.bt_print = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_select = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txb_price = new System.Windows.Forms.TextBox();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txb_huohao = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lab_daoxiao = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "产品货号";
            // 
            // cbx_select
            // 
            this.cbx_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_select.FormattingEnabled = true;
            this.cbx_select.Location = new System.Drawing.Point(70, 293);
            this.cbx_select.Name = "cbx_select";
            this.cbx_select.Size = new System.Drawing.Size(168, 20);
            this.cbx_select.TabIndex = 5;
            this.cbx_select.DropDownClosed += new System.EventHandler(this.cbx_select_DropDownClosed);
            // 
            // rb_tag
            // 
            this.rb_tag.AutoSize = true;
            this.rb_tag.Checked = true;
            this.rb_tag.Location = new System.Drawing.Point(166, 257);
            this.rb_tag.Name = "rb_tag";
            this.rb_tag.Size = new System.Drawing.Size(83, 16);
            this.rb_tag.TabIndex = 6;
            this.rb_tag.TabStop = true;
            this.rb_tag.Text = "打印标价牌";
            this.rb_tag.UseVisualStyleBackColor = true;
            // 
            // rb_wash
            // 
            this.rb_wash.AutoSize = true;
            this.rb_wash.Location = new System.Drawing.Point(255, 257);
            this.rb_wash.Name = "rb_wash";
            this.rb_wash.Size = new System.Drawing.Size(83, 16);
            this.rb_wash.TabIndex = 7;
            this.rb_wash.TabStop = true;
            this.rb_wash.Text = "打印洗唛牌";
            this.rb_wash.UseVisualStyleBackColor = true;
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(244, 293);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(78, 21);
            this.numericUpDown.TabIndex = 8;
            this.numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bt_print
            // 
            this.bt_print.Location = new System.Drawing.Point(328, 291);
            this.bt_print.Name = "bt_print";
            this.bt_print.Size = new System.Drawing.Size(75, 23);
            this.bt_print.TabIndex = 9;
            this.bt_print.Text = "打印";
            this.bt_print.UseVisualStyleBackColor = true;
            this.bt_print.Click += new System.EventHandler(this.bt_print_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "打印尺寸";
            // 
            // bt_select
            // 
            this.bt_select.Location = new System.Drawing.Point(183, 24);
            this.bt_select.Name = "bt_select";
            this.bt_select.Size = new System.Drawing.Size(75, 23);
            this.bt_select.TabIndex = 11;
            this.bt_select.Text = "选择";
            this.bt_select.UseVisualStyleBackColor = true;
            this.bt_select.Click += new System.EventHandler(this.bt_select_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(210, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "产品价格";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "产品产地";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "产品等级";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "执行标准";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "安全类别";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "产品种类";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "产品货号";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txb_price);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(14, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 182);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // txb_price
            // 
            this.txb_price.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Price", true));
            this.txb_price.Location = new System.Drawing.Point(269, 107);
            this.txb_price.Name = "txb_price";
            this.txb_price.ReadOnly = true;
            this.txb_price.Size = new System.Drawing.Size(100, 21);
            this.txb_price.TabIndex = 27;
            this.txb_price.TabStop = false;
            this.txb_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txb_price.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_price_KeyDown);
            this.txb_price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_price_KeyPress);
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Mondiland.BLLEntity.BEProductDataAllInfo);
            // 
            // textBox6
            // 
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "MadePlace", true));
            this.textBox6.Location = new System.Drawing.Point(269, 66);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(100, 21);
            this.textBox6.TabIndex = 26;
            this.textBox6.TabStop = false;
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DengJi", true));
            this.textBox5.Location = new System.Drawing.Point(269, 31);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(100, 21);
            this.textBox5.TabIndex = 25;
            this.textBox5.TabStop = false;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "StandardData", true));
            this.textBox4.Location = new System.Drawing.Point(72, 144);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(117, 21);
            this.textBox4.TabIndex = 24;
            this.textBox4.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "SafeData", true));
            this.textBox3.Location = new System.Drawing.Point(72, 107);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(117, 21);
            this.textBox3.TabIndex = 23;
            this.textBox3.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "HuoHao", true));
            this.textBox2.Location = new System.Drawing.Point(72, 69);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(117, 21);
            this.textBox2.TabIndex = 22;
            this.textBox2.TabStop = false;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "PartName", true));
            this.textBox1.Location = new System.Drawing.Point(72, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(117, 21);
            this.textBox1.TabIndex = 21;
            this.textBox1.TabStop = false;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txb_huohao
            // 
            this.txb_huohao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txb_huohao.Location = new System.Drawing.Point(70, 25);
            this.txb_huohao.Name = "txb_huohao";
            this.txb_huohao.Size = new System.Drawing.Size(100, 21);
            this.txb_huohao.TabIndex = 1;
            this.txb_huohao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_huohao_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(359, 260);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = " ";
            // 
            // lab_daoxiao
            // 
            this.lab_daoxiao.AutoSize = true;
            this.lab_daoxiao.ForeColor = System.Drawing.Color.Red;
            this.lab_daoxiao.Location = new System.Drawing.Point(335, 259);
            this.lab_daoxiao.Name = "lab_daoxiao";
            this.lab_daoxiao.Size = new System.Drawing.Size(65, 12);
            this.lab_daoxiao.TabIndex = 23;
            this.lab_daoxiao.Text = "(未知大小)";
            this.lab_daoxiao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 331);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lab_daoxiao);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txb_huohao);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bt_select);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bt_print);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.rb_wash);
            this.Controls.Add(this.rb_tag);
            this.Controls.Add(this.cbx_select);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品信息打印";
            this.Load += new System.EventHandler(this.PrintForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_select;
        private System.Windows.Forms.RadioButton rb_tag;
        private System.Windows.Forms.RadioButton rb_wash;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Button bt_print;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Button bt_select;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txb_price;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txb_huohao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lab_daoxiao;
        private System.Windows.Forms.Button button1;
    }
}