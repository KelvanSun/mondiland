using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Mondiland.EFModule;

namespace Mondiland.Obj
{
    public class SupplierManager
    {
        public List<int> QuerySupplierMByPym(string text)
        {
            List<int> list = new List<int>();

            using(ProductContext ctx = new ProductContext())
            {
                var ids = from entity in ctx.SupplierM
                         where entity.pym.IndexOf(text) >= 0
                         select entity.id;

                foreach(int id in ids)
                {
                    list.Add(id);
                }
            }

            return list;
        }

        public List<int>QuerySupplierMByName(string text)
        {
            List<int> list = new List<int>();

            using (ProductContext ctx = new ProductContext())
            {
                var ids = from entity in ctx.SupplierM
                          where entity.name.IndexOf(text) >= 0
                          select entity.id;

                foreach (int id in ids)
                {
                    list.Add(id);
                }
            }

            return list;
        }

        public List<int>QuerySupplierMByIntactName(string text)
        {
            List<int> list = new List<int>();

            using (ProductContext ctx = new ProductContext())
            {
                var ids = from entity in ctx.SupplierM
                          where entity.intact_name.IndexOf(text) >= 0
                          select entity.id;

                foreach (int id in ids)
                {
                    list.Add(id);
                }
            }

            return list;
        }
    }
}
