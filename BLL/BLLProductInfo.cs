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
        private ITable_ProductData ProductData_Dal = null;
        
        private ITable_PartName PartName_Dal = null;
        private ITable_Dengji Dengji_Dal = null;
        private ITable_MadePlace MadePlace_Dal = null;
        private ITable_SafeData SafeData_Dal = null;
        private ITable_StandardData StandardData_Dal = null;

        public BLLProductInfo()
        {
            ProductData_Dal = Reflect<ITable_ProductData>.Create("DAL_ProductData", "Mondiland.DAL");
            PartName_Dal = Reflect<ITable_PartName>.Create("DAL_PartName", "Mondiland.DAL");
            Dengji_Dal = Reflect<ITable_Dengji>.Create("DAL_Dengji", "Mondiland.DAL");
            MadePlace_Dal = Reflect<ITable_MadePlace>.Create("DAL_MadePlace", "Mondiland.DAL");
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

        /// <summary>
        /// 反回产品产地的列表信息
        /// </summary>
        /// <returns>绑定列表</returns>
        public BindingList<BEMadePlaceProduct> GetMadePlaceList()
        {
            BindingList<BEMadePlaceProduct> list = new BindingList<BEMadePlaceProduct>();

            foreach (Table_MadePlace_Entity entity in MadePlace_Dal.GetAll(false))
            {
                BEMadePlaceProduct info = new BEMadePlaceProduct();

                info.Id = entity.Id;
                info.Type = entity.Type;

                list.Add(info);
            }

            return list;
        }

        /// <summary>
        /// 返回产品等级所有信息列表
        /// </summary>
        /// <returns>绑定列表</returns>
        public BindingList<BEDengjiProduct> GetDengjiList()
        {
            BindingList<BEDengjiProduct> list = new BindingList<BEDengjiProduct>();

            foreach (Table_Dengji_Entity entity in Dengji_Dal.GetAll(false))
            {
                BEDengjiProduct info = new BEDengjiProduct();

                info.Id = entity.Id;
                info.Type = entity.Type;
                info.Memo = entity.Memo;

                list.Add(info);
            }

            return list;
        }
     
    }
}
