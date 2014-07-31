using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.BLLEntity
{
    public class BEPartNameProduct:BLLEntity
    {
        private int m_id = 0;
        private string m_partname = string.Empty;
        private string m_class_type = string.Empty;
        private string m_memo = string.Empty;

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public string PartName
        {
            get { return m_partname; }
            set { m_partname = value; }
        }

        public string ClassType
        {
            get { return m_class_type; }
            set { m_class_type = value; }
        }

        public string Memo
        {
            get { return m_memo; }
            set { m_memo = value; }
        }

    }
}
