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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintForm));
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.bt_print = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_select = new Mondiland.UCControl.MultiColumnComboBoxEx();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(276, 38);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(78, 21);
            this.numericUpDown.TabIndex = 1;
            this.numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Enter += new System.EventHandler(this.numericUpDown_Enter);
            // 
            // bt_print
            // 
            this.bt_print.Image = ((System.Drawing.Image)(resources.GetObject("bt_print.Image")));
            this.bt_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_print.Location = new System.Drawing.Point(340, 80);
            this.bt_print.Name = "bt_print";
            this.bt_print.Size = new System.Drawing.Size(87, 23);
            this.bt_print.TabIndex = 9;
            this.bt_print.Text = "打印   ";
            this.bt_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_print.UseVisualStyleBackColor = true;
            this.bt_print.Click += new System.EventHandler(this.bt_print_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "打印尺寸";
            // 
            // cbx_select
            // 
            this.cbx_select.ComboBoxHeight = 14;
            this.cbx_select.DropDownHeight = 114;
            this.cbx_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_select.DropDownWidth = 121;
            this.cbx_select.FormattingEnabled = true;
            this.cbx_select.ItemDropDownHeight = 14;
            this.cbx_select.Location = new System.Drawing.Point(123, 38);
            this.cbx_select.Name = "cbx_select";
            this.cbx_select.Size = new System.Drawing.Size(133, 20);
            this.cbx_select.TabIndex = 2;
            this.cbx_select.DropDownClosed += new System.EventHandler(this.cbx_select_DropDownClosed);
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Mondiland.UI.ProductObject);
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 115);
            this.Controls.Add(this.cbx_select);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bt_print);
            this.Controls.Add(this.numericUpDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打印";
            this.Load += new System.EventHandler(this.PrintForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Button bt_print;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bindingSource;
        private UCControl.MultiColumnComboBoxEx cbx_select;
    }
}