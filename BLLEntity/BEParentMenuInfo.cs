using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.BLLEntity
{
    public class BEParentMenuInfo:BLLEntity
    {
        /// <summary>
        /// 父菜单的名称
        /// </summary>
        private string m_Menu_name;
        /// <summary>
        /// 父菜单的ID号
        /// </summary>
        private int m_Menu_id;

        public string Menu_name
        {
            get { return m_Menu_name; }
            set { m_Menu_name = value; }
        }

        public int Menu_id
        {
            get { return m_Menu_id; }
            set { m_Menu_id = value; }
        }
    }
}
