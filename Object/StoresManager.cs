using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Mondiland.EFModule;

namespace Mondiland.Obj
{
    public class StoresManager
    {

        public static BindingList<StoreObject> GetLogAllList()
        {
            BindingList<StoreObject> list = new BindingList<StoreObject>();

            using(ProductContext ctx = new ProductContext())
            {
                var stores = from entity in ctx.StoresInfo
                             orderby entity.name
                             select entity;

                foreach(var store in stores)
                {
                    StoreObject obj = new StoreObject();
                    obj.Id = store.id;
                    obj.Name = store.name;
                    obj.Address = store.address;
                    obj.Manager = store.manager;
                    obj.ManagerPhone = store.manager_phone;
                    obj.Phone = store.phone;
                    obj.Memo = store.memo;
                    obj.LasTamp = store.lastamp;

                    list.Add(obj);
                }
            }


            return list;
        }
    }

}
