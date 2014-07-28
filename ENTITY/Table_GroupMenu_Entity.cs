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
        
        public int Group_Id
        {
            get { return m_group_id; }
            set { m_group_id  = value; }
        }

        public int Menu_Id
        {
            get { return m_menu_id; }
            set { m_menu_id = value; }
        }
    }
}
