using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.BLLEntity
{
    public class BEMaterialFillData:BLLEntity
    {
        private int m_id = 0;
        private string m_size_name = string.Empty;
        private string m_type = string.Empty;
        private string m_fill = string.Empty;

        /// <summary>
        /// 对应与表的记录表ID
        /// </summary>
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        /// <summary>
        /// 规格
        /// </summary>
        public string SizeName
        {
            get { return m_size_name; }
            set { m_size_name = value; }
        }

        /// <summary>
        /// 填充物的材质
        /// </summary>
        public string Type
        {
            get { return m_type; }
            set { m_type = value; }
        }

        /// <summary>
        /// 每个规格的填充克数
        /// </summary>
        public string Fill
        {
            get { return m_fill; }
            set { m_fill = value; }
        }
    }
}
