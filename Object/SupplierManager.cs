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
        public static BindingList<SupplierObject> QuerySupplierMByClassId(int class_id)
        {
            BindingList<SupplierObject> list = new BindingList<SupplierObject>();

            using (ProductContext ctx = new ProductContext())
            {
                var ids = from entity in ctx.SupplierM
                          where entity.class_id == class_id
                          orderby entity.name
                          select entity.id;

                foreach (int id in ids)
                {
                    list.Add(new SupplierObject(id));
                }

            }

            return list;
        }

        public static BindingList<SupplierObject> QuerySupplierMByPym(string text)
        {
            BindingList<SupplierObject> list = new BindingList<SupplierObject>();

            using (ProductContext ctx = new ProductContext())
            {
                var ids = from entity in ctx.SupplierM
                          where entity.pym.IndexOf(text) >= 0
                          orderby entity.name
                          select entity.id;

                foreach (int id in ids)
                {
                    list.Add(new SupplierObject(id));
                }
            }

            return list;
        }

        public static BindingList<SupplierObject> QueryContactsByPym(string text)
        {
            BindingList<SupplierObject> list = new BindingList<SupplierObject>();

            using (ProductContext ctx = new ProductContext())
            {
                var ids = from entity in ctx.SupplierD
                          where entity.pym.IndexOf(text) >= 0
                          orderby entity.name
                          select entity.supplier_id;

                foreach (int id in ids)
                {
                    list.Add(new SupplierObject(id));
                }
            }

            return list;
        }

        public static BindingList<SupplierObject> QueryContactsByName(string text)
        {
            BindingList<SupplierObject> list = new BindingList<SupplierObject>();

            using (ProductContext ctx = new ProductContext())
            {
                var ids = from entity in ctx.SupplierD
                          where entity.name.IndexOf(text) >= 0
                          orderby entity.name
                          select entity.supplier_id;

                foreach (int id in ids)
                {
                    list.Add(new SupplierObject(id));
                }
            }

            return list;
        }

        public static BindingList<SupplierObject> QuerySupplierMByName(string text)
        {
            BindingList<SupplierObject> list = new BindingList<SupplierObject>();

            using (ProductContext ctx = new ProductContext())
            {
                var ids = from entity in ctx.SupplierM
                          where entity.name.IndexOf(text) >= 0
                          orderby entity.name
                          select entity.id;

                foreach (int id in ids)
                {
                    list.Add(new SupplierObject(id));
                }
            }

            return list;
        }

        public static BindingList<SupplierObject> QuerySupplierMByIntactName(string text)
        {
            BindingList<SupplierObject> list = new BindingList<SupplierObject>();

            using (ProductContext ctx = new ProductContext())
            {
                var ids = from entity in ctx.SupplierM
                          where entity.intact_name.IndexOf(text) >= 0
                          orderby entity.name
                          select entity.id;

                foreach (int id in ids)
                {
                    list.Add(new SupplierObject(id));
                }
            }

            return list;
        }

        public static BindingList<SupplierObject> GetAllInfoList()
        {
            BindingList<SupplierObject> list = new BindingList<SupplierObject>();

            using (ProductContext ctx = new ProductContext())
            {
                var ids = from entity in ctx.SupplierM
                          orderby entity.name
                          select entity.id;

                foreach (int id in ids)
                {
                    list.Add(new SupplierObject(id));
                }
            }

            return list;
        }
    }
}
