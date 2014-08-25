using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.BLLEntity
{
    public class BESupplierClass:BLLEntity
    {
        private int m_id = 0;
        private string m_name = string.Empty;
        private string m_memo = string.Empty;

        /// <summary>
        /// 供应商分类ID
        /// </summary>
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }
        
        /// <summary>
        /// 供应商分类名称
        /// </summary>
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        /// <summary>
        /// 供应商分类备注
        /// </summary>
        public string Memo
        {
            get { return m_memo; }
            set { m_memo = value; }
        }
    }
}
