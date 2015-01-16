using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Mondiland.EFModule;

namespace Mondiland.Obj
{
    public class ColorDataManager
    {
        public static BindingList<ColorDataListObj> ColorDataList
        {
            get
            {
                BindingList<ColorDataListObj> list = new BindingList<ColorDataListObj>();

                using (ProductContext ctx = new ProductContext())
                {
                    var colors = from entity in ctx.ColorData
                                     select entity;

                    foreach (var color in colors)
                    {
                        ColorDataListObj info = new ColorDataListObj();
                        info.Id = color.id;
                        info.Type = color.type;

                        list.Add(info);
                    }
                }

                return list;
            }
        }
    }

    public class ColorDataListObj
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
