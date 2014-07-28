using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Entity
{
    public class Table_SizeData_Entity:BaseEntity
    {
        private int m_id = 0;
        private int m_class_id = 0;
        private string m_size_name = string.Empty;
        private string m_size_type = string.Empty;
        private string m_other = string.Empty;
        private string m_memo = string.Empty;
        private long m_lasLasTamp = 0;

        public long LasTamp
        {
            get { return m_lasLasTamp; }
            set { m_lasLasTamp = value; }
        }

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public int Class_Id
        {
            get { return m_class_id; }
            set { m_class_id = value; }
        }

        public string Size_Name
        {
            get { return m_size_name; }
            set
            {
                if (value.Length > 50)
                    m_size_name = value.Substring(0, 49);
                else
                    m_size_name = value;
            }
        }

        public string Size_Type
        {
            get { return m_size_type; }
            set
            {
                if (value.Length > 10)
                    m_size_type = value.Substring(0, 9);
                else
                    m_size_type = value;
            }
        }

        public string Other
        {
            get { return m_other; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    m_other = "";
                else
                {
                    if (value.Length > 50)
                        m_other = value.Substring(0, 49);
                    else
                        m_other = value;
                }
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
