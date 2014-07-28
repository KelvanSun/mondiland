using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Entity
{
    public class Table_TagPrintTemplate_Entity:BaseEntity
    {
        private string m_type = string.Empty;
        private string m_file_name = string.Empty;
        private string m_memo = string.Empty;
 
        public string File_Name
        {
            get { return m_file_name; }
            set 
            {
                if (value.Length > 50)
                    m_file_name = value.Substring(0, 49);
                else
                    m_file_name = value;
            }
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
