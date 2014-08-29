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

            foreach (Table_MaterialFill_Entity entity in MaterialFill_Dal.Find(hash, SqlOperator.And, true))
            {
                BEMaterialFillData info = new BEMaterialFillData();

                info.Id = entity.Id;
                info.SizeName = entity.Size_Name;
                info.Fill = entity.Fill;

                list.Add(info);
            }

            return list;
        }

        /// <summary>
        /// 取得填充物的面料成份
        /// </summary>
        /// <param name="id">产品ID</param>
        /// <returns>面料成份内容</returns>
        public string ReadMaterialFillMaterial(int id)
        {
            string str = string.Empty;
            
            Hashtable hash = new Hashtable();
            hash.Add("product_id", id);

            foreach (Table_MaterialFill_Entity entity in MaterialFill_Dal.Find(hash, SqlOperator.And, true))
            {
                str = entity.Type;
                break;
            }
            
            return str;
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

            int index = 1;

            foreach (Table_SizeData_Entity entity in SizeData_Dal.Find(hash, SqlOperator.And, true))
            {
                BESizeDataList info = new BESizeDataList();

                if (entity.Other == string.Empty)
                {
                    info.Id = index++;
                    info.SizeName = entity.Size_Name;
                    info.SizeType = entity.Size_Type;
                }
                else
                {
                    info.Id = index++;
                    info.SizeName = entity.Size_Name;
                    info.SizeType = string.Format("{0}({1})", entity.Size_Type, entity.Other);

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
            info.Pwash = entity.Pwash > 0 ? true:false;
            info.Pbad = entity.Pbad > 0 ? true : false;
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
            info.Pwash = entity.Pwash > 0 ? true : false;
            info.Pbad = entity.Pbad > 0 ? true : false;
            info.LasTamp = entity.LasTamp;
            info.Tag_Id = entity.Tag_Id;
            info.Wash_Id = entity.Wash_Id;
           

            return info;
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
        /// 返回所有产品货号信息
        /// </summary>
        /// <returns>列表<</returns>
        public List<string> GetHuoHaoList()
        {
            List<string> list = new List<string>();

            foreach (Table_ProductData_Entity entity in ProductData_Dal.GetAll(false))
            {
                list.Add(entity.HuoHao);
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

            foreach (Table_MaterialData_Entity entity in MaterialData_Dal.Find(hash, SqlOperator.And, true))
            {
                BEMaterialDataInfo info = new BEMaterialDataInfo();
                info.Id = entity.Id;
                info.Type = entity.Type;

                list.Add(info);
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
        public string GetTagFileName(bool pwash, bool pbad, int row)
        {
            Table_TagPrintTemplate_Entity entity = new Table_TagPrintTemplate_Entity();
            Hashtable hash = new Hashtable();

            if (pwash)
            {
                hash.Add("file_name", string.Format("TagA{0}.btw", row.ToString()));
            }
            else if(pbad)
            {
                hash.Add("file_name", string.Format("TagP{0}.btw", row.ToString()));
            }
            else
            {
                hash.Add("file_name", string.Format("Tag{0}.btw", row.ToString()));
            }

            entity = TagPrintTemplate_Dal.Find(hash);
            
            return entity.File_Name;
        }

        /// <summary>
        /// 返回吊牌文件名ID
        /// </summary>
        /// <param name="pwash">是否要打印水洗产品字样</param>
        /// <param name="row">成份行数</param>
        /// <returns>文件名ID</returns>
        public int GetTagFileNameId(bool pwash,bool pbad,int row)
        {
            Table_TagPrintTemplate_Entity entity = new Table_TagPrintTemplate_Entity();
            Hashtable hash = new Hashtable();

            if (pwash)
            {
                hash.Add("file_name", string.Format("TagA{0}.btw", row.ToString()));
            }
            else if(pbad)
            {
                hash.Add("file_name", string.Format("TagP{0}.btw", row.ToString()));
            }
            else
            {
                hash.Add("file_name", string.Format("Tag{0}.btw", row.ToString()));
            }

            entity = TagPrintTemplate_Dal.Find(hash);

            return entity.Id;

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

            foreach (Table_WashPrintTemplate_Entity entity in WashPrintTemplate_Dal.Find(hash, SqlOperator.Like, false))
            {
                if (entity.File_Name.Substring(5, 1) == row.ToString())
                {
                    result = entity.File_Name;
                    break;
                }
            }
            
            return result;
        }

        /// <summary>
        /// 返回洗唛文件名ID
        /// </summary>
        /// <param name="huohao">产品货号</param>
        /// <param name="row">成份行数</param>
        /// <returns>文件名ID</returns>
        public int GetWashFileNameId(string huohao, int row)
        {
            string str_clss = huohao.Substring(0, 1);
            int result = 0;

            Hashtable hash = new Hashtable();
            hash.Add("type", str_clss);

            foreach (Table_WashPrintTemplate_Entity entity in WashPrintTemplate_Dal.Find(hash, SqlOperator.Like, false))
            {
                if (entity.File_Name.Substring(5, 1) == row.ToString())
                {
                    result = entity.Id;
                    break;
                }
            }

            return result;
        }
        
                     
        public bool AddMaterialInfo(int product_id,string type,int order)
        {
            Table_MaterialData_Entity entity = new Table_MaterialData_Entity();
            entity.Product_Id = product_id;
            entity.Type = type;
            entity.Order_Index = order;
            entity.LasTamp = UtilFun.GetTimeSLasTamp();

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
            if (info.Pwash)
                entity.Pwash = 1;
            else
                entity.Pwash = 0;
            if (info.Pbad)
                entity.Pbad = 1;
            else
                entity.Pbad = 0;
            entity.LasTamp = UtilFun.GetTimeSLasTamp();
            
            return ProductData_Dal.Insert(entity);
        }

        /// <summary>
        /// 保存填充数据前先删除原先信息
        /// </summary>
        /// <param name="product_id"></param>
        /// <returns></returns>
        public bool DeleteMaterialFillInfo(int product_id)
        {
            Hashtable hash = new Hashtable();

            hash.Add("product_id", product_id);

            return MaterialFill_Dal.Delete(hash);
        }

        /// <summary>
        /// 保存前删除成份信息
        /// </summary>
        /// <param name="product_id"></param>
        /// <returns></returns>
        public bool DeleteMaterialInfo(int product_id)
        {
            Hashtable hash = new Hashtable();
            hash.Add("product_id",product_id);

            return MaterialData_Dal.Delete(hash);
        }

        /// <summary>
        /// 保存主记录信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool UpdateProductInfo(BEProductDataInfo info)
        {
            Hashtable field = new Hashtable();
            field.Add("huohao", info.HuoHao);
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
            field.Add("pbad", info.Pbad);
            field.Add("lastamp", UtilFun.GetTimeSLasTamp());

            Hashtable where = new Hashtable();

            where.Add("id", info.Id);

            return ProductData_Dal.Update(field, where);
   
        }
                     
        /// <summary>
        /// 根据货号检察记录是否存在        
        /// </summary>
        /// <param name="str_huohao">货号</param>
        /// <returns>true 代表存在</returns>
        public bool CheckProductHuoHaoIsExist(string str_huohao)
        {
       
            Hashtable hash = new Hashtable();

            hash.Add("huohao", str_huohao);

            return ProductData_Dal.IsExistKey(hash);
        }

        /// <summary>
        /// 根据货号检察记录是否存在排除自身
        /// </summary>
        /// <param name="id">产品ID号</param>
        /// <param name="str_huohao">产品货号</param>
        /// <returns>true为找到重复</returns>
        public bool CheckProductHuoHaoIsExitsWithoutMe(int id,string str_huohao)
        {
            Hashtable hash = new Hashtable();

            hash.Add("id", id);
            hash.Add("huohao", str_huohao);

            List<Table_ProductData_Entity> list = ProductData_Dal.Find(hash, SqlOperator.And, false);

            return list.Count > 1 ? true : false; 
        }
        
        /// <summary>
        /// 修改保存前检察lastamp是否有变动
        /// </summary>
        /// <param name="lastamp"></param>
        /// <returns>true为已经变动</returns>
        public bool UpdateCheckLastamp(int id,long lastamp)
        {
            Table_ProductData_Entity entity = ProductData_Dal.FindByID(id);

            return entity.LasTamp != lastamp;
        }
   
    }
}
