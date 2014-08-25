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
        public BLLSupplierInfo()
        {
            SupplierM_Dal = Reflect<ITable_SupplierM>.Create("DAL_SupplierM", "Mondiland.DAL");
            SupplierD_Dal = Reflect<ITable_SupplierD>.Create("DAL_SupplierD", "Mondiland.DAL");
        }
    }
}
