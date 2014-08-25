using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;

using Mondiland.Entity;
using Mondiland.IDal;
using Mondiland.BLLEntity;
using Mondiland.Global;

namespace Mondiland.BLL
{
    public class BLLSupplierInfo:BaseBLL
    {
        private ITable_SupplierM SupplierM_Dal = null;
        private ITable_SupplierD SupplierD_Dal = null;
        private ITable_SupplierClass SupplierClass_Dal = null;
        public BLLSupplierInfo()
        {
            SupplierM_Dal = Reflect<ITable_SupplierM>.Create("DAL_SupplierM", "Mondiland.DAL");
            SupplierD_Dal = Reflect<ITable_SupplierD>.Create("DAL_SupplierD", "Mondiland.DAL");
            SupplierClass_Dal = Reflect<ITable_SupplierClass>.Create("DAL_SupplierClass", "Mondiland.DAL");
        }

        /// <summary>
        /// 得到供应商分类列表
        /// </summary>
        /// <returns>列表</returns>
        public BindingList<BESupplierClass> GetSupplierClassList()
        {
            BindingList<BESupplierClass> list = new BindingList<BESupplierClass>();

            IEnumerator<Table_SupplierClass_Entity> ator = SupplierClass_Dal.GetAll(false).GetEnumerator();

            while(ator.MoveNext())
            {
                BESupplierClass info = new BESupplierClass();
                info.Id = ator.Current.Id;
                info.Name = ator.Current.Name;
                info.Memo = ator.Current.Memo;

                list.Add(info);
            }

            return list;
        }
    }
}
