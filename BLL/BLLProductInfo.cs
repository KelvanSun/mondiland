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

        public int GetOptimizePwash(int partname_id)
        {
            Table_PartName_Entity entity = PartName_Dal.FindByID(partname_id);

            return entity.Pwash;
        }

        /// <summary>
        /// 返回所有产品货号信息
        /// </summary>
        /// <returns>列表<</returns>
        public List<string> GetHuoHaoList()
        {
            List<string> list = new List<string>();

            IEnumerator<Table_ProductData_Entity> ator = ProductData_Dal.GetAll(false).GetEnumerator();

            while (ator.MoveNext())
            {
                list.Add(ator.Current.HuoHao);
            }

            return list;
        }

        /// <summary>
        /// 返回洗唛列表
        /// </summary>
        /// <returns>绑定列表</returns>
        public BindingList<BEWashPrintTemplateProduct> GetWashPrintTemplateList()
        {
            BindingList<BEWashPrintTemplateProduct> list = new BindingList<BEWashPrintTemplateProduct>();

            IEnumerator<Table_WashPrintTemplate_Entity> ator = WashPrintTemplate_Dal.GetAll(false).GetEnumerator();

            while (ator.MoveNext())
            {
                BEWashPrintTemplateProduct info = new BEWashPrintTemplateProduct();

                info.Id = ator.Current.Id;
                info.Type = ator.Current.Type;
                info.DaXiao = ator.Current.DaXiao;
       
                list.Add(info);
            }

            return list;    
        }

        /// <summary>
        /// 返回执行标准信息列表
        /// </summary>
        /// <returns>绑定列表</returns>
        public BindingList<BEStandardDataProduct> GetStandardDataList()
        {
            BindingList<BEStandardDataProduct> list = new BindingList<BEStandardDataProduct>();

            IEnumerator<Table_StardardData_Entity> ator = StandardData_Dal.GetAll(true).GetEnumerator();

            while (ator.MoveNext())
            {
                BEStandardDataProduct info = new BEStandardDataProduct();

                info.Id = ator.Current.Id;
                info.Type = ator.Current.Type;
                info.Memo = ator.Current.Memo;

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

            IEnumerator<Table_SafeData_Entity> ator = SafeData_Dal.GetAll(true).GetEnumerator();

            while(ator.MoveNext())
            {
                BESafeDataProduct info = new BESafeDataProduct();

                info.Id = ator.Current.Id;
                info.Type = ator.Current.Type;
                info.Memo = ator.Current.Memo;

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

            IEnumerator<Table_PartName_Entity> ator = PartName_Dal.GetAll(false).GetEnumerator();

            while(ator.MoveNext())
            {
                BEPartNameProduct info = new BEPartNameProduct();

                Table_SizeClass_Entity entity = SizeClass_Dal.FindByID(ator.Current.SizeClass_id);

                info.Id = ator.Current.Id;
                info.PartName = ator.Current.Name;
                info.ClassType = entity.Type;
                info.Memo = ator.Current.Memo;

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

            IEnumerator<Table_MadePlace_Entity> ator = MadePlace_Dal.GetAll(false).GetEnumerator();

            while(ator.MoveNext())
            {
                BEMadePlaceProduct info = new BEMadePlaceProduct();

                info.Id = ator.Current.Id;
                info.Type = ator.Current.Type;

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

            IEnumerator<Table_Dengji_Entity> ator = Dengji_Dal.GetAll(false).GetEnumerator();

            while(ator.MoveNext())
            {
                BEDengjiProduct info = new BEDengjiProduct();

                info.Id = ator.Current.Id;
                info.Type = ator.Current.Type;
                info.Memo = ator.Current.Memo;

                list.Add(info);
            }

            return list;
        }

        public BindingList<BEMaterialDataInfo> GetMaterialDataList(int product_id)
        {
            BindingList<BEMaterialDataInfo> list = new BindingList<BEMaterialDataInfo>();
            
            Hashtable hash = new Hashtable();
            hash.Add("product_id",product_id);

            IEnumerator<Table_MaterialData_Entity> ator = MaterialData_Dal.Find(hash,SqlOperator.And,true).GetEnumerator();

            while(ator.MoveNext())
            {
                BEMaterialDataInfo info = new BEMaterialDataInfo();
                info.Id = ator.Current.Id;
                info.Type = ator.Current.Type;

                list.Add(info);
            }
            
            return list;

        }

        /// <summary>
        /// 读取存在的记录
        /// </summary>
        /// <param name="str_huohao">货号</param>
        /// <returns>BEProductDataReadProduct</returns>
        public BEProductDataReadProduct ReadProductData(string str_huohao)
        {
            BEProductDataReadProduct info = new BEProductDataReadProduct();

            Hashtable hash = new Hashtable();
            hash.Add("huohao", str_huohao);

            Table_ProductData_Entity entity = ProductData_Dal.Find(hash);

            info.PartName_Id = entity.PartName_Id;
            info.Dengji_Id = entity.Dengji_Id;
            info.MadePlace_Id = entity.MadePlace_Id;
            info.Price = entity.Price;
            info.SafeData_Id = entity.SafeData_Id;
            info.StandardData_Id = entity.StandardData_Id;
            info.Memo = entity.Memo;
            info.Tag = GetTagType(entity.Tag_Id);
            info.Wash_Id = entity.Wash_Id;
            info.Id = entity.Id;
            info.Pwash = entity.Pwash;
            info.LasTamp = entity.LasTamp;

            return info;
        }

        private string GetTagType(int id)
        {
            Table_TagPrintTemplate_Entity entity = TagPrintTemplate_Dal.FindByID(id);

            return entity.Type;
        }

    
        public List<string> GetFillSizeList(int partname_id)
        {
            
            List<string> list = new List<string>();

            Table_PartName_Entity parntname = PartName_Dal.FindByID(partname_id);

            Hashtable hash = new Hashtable();
            hash.Add("class_id",parntname.SizeClass_id);

            IEnumerator<Table_SizeData_Entity> ator = SizeData_Dal.Find(hash, SqlOperator.And, true).GetEnumerator();

            while(ator.MoveNext())
            {
                list.Add(ator.Current.Size_Name);
            }

            return list;
        }
        public int GetProductId(string str_huohao)
        {
            Hashtable hash = new Hashtable();
            hash.Add("huohao", str_huohao);

            return ProductData_Dal.FindPrimaryKey(hash);
        }

        public string GetTagName(bool wash,int count)
        {
            Table_TagPrintTemplate_Entity entity = new Table_TagPrintTemplate_Entity();
            Hashtable hash = new Hashtable();

            if (wash)
            {
                hash.Add("file_name", string.Format("TagA{0}.btw", count.ToString()));
            }
            else
            {
                hash.Add("file_name", string.Format("Tag{0}.btw", count.ToString()));
            }

            entity = TagPrintTemplate_Dal.Find(hash);
            return entity.Type;
        }

        
        public bool AddMaterialInfo(int product_id,string type,int order)
        {
            Table_MaterialData_Entity entity = new Table_MaterialData_Entity();
            entity.Product_Id = product_id;
            entity.Type = type;
            entity.Order_Index = order;

            return MaterialData_Dal.Insert(entity);
        }

        public bool AddMaterialFillInfo(int product_id,string size_name,string type,string fill)
        {
            Table_MaterialFill_Entity entity = new Table_MaterialFill_Entity();

            entity.Product_Id = product_id;
            entity.Size_Name = size_name;
            entity.Type = type;
            entity.Fill = fill;

            return MaterialFill_Dal.Insert(entity);
        }

        public bool AddProductInfo(BEProductDataInfo info)
        {
    
            Table_ProductData_Entity entity = new Table_ProductData_Entity();

            entity.PartName_Id = info.PartName_Id;
            entity.HuoHao = info.HuoHao;
            entity.SafeData_Id = info.SafeData_Id;
            entity.StandardData_Id = info.StandardData_Id;
            entity.Price = info.Price;
            entity.MadePlace_Id = info.MadePlace_Id;
            entity.Dengji_Id = info.Dengji_Id;
            entity.Tag_Id = info.Tag_Id;
            entity.Wash_Id = info.Wash_Id;
            entity.Memo = info.Memo;
            entity.Pwash = info.Pwash;
            entity.LasTamp = UtilFun.GetTimeSLasTamp();
            
            return ProductData_Dal.Insert(entity);
        }

        public bool DeleteMaterialInfo(int product_id)
        {
            Hashtable hash = new Hashtable();
            hash.Add("product_id",product_id);

            return MaterialData_Dal.Delete(hash);
        }

        public bool UpdateProductInfo(BEProductDataInfo info,int product_id,long LasTamp)
        {
            Hashtable field = new Hashtable();
            field.Add("partname_id", info.PartName_Id);
            field.Add("safedata_id", info.SafeData_Id);
            field.Add("standarddata_id", info.StandardData_Id);
            field.Add("price", info.Price);
            field.Add("madeplace_id", info.MadePlace_Id);
            field.Add("dengji_id", info.Dengji_Id);
            field.Add("tag_id", info.Tag_Id);
            field.Add("wash_id", info.Wash_Id);
            field.Add("memo", info.Memo);
            field.Add("pwash", info.Pwash);

            Hashtable where = new Hashtable();

            where.Add("id", product_id);
            where.Add("lastamp", LasTamp);

            if (ProductData_Dal.Update(field, where))
            {
                field.Clear();

                field.Add("lastamp", UtilFun.GetTimeSLasTamp());

                return ProductData_Dal.Update(product_id, field);
            }
            else
                return false;
        }

        public int GetTagTemplateId(string str_name)
        {
            Hashtable hash = new Hashtable();
            hash.Add("type", str_name);

            return TagPrintTemplate_Dal.FindPrimaryKey(hash);
        }

      
        /// <summary>
        /// 根据货号检察记录是否存在        
        /// </summary>
        /// <param name="str_huohao">货号</param>
        /// <returns>true 代表存在</returns>
        public bool CheckProductDataIsExist(string str_huohao)
        {
       
            Hashtable hash = new Hashtable();

            hash.Add("huohao", str_huohao);

            return ProductData_Dal.IsExistKey(hash);
        }
   
   
    }
}
