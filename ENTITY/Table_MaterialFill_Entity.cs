using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Entity
{
    public class Table_MaterialFill_Entity:BaseEntity
    {
        private int m_id = 0;
        private int m_product_id = 0;
        private string m_size_name = string.Empty;
        private string m_type = string.Empty;
        private string m_fill = string.Empty;
        private long m_lastamp = 0;

        public long LasTamp
        {
            get { return m_lastamp; }
            set { m_lastamp = value; }
        }
        public int Product_Id
        {
            get { return m_product_id; }
            set { m_product_id = value; }
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

        public string Fill
        {
            get { return m_fill; }
            set
            {
                if (value.Length > 50)
                    m_fill = value.Substring(0, 49);
                else
                    m_fill = value;
            }
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
    }
}
