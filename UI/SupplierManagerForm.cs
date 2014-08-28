using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Mondiland.BLL;
using Mondiland.Obj;

namespace Mondiland.UI
{
    public partial class SupplierManagerForm : Mondiland.UI.BaseForm,IMenuFavorites
    {
        private bool m_favorites = false;
        private BindingList<SupplierObject> main_list = new BindingList<SupplierObject>();

        public SupplierManagerForm()
        {
            InitializeComponent();
            
            
            UpdateFavoritesMenu();                       

        }

        /// <summary>
        /// 更新收藏菜单状态
        /// </summary>
        private void UpdateFavoritesMenu()
        {
            m_favorites = BLLFactory<BLLMenuInfo>.Instance.IsUserMenuFavorites(Program.main_form.UserId,
                                                                               this.Name);
                        
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
            if (BLLFactory<BLLMenuInfo>.Instance.UnFavorites(Program.main_form.UserId, this.Name))
                MessageUtil.ShowWarning("成功取消快捷方式!");
            else
                MessageUtil.ShowWarning("取消快捷方式失败!");

        }

        public void SetFavorites()
        {
            if (BLLFactory<BLLMenuInfo>.Instance.SetFavorites(Program.main_form.UserId, this.Name))
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

        private void add_Click(object sender, EventArgs e)
        {
            SupplierObject ob = new SupplierObject();
            
            SupplierAEForm form = new SupplierAEForm(ob);
            form.ShowDialog();
        }

        private void SupplierManagerForm_Load(object sender, EventArgs e)
        {
            this.cbx_query_type.Text = "拼音码";
           
        }

        private void cbx_query_type_DropDownClosed(object sender, EventArgs e)
        {
            this.txb_query_text.Text = string.Empty;
            this.txb_query_text.Focus();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txb_query_text.Text)) return;

            main_list.Clear();

            if(cbx_query_type.Text == "拼音码")
            {
                              
                IEnumerator<int> ator = BLLFactory<BLLSupplierInfo>.Instance.QuerySupplierMByPym(this.txb_query_text.Text.Trim()).GetEnumerator();

                while(ator.MoveNext())
                {
                    SupplierObject ob = new SupplierObject(ator.Current);

                    main_list.Add(ob);
                }
               
            }

            if(cbx_query_type.Text == "公司简称")
            {
                IEnumerator<int> ator = BLLFactory<BLLSupplierInfo>.Instance.QuerySupplierMByName(this.txb_query_text.Text.Trim()).GetEnumerator();

                while (ator.MoveNext())
                {
                    SupplierObject ob = new SupplierObject(ator.Current);

                    main_list.Add(ob);
                }
            }

            if(cbx_query_type.Text == "公司全称")
            {
                IEnumerator<int> ator = BLLFactory<BLLSupplierInfo>.Instance.QuerySupplierMByIntactName(this.txb_query_text.Text.Trim()).GetEnumerator();

                while (ator.MoveNext())
                {
                    SupplierObject ob = new SupplierObject(ator.Current);

                    main_list.Add(ob);
                }
            }

            this.bindingSource_query.DataSource = main_list;

            this.label_search_result.Text = string.Format("共查询到 {0} 条记录", main_list.Count);

            this.dgv_main.Focus();

        }

        private void txb_query_text_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button_search_Click(sender, e);
            }
        }

        private void dgv_main_SelectionChanged(object sender, EventArgs e)
        {
            if (this.bindingSource_query.Current == null)
            {
                this.bindingSource_main.DataSource = new SupplierObject();
                return;
            }
            this.bindingSource_main.DataSource = this.bindingSource_query.Current as SupplierObject;
        }

        private void tsmi_supplier_add_Click(object sender, EventArgs e)
        {
            SupplierObject ob = new SupplierObject();

            SupplierAEForm form = new SupplierAEForm(ob);
            form.ShowDialog();
        }

        private void tsmi_supplier_edit_Click(object sender, EventArgs e)
        {
            if(this.bindingSource_query.Current == null)
            {
                MessageUtil.ShowWarning("先查询到记录再编辑!");
                return;
            }

            SupplierAEForm form = new SupplierAEForm(this.bindingSource_query.Current as SupplierObject);
            form.ShowDialog();

            this.main_list.Clear();
        }
      
    }
}
