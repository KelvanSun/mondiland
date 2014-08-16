using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.Serialization.Formatters.Binary;

using Mondiland.BLL;
using Mondiland.BLLEntity;

using Seagull.BarTender.Print;

namespace Mondiland.UI
{
    /// <summary>
    /// 产品对象类
    /// </summary>
    [Serializable]
    public class ProductObject:ICloneable
    {
        public enum PrintType
        {
            Tag,
            Wash,
        }
             
        private int m_id = 0;
        
        private string m_huohao = string.Empty;
        private int m_huohao_id = 0;
        
        private string m_dengji = string.Empty;
        private int m_dengji_id = 0;
        
        private string m_madeplace = string.Empty;
        private int m_madeplace_id = 0;

        private string m_parntname = string.Empty;
        private int m_partname_id = 0;

        private string m_safedata = string.Empty;
        private int m_safedata_id = 0;

        private string m_standarddata = string.Empty;
        private int m_standarddata_id = 0;

        private int m_tag_id = 0;
        private int m_wash_id = 0;

        private string m_wash_size = string.Empty;

        /// <summary>
        /// 洗唛大小
        /// </summary>
        public string WashSize
        {
            get { return m_wash_size; }
        }


        private decimal m_price = 0;
        private string m_memo = string.Empty;
        private bool m_pwash = false;
        private long m_lastamp = 0;
        /// <summary>
        /// 条形码前缀
        /// </summary>
        private string m_barcode_prefix = string.Empty;
        /// <summary>
        /// 吊牌文件名
        /// </summary>
        private string m_tag_filename = string.Empty;
        /// <summary>
        /// 洗唛文件名
        /// </summary>
        private string m_wash_filename = string.Empty;

        /// <summary>
        /// 产品号型列表
        /// </summary>size_data_list
        private BindingList<BESizeDataList> m_size_data_list = new BindingList<BESizeDataList>();
        /// <summary>
        /// 产品成份信息
        /// </summary>
        private BindingList<BEMaterialDataInfo> m_material_data_list = new BindingList<BEMaterialDataInfo>();
        /// <summary>
        /// 产品填充信息
        /// </summary>
        private BindingList<BEMaterialFillData> m_material_fill_list = new BindingList<BEMaterialFillData>();
        
        
        public BindingList<BESizeDataList> SizeDataList
        {
            get { return m_size_data_list; }
        }

        /// <summary>
        /// 打印吊牌模板文件ID号
        /// </summary>
        public int Tag_Id
        {
            get { return m_tag_id; }
            set { m_tag_id = value; }
        }

        /// <summary>
        /// 打印洗唛模板文件ID号
        /// </summary>
        public int Wash_Id
        {
            get { return m_wash_id; }
            set { m_wash_id = value; }
        }

        /// <summary>
        /// 是否打印[水洗产品] false为不打印
        /// </summary>
        public bool Pwash
        {
            get { return m_pwash; }
            set { m_pwash = value; }
        }
        /// <summary>
        /// 产品备注信息
        /// </summary>
        public string Memo
        {
            get { return m_memo; }
            set { m_memo = value; }
        }
        /// <summary>
        /// 产品价格
        /// </summary>
        public decimal Price
        {
            get { return m_price; }
            set { m_price = value; }
        }
        /// <summary>
        /// 执行标准ID号
        /// </summary>
        public int StandardData_Id
        {
            get { return m_standarddata_id; }
            set 
            { 
                m_standarddata_id = value;
                m_standarddata = BLLFactory<BLLProductInfo>.Instance.ReadStandardDataTypeByPrimaryKey(m_standarddata_id);
            }
        }
        /// <summary>
        /// 执行标准名称
        /// </summary>
        public string StandardData
        {
            get { return m_standarddata;}
        }
        /// <summary>
        /// 安全标准ID号
        /// </summary>
        public int SafeData_Id
        {
            get { return m_safedata_id; }
            set 
            { 
                m_safedata_id = value;
                m_safedata = BLLFactory<BLLProductInfo>.Instance.ReadSafeDataTypeByPrimaryKey(m_safedata_id);
            }
        }
        /// <summary>
        /// 安全标准内容
        /// </summary>
        public string SafeData
        {
            get { return m_safedata; }
        }
        /// <summary>
        /// 产品分类ID号
        /// </summary>
        public int PartName_Id
        {
            get { return m_partname_id; }
            set 
            { 
                m_partname_id = value;
                m_parntname = BLLFactory<BLLProductInfo>.Instance.ReadPartNameTypeByPrimaryKey(m_partname_id);

                this.m_size_data_list = BLLFactory<BLLProductInfo>.Instance.ReadSizeDataList(m_partname_id);
            }
        }

