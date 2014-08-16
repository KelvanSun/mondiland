using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mondiland.BLLEntity
{
    [Serializable]
    public class BEMaterialDataInfo:BLLEntity
    {
        private int m_id = 0;
        private string m_type = string.Empty;
 
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public string Type
        {
            get { return m_type; }
            set { m_type = value; }
        }

    }
}
