using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Mondiland.EFModule;

namespace Mondiland.Obj
{
    public class DengjiManager
    {
        public BindingList<DengjiListObj> GetDengjiList()
        {
            BindingList<DengjiListObj> list = new BindingList<DengjiListObj>();

            using(ProductContext ctx = new ProductContext())
            {
                var dengjis = from entity in ctx.Dengji
                              select entity;

                foreach(var denji in dengjis)
                {
                    DengjiListObj info = new DengjiListObj();
                    info.Id = denji.id;
                    info.Type = denji.type;
                    info.Memo = denji.memo;

                    list.Add(info);
                }

            }

            return list;
        }
        public class DengjiListObj
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
