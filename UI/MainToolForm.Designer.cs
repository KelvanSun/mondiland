namespace Mondiland.UI
{
    partial class MainToolForm
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
            this.outlookBar = new UtilityLibrary.WinControls.OutlookBar();
            this.SuspendLayout();
            // 
            // outlookBar
            // 
            this.outlookBar.AnimationSpeed = 20;
            this.outlookBar.BackgroundBitmap = null;
            this.outlookBar.BorderType = UtilityLibrary.WinControls.BorderType.None;
            this.outlookBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outlookBar.FlatArrowButtons = false;
            this.outlookBar.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.outlookBar.LeftTopColor = System.Drawing.Color.Empty;
            this.outlookBar.Location = new System.Drawing.Point(0, 0);
            this.outlookBar.Name = "outlookBar";
            this.outlookBar.RightBottomColor = System.Drawing.Color.Empty;
            this.outlookBar.Size = new System.Drawing.Size(174, 590);
            this.outlookBar.TabIndex = 0;
            this.outlookBar.Text = "outlookBar1";
            // 
            // MainToolForm
            // 
            this.ClientSize = new System.Drawing.Size(174, 590);
            this.Controls.Add(this.outlookBar);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "MainToolForm";
            this.Text = "导航条";
            this.ResumeLayout(false);

        }

        #endregion

        private UtilityLibrary.WinControls.OutlookBar outlookBar;
    }
}
