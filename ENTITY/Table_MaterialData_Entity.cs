using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Entity
{
    public class Table_MaterialData_Entity:BaseEntity
    {
        private int m_id = 0;
        private int m_product_id = 0;
        private int m_order_index = 0;
        private string m_type = string.Empty;

        public int Order_Index
        {
            get { return m_order_index; }
            set { m_order_index = value; }
        }
        
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public int Product_Id
        {
            get { return m_product_id; }
            set { m_product_id = value; }
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
