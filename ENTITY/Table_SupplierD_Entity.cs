using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.Entity
{
    public class Table_SupplierD_Entity:BaseEntity
    {
        private int m_supplier_id = 0;
        private string m_name = string.Empty;
        private string m_pym = string.Empty;
        private string m_phone = string.Empty;
        private string m_fax = string.Empty;
        private string m_email = string.Empty;
        private string m_qq = string.Empty;
        private string m_address = string.Empty;
        private string m_memo = string.Empty;

        /// <summary>
        /// 供应商外键表
        /// </summary>
        public int Supplier_Id
        {
            get { return m_supplier_id; }
            set { m_supplier_id = value; }
        }

        /// <summary>
        /// 联系人名称
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
        /// 拼音码
        /// </summary>
        public string Pym
        {
            get { return m_pym; }
            set
            {
                if (value.Length > 50)
                    m_pym = value.Substring(0, 49);
                else
                    m_pym = value;
            }
        }

        /// <summary>
        /// 联系人电话
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
        /// 联系人传真
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
        /// 联系人email
        /// </summary>
        public string Email
        {
            get { return m_email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    m_email = string.Empty;
                else
                {
                    if (value.Length > 50)
                        m_email = value.Substring(0, 49);
                    else
                        m_email = value;
                }
            }
        }

        /// <summary>
        /// 联系人QQ号
        /// </summary>
        public string QQ
        {
            get { return m_qq; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    m_qq = string.Empty;
                else
                {
                    if (value.Length > 50)
                        m_qq = value.Substring(0, 49);
                    else
                        m_qq = value;
                }
            }
        }

        /// <summary>
        /// 联系人地址
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
        /// 备注信息
        /// </summary>
        public string Memo
        {
            get { return m_memo; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    m_memo = string.Empty;
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
