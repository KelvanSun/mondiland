using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.BLLEntity
{
    public class BEUserMenuFavorites:BLLEntity
    {
        private string m_menu_name = string.Empty;
        private int m_menu_bmp = 0;
        private string m_menu_window = string.Empty;
        private string m_menu_memo = string.Empty;

        public string MenuMemo
        {
            get { return m_menu_memo; }
            set { m_menu_memo = value; }
        }

        public string MenuWindow
        {
            get { return m_menu_window; }
            set { m_menu_window = value; }

        }

        public string MenuName
        {
            get { return m_menu_name; }
            set { m_menu_name = value; }
        }

        public int MenuBmp
        {
            get { return m_menu_bmp; }
            set { m_menu_bmp = value; }
        }
    }
}
