using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.BLLEntity
{
    /// <summary>
    /// 产品规格号型外表结构
    /// </summary>
    [Serializable]
    public class BESizeDataList:BLLEntity
    {
        private int m_id = 0;
        private string m_size_name = string.Empty;
        private string m_size_type = string.Empty;

        /// <summary>
        /// 用以定位用户选择的项
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
        /// 号型
        /// </summary>
        public string SizeType
        {
            get { return m_size_type; }
            set { m_size_type = value; }
        }
    }
}
