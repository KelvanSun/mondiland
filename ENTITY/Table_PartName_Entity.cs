using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Entity
{
    public class Table_PartName_Entity:BaseEntity
    {
        private string m_name = string.Empty;
        private string m_barcode = string.Empty;
        private int m_size_class_id = 0;
        private int m_safe_id = 0;
        private int m_standard_id = 0;
        private int m_pwash = 0;
        private int m_pbad = 0;
        private string m_memo = string.Empty;

        public int Pbad
        {
            get { return m_pbad; }
            set { m_pbad = value; }
        }
        public int Pwash
        {
            get { return m_pwash; }
            set { m_pwash = value; }
        }

        public int Safe_Id
        {
            get { return m_safe_id; }
            set { m_safe_id = value; }
        }

        public int Standard_Id
        {
            get { return m_standard_id; }
            set { m_standard_id = value; }
        }


        public string Name
        {
            get { return m_name; }
            set
            {
                if (value.Length > 50)
                    m_name = value.Substring(0, 49);
                else
                    m_name = value;
            }

        }
   
        public string Barcode
        {
            get { return m_barcode; }
            set
            {
                if (value.Length > 50)
                    m_barcode = value.Substring(0, 49);
                else
                    m_barcode = value;
            }
        }
    
        public int SizeClass_id
        {
            get { return m_size_class_id; }
            set { m_size_class_id = value; }
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
