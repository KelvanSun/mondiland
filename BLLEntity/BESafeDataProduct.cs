using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.BLLEntity
{
    public class BESafeDataProduct:BLLEntity
    {
        private int m_id = 0;
        private string m_type = string.Empty;
        private string m_memo = string.Empty;

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public string Type
        {
            get { return m_type; }
            set { m_type = value; }
        }

        public string Memo
        {
            get { return m_memo; }
            set { m_memo = value; }
        }
    }
}