        /// <summary>
        /// 产品分类名称
        /// </summary>
        public string PartName
        {
            get { return m_parntname; }
        }

        /// <summary>
        /// 产品产地ID号
        /// </summary>
        public int MadePlace_Id
        {
            get { return m_madeplace_id; }
            set 
            { 
                m_madeplace_id = value;

                m_madeplace = BLLFactory<BLLProductInfo>.Instance.ReadMadePlaceTypeByPrimaryKey(m_madeplace_id);
            }
        }
        /// <summary>
        /// 产品产地名称
        /// </summary>
        public string MadePlace
        {
            get { return m_madeplace; }
        }
        /// <summary>
        /// 产品等级ID号
        /// </summary>
        public int DengJi_Id
        {
            get { return m_dengji_id; }
            set 
            { 
                m_dengji_id = value;
                m_dengji = BLLFactory<BLLProductInfo>.Instance.ReadDengJiTypeByPrimaryKey(m_dengji_id);
            }
        }
        /// <summary>
        /// 产品等级内容
        /// </summary>
        public string DengJi
        {
            get { return m_dengji; }
        }
        /// <summary>
        /// 产品ID号
        /// </summary>
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        /// <summary>
        /// 产品货号
        /// </summary>
        public string HuoHao
        {
            get { return m_huohao; }
            set { m_huohao = value; }
        }
        /// <summary>
        /// 产品货号ID
        /// </summary>
        public int HuoHao_Id
        {
            get { return m_huohao_id; }
            set { m_huohao_id = value; }
        }

        public ProductObject() {}
        
        /// <summary>
        /// 以产品ID号构造
        /// </summary>
        /// <param name="id">ID号</param>
        public ProductObject(int id)
        {
            BEProductDataInfo product_info = BLLFactory<BLLProductInfo>.Instance.ReadByPrimaryKey(id);

            if(product_info != null)    LoadProductData(product_info);
        }

        /// <summary>
        /// 载入数据
        /// </summary>
        /// <param name="info">BEProductDataInfo结构</param>
        private void LoadProductData(BEProductDataInfo info)
        {
            this.m_id = info.Id;
            this.HuoHao = info.HuoHao;
            this.DengJi_Id = info.Dengji_Id;
            this.MadePlace_Id = info.MadePlace_Id;
            this.PartName_Id = info.PartName_Id;
            this.SafeData_Id = info.SafeData_Id;
            this.StandardData_Id = info.StandardData_Id;
            this.m_price = info.Price;
            this.m_memo = info.Memo;
            this.Pwash = info.Pwash > 0 ? true : false;
            this.Tag_Id = info.Tag_Id;
            this.Wash_Id = info.Wash_Id;
            this.m_lastamp = info.LasTamp;

            this.m_wash_size = BLLFactory<BLLProductInfo>.Instance.GetWashSize(this.m_id);

            this.m_material_data_list = BLLFactory<BLLProductInfo>.Instance.ReadMaterialDataList(this.m_id);
            this.m_material_fill_list = BLLFactory<BLLProductInfo>.Instance.ReadMaterialFillDataList(this.m_id);

            this.m_tag_filename = string.Format("{0}\\{1}",ConfigurationManager.AppSettings["Template"],
                BLLFactory<BLLProductInfo>.Instance.GetTagFileName(this.m_pwash, this.m_material_data_list.Count));
            this.m_wash_filename = string.Format("{0}\\{1}",ConfigurationManager.AppSettings["Template"],
                BLLFactory<BLLProductInfo>.Instance.GetWashFileName(this.m_huohao, this.m_material_data_list.Count));
        }

