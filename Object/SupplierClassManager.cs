using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Mondiland.EFModule;

namespace Mondiland.Obj
{
    public class SupplierClassManager
    {
        public BindingList<SupplierClassListObj> GetSupplierClassList()
        {
            BindingList<SupplierClassListObj> list = new BindingList<SupplierClassListObj>();

            using(ProductContext ctx = new ProductContext())
            {
                var SupplierClasss = from entity in ctx.SupplierClass
                                     select entity;

                foreach(var supplierclass in SupplierClasss)
                {
                    SupplierClassListObj info = new SupplierClassListObj();

                    info.Id = supplierclass.id;
                    info.Name = supplierclass.name;
                    info.Memo = supplierclass.memo;

                    list.Add(info);
                }
            }


            return list;
        }


        public class SupplierClassListObj
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
}
