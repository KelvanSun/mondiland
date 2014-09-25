using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Mondiland.Global;
using Mondiland.Obj;

namespace Mondiland.UI
{
    public partial class StoreManagerForm : Mondiland.UI.BaseForm,IMenuFavorites
    {
        private bool m_favorites = false;
        
        public StoreManagerForm()
        {
            InitializeComponent();

            UpdateFavoritesMenu();

            this.progressBar.Location = new System.Drawing.Point((this.Width - this.progressBar.Size.Width) / 2,
                (this.Height - this.progressBar.Size.Height) / 2);
        }

        /// <summary>
        /// 更新收藏菜单状态
        /// </summary>
        private void UpdateFavoritesMenu()
        {
            m_favorites = AuthorManager.LoginUser.IsUserMenuFavorites(this.Name);

            if (m_favorites)
            {
                this.toolStrip.Items["favorites"].Text = "取消收藏";
                this.toolStrip.Items["favorites"].ToolTipText = "取消收藏";
            }
            else
            {
                this.toolStrip.Items["favorites"].Text = "收藏";
                this.toolStrip.Items["favorites"].ToolTipText = "收藏";
            }
        }


        public void UnFavorites()
        {
            if (AuthorManager.LoginUser.UnFavorites(this.Name))
                MessageUtil.ShowWarning("成功取消快捷方式!");
            else
                MessageUtil.ShowWarning("取消快捷方式失败!");

        }

        public void SetFavorites()
        {
            if (AuthorManager.LoginUser.SetFavorites(this.Name))
                MessageUtil.ShowWarning("成功收藏快捷方式!");
            else
                MessageUtil.ShowWarning("收藏快捷方式失败!");
        }

        private void favorites_Click(object sender, EventArgs e)
        {
            if (m_favorites)
                UnFavorites();
            else
                SetFavorites();

            UpdateFavoritesMenu();
        }

        private void tsmi_add_Click(object sender, EventArgs e)
        {
            StoreObject obj = new StoreObject();
            StoreAEForm form = new StoreAEForm(obj);

            form.ShowDialog();

            tsb_all_Click(sender, e);
        }

        private void tsmi_edit_Click(object sender, EventArgs e)
        {
            if (this.storeObjectBindingSource.Current == null)
            {
                MessageUtil.ShowWarning("先查询到记录再编辑!");
                return;
            }

            StoreAEForm form = new StoreAEForm(this.storeObjectBindingSource.Current as StoreObject);
            form.ShowDialog();

            tsb_all_Click(sender, e);
        }

        private void tsb_all_Click(object sender, EventArgs e)
        {
            this.storeObjectBindingSource.DataSource = StoresManager.GetLogAllList();

            this.label_search_result.Text = string.Format("共有 {0} 家店铺", this.storeObjectBindingSource.Count);
        }

        private void StoreManagerForm_Load(object sender, EventArgs e)
        {
            
            tsb_all_Click(sender, e);
        }

        private void tsb_view_Click(object sender, EventArgs e)
        {
            if (this.storeObjectBindingSource.Current == null)
            {
                return;
            }

            StoreInfoViewForm form = new StoreInfoViewForm(this.storeObjectBindingSource.Current as StoreObject);

            form.ShowDialog();
        }

        private void dgv_main_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsb_view_Click(sender, e);
        }

        private void tsb_export_Click(object sender, EventArgs e)
        {
            if(this.storeObjectBindingSource.Count == 0)
            {
                MessageUtil.ShowWarning("当前无记录无法导出信息");
                return;
            }

            if(saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var excel = new Microsoft.Office.Interop.Excel.Application();
                var excelBook = excel.Workbooks.Add(Type.Missing);
                var excelSheet = excelBook.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;

                //处理标题
                string[] arrayColumn = new string[] { "店名", "地址","店长","店长手机","店厅电话","备注信息"};
                int[] arrayColumnWidth = new int[] { 15, 60, 15, 15, 15, 100 };

                for (int index = 0; index < 6;index ++ )
                {
                    excelSheet.get_Range(excel.Cells[1, index + 1] as Microsoft.Office.Interop.Excel.Range, excel.Cells[1, index + 1] as Microsoft.Office.Interop.Excel.Range).Font.Bold = true;
                    excelSheet.get_Range(excel.Cells[1, index + 1] as Microsoft.Office.Interop.Excel.Range, excel.Cells[1, index + 1] as Microsoft.Office.Interop.Excel.Range).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    excelSheet.get_Range(excel.Cells[1, index + 1] as Microsoft.Office.Interop.Excel.Range, excel.Cells[1, index + 1] as Microsoft.Office.Interop.Excel.Range).Font.Size = 10;
                    excelSheet.get_Range(excel.Cells[1, index + 1] as Microsoft.Office.Interop.Excel.Range, excel.Cells[1, index + 1] as Microsoft.Office.Interop.Excel.Range).Value = arrayColumn[index];
                    excelSheet.get_Range(excel.Cells[1, index + 1] as Microsoft.Office.Interop.Excel.Range, excel.Cells[1, index + 1] as Microsoft.Office.Interop.Excel.Range).Columns.ColumnWidth = arrayColumnWidth[index];
                }

                int row = 2;
                int stepValue = 0;
                string[] arrayText = new string[6];

                this.progressBar.Visible = true;
                this.progressBar.Maximum = this.storeObjectBindingSource.Count;
                this.progressBar.Minimum = 0;
                this.progressBar.Step = 1;

                foreach(StoreObject obj in this.storeObjectBindingSource)
                {
                    arrayText[0] = obj.Name;
                    arrayText[1] = obj.Address;
                    arrayText[2] = obj.Manager;
                    arrayText[3] = obj.ManagerPhone;
                    arrayText[4] = obj.Phone;
                    arrayText[5] = obj.Memo;
                    
                    
                    for(int index = 0;index < 6;index ++)
                    {
                        excelSheet.get_Range(excel.Cells[row, index + 1] as Microsoft.Office.Interop.Excel.Range, excel.Cells[row, index + 1] as Microsoft.Office.Interop.Excel.Range).Font.Size = 10;
                        excelSheet.get_Range(excel.Cells[row, index + 1] as Microsoft.Office.Interop.Excel.Range, excel.Cells[row, index + 1] as Microsoft.Office.Interop.Excel.Range).Value = arrayText[index];
                    }

                    ++row;

                    this.progressBar.Value = ++stepValue;
                }

                
                excelSheet.Name = "全国店铺信息";

                excelBook.Saved = true;
                excelBook.SaveCopyAs(saveFileDialog.FileName);

                excel.Quit();
                GC.Collect();

                this.progressBar.Visible = false;

                MessageUtil.ShowTips("导出成功!");

            }
        }
    }
}
