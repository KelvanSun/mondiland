using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Mondiland.EFModule;

namespace Mondiland.Obj
{
    public class PartNameManager
    {

        public BindingList<PartNameListObj> GetPartNameList()
        {
            BindingList<PartNameListObj> list = new BindingList<PartNameListObj>();

            using (ProductContext ctx = new ProductContext())
            {
                var partnames = from entity in ctx.PartName
                                select entity;

                foreach (var partname in partnames)
                {
                    PartNameListObj info = new PartNameListObj();
                    info.Id = partname.id;
                    info.PartName = partname.name;
                    info.ClassType = partname.SizeClass.type;
                    info.Memo = partname.memo;

                    list.Add(info);
                }

            }

            return list;
        }

        public OptimizeInfo GetOptimizeInfo(int partname_id)
        {
            OptimizeInfo info = new OptimizeInfo();

            using (ProductContext ctx = new ProductContext())
            {
                var data = (from entity in ctx.PartName
                           where entity.id == partname_id
                           select entity).FirstOrDefault();

                info.Pbad = data.pbad == 0 ? false : true;
                info.Pwash = data.pwash == 0 ? false : true;
                info.Safe_Id = data.safe_id;
                info.Standard_Id = data.standard_id;
            }


            return info;
        }


        public class PartNameListObj
        {
            private int m_id = 0;
            private string m_partname = string.Empty;
            private string m_class_type = string.Empty;
            private string m_memo = string.Empty;

            public int Id
            {
                get { return m_id; }
                set { m_id = value; }
            }

            public string PartName
            {
                get { return m_partname; }
                set { m_partname = value; }
            }

            public string ClassType
            {
                get { return m_class_type; }
                set { m_class_type = value; }
            }

            public string Memo
            {
                get { return m_memo; }
                set { m_memo = value; }
            }
        }

        public class OptimizeInfo
        {
            private int m_safe_id = 0;
            private int m_standard_id = 0;
            private bool m_pwash = false;
            private bool m_pbad = false;

            public bool Pbad
            {
                get { return m_pbad; }
                set { m_pbad = value; }
            }
            public bool Pwash
            {
                get { return m_pwash; }
                set { m_pwash = value; }
            }

            public int Safe_Id
            {
                get { return m_safe_id; }
                set { m_safe_id = value; }
            }

            public int Standard_Id
            {
                get { return m_standard_id; }
                set { m_standard_id = value; }
            }
        }
    }
            
}
