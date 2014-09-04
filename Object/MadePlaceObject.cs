using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Mondiland.EFModule;

namespace Mondiland.Obj
{
    public class MadePlaceObject
    {
        public BindingList<MadePlaceList> GetMadePlaceList()
        {
            BindingList<MadePlaceList> list = new BindingList<MadePlaceList>();

            using(ProductContext ctx = new ProductContext())
            {
                var madeplaces = from entity in ctx.MadePlace
                                 select entity;

                foreach(var madeplace in madeplaces)
                {
                    MadePlaceList info = new MadePlaceList();
                    info.Id = madeplace.id;
                    info.Type = madeplace.type;

                    list.Add(info);
                }
            }

            return list;
        }
        
        
        public class MadePlaceList
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
}
