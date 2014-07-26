using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Entity
{
    public class Table_UserMenu_Entity:BaseEntity
    {
        private int m_id = 0;
        private int m_user_id = 0;
        private int m_menu_id = 0;

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public int User_Id
        {
            get { return m_user_id; }
            set { m_user_id = value; }
        }

        public int Menu_Id
        {
            get { return m_menu_id; }
            set { m_menu_id = value; }
        }
    }
}
