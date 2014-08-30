using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.BLLEntity
{
    public class BEProductDataInfo:BLLEntity
    {
        private int m_id = 0;
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
        private bool m_pwash = false;
        private bool m_pbad = false;
        private string m_lastamp = string.Empty;


        public bool Pbad
        {
            get { return m_pbad; }
            set { m_pbad = value; }
        }
        public string LasTamp
        {
            get { return m_lastamp; }
            set { m_lastamp = value; }
        }

        public bool Pwash
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
            set {m_huohao = value;}
        }
    }
}
