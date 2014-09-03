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
        private ITable_TagPrintTemplate TagPrintTemplate_Dal = null;
        private ITable_MaterialData MaterialData_Dal = null;
        private ITable_SizeData SizeData_Dal = null;
        private ITable_MaterialFill MaterialFill_Dal = null;
        private ITable_WashPrintTemplate WashPrintTemplate_Dal = null;
        private ITable_SizeClass SizeClass_Dal = null;

        public BLLProductInfo()
        {
            ProductData_Dal = Reflect<ITable_ProductData>.Create("DAL_ProductData", "Mondiland.DAL");
            PartName_Dal = Reflect<ITable_PartName>.Create("DAL_PartName", "Mondiland.DAL");
            Dengji_Dal = Reflect<ITable_Dengji>.Create("DAL_Dengji", "Mondiland.DAL");
            MadePlace_Dal = Reflect<ITable_MadePlace>.Create("DAL_MadePlace", "Mondiland.DAL");
            SafeData_Dal = Reflect<ITable_SafeData>.Create("DAL_SafeData", "Mondiland.DAL");
            StandardData_Dal = Reflect<ITable_StandardData>.Create("DAL_StandardData", "Mondiland.DAL");
            TagPrintTemplate_Dal = Reflect<ITable_TagPrintTemplate>.Create("DAL_TagPrintTemplate", "Mondiland.DAL");
            MaterialData_Dal = Reflect<ITable_MaterialData>.Create("DAL_MaterialData", "Mondiland.DAL");
            SizeData_Dal = Reflect<ITable_SizeData>.Create("DAL_SizeData", "Mondiland.DAL");
            MaterialFill_Dal = Reflect<ITable_MaterialFill>.Create("DAL_MaterialFill", "Mondiland.DAL");
            WashPrintTemplate_Dal = Reflect<ITable_WashPrintTemplate>.Create("DAL_WashPrintTemplate", "Mondiland.DAL");
            SizeClass_Dal = Reflect<ITable_SizeClass>.Create("DAL_SizeClass", "Mondiland.DAL");
        }

      
        
        public bool GetOptimizePbad(int partname_id)
        {
            Table_PartName_Entity entity = PartName_Dal.FindByID(partname_id);

            return entity.Pbad > 0 ? true : false;
        }
        /// <summary>
        /// 根据产品种类选择合适的安全标准
        /// </summary>
        /// <param name="partname_id"></param>
        /// <returns>安全标准ID</returns>
        public int GetOptimizeSafeId(int partname_id)
        {
            Table_PartName_Entity entity = PartName_Dal.FindByID(partname_id);

            return entity.Safe_Id;
        }
        /// <summary>
        /// 根据产品种类选择合适的执行标准
        /// </summary>
        /// <param name="partname_id"></param>
        /// <returns>安全标准ID</returns>
        public int GetOptimizeStandardId(int partname_id)
        {
            Table_PartName_Entity entity = PartName_Dal.FindByID(partname_id);

            return entity.Standard_Id;
        }

        public bool GetOptimizePwash(int partname_id)
        {
            Table_PartName_Entity entity = PartName_Dal.FindByID(partname_id);

            return entity.Pwash > 0 ? true : false;
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
        /// 返回产品种类信息列表
        /// </summary>
        /// <returns>绑定列表</returns>
        public BindingList<BEPartNameProduct> GetPartNameList()
        {
            BindingList<BEPartNameProduct> list = new BindingList<BEPartNameProduct>();

            foreach(Table_PartName_Entity partname in PartName_Dal.GetAll(false))
            {
                BEPartNameProduct info = new BEPartNameProduct();

                Table_SizeClass_Entity entity = SizeClass_Dal.FindByID(partname.SizeClass_id);

                info.Id = partname.Id;
                info.PartName = partname.Name;
                info.ClassType = entity.Type;
                info.Memo = partname.Memo;

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
