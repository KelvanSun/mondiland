using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.BLLEntity
{
    public class BEProductDataAllInfo:BLLEntity
    {
        private string m_parntname = string.Empty;
        private string m_huohao = string.Empty;
        private string m_safedata = string.Empty;
        private string m_standarddata = string.Empty;
        private decimal m_price = 0;
        private string m_madeplace = string.Empty;
        private string m_dengji = string.Empty;
        private string m_memo = string.Empty;
        private string m_tag = string.Empty;
        private string m_wash = string.Empty;
        private int m_id = 0;
        private int m_pwash = 0;

        public int Pwash
        {
            get { return m_pwash; }
            set { m_pwash = value; }
        }
        
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }
        public string Tag
        {
            get { return m_tag; }
            set { m_tag = value; }
        }

        public string Wash
        {
            get { return m_wash; }
            set { m_wash = value; }
        }
        public string Memo
        {
            get { return m_memo; }
            set { m_memo = value; }
        }

        public string PartName
        {
            get { return m_parntname; }
            set { m_parntname = value; }
        }

        public string HuoHao
        {
            get { return m_huohao; }
            set { m_huohao = value; }
        }

        public string SafeData
        {
            get { return m_safedata; }
            set { m_safedata = value; }
        }

        public string StandardData
        {
            get { return m_standarddata; }
            set { m_standarddata = value; }
        }

        public decimal Price
        {
            get { return m_price; }
            set { m_price = value; }
        }

        public string MadePlace
        {
            get { return m_madeplace;}
            set {m_madeplace = value;}
        }

        public string DengJi
        {
            get { return m_dengji; }
            set { m_dengji = value;}
        }
    }
}
