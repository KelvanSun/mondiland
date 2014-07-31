using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.BLLEntity
{
    public class BEProductDataReadProduct : BLLEntity
    {
        private int m_id = 0;
        private int m_partname_id = 0;
        private string m_huohao = string.Empty;
        private int m_safedata_id = 0;
        private int m_standarddata_id = 0;
        private decimal m_price = 0;
        private int m_madeplace_id = 0;
        private int m_dengji_id = 0;
        private string m_tag = string.Empty;
        private int m_wash_id = 0;
        private string m_memo = string.Empty;
        private int m_pwash = 0;
        private long m_lasLasTamp = 0;

        public long LasTamp
        {
            get { return m_lasLasTamp; }
            set { m_lasLasTamp = value; }
        }

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
                    m_memo = value;
            }
        }
        public int Wash_Id
        {
            get { return m_wash_id; }
            set { m_wash_id = value; }
        }
        public string Tag
        {
            get { return m_tag; }
            set { m_tag = value; }
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

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public int PartName_Id
        {
            get { return m_partname_id; }
            set { m_partname_id = value; }
        }

        public string HuoHao
        {
            get { return m_huohao; }
            set { m_huohao = value; }
        }
    }
}
