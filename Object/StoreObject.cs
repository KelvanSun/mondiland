using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Obj
{
    public class StoreObject
    {
        private int m_id = 0;
        private string m_name = string.Empty;
        private string m_address = string.Empty;
        private string m_manager = string.Empty;
        private string m_manager_phone = string.Empty;
        private string m_phone = string.Empty;
        private string m_memo = string.Empty;
        private System.Guid m_lastamp = System.Guid.Empty;

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public string Address
        {
            get { return m_address; }
            set { m_address = value; }
        }

        public string Manager
        {
            get { return m_manager; }
            set { m_manager = value; }
        }

        public string ManagerPhone
        {
            get { return m_manager_phone; }
            set { m_manager_phone = value; }
        }

        public string Phone
        {
            get { return m_phone; }
            set { m_phone = value; }
        }

        public string Memo
        {
            get { return m_memo; }
            set { m_memo = value; }
        }

        public System.Guid LasTamp
        {
            get { return m_lastamp; }
            set { m_lastamp = value; }
        }
    }
}
