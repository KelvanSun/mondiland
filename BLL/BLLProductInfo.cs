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
        /// 得到洗唛大小
        /// </summary>
        /// <param name="product_id">产品ID</param>
        /// <returns></returns>
        public string GetWashSize(int product_id)
        {
            Table_ProductData_Entity product = ProductData_Dal.FindByID(product_id);
            Table_WashPrintTemplate_Entity wash = WashPrintTemplate_Dal.FindByID(product.Wash_Id);

            return wash.DaXiao;
        }
        /// <summary>
        /// 得到条码前缀
        /// </summary>
        /// <param name="part_name_id">产品分类ID</param>
        /// <returns></returns>
        public string GetBarCodePrefix(int part_name_id)
        {
            Table_PartName_Entity entity = PartName_Dal.FindByID(part_name_id);

            return entity.Barcode;
        }

        /// <summary>
        /// 读取填充量内容
        /// </summary>
        /// <param name="id">产品ID</param>
        /// <returns>BEMaterialFillData结构</returns>
        public BindingList<BEMaterialFillData> ReadMaterialFillDataList(int id)
        {
            BindingList<BEMaterialFillData> list = new BindingList<BEMaterialFillData>();

            Hashtable hash = new Hashtable();
            hash.Add("product_id", id);

            IEnumerator<Table_MaterialFill_Entity> ator = MaterialFill_Dal.Find(hash, SqlOperator.And, true).GetEnumerator();

            while(ator.MoveNext())
            {
                BEMaterialFillData info = new BEMaterialFillData();

                info.Id = ator.Current.Id;
                info.SizeName = ator.Current.Size_Name;
                info.Type = ator.Current.Type;
                info.Fill = ator.Current.Fill;

                list.Add(info);
            }

            return list;
        }


        /// <summary>
        /// 根据分类ID号读取产品号型列表
        /// </summary>
        /// <param name="parntname_id">分类ID号</param>
        /// <returns>号型列表</returns>
        public BindingList<BESizeDataList> ReadSizeDataList(int parntname_id)
        {
            BindingList<BESizeDataList> list = new BindingList<BESizeDataList>();

            Table_PartName_Entity partname = PartName_Dal.FindByID(parntname_id);

            Hashtable hash = new Hashtable();
            hash.Add("class_id", partname.SizeClass_id);

            IEnumerator<Table_SizeData_Entity> ator = SizeData_Dal.Find(hash, SqlOperator.And, true).GetEnumerator();

            int index = 1;

            while (ator.MoveNext())
            {
                BESizeDataList info = new BESizeDataList();                
                
                if (ator.Current.Other == string.Empty)
                {
                    info.Id = index++;
                    info.SizeName = ator.Current.Size_Name;
                    info.SizeType = ator.Current.Size_Type;

                    
                }
                else
                {
                    info.Id = index++;
                    info.SizeName = ator.Current.Size_Name;
                    info.SizeType = string.Format("{0}({1})", ator.Current.Size_Type, ator.Current.Other);

                }

                list.Add(info);
            }

            return list;
        }
        /// <summary>
        /// 根据产品ID返回表信息
        /// </summary>
        /// <param name="id">产品ID</param>
        /// <returns>BEProductDataInfo结构</returns>
        public BEProductDataInfo ReadByPrimaryKey(int id)
        {
            BEProductDataInfo info = new BEProductDataInfo();
            
            Table_ProductData_Entity entity = ProductData_Dal.FindByID(id);

            if (entity == null) return null;

            info.Id = entity.Id;
            info.HuoHao = entity.HuoHao;
            info.Dengji_Id = entity.Dengji_Id;
            info.MadePlace_Id = entity.MadePlace_Id;
            info.PartName_Id = entity.PartName_Id;
            info.SafeData_Id = entity.SafeData_Id;
            info.StandardData_Id = entity.StandardData_Id;
            info.Price = entity.Price;
            info.Memo = entity.Memo;
            info.Pwash = entity.Pwash;
            info.LasTamp = entity.LasTamp;
            info.Tag_Id = entity.Tag_Id;
            info.Wash_Id = entity.Wash_Id;

            return info;
        }

        /// <summary>
        /// 根据执行标准ID得到执行标准内容
        /// </summary>
        /// <param name="id">执行标准ID</param>
        /// <returns>执行标准内容</returns>
        public string ReadStandardDataTypeByPrimaryKey(int id)
        {
            Table_StardardData_Entity entity = StandardData_Dal.FindByID(id);

            return entity.Type;
        }
        /// <summary>
        /// 根据安全类别ID得到安全类别名称
        /// </summary>
        /// <param name="id">全类别ID</param>
        /// <returns>安全类别名称</returns>
        public string ReadSafeDataTypeByPrimaryKey(int id)
        {
            Table_SafeData_Entity entity = SafeData_Dal.FindByID(id);

            return entity.Type;
        }
        /// <summary>
        /// 根据等级ID得到等级名称
        /// </summary>
        /// <param name="id">等级ID</param>
        /// <returns>等级名称</returns>
        public string ReadDengJiTypeByPrimaryKey(int id)
        {
            Table_Dengji_Entity entity = Dengji_Dal.FindByID(id);

            return entity.Type;
        }

        /// <summary>
        /// 根据产地ID得到产地名称
        /// </summary>
        /// <param name="id">产地ID</param>
        /// <returns>产地名称</returns>
        public string ReadMadePlaceTypeByPrimaryKey(int id)
        {
            Table_MadePlace_Entity entity = MadePlace_Dal.FindByID(id);

            return entity.Type;
        }

        /// <summary>
        /// 根据分类ID得到分类名称
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns>分类名称</returns>
        public string ReadPartNameTypeByPrimaryKey(int id)
        {
            Table_PartName_Entity entity = PartName_Dal.FindByID(id);

            return entity.Name;
        }

        /// <summary>
        /// 根据产品货号返回表信息
        /// </summary>
        /// <param name="huohao">产品货号</param>
        /// <returns>BEProductDataInfo结构</returns>
        public BEProductDataInfo ReadByHuoHao(string huohao)
        {
            BEProductDataInfo info = new BEProductDataInfo();

            Hashtable hash = new Hashtable();
            hash.Add("huohao", huohao);

            Table_ProductData_Entity entity = ProductData_Dal.Find(hash);

            if (entity == null) return null;
            
            info.Id = entity.Id;
            info.HuoHao = entity.HuoHao;
            info.Dengji_Id = entity.Dengji_Id;
            info.MadePlace_Id = entity.MadePlace_Id;
            info.PartName_Id = entity.PartName_Id;
            info.SafeData_Id = entity.SafeData_Id;
            info.StandardData_Id = entity.StandardData_Id;
            info.Price = entity.Price;
            info.Memo = entity.Memo;
            info.Pwash = entity.Pwash;
            info.LasTamp = entity.LasTamp;
            info.Tag_Id = entity.Tag_Id;
            info.Wash_Id = entity.Wash_Id;
           

            return info;
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

        /// <summary>
        /// 读出指定产品ID号的成份列表
        /// </summary>
        /// <param name="product_id"></param>
        /// <returns></returns>
        public BindingList<BEMaterialDataInfo> ReadMaterialDataList(int product_id)
        {
            BindingList<BEMaterialDataInfo> list = new BindingList<BEMaterialDataInfo>();

            Hashtable hash = new Hashtable();
            hash.Add("product_id", product_id);

            IEnumerator<Table_MaterialData_Entity> ator = MaterialData_Dal.Find(hash, SqlOperator.And, true).GetEnumerator();

            while (ator.MoveNext())
            {
                BEMaterialDataInfo info = new BEMaterialDataInfo();
                info.Id = ator.Current.Id;
                info.Type = ator.Current.Type;

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

        /// <summary>
        /// 返回吊牌文件名
        /// </summary>
        /// <param name="pwash">是否要打印水洗产品字样</param>
        /// <param name="row">成份行数</param>
        /// <returns>文件名</returns>
        public string GetTagFileName(bool pwash,int row)
        {
            Table_TagPrintTemplate_Entity entity = new Table_TagPrintTemplate_Entity();
            Hashtable hash = new Hashtable();

            if (pwash)
            {
                hash.Add("file_name", string.Format("TagA{0}.btw", row.ToString()));
            }
            else
            {
                hash.Add("file_name", string.Format("Tag{0}.btw", row.ToString()));
            }

            entity = TagPrintTemplate_Dal.Find(hash);
            
            return entity.File_Name;
        }

        /// <summary>
        /// 返回洗唛文件名
        /// </summary>
        /// <param name="huohao">产品货号</param>
        /// <param name="row">成份行数</param>
        /// <returns>文件名</returns>
        public string GetWashFileName(string huohao,int row)
        {
            string str_clss = huohao.Substring(0, 1);
            string result = string.Empty;

            Hashtable hash = new Hashtable();
            hash.Add("type",str_clss);

            IEnumerator<Table_WashPrintTemplate_Entity> ator = WashPrintTemplate_Dal.Find(hash, SqlOperator.Like, false).GetEnumerator();

            while(ator.MoveNext())
            {
                if(ator.Current.File_Name.Substring(5,1) == row.ToString())
                {
                    result = ator.Current.File_Name;
                    break;
                }
            }
            
            return result;
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
            entity.LasTamp = UtilFun.GetTimeSLasTamp();

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
