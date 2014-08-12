using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Mondiland.BLL;
using Mondiland.BLLEntity;
using Mondiland.Global;

namespace Mondiland.UI
{
    public partial class DefaultForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public DefaultForm()
        {
            InitializeComponent();
        }

        public void LoadFavoritesMenu()
        {
            this.flowLayoutPanel.Controls.Clear();

            IEnumerator<BEUserMenuFavorites> ator = BLLFactory<BLLMenuInfo>.Instance.GetUserMenuFavoritesList(Program.main_form.UserId).GetEnumerator();

            while(ator.MoveNext())
            {
                UCListViewItem item = new UCListViewItem();

                item.ItemCaption = ator.Current.MenuName;
                item.ItemImage = Program.main_form.imageList.Images[ator.Current.MenuBmp];
                item.ItemMemo = ator.Current.MenuMemo;
                item.ItemFormName = ator.Current.MenuWindow;

                this.flowLayoutPanel.Controls.Add(item);
            }

        }
    }
}
