using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Entity
{
    public class Table_ProductData_Entity:BaseEntity
    {
        private int m_partname_id = 0;
        private string m_huohao = string.Empty;
        private int m_safedata_id = 0;
        private int m_standarddata_id = 0;
        private decimal m_price = 0;
        private int m_madeplace_id = 0;
        private int m_dengji_id = 0;
        private int m_tag_id = 0;
        private int m_wash_id = 0;
        private string m_memo = string.Empty;
        private int m_pwash = 0;

        public int Pwash
        {
            get { return m_pwash; }
            set { m_pwash = value; }
        }
        public int Dengji_Id
        {
            get { return m_dengji_id; }
            set { m_dengji_id = value; }
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
        public int Wash_Id
        {
            get { return m_wash_id; }
            set { m_wash_id = value; }
        }
        public int Tag_Id
        {
            get { return m_tag_id; }
            set { m_tag_id = value; }
        }
        public int MadePlace_Id
        {
            get { return m_madeplace_id; }
            set { m_madeplace_id = value; }
        }
        public decimal Price
        {
            get { return m_price; }
            set { m_price = value; }
        }
        public int StandardData_Id
        {
            get { return m_standarddata_id; }
            set { m_standarddata_id = value; }
        }

        public int SafeData_Id
        {
            get { return m_safedata_id; }
            set { m_safedata_id = value; }
        }

        public int PartName_Id
        {
            get { return m_partname_id; }
            set { m_partname_id = value; }
        }

        public string HuoHao
        {
            get { return m_huohao; }
            set
            {
                if (value.Length > 20)
                    m_huohao = value.Substring(0, 19);
                else
                    m_huohao = value;
            }
        }

    }
}
