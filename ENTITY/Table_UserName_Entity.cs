using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Entity
{
    public class Table_UserName_Entity:BaseEntity
    {
        private int m_id = 0;
        private string m_name = string.Empty;
        private string m_pwd = string.Empty;

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public string Name
        {
            get { return m_name; }
            set
            {
                if (value.Length > 50)
                    m_name = value.Substring(0, 49);
                else
                    m_name = value;
            }
        }

        public string Pwd
        {
            get { return m_pwd; }
            set
            {
                if (value.Length > 50)
                    m_pwd = value.Substring(0, 49);
                else
                    m_pwd = value;
            }
        }
    }
}
