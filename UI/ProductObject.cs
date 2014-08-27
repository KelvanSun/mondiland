using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
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

        public enum CodeType
        {
            Ok,
            Error,
        }
        //保存返回信息
        [Serializable]
        public class SaveResult
        {
            public CodeType Code;
            public string Message = string.Empty;
        }

        [Serializable]
        public class MaterialFillDataObject
        {
            /// <summary>
            /// 填充成份
            /// </summary>
            public string material_type = string.Empty;
            /// <summary>
            /// 填充方式
            /// </summary>
            public BindingList<BEMaterialFillData> m_material_fill_list = new BindingList<BEMaterialFillData>(); 
        };


        public MaterialFillDataObject MaterialFillData = new MaterialFillDataObject();
                    
        private int m_id = 0;
        
        private string m_huohao = string.Empty;
         
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

        private bool m_pbad = false;

        public bool Pbad
        {
            get { return m_pbad; }
            set { m_pbad = value; }
        }

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
        /// 产品成份信息
        /// </summary>
        public BindingList<BEMaterialDataInfo> MaterialDataList
        {
            get { return this.m_material_data_list; }
        }

        public BindingList<BESizeDataList> SizeDataList
        {
            get { return this.m_size_data_list; }
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
            set 
            {
                m_pwash = value; 
            }
        }
        /// <summary>
        /// 产品备注信息
        /// </summary>
        public string Memo
        {
            get { return m_memo; }
            set 
            {
                m_memo = value; 
            }
        }
        /// <summary>
        /// 产品价格
        /// </summary>
        public decimal Price
        {
            get { return m_price; }
            set 
            {
                m_price = value; 
            }
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

                if(this.m_standarddata_id > 0)
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

                if (m_safedata_id > 0)
                {
                    m_safedata = BLLFactory<BLLProductInfo>.Instance.ReadSafeDataTypeByPrimaryKey(m_safedata_id);
                }
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

                if (m_partname_id > 0)
                {

                    m_parntname = BLLFactory<BLLProductInfo>.Instance.ReadPartNameTypeByPrimaryKey(m_partname_id);

                    this.m_size_data_list = BLLFactory<BLLProductInfo>.Instance.ReadSizeDataList(m_partname_id);

                    //初始化自定义填充列表
                    IEnumerator<BESizeDataList> ator = this.m_size_data_list.GetEnumerator();

                    while (ator.MoveNext())
                    {
                        BEMaterialFillData data = new BEMaterialFillData();

                        data.SizeName = ator.Current.SizeName;
                        data.Fill = "0";

                        this.MaterialFillData.m_material_fill_list.Add(data);
                    }
                }
                
            }
        }

        /// <summary>
        /// 更新填充列表信息
        /// </summary>
        /// <param name="size_name">规格</param>
        /// <param name="fill">填充内容</param>
        public void UpdataMaterialFillList(string size_name,string fill)
        {
            IEnumerator<BEMaterialFillData> ator = this.MaterialFillData.m_material_fill_list.GetEnumerator();

            while(ator.MoveNext())
            {
                if (ator.Current.SizeName == size_name)
                    ator.Current.Fill = fill;
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

                if(this.m_madeplace_id > 0)
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
                
                if(m_dengji_id > 0)
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
            set 
            {
                m_huohao = value; 
            }
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
            this.m_pwash = info.Pwash;
            this.m_tag_id = info.Tag_Id;
            this.m_wash_id = info.Wash_Id;
            this.m_lastamp = info.LasTamp;
            this.m_pbad = info.Pbad;
            
            this.m_wash_size = BLLFactory<BLLProductInfo>.Instance.GetWashSize(this.m_id);

            this.m_material_data_list = BLLFactory<BLLProductInfo>.Instance.ReadMaterialDataList(this.m_id);
            this.MaterialFillData.m_material_fill_list = BLLFactory<BLLProductInfo>.Instance.ReadMaterialFillDataList(this.m_id);
            this.MaterialFillData.material_type = BLLFactory<BLLProductInfo>.Instance.ReadMaterialFillMaterial(this.m_id);

            this.m_tag_filename = string.Format("{0}\\{1}",ConfigurationManager.AppSettings["Template"],
                BLLFactory<BLLProductInfo>.Instance.GetTagFileName(this.m_pwash,this.m_pbad, this.m_material_data_list.Count + (this.MaterialFillData.m_material_fill_list.Count > 0 ? 1:0)));
            this.m_wash_filename = string.Format("{0}\\{1}",ConfigurationManager.AppSettings["Template"],
                BLLFactory<BLLProductInfo>.Instance.GetWashFileName(this.m_huohao, this.m_material_data_list.Count + (this.MaterialFillData.m_material_fill_list.Count > 0 ? 1 : 0)));
        }

        /// <summary>
        /// 以产品货号构造
        /// </summary>
        /// <param name="huohao">产品货号</param>
        public ProductObject(string huohao)
        {
            BEProductDataInfo product_info = BLLFactory<BLLProductInfo>.Instance.ReadByHuoHao(huohao);

            if (product_info == null)
                this.HuoHao = huohao;
            else
                LoadProductData(product_info);
        }

        /// <summary>
        /// 打印功能
        /// </summary>
        /// <param name="engine">打印引擎</param>
        /// <param name="printer_name">打印机名称</param>
        /// <param name="type">打印类型</param>
        /// <param name="select">规格</param>
        /// <param name="count">打印数量</param>
        public void Print(Engine engine,string printer_name,PrintType type,int select,int count)
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
            format.PrintSetup.PrinterName = printer_name;

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

            IEnumerator<BEMaterialFillData> materialfill_ator = this.MaterialFillData.m_material_fill_list.GetEnumerator();

            while(materialfill_ator.MoveNext())
            {
                if(materialfill_ator.Current.SizeName == str_size_name)
                {
                    str.Append(this.MaterialFillData.material_type);
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

        /// <summary>
        /// 保存记录
        /// </summary>
        /// <returns></returns>
        public SaveResult Save()
        {
            SaveResult result = new SaveResult();

            //save new
            if(this.m_id == 0)
            {
                if(this.m_huohao.Trim() == string.Empty)
                {
                    result.Code = CodeType.Error;
                    result.Message = "[产品货号]不能为空或输入的不合法,无法保存!";

                    return result;
                }

                if (BLLFactory<BLLProductInfo>.Instance.CheckProductHuoHaoIsExist(this.m_huohao.Trim()))
                {
                    result.Code = CodeType.Error;
                    result.Message = "[产品货号]重复,无法保存!";

                    return result;
                }

                if(this.m_partname_id == 0)
                {
                    result.Code = CodeType.Error;
                    result.Message = "[产品种类]不能为空,无法保存!";

                    return result;
                }

                if(this.m_dengji_id == 0)
                {
                    result.Code = CodeType.Error;
                    result.Message = "[产品等级]不能为空,无法保存!";

                    return result;
                }

                if(this.m_madeplace_id == 0)
                {
                    result.Code = CodeType.Error;
                    result.Message = "[产品产地]不能为空,无法保存!";

                    return result;
                }

                if(this.m_price == 0)
                {
                    result.Code = CodeType.Error;
                    result.Message = "[产品价格]不能为空，无法保存!";

                    return result;
                }

                if(this.m_safedata_id == 0)
                {
                    result.Code = CodeType.Error;
                    result.Message = "[安全标准]不能为空,无法保存!";

                    return result;
                }

                if(this.m_standarddata_id == 0)
                {
                    result.Code = CodeType.Error;
                    result.Message = "[执行标准]不能为空,无法保存!";

                    return result;
                }

                if(this.m_material_data_list.Count == 0)
                {
                    result.Code = CodeType.Error;
                    result.Message = "[面料成份信息列表]不能为空，无法保存!";

                    return result;
                }

                //当填充材质不为空时处理填充数据
                if(this.MaterialFillData.material_type.Trim() != string.Empty)
                {
                    IEnumerator<BEMaterialFillData> ator_data = this.MaterialFillData.m_material_fill_list.GetEnumerator();

                    while(ator_data.MoveNext())
                    {
                        if(ator_data.Current.Fill == "0")
                        {
                            result.Code = CodeType.Error;
                            result.Message = "填充规则数据制定不完整,请重新制定!";

                            return result;
                        }
                    }
                }


                BEProductDataInfo info = new BEProductDataInfo();

                info.HuoHao = this.m_huohao;
                info.PartName_Id = this.m_partname_id;
                info.Dengji_Id = this.m_dengji_id;
                info.MadePlace_Id = this.m_madeplace_id;
                info.Price = this.m_price;
                info.SafeData_Id = this.m_safedata_id;
                info.StandardData_Id = this.m_standarddata_id;
                info.Pwash = this.m_pwash;
                info.Pbad = this.m_pbad;
                
                info.Tag_Id = BLLFactory<BLLProductInfo>.Instance.GetTagFileNameId(info.Pwash,info.Pbad, this.m_material_data_list.Count + (this.MaterialFillData.m_material_fill_list.Count > 0 ? 1 : 0));
                info.Wash_Id = BLLFactory<BLLProductInfo>.Instance.GetWashFileNameId(this.m_huohao,this.m_material_data_list.Count + (this.MaterialFillData.m_material_fill_list.Count > 0 ? 1 : 0));
                
                if(info.Tag_Id == 0)
                {
                    result.Code = CodeType.Error;
                    result.Message = "系统未能找到对应的吊牌模板文件,保存无法继续!";

                    return result;
                }

                if(info.Wash_Id == 0)
                {
                    result.Code = CodeType.Error;
                    result.Message = "系统未能找到对应的洗唛模板文件,保存无法继续!";

                    return result;
                }


                if(!BLLFactory<BLLProductInfo>.Instance.AddProductInfo(info))
                {
                    result.Code = CodeType.Error;
                    result.Message = "产品基本信息保存失败";

                    return result;
                }

                this.m_id = BLLFactory<BLLProductInfo>.Instance.GetProductId(this.m_huohao);

                IEnumerator<BEMaterialDataInfo> ator = this.m_material_data_list.GetEnumerator();

                int index = 1;

                while(ator.MoveNext())
                {
                    BLLFactory<BLLProductInfo>.Instance.AddMaterialInfo(this.m_id, ator.Current.Type, index++);
                }

                if(this.MaterialFillData.material_type.Trim() != string.Empty)
                {
                    IEnumerator<BEMaterialFillData> fill_ator = this.MaterialFillData.m_material_fill_list.GetEnumerator();

                    while(fill_ator.MoveNext())
                    {
                        BLLFactory<BLLProductInfo>.Instance.AddMaterialFillInfo(this.m_id, fill_ator.Current.SizeName, this.MaterialFillData.material_type, fill_ator.Current.Fill);
                    }
                }

                result.Code = CodeType.Ok;
                result.Message = "保存成功!";
            }

            //Edit Save
            if(this.m_id != 0)
            {
                if (this.m_huohao.Trim() == string.Empty)
                {
                    result.Code = CodeType.Error;
                    result.Message = "[产品货号]不能为空或输入的不合法,无法保存!";

                    return result;
                }

                if (BLLFactory<BLLProductInfo>.Instance.CheckProductHuoHaoIsExitsWithoutMe(this.m_id,this.m_huohao.Trim()))
                {
                    result.Code = CodeType.Error;
                    result.Message = "[产品货号]重复,无法保存!";

                    return result;
                }

                if (this.m_price == 0)
                {
                    result.Code = CodeType.Error;
                    result.Message = "[产品价格]不能为空，无法保存!";

                    return result;
                }

                if (this.m_safedata_id == 0)
                {
                    result.Code = CodeType.Error;
                    result.Message = "[安全标准]不能为空,无法保存!";

                    return result;
                }

                if (this.m_standarddata_id == 0)
                {
                    result.Code = CodeType.Error;
                    result.Message = "[执行标准]不能为空,无法保存!";

                    return result;
                }

                if (this.m_material_data_list.Count == 0)
                {
                    result.Code = CodeType.Error;
                    result.Message = "[面料成份信息列表]不能为空，无法保存!";

                    return result;
                }

                //当填充材质不为空时处理填充数据
                if (this.MaterialFillData.material_type.Trim() != string.Empty)
                {
                    IEnumerator<BEMaterialFillData> ator_data = this.MaterialFillData.m_material_fill_list.GetEnumerator();

                    while (ator_data.MoveNext())
                    {
                        if (ator_data.Current.Fill == "0")
                        {
                            result.Code = CodeType.Error;
                            result.Message = "填充规则数据制定不完整,请重新制定!";

                            return result;
                        }
                    }
                }

                if(BLLFactory<BLLProductInfo>.Instance.UpdateCheckLastamp(this.m_id,this.m_lastamp))
                {
                    result.Code = CodeType.Error;
                    result.Message = "当前编辑的记录已经变更,无法保存!";

                    return result;
                }

                BEProductDataInfo info = new BEProductDataInfo();

                info.Id = this.m_id;
                info.HuoHao = this.m_huohao;
                info.PartName_Id = this.m_partname_id;
                info.Dengji_Id = this.m_dengji_id;
                info.MadePlace_Id = this.m_madeplace_id;
                info.Price = this.m_price;
                info.SafeData_Id = this.m_safedata_id;
                info.StandardData_Id = this.m_standarddata_id;
                info.Pwash = this.m_pwash;
                info.Pbad = this.m_pbad;

                info.Tag_Id = BLLFactory<BLLProductInfo>.Instance.GetTagFileNameId(info.Pwash, info.Pbad, this.m_material_data_list.Count + (this.MaterialFillData.m_material_fill_list.Count > 0 ? 1 : 0));
                info.Wash_Id = BLLFactory<BLLProductInfo>.Instance.GetWashFileNameId(this.m_huohao, this.m_material_data_list.Count + (this.MaterialFillData.m_material_fill_list.Count > 0 ? 1 : 0));

                if (info.Tag_Id == 0)
                {
                    result.Code = CodeType.Error;
                    result.Message = "系统未能找到对应的吊牌模板文件,保存无法继续!";

                    return result;
                }

                if (info.Wash_Id == 0)
                {
                    result.Code = CodeType.Error;
                    result.Message = "系统未能找到对应的洗唛模板文件,保存无法继续!";

                    return result;
                }

                if (!BLLFactory<BLLProductInfo>.Instance.UpdateProductInfo(info))
                {
                    result.Code = CodeType.Error;
                    result.Message = "产品基本信息保存失败";

                    return result;
                }

                //保存成份信息
                BLLFactory<BLLProductInfo>.Instance.DeleteMaterialInfo(this.m_id);

                IEnumerator<BEMaterialDataInfo> ator = this.m_material_data_list.GetEnumerator();

                int index = 1;

                while (ator.MoveNext())
                {
                    BLLFactory<BLLProductInfo>.Instance.AddMaterialInfo(this.m_id, ator.Current.Type, index++);
                }
                ////////////////////////////////////////////////////////

                BLLFactory<BLLProductInfo>.Instance.DeleteMaterialFillInfo(this.m_id);

                if (this.MaterialFillData.material_type.Trim() != string.Empty)
                {
                    IEnumerator<BEMaterialFillData> fill_ator = this.MaterialFillData.m_material_fill_list.GetEnumerator();

                    while (fill_ator.MoveNext())
                    {
                        BLLFactory<BLLProductInfo>.Instance.AddMaterialFillInfo(this.m_id, fill_ator.Current.SizeName, this.MaterialFillData.material_type, fill_ator.Current.Fill);
                    }
                }

                result.Code = CodeType.Ok;
                result.Message = "保存成功!";
            }
            

            return result;
        }
        
    }
}