        /// <summary>
        /// 以产品货号构造
        /// </summary>
        /// <param name="huohao">产品货号</param>
        public ProductObject(string huohao)
        {
            BEProductDataInfo product_info = BLLFactory<BLLProductInfo>.Instance.ReadByHuoHao(huohao);

            if (product_info != null) LoadProductData(product_info);
        }

        /// <summary>
        /// 打印功能
        /// </summary>
        /// <param name="engine">打印引擎</param>
        /// <param name="type">打印类型</param>
        /// <param name="select">规格</param>
        /// <param name="count">打印数量</param>
        public void Print(Engine engine,PrintType type,int select,int count)
        {
            string str_size_name = string.Empty;
            string str_size_type = string.Empty;
            
            LabelFormatDocument format = null;
            
            //先得到对应的规格号型
            IEnumerator<BESizeDataList> ator = this.m_size_data_list.GetEnumerator();
            
            while(ator.MoveNext())
            {
                if(ator.Current.Id == select)
                {
                    str_size_name = ator.Current.SizeName;
                    str_size_type = ator.Current.SizeType;

                    break;
                }
            }

            //打印吊牌
            if(type == PrintType.Tag)
            {
                format = engine.Documents.Open(this.m_tag_filename);

                format.SubStrings.SetSubString("PinMin", this.m_parntname);
                format.SubStrings.SetSubString("HuoHao", this.m_huohao);
                format.SubStrings.SetSubString("GuiGe", str_size_name);
                format.SubStrings.SetSubString("XingHao", str_size_type);
                format.SubStrings.SetSubString("SafeData", this.m_safedata);
                format.SubStrings.SetSubString("StandardData", this.m_standarddata);
                format.SubStrings.SetSubString("JiaGe", string.Format("￥{0:F2}", Convert.ToDecimal(this.m_price)));
                format.SubStrings.SetSubString("ChanDi", this.m_madeplace);
                format.SubStrings.SetSubString("DengJi", this.m_dengji);
                format.SubStrings.SetSubString("ChengFeng",this.BuildMaterialDataString(str_size_name));
                format.SubStrings.SetSubString("TiaoMa", this.BuildBarcode(str_size_name));
                
            }
            else if(type == PrintType.Wash)
            {
                format = engine.Documents.Open(this.m_wash_filename);

                format.SubStrings.SetSubString("HuoHao", this.m_huohao);
                format.SubStrings.SetSubString("GuiGe", str_size_name);
                format.SubStrings.SetSubString("XingHao", str_size_type);
                format.SubStrings.SetSubString("ChengFeng", this.BuildMaterialDataString(str_size_name));
            }

            format.PrintSetup.IdenticalCopiesOfLabel = Convert.ToInt32(count);

            format.Print();
            
        }

        /// <summary>
        /// 生成条型码
        /// </summary>
        /// <param name="size_name">规格</param>
        /// <returns>条型码字符串</returns>
        public string BuildBarcode(string size_name)
        {

            return string.Format("{0}{1}{2}", BLLFactory<BLLProductInfo>.Instance.GetBarCodePrefix(this.m_partname_id),
                                          this.m_huohao,size_name);
        }

        /// <summary>
        /// 生成成份打印字符串
        /// </summary>
        /// <param name="str_size_name">规格</param>
        /// <returns>生成的字符串</returns>
        private string BuildMaterialDataString(string str_size_name)
        {
            StringBuilder str = new StringBuilder();

            IEnumerator<BEMaterialDataInfo> material_ator = this.m_material_data_list.GetEnumerator();

            while(material_ator.MoveNext())
            {
                str.Append(material_ator.Current.Type);
                str.Append("\r\n");
            }

            IEnumerator<BEMaterialFillData> materialfill_ator = this.m_material_fill_list.GetEnumerator();

            while(materialfill_ator.MoveNext())
            {
                if(materialfill_ator.Current.SizeName == str_size_name)
                {
                    str.Append(materialfill_ator.Current.Type);
                    str.Append(string.Format(" 充绒量:{0}g\r\n",materialfill_ator.Current.Fill));
                }
            }

            return str.ToString().Substring(0, str.Length - 2);
  
        }

        public Object Clone()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;

            return formatter.Deserialize(stream);
        }
        
    }
}
