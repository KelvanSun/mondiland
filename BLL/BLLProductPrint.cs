using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using Mondiland.Entity;
using Mondiland.IDal;
using Mondiland.BLLEntity;
using Mondiland.Global;

namespace Mondiland.BLL
{
    public class BLLProductPrint:BaseBLL
    {
        private ITable_ProductData ProductData_Dal = null;
        private ITable_SizeData SizeData_Dal = null;
        private ITable_PartName PartName_Dal = null;
        private ITable_SafeData SafeData_Dal = null;
        private ITable_StandardData StandardData_Dal = null;
        private ITable_Dengji Dengji_Dal = null;
        private ITable_MadePlace MadePlace_Dal = null;
        private ITable_TagPrintTemplate TagPrintTemplate_Dal = null;
        private ITable_MaterialData MaterialData_Dal = null;
        private ITable_MaterialFill MaterialFill_Dal = null;
        private ITable_WashPrintTemplate WashPrintTemplate_Dal = null;

        public BLLProductPrint()
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
        public bool UpdatePrice(int product_id,decimal price)
        {
            Hashtable hash_update = new Hashtable();;
            Hashtable hash_where = new Hashtable();

            hash_update.Add("price",price);
            hash_where.Add("id",product_id);

            return ProductData_Dal.Update(hash_update, hash_where);
        }
        public string GetTagPrintTemplateFileName(int product_id)
        {
            Table_ProductData_Entity product = ProductData_Dal.FindByID(product_id);
            Table_TagPrintTemplate_Entity tag = TagPrintTemplate_Dal.FindByID(product.Tag_Id);

            return tag.File_Name;
        }

        public string GetWashDaXiao(int product_id)
        {
            Table_ProductData_Entity product = ProductData_Dal.FindByID(product_id);
            Table_WashPrintTemplate_Entity wash = WashPrintTemplate_Dal.FindByID(product.Wash_Id);

            return wash.DaXiao;
        }


        public string GetWashPrintTemplateFileName(int product_id)
        {
            Table_ProductData_Entity product = ProductData_Dal.FindByID(product_id);
            Table_WashPrintTemplate_Entity wash = WashPrintTemplate_Dal.FindByID(product.Wash_Id);

            return wash.File_Name;
        }

        public BEProductDataAllInfo GetProductInfoAll(int id)
        {
       
            BEProductDataAllInfo info = new BEProductDataAllInfo();

            Table_ProductData_Entity product = ProductData_Dal.FindByID(id);

            Table_PartName_Entity partname = PartName_Dal.FindByID(product.PartName_Id);
            Table_SafeData_Entity safedata = SafeData_Dal.FindByID(product.SafeData_Id);
            Table_StardardData_Entity stardarddata = StandardData_Dal.FindByID(product.StandardData_Id);
            Table_Dengji_Entity dengji = Dengji_Dal.FindByID(product.Dengji_Id);
            Table_MadePlace_Entity madeplace = MadePlace_Dal.FindByID(product.MadePlace_Id);

            info.PartName = partname.Name;
            info.HuoHao = product.HuoHao;
            info.SafeData = safedata.Type;
            info.StandardData = stardarddata.Type;
            info.Price = product.Price;
            info.MadePlace = madeplace.Type;
            info.DengJi = dengji.Type;

            return info;
        }
        public int GetProductId(string str_huohao)
        {
            Hashtable hash = new Hashtable();
            hash.Add("huohao", str_huohao);

            return ProductData_Dal.FindPrimaryKey(hash);
        }

        public string GetBarcode(int product_id,string size_name)
        {
            string str = string.Empty;

            Table_ProductData_Entity product = ProductData_Dal.FindByID(product_id);
            Table_PartName_Entity partname = PartName_Dal.FindByID(product.PartName_Id);


            str = string.Format("{0}{1}{2}", partname.Barcode, product.HuoHao, size_name);

            return str;
        }

        public string GetMaterialData(int product_id,string size_name)
        {
            string str = string.Empty;
            
            Hashtable hash = new Hashtable();
            hash.Add("product_id", product_id);

            IEnumerator<Table_MaterialData_Entity> ator = MaterialData_Dal.Find(hash, SqlOperator.And, true).GetEnumerator();

            while(ator.MoveNext())
            {
                str += ator.Current.Type;
                str += "\r\n";
            }

            hash.Clear();

            hash.Add("product_id",product_id);

            if(MaterialFill_Dal.IsExistKey(hash))
            {
                hash.Clear();
                hash.Add("product_id", product_id);
                hash.Add("size_name",size_name);

                Table_MaterialFill_Entity fill = MaterialFill_Dal.Find(hash);

                str += fill.Type + string.Format("充绒量:{0}g\r\n", fill.Fill);
            }

            return str = str.Substring(0, str.Length - 2); 
         }
        public List<string> GetSizeDataInfo(int product_id)
        {
            List<string> list = new List<string>();

            Table_ProductData_Entity product = ProductData_Dal.FindByID(product_id);
            Table_PartName_Entity partname = PartName_Dal.FindByID(product.PartName_Id);

            Hashtable hash = new Hashtable();
            hash.Add("class_id", partname.SizeClass_id);

            IEnumerator<Table_SizeData_Entity> ator = SizeData_Dal.Find(hash, SqlOperator.And, true).GetEnumerator();

            while(ator.MoveNext())
            {
                if (ator.Current.Other == string.Empty)
                {
                    list.Add(string.Format("{0}---{1}", ator.Current.Size_Name, ator.Current.Size_Type));
                }
                else
                {
                    list.Add(string.Format("{0}---{1}({2})", ator.Current.Size_Name, ator.Current.Size_Type,ator.Current.Other));
                }
            }

            return list;
        }
    }
}
