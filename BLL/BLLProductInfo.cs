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
    public class BLLProductInfo : BaseBLL
    {
        private ITable_SafeData SafeData_Dal = null;
        private ITable_StandardData StandardData_Dal = null;

        public BLLProductInfo()
        {

            SafeData_Dal = Reflect<ITable_SafeData>.Create("DAL_SafeData", "Mondiland.DAL");
            StandardData_Dal = Reflect<ITable_StandardData>.Create("DAL_StandardData", "Mondiland.DAL");
        }

        /// <summary>
        /// 返回执行标准信息列表
        /// </summary>
        /// <returns>绑定列表</returns>
        public BindingList<BEStandardDataProduct> GetStandardDataList()
        {
            BindingList<BEStandardDataProduct> list = new BindingList<BEStandardDataProduct>();

            foreach (Table_StardardData_Entity entity in StandardData_Dal.GetAll(true))
            {
                BEStandardDataProduct info = new BEStandardDataProduct();

                info.Id = entity.Id;
                info.Type = entity.Type;
                info.Memo = entity.Memo;

                list.Add(info);
            }

            return list;
        }

        /// <summary>
        /// 返回安全类别信息列表
        /// </summary>
        /// <returns>绑定列表</returns>
        public BindingList<BESafeDataProduct> GetSafeDataList()
        {
            BindingList<BESafeDataProduct> list = new BindingList<BESafeDataProduct>();

            foreach (Table_SafeData_Entity entity in SafeData_Dal.GetAll(true))
            {
                BESafeDataProduct info = new BESafeDataProduct();

                info.Id = entity.Id;
                info.Type = entity.Type;
                info.Memo = entity.Memo;

                list.Add(info);
            }

            return list;
        }

       
     
    }
}
