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

        public BEProductDataAllInfo GetProductAllInfo(string str_huohao)
        {
            
            BEProductDataAllInfo info = new BEProductDataAllInfo();

            Hashtable hash = new Hashtable();
            hash.Add("huohao", str_huohao);

            Table_ProductData_Entity entity = ProductData_Dal.Find(hash);

            info.PartName = GetPartNameType(entity.PartName_Id);
            info.DengJi = GetDengjiType(entity.Dengji_Id);
            info.MadePlace = GetMadePlaceType(entity.MadePlace_Id);
            info.Price = entity.Price;
            info.SafeData = GetSafeDataType(entity.SafeData_Id);
            info.StandardData = GetStandardDataType(entity.StandardData_Id);
            info.Memo = entity.Memo;
            info.Tag = GetTagType(entity.Tag_Id);
            info.Wash = GetWashType(entity.Wash_Id);
            info.Id = entity.Id;
            info.Pwash = entity.Pwash;
            info.LasTamp = entity.LasTamp;
            
            return info;
            
        }

        private string GetWashType(int id)
        {
            Table_WashPrintTemplate_Entity entity = WashPrintTemplate_Dal.FindByID(id);

            return entity.Type;
        }
        private string GetTagType(int id)
        {
            Table_TagPrintTemplate_Entity entity = TagPrintTemplate_Dal.FindByID(id);

            return entity.Type;
        }

        private string GetStandardDataType(int id)
        {
            Table_StardardData_Entity entity = StandardData_Dal.FindByID(id);

            return entity.Type;

        }

        private string GetSafeDataType(int id)
        {
            
            Table_SafeData_Entity entity = SafeData_Dal.FindByID(id);

            return entity.Type;
        }
        private string GetMadePlaceType(int id)
        {
            Table_MadePlace_Entity entity = MadePlace_Dal.FindByID(id);

            return entity.Type;
        }

        private string GetDengjiType(int id)
        {
            Table_Dengji_Entity entity = Dengji_Dal.FindByID(id);

            return entity.Type;
        }

        private string GetPartNameType(int id)
        {
            Table_PartName_Entity entity = PartName_Dal.FindByID(id);

            return entity.Name;
        }

        public List<string> GetFillSizeList(string str_parntname)
        {
            Table_PartName_Entity parntname = new Table_PartName_Entity();
            List<string> list = new List<string>();

            Hashtable hash1 = new Hashtable();
            hash1.Add("name", str_parntname);
            parntname = PartName_Dal.Find(hash1);

            Hashtable hash2 = new Hashtable();
            hash2.Add("class_id",parntname.SizeClass_id);

            IEnumerator<Table_SizeData_Entity> ator = SizeData_Dal.Find(hash2, SqlOperator.And, true).GetEnumerator();

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
            where.Add("LasTamp", LasTamp);

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

        public int GetStandardDataId(string str_name)
        {
            Hashtable hash = new Hashtable();
            hash.Add("type", str_name);

            return StandardData_Dal.FindPrimaryKey(hash);
        }
        public int GetSafeDataId(string str_name)
        {
            Hashtable hash = new Hashtable();
            hash.Add("type", str_name);

            return SafeData_Dal.FindPrimaryKey(hash);

        }
        public int GetMadePlaceId(string str_name)
        {
  
            Hashtable hash = new Hashtable();
            hash.Add("type", str_name);

            return MadePlace_Dal.FindPrimaryKey(hash);
        }

        public int GetPartNameId(string str_partname)
        {
            Hashtable hash = new Hashtable();
            hash.Add("name",str_partname);

            return PartName_Dal.FindPrimaryKey(hash);
        }
         
        public int GetDengjiNameId(string str_name)
        {
            Hashtable hash = new Hashtable();
            hash.Add("type", str_name);

            return Dengji_Dal.FindPrimaryKey(hash);
        }

        public int GetWashNameId(string str_name)
        {
            Hashtable hash = new Hashtable();
            hash.Add("type", str_name);

            return WashPrintTemplate_Dal.FindPrimaryKey(hash);
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


        public List<string> GetStandarDataName()
        {
            IEnumerator<string> ator = StandardData_Dal.GetItemString("type",true).GetEnumerator();
            List<string> list = new List<string>();

            while (ator.MoveNext())
            {
                list.Add(ator.Current.ToString());
            }

            return list;
        }
        
        
        public List<string> GetSafeDataName()
        {
            IEnumerator<string> ator = SafeData_Dal.GetItemString("type",true).GetEnumerator();
            List<string> list = new List<string>();

            while (ator.MoveNext())
            {
                list.Add(ator.Current.ToString());
            }

            return list;
        }



        public List<string> GetMadePlaceName()
        {
            IEnumerator<string> ator = MadePlace_Dal.GetItemString("type",false).GetEnumerator();
            List<string> list = new List<string>();

            while(ator.MoveNext())
            {
                list.Add(ator.Current.ToString());
            }

            return list;
        }
        
        public List<string> GetPartName()
        {
            IEnumerator<string> ator = PartName_Dal.GetItemString("name",false).GetEnumerator();
            List<string> list = new List<string>();

            while(ator.MoveNext())
            {
                list.Add(ator.Current.ToString());
            }

            return list;
        }

        public List<string> GetWashTemplateName()
        {
            IEnumerator<string> ator = WashPrintTemplate_Dal.GetItemString("type",false).GetEnumerator();
            
            List<string> list = new List<string>();

            while(ator.MoveNext())
            {
                list.Add(ator.Current.ToString());
            }
            
            return list;
        }

        public List<string> GetDengjiName()
        {
            IEnumerator<string> ator = Dengji_Dal.GetItemString("type",false).GetEnumerator();
            List<string> list = new List<string>();

            while(ator.MoveNext())
            {
                list.Add(ator.Current.ToString());
            }

            return list;
        }

    }
}
