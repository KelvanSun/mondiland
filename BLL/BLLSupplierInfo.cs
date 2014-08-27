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

        /// <summary>
        /// 更新SupplierM表记录
        /// </summary>
        /// <param name="info">BESupplierMInfo对象</param>
        /// <returns>成功true</returns>
        public bool UpdateSupplierM(BESupplierMInfo info)
        {
            Hashtable field = new Hashtable();

            field.Add("class_id", info.Class_Id);
            field.Add("pym", info.Pym);
            field.Add("name", info.Name);
            field.Add("intact_name", info.Intact_Name);
            field.Add("bank_name", info.Bank_Name);
            field.Add("account", info.Account);
            field.Add("phone", info.Phone);
            field.Add("fax", info.Fax);
            field.Add("address", info.Address);
            field.Add("memo", info.Memo);
            field.Add("lastamp", UtilFun.GetTimeSLasTamp());

            Hashtable where = new Hashtable();

            where.Add("id", info.Id);

            return SupplierM_Dal.Update(field, where);
        }


        

        /// <summary>
        /// 根据SupplierM表ID值读出数据
        /// </summary>
        /// <param name="id">ID号</param>
        /// <returns>BESupplierMInfo结构</returns>
        public BESupplierMInfo ReadSupplierMInfoByPrimaryKey(int id)
        {
            BESupplierMInfo info = new BESupplierMInfo();

            Table_SupplierM_Entity entity = SupplierM_Dal.FindByID(id);

            info.Id = entity.Id;
            info.Class_Id = entity.Class_Id;
            info.Pym = entity.Pym;
            info.Name = entity.Name;
            info.Intact_Name = entity.Intact_Name;
            info.Bank_Name = entity.Bank_Name;
            info.Account = entity.Account;
            info.Phone = entity.Phone;
            info.Fax = entity.Fax;
            info.Address = entity.Address;
            info.Memo = entity.Memo;
            info.LasTamp = entity.LasTamp;

            return info;
        }

        /// <summary>
        /// 修改保存前检察lastamp是否有变动
        /// </summary>
        /// <param name="lastamp"></param>
        /// <returns>true为已经变动</returns>
        public bool UpdateCheckLastamp(int id, long lastamp)
        {
            Table_SupplierM_Entity entity = SupplierM_Dal.FindByID(id);

            return entity.LasTamp != lastamp;
        }

        /// <summary>
        /// 供应商主表拼音码方式查询
        /// </summary>
        /// <param name="pym">拼音码</param>
        /// <returns>查到的信息ID列表</returns>
        public List<int> QuerySupplierMByPym(string pym)
        {
            List<int> list = new List<int>();

            Hashtable hash = new Hashtable();
            hash.Add("pym", pym);

            IEnumerator<Table_SupplierM_Entity> ator = SupplierM_Dal.Find(hash, SqlOperator.Like, false).GetEnumerator();

            while(ator.MoveNext())
            {
                list.Add(ator.Current.Id);
            }

            return list;
        }

        /// <summary>
        /// 供应商主表简称方式查询
        /// </summary>
        /// <param name="name">简称</param>
        /// <returns>查到的信息ID列表</returns>
        public List<int> QuerySupplierMByName(string name)
        {
            List<int> list = new List<int>();

            Hashtable hash = new Hashtable();
            hash.Add("name", name);

            IEnumerator<Table_SupplierM_Entity> ator = SupplierM_Dal.Find(hash, SqlOperator.Like, false).GetEnumerator();

            while (ator.MoveNext())
            {
                list.Add(ator.Current.Id);
            }

            return list;
        }

        /// <summary>
        /// 供应商主表全称方式查询
        /// </summary>
        /// <param name="name">全称</param>
        /// <returns>查到的信息ID列表</returns>
        public List<int> QuerySupplierMByIntactName(string name)
        {
            List<int> list = new List<int>();

            Hashtable hash = new Hashtable();
            hash.Add("intact_name", name);

            IEnumerator<Table_SupplierM_Entity> ator = SupplierM_Dal.Find(hash, SqlOperator.Like, false).GetEnumerator();

            while (ator.MoveNext())
            {
                list.Add(ator.Current.Id);
            }

            return list;
        }
    }
}
