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

        /// <summary>
        /// 根据分类ID得到分类名称
        /// </summary>
        /// <param name="clss_id">分类ID</param>
        /// <returns>分类名称</returns>
        public string GetSupplierClassName(int clss_id)
        {
            Table_SupplierClass_Entity entity = SupplierClass_Dal.FindByID(clss_id);

            return entity.Name;
        }

        /// <summary>
        /// 添加SupplierM表记录
        /// </summary>
        /// <param name="info">BESupplierMInfo对象</param>
        /// <returns>成功true</returns>
        public bool AddSupplierM(BESupplierMInfo info)
        {
            Table_SupplierM_Entity entity = new Table_SupplierM_Entity();

            entity.Class_Id = info.Class_Id;
            entity.Pym = info.Pym;
            entity.Name = info.Name;
            entity.Intact_Name = info.Intact_Name;
            entity.Bank_Name = info.Bank_Name;
            entity.Account = info.Account;
            entity.Phone = info.Phone;
            entity.Fax = info.Fax;
            entity.Address = info.Address;
            entity.Memo = info.Memo;
            entity.LasTamp = UtilFun.GetTimeSLasTamp();

            return SupplierM_Dal.Insert(entity);
        }
    }
}
