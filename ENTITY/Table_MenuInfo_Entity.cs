using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Entity
{
    public class Table_MenuInfo_Entity:BaseEntity
    {
        private int m_id = 0;
        private string m_menu_name = string.Empty;
        private int m_menu_bmp = 0;
        private string m_menu_window = string.Empty;
        private string m_menu_memo = string.Empty;
        private long m_lastamp = 0;

        public long LasTamp
        {
            get { return m_lastamp; }
            set { m_lastamp = value; }
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
                if (value.Length > 50)
                    m_menu_window = value.Substring(0, 49);
                else
                    m_menu_window = value;
            }

        }
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
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
