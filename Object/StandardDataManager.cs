using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Mondiland.EFModule;

namespace Mondiland.Obj
{
    public class StandardDataManager
    {
        public static BindingList<StandardDataListObj> StandardDataList
        {
            get
            {
                BindingList<StandardDataListObj> list = new BindingList<StandardDataListObj>();

                using (ProductContext ctx = new ProductContext())
                {
                    var standarddatas = from entity in ctx.StandardData
                                        select entity;

                    foreach (var standarddata in standarddatas)
                    {
                        StandardDataListObj info = new StandardDataListObj();
                        info.Id = standarddata.id;
                        info.Type = standarddata.type;
                        info.Memo = standarddata.memo;

                        list.Add(info);
                    }
                }

                return list;
            }
        }
        
        public class StandardDataListObj
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
