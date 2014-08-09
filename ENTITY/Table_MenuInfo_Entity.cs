using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Entity
{
    public class Table_MenuInfo_Entity:BaseEntity
    {
        private string m_menu_name = string.Empty;
        private int m_menu_bmp = 0;
        private string m_menu_window = string.Empty;
        private int m_menu_parent = 0;
        private int m_menu_order = 0;
        private string m_menu_memo = string.Empty;

        public int MenuOrder
        {
            get { return m_menu_order; }
            set { m_menu_order = value; }
        }
        public int MenuParent
        {
            get { return m_menu_parent; }
            set { m_menu_parent = value; }
        }
        
        public string MenuMemo
        {
            get { return m_menu_memo; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    m_menu_memo = "";
                else
                {
                    if (value.Length > 400)
                        m_menu_memo = value.Substring(0, 399);
                    else
                        m_menu_memo = value;
                }
            }
        }

        public string MenuWindow
        {
            get { return m_menu_window; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    m_menu_window = "";
                else
                {
                    if (value.Length > 50)
                        m_menu_window = value.Substring(0, 49);
                    else
                        m_menu_window = value;
                }
            }

        }
 
        public string MenuName
        {
            get { return m_menu_name; }
            set
            {
                if (value.Length > 50)
                    m_menu_name = value.Substring(0, 49);
                else
                    m_menu_name = value;
            }

        }

        public int MenuBmp
        {
            get { return m_menu_bmp; }
            set { m_menu_bmp = value; }
        }



    }
}
