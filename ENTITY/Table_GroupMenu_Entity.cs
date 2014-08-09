using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Entity
{
    public class Table_GroupMenu_Entity:BaseEntity
    {
        private int m_group_id = 0;
        private int m_menu_id = 0;
        private int m_menu_order = 0;

        public int MenuOrder
        {
            get { return m_menu_order; }
            set { m_menu_order = value; }
        }
        
        public int GroupId
        {
            get { return m_group_id; }
            set { m_group_id  = value; }
        }

        public int MenuId
        {
            get { return m_menu_id; }
            set { m_menu_id = value; }
        }
    }
}
