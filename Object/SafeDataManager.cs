using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Mondiland.EFModule;

namespace Mondiland.Obj
{
    public class SafeDataManager
    {
        public static BindingList<SafeDataListObj> SafeDataList
        {
            get
            {
                BindingList<SafeDataListObj> list = new BindingList<SafeDataListObj>();

                using (ProductContext ctx = new ProductContext())
                {
                    var safedatas = from entity in ctx.SafeData
                                    select entity;

                    foreach (var safedata in safedatas)
                    {
                        SafeDataListObj info = new SafeDataListObj();
                        info.Id = safedata.id;
                        info.Type = safedata.type;
                        info.Memo = safedata.memo;

                        list.Add(info);
                    }

                }

                return list;
            }
        }

        public class SafeDataListObj
        {
            private int m_id = 0;
            private string m_type = string.Empty;
            private string m_memo = string.Empty;

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

            public string Memo
            {
                get { return m_memo; }
                set { m_memo = value; }
            }
        }
    }
}
