using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Entity
{
    public class Table_MadePlace_Entity:BaseEntity
    {
        private int m_id = 0;
        private string m_type = string.Empty;
        private string m_memo = string.Empty;
        private long m_lastamp = 0;

        public long LastTamp
        {
            get { return m_lastamp; }
            set { m_lastamp = value; }
        }

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public string Type
        {
            get { return m_type; }
            set
            {
                if (value.Length > 50)
                    m_type = value.Substring(0, 49);
                else
                    m_type = value;
            }
        }

        public string Memo
        {
            get { return m_memo; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    m_memo = "";
                else
                {
                    if (value.Length > 400)
                        m_memo = value.Substring(0, 399);
                    else
                        m_memo = value;
                }
            }
        }
    }
}
