using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.BLLEntity
{
    public class BESupplierMInfo:BLLEntity
    {
        private int m_id = 0;
        private int m_class_id = 0;
        private string m_pym = string.Empty;
        private string m_name = string.Empty;
        private string m_intact_name = string.Empty;
        private string m_bank_name = string.Empty;
        private string m_account = string.Empty;
        private string m_phone = string.Empty;
        private string m_fax = string.Empty;
        private string m_address = string.Empty;
        private string m_memo = string.Empty;
        private long m_lastamp = 0;

        public long LasTamp
        {
            get { return m_lastamp; }
            set { m_lastamp = value; }
        }

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        /// <summary>
        /// 供应商对应的分类ID
        /// </summary>
        public int Class_Id
        {
            get { return m_class_id; }
            set { m_class_id = value; }
        }

        /// <summary>
        /// 拼音码
        /// </summary>
        public string Pym
        {
            get { return m_pym; }
            set
            {
                if (value.Length > 100)
                    m_pym = value.Substring(0, 99);
                else
                    m_pym = value;
            }
        }

        /// <summary>
        /// 供应商简称
        /// </summary>
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

        /// <summary>
        /// 供应商全称
        /// </summary>
        public string Intact_Name
        {
            get { return m_intact_name; }
            set
            {
                if (value.Length > 50)
                    m_intact_name = value.Substring(0, 49);
                else
                    m_intact_name = value;
            }
        }

        /// <summary>
        /// 供应商开户行名称
        /// </summary>
        public string Bank_Name
        {
            get { return m_bank_name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    m_bank_name = "";
                else
                {
                    if (value.Length > 50)
                        m_bank_name = value.Substring(0, 49);
                    else
                        m_bank_name = value;
                }
            }
        }

        /// <summary>
        /// 供应商帐号
        /// </summary>
        public string Account
        {
            get { return m_account; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    m_account = "";
                else
                {
                    if (value.Length > 50)
                        m_account = value.Substring(0, 49);
                    else
                        m_account = value;
                }
            }
        }

        /// <summary>
        /// 公司电话
        /// </summary>
        public string Phone
        {
            get { return m_phone; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    m_phone = string.Empty;
                else
                {
                    if (value.Length > 50)
                        m_phone = value.Substring(0, 49);
                    else
                        m_phone = value;
                }
            }
        }

        /// <summary>
        /// 公司地址
        /// </summary>
        public string Address
        {
            get { return m_address; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    m_address = string.Empty;
                else
                {
                    if (value.Length > 50)
                        m_address = value.Substring(0, 49);
                    else
                        m_address = value;
                }
            }
        }

        /// <summary>
        /// 公司传真
        /// </summary>
        public string Fax
        {
            get { return m_fax; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    m_fax = "";
                else
                {
                    if (value.Length > 50)
                        m_fax = value.Substring(0, 49);
                    else
                        m_fax = value;
                }
            }
        }

        /// <summary>
        /// 备注信息
        /// </summary>
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
