using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Entity
{
    public class BaseEntity
    {
        protected int m_id = 0;
        protected string m_lastamp = string.Empty;

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public string LasTamp
        {
            get { return m_lastamp; }
            set { m_lastamp = value; }
        }

    }
}
