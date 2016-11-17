using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

using Mondiland.EFModule;
using Mondiland.Global;

using Seagull.BarTender.Print;

namespace Mondiland.Obj
{
    /// <summary>
    /// 产品对象类
    /// </summary>
    [Serializable]
    public class ProductObject:ICloneable
    {
        public enum PrintType
        {
            TagCODE93,
            TagEAN13,
            Wash,
        }

        [Serializable]
        public class EAN13DataInfo
        {
            private int m_id = 0;
            private string m_size_name = string.Empty;
            private string m_barcode_type = string.Empty;
            private string m_memo = string.Empty;

            public int Id
            {
                get { return m_id; }
                set { m_id = value; }
            }

            /// <summary>
            /// 规格
            /// </summary>
            public string SizeName
            {
                get { return m_size_name; }
                set { m_size_name = value; }
            }
 
            public string BarcodeType
            {
                get { return m_barcode_type; }
                set { m_barcode_type = value; }
            }

            public string Memo
            {
                get { return m_memo; }
                set { m_memo = value; }
            }

        }

        [Serializable]
        public class SizeDataList
        {
            private int m_id = 0;
            private string m_size_name = string.Empty;
            private string m_size_type = string.Empty;

            /// <summary>
            /// 用以定位用户选择的项
            /// </summary>
            public int Id
            {
                get { return m_id; }
                set { m_id = value; }
            }

            /// <summary>
            /// 规格
            /// </summary>
            public string SizeName
            {
                get { return m_size_name; }
                set { m_size_name = value; }
            }
            /// <summary>
            /// 号型
            /// </summary>
            public string SizeType
            {
                get { return m_size_type; }
                set { m_size_type = value; }
            }
        }

        [Serializable]
        public class MaterialFillInfoObject
        {
            /// <summary>
            /// 填充成份
            /// </summary>
            public string material_type = string.Empty;
            /// <summary>
            /// 填充方式
            /// </summary>
            public BindingList<MaterialFillData> m_material_fill_list = new BindingList<MaterialFillData>();

            [Serializable]
            public class MaterialFillData
            {
                private int m_id = 0;
                private string m_size_name = string.Empty;
                private string m_fill = string.Empty;

                /// <summary>
                /// 对应与表的记录表ID
                /// </summary>
                public int Id
                {
                    get { return m_id; }
                    set { m_id = value; }
                }

                /// <summary>
                /// 规格
                /// </summary>
                public string SizeName
                {
                    get { return m_size_name; }
                    set { m_size_name = value; }
                }

                /// <summary>
                /// 每个规格的填充克数
                /// </summary>
                public string Fill
                {
                    get { return m_fill; }
                    set { m_fill = value; }
                }
            }
        };


        public MaterialFillInfoObject MaterialFillInfo = new MaterialFillInfoObject();
                    
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

        private bool m_ptemplate = false;
        private string m_template_data = string.Empty;

        private string m_gyear = string.Empty;
        private string m_gmonth = string.Empty;
        private string m_colordata = string.Empty;
        private int m_color_id = 0;

        public bool Ptemplate
        {
            get { return m_ptemplate; }
            set { m_ptemplate = value; }
        }

        public string TemplateData
        {
            get { return m_template_data; }
            set { m_template_data = value; }
        }

        public string Gyear
        {
            get { return m_gyear; }
            set { m_gyear = value; }
        }

        public string Gmonth
        {
            get { return m_gmonth; }
            set { m_gmonth = value; }
        }

        public int Color_Id
        {
            get { return m_color_id; }
            set { 
                m_color_id = value;
 
                if(this.m_color_id > 0)
                {
                    using (ProductContext ctx = new ProductContext())
                    {
                        this.m_colordata = (from data in ctx.ColorData
                                            where data.id == m_color_id
                                            select data.type).FirstOrDefault();
                    }
                }
            }
        }

        public string ColorData
        {
            get { return m_colordata; }
        }

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
        private int m_wash_u = 0;

        private Guid m_lastamp = Guid.Empty;
        /// <summary>
        /// 条形码前缀
        /// </summary>
        private string m_barcode_prefix = string.Empty;
        /// <summary>
        /// 吊牌文件名
        /// </summary>
        private string m_tagCODE93_filename = string.Empty;
        /// <summary>
        /// 洗唛文件名
        /// </summary>
        private string m_wash_filename = string.Empty;

        private string m_tagEAN13_filename = string.Empty;

        /// <summary>
        /// 产品号型列表
        /// </summary>size_data_list
        private BindingList<SizeDataList> m_size_data_list = new BindingList<SizeDataList>();
        /// <summary>
        /// 产品成份信息
        /// </summary>
        private BindingList<MaterialDataInfo> m_material_data_list = new BindingList<MaterialDataInfo>();

        /// <summary>
        /// EAN13条码信息
        /// </summary>
        private BindingList<EAN13DataInfo> m_ean13_data_list = new BindingList<EAN13DataInfo>();


        [Serializable]
        public class MaterialDataInfo
        {
            private int m_id = 0;
            private bool m_sel = true;
            private string m_type = string.Empty;
            private string m_memo = string.Empty;

            public int Id
            {
                get { return m_id; }
                set { m_id = value; }
            }

            public string Type
            {
                get { return m_type; }
                set { m_type = value; }
            }

            public bool Sel
            {
                get { return m_sel; }
                set { m_sel = value; }
            }

            public string Memo
            {
                get { return m_memo; }
                set { m_memo = value; }
            }

        }


        /// <summary>
        /// 产品成份信息
        /// </summary>
        public BindingList<MaterialDataInfo> MaterialDataList
        {
            get { return this.m_material_data_list; }
        }

        public BindingList<SizeDataList> SizeDataListInfo
        {
            get { return this.m_size_data_list; }
        }

        public BindingList<EAN13DataInfo> EAN13DataListInfo
        {
            get { return this.m_ean13_data_list; }
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
                {
                    using (ProductContext ctx = new ProductContext())
                    {
                        m_standarddata = (from data in ctx.StandardData
                                          where data.id == m_standarddata_id
                                          select data.type).FirstOrDefault();
                    }
                }
                   
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
                    using (ProductContext ctx = new ProductContext())
                    {
                        m_safedata = (from data in ctx.SafeData
                                      where data.id == m_safedata_id
                                      select data.type).FirstOrDefault();
                    }
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

                    using (ProductContext ctx = new ProductContext())
                    {
                        m_parntname = (from data in ctx.PartName
                                       where data.id == m_partname_id
                                       select data.name).FirstOrDefault();

                        int class_id = (from data in ctx.PartName
                                        where data.id == m_partname_id
                                        select data.size_class_id).FirstOrDefault();

                        var sizedata = from data in ctx.SizeData
                                       where data.class_id == class_id
                                       orderby data.size_name
                                       select data;

                        int index = 1;

                        m_size_data_list.Clear();

                        foreach (var data in sizedata)
                        {
                            SizeDataList info = new SizeDataList();

                            if(string.IsNullOrEmpty(data.other))
                            {
                                info.Id = index++;
                                info.SizeName = data.size_name;
                                info.SizeType = data.size_type;
                            }
                            else
                            {
                                info.Id = index++;
                                info.SizeName = data.size_name;
                                info.SizeType = string.Format("{0}({1})", data.size_type, data.other);
                            }

                            m_size_data_list.Add(info);
                        }

                    }


                    this.MaterialFillInfo.m_material_fill_list.Clear();
                    //初始化自定义填充列表
                    foreach (SizeDataList item in this.m_size_data_list)
                    {
                        MaterialFillInfoObject.MaterialFillData data = new MaterialFillInfoObject.MaterialFillData();

                        data.SizeName = item.SizeName;
                        data.Fill = "0";

                        this.MaterialFillInfo.m_material_fill_list.Add(data);
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
            foreach(MaterialFillInfoObject.MaterialFillData data in this.MaterialFillInfo.m_material_fill_list)
            {
                if (data.SizeName == size_name)
                    data.Fill = fill;
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
                {
                    using (ProductContext ctx = new ProductContext())
                    {
                        m_madeplace = (from data in ctx.MadePlace
                                       where data.id == m_madeplace_id
                                       select data.type).FirstOrDefault();
                    }
                }
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
                {
                    using (ProductContext ctx = new ProductContext())
                    {
                        m_dengji = (from data in ctx.Dengji
                                    where data.id == m_dengji_id
                                    select data.type).FirstOrDefault();
                    }
                }
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
            using (ProductContext ctx = new ProductContext())
            {
                ProductData data = (from product in ctx.ProductData
                                    where product.id == id
                                    select product).FirstOrDefault();

                if(data != null)
                    LoadProductData(data);
            }                       
        }

        /// <summary>
        /// 载入数据
        /// </summary>
        /// <param name="info">BEProductDataInfo结构</param>
        private void LoadProductData(ProductData data)
        {
            this.m_id = data.id;
            this.HuoHao = data.huohao;
            this.DengJi_Id = data.dengji_id;
            this.MadePlace_Id = data.madeplace_id;
            this.PartName_Id = data.partname_id;
            this.SafeData_Id = data.safedata_id;
            this.StandardData_Id = data.standarddata_id;
            this.m_price = data.price;
            this.m_memo = data.memo;
            this.m_pwash = data.pwash == 1 ? true : false;
            this.m_tag_id = data.tag_id;
            this.m_wash_id = data.wash_id;
            this.m_lastamp = data.lastamp;
            this.m_pbad = data.pbad == 1 ? true : false;

            this.m_ptemplate = data.ptemplate == 1 ? true : false;
            this.m_wash_u = data.wash_u;
            this.m_template_data = data.template_data;

            this.Color_Id = (int)data.color_id;
            this.m_gyear = data.gyear;
            this.m_gmonth = data.gmonth;


            //加载EAN13信息
            using (ProductContext ctx = new ProductContext())
            {
                var ean13_data = from mater in ctx.BarcodeInfo
                           where mater.product_id == this.m_id
                           orderby mater.size_name
                           select mater;

                foreach(var obj in ean13_data)
                {
                    EAN13DataInfo info = new EAN13DataInfo();

                    info.Id = obj.id;
                    info.SizeName = obj.size_name;
                    info.BarcodeType = obj.barcode;
                    info.Memo = obj.memo;

                    this.m_ean13_data_list.Add(info);
                }
            }

            
            using (ProductContext ctx = new ProductContext())
            {
                //洗唛宽度
                this.m_wash_size = (from product in ctx.ProductData
                                    where product.id == this.m_id
                                    select product.WashPrintTemplate.daxiao).FirstOrDefault();

                //处理成份信息

                var materialData_entity = from mater in ctx.MaterialData
                                          where mater.product_id == this.m_id
                                          orderby mater.order_index
                                          select mater;

                foreach(var obj in materialData_entity)
                {
                    MaterialDataInfo info = new MaterialDataInfo();

                    info.Id = obj.id;
                    info.Type = obj.type;
                    info.Sel = obj.sel;
                    info.Memo = obj.memo;

                    this.m_material_data_list.Add(info);
                }

                /*******************************************************/

                //处理填充信息
                var fill_entity = from fill in ctx.MaterialFill
                                  where fill.product_id == this.m_id
                                  orderby fill.size_name
                                  select fill;

                foreach(var obj in fill_entity)
                {

                    UpdataMaterialFillList(obj.size_name, obj.fill);
                }

                this.MaterialFillInfo.material_type = (from fill in ctx.MaterialFill
                                                       where fill.product_id == this.m_id
                                                       select fill.type).FirstOrDefault();

                //处理打印模板信息
            }

            this.m_tagCODE93_filename = string.Format("{0}\\{1}", ConfigurationManager.AppSettings["Template"], GetTagFileName());

            //this.m_wash_filename = string.Format("{0}\\{1}", ConfigurationManager.AppSettings["Template"], GetWashFileName());
            this.m_wash_filename = string.Format("{0}\\{1}", ConfigurationManager.AppSettings["Template"],GetWashFileNameById(this.Wash_Id));
            this.m_tagEAN13_filename = string.Format("{0}\\13{1}", ConfigurationManager.AppSettings["Template"], GetTagFileName());

        }

        public string GetWashFileNameById(int id)
        {
            using(ProductContext ctx = new ProductContext())
            {
                return ( from wash in ctx.WashPrintTemplate
                             where wash.id == id
                             select wash.file_name).FirstOrDefault();
            }
        }

        public string GetWashFileName()
        {
                   
            
            int materialdata_count = 0;


            if(m_wash_u > 0)
            {
                using (ProductContext ctx = new ProductContext())
                {
                    WashPrintTemplate wash_info = (from wash in ctx.WashPrintTemplate
                                where wash.id == this.m_wash_u
                                select wash).FirstOrDefault();

                    return wash_info.file_name;
                }
            }


            if (this.m_huohao.Substring(0, 1) == "L")
            {
                return "WashG.btw";
            }

            if (this.m_huohao.Substring(0,1) == "W")
            {
                return "WashW.btw";
            }


            foreach (var obj in this.m_material_data_list)
            {
                if (obj.Sel)
                    ++materialdata_count;
            }

            
            int row = materialdata_count + (string.IsNullOrEmpty(this.MaterialFillInfo.material_type) ? 0 : 1);
            string str_class = this.m_huohao.Substring(0, 1);
            string file_name = string.Empty;

            using (ProductContext ctx = new ProductContext())
            {
                IQueryable<WashPrintTemplate> wash_info = null;

                if(this.m_huohao.Substring(0,1) == "S")
                {
                    int count = Regex.Matches(this.m_huohao, "-").Count;

                    if(count == 1)
                    {
                        wash_info = from wash in ctx.WashPrintTemplate
                                    where wash.type.IndexOf(str_class) >= 0 && wash.daxiao == "7cm"
                                    select wash;
                    }
                    else
                    {
                        wash_info = from wash in ctx.WashPrintTemplate
                                    where wash.type.IndexOf(str_class) >= 0 && wash.daxiao == "4cm"
                                    select wash;
                    }


                }
                else
                {
                    wash_info = from wash in ctx.WashPrintTemplate
                                where wash.type.IndexOf(str_class) >= 0
                                select wash;

                }

                foreach(var wash in wash_info)
                {
                    if(wash.file_name.Substring(5,1) == row.ToString())
                    {
                        file_name = wash.file_name;
                        break;
                    }
                }

            }
            
            if(this.m_ptemplate)
            {
                file_name = string.Format("T{0}", file_name);
            }

            return file_name;
        }

        public int GetWashFileNameId()
        {
            string file = this.GetWashFileName();
            
            using (ProductContext ctx = new ProductContext())
            {
                return (from wash in ctx.WashPrintTemplate
                        where wash.file_name == file
                        select wash.id).FirstOrDefault();
            }
        }


        public int GetTagFileNameId()
        {
            string file = this.GetTagFileName();
            
            using (ProductContext ctx = new ProductContext())
            {
                return (from tag in ctx.TagPrintTemplate
                        where tag.file_name == file
                        select tag.id).FirstOrDefault();
            }
        }

        public string GetTagFileName()
        {
            int materialdata_count = 0;

            foreach (var obj in this.m_material_data_list)
            {
                if (obj.Sel)
                    ++materialdata_count;
            }


            int row = materialdata_count + (string.IsNullOrEmpty(this.MaterialFillInfo.material_type) ? 0 : 1);
            string file_name = string.Empty;

            if (this.m_huohao.Substring(0, 1) == "G")
            {
                file_name = string.Format("TagG{0}.btw", row);
            }
            else if (this.m_huohao.Substring(0, 1) == "L")
            {
                file_name = string.Format("TagL{0}.btw", row);
            }
            else if(this.m_huohao.Substring(0,1) == "W")
            {
                file_name = string.Format("TagW{0}.btw", row);
            }
            else if(this.m_pwash)
            {
                file_name = string.Format("TagA{0}.btw", row);
            }
            else if(this.m_pbad)
            {
                file_name = string.Format("TagP{0}.btw", row);
            }
            else
            {
                file_name = string.Format("Tag{0}.btw",row);
            }

            return file_name;
        }


        /// <summary>
        /// 以产品货号构造
        /// </summary>
        /// <param name="huohao">产品货号</param>
        public ProductObject(string huohao)
        {
            using (ProductContext ctx = new ProductContext())
            {
                ProductData data = (from product in ctx.ProductData
                                    where product.huohao == huohao
                                    select product).FirstOrDefault();

                if (data == null)
                    this.HuoHao = huohao;
                else
                    LoadProductData(data);
            }   
          
        }

        public void PrintBlank(Engine engine, string printer_name)
        {
                  
            LabelFormatDocument format = engine.Documents.Open("d:\\Template\\WashBlank.btw");

            format.PrintSetup.IdenticalCopiesOfLabel = 2;
            format.PrintSetup.PrinterName = printer_name;

            format.Print();
        }

        //public class Tmp
        //{
        //    public string hh = string.Empty;
        //    public string gg = string.Empty;
        //    public string tm = string.Empty;
        //};


        public void PrintDh(Engine engine)
        {
            string line = string.Empty;
            LabelFormatDocument format = engine.Documents.Open("C:\\11.btw");

            //BindingList<Tmp> EAN13 = new BindingList<Tmp>();

            //// Read the file and display it line by line.
            //System.IO.StreamReader file =
            //   new System.IO.StreamReader("c:\\22.txt", System.Text.Encoding.Default);
            //while ((line = file.ReadLine()) != null)
            //{
            //    string[] sArray = Regex.Split(line, "\t", RegexOptions.IgnoreCase);

            //    Tmp tmp = new Tmp();

            //    tmp.hh = sArray[0];
            //    tmp.gg = sArray[1];
            //    tmp.tm = sArray[2];

            //    EAN13.Add(tmp);
            //}

            //file.Close();

            System.IO.StreamReader file =
               new System.IO.StreamReader("c:\\11.txt", System.Text.Encoding.Default);

            while((line = file.ReadLine()) != null)
            {
                string[] sArray = Regex.Split(line, "\t", RegexOptions.IgnoreCase);

                format.SubStrings.SetSubString("TXT", sArray[0]);
                format.PrintSetup.IdenticalCopiesOfLabel = 1;

                format.Print();
            }

            file.Close();

            
            
            
            //Dictionary<string, string> myDictionary = new Dictionary<string, string>();

            //myDictionary.Add("K", "508");
            //myDictionary.Add("C", "503");
            //myDictionary.Add("T", "504");
            //myDictionary.Add("J", "505");
            //myDictionary.Add("F", "502");


            //LabelFormatDocument format = engine.Documents.Open("C:\\TWashC1.btw");


            //string line = string.Empty;
            //string begin = string.Empty;


            //// Read the file and display it line by line.
            //System.IO.StreamReader file =
            //   new System.IO.StreamReader("c:\\11.txt", System.Text.Encoding.Default);
            //while ((line = file.ReadLine()) != null)
            //{
            //    string[] sArray = Regex.Split(line, "\t", RegexOptions.IgnoreCase);

            //    begin = myDictionary[sArray[0].Trim().Substring(0, 1)];

            //    format.SubStrings.SetSubString("TM", string.Format("{0}{1}{2}",begin,sArray[0].Trim(),sArray[1].Trim()));

            //    format.PrintSetup.IdenticalCopiesOfLabel = 1;

            //    format.Print();

            //}

            //file.Close();



            
            //LabelFormatDocument format = engine.Documents.Open("C:\\t.btw");

            //string line = string.Empty;

            //// Read the file and display it line by line.
            //System.IO.StreamReader file =
            //   new System.IO.StreamReader("c:\\11.txt", System.Text.Encoding.Default);
            //while ((line = file.ReadLine()) != null)
            //{
            //    string[] sArray = Regex.Split(line, "\t", RegexOptions.IgnoreCase);

            //    ///format.SubStrings.SetSubString("lb", sArray[0]);
            //    format.SubStrings.SetSubString("hh", sArray[0]);
            //    format.SubStrings.SetSubString("cf", sArray[1]);
            //    //format.SubStrings.SetSubString("jg", string.Format("￥{0:F2}", Convert.ToDecimal(sArray[2])));
                
            //    format.PrintSetup.IdenticalCopiesOfLabel = 1;

            //    format.Print();
            //}

            //file.Close();

            

            //string data_line = string.Empty;
            //string data2_line = string.Empty;

            //Dictionary<string,string> myDictionary = new Dictionary<string,string>();

                        

            //System.IO.StreamReader data_file =
            //    new System.IO.StreamReader("c:\\data.txt", System.Text.Encoding.Default);

            //while((data_line = data_file.ReadLine()) != null)
            //{
            //    string[] sArray = Regex.Split(data_line, "\t", RegexOptions.IgnoreCase);

            //    if (myDictionary.ContainsKey(string.Format("{0}-{1}", sArray[1].Trim(), sArray[2].Trim())) == false)
            //    {
            //        myDictionary.Add(string.Format("{0}-{1}", sArray[1].Trim(), sArray[2].Trim()), sArray[0].Trim());
            //    }
               
            //}

            //data_file.Close();

            //int count = 0;

            //LabelFormatDocument format = engine.Documents.Open("d:\\Template\\TM.btw");


            //System.IO.StreamReader data2_file =
            //    new System.IO.StreamReader("c:\\11.txt", System.Text.Encoding.Default);

            //while((data2_line = data2_file.ReadLine()) != null)
            //{
            //    string[] sArray = Regex.Split(data2_line, "\t", RegexOptions.IgnoreCase);

            //    if(myDictionary.ContainsKey(string.Format("{0}-{1}",sArray[0].Trim(), sArray[1].Trim())) == false)
            //    {
            //        //int temp = 0;

            //        continue;
            //    }

            //    format.SubStrings.SetSubString("Product", string.Format("号型:{0} 规格:{1}", sArray[0],sArray[1]));
            //    format.SubStrings.SetSubString("TiaoMa", myDictionary[string.Format("{0}-{1}", sArray[0].Trim(), sArray[1].Trim())]);
            //    format.PrintSetup.IdenticalCopiesOfLabel = 1;

            //    count = int.Parse(sArray[2]);

            //    for(int index = 0;index < count;index++)
            //    {
            //        format.Print();
            //    }

            //}

            //data2_file.Close();


            //LabelFormatDocument format = null;

            //format = engine.Documents.Open("d:\\Template\\TM.btw");

            //string line = string.Empty;
            //int id = 0;
            //string temp = string.Empty;
            //string temp2 = string.Empty;
            //int count = 0;

            //System.IO.StreamReader file =
            //    new System.IO.StreamReader("c:\\11.txt", System.Text.Encoding.Default);

            //while((line = file.ReadLine()) != null)
            //{
            //    string[] sArray = Regex.Split(line, "\t", RegexOptions.IgnoreCase);

            //    using (ProductContext ctx = new ProductContext())
            //    {
            //        temp = sArray[0];
            //        temp2 = sArray[1];
            //        count = int.Parse(sArray[2]);
                    
            //        id = (from product in ctx.ProductData
            //              where product.huohao == temp
            //              select product.id).FirstOrDefault();

            //        if (id == 0)
            //        { 
            //            break; 
            //        }


            //        BarcodeInfo entity = (from info in ctx.BarcodeInfo
            //                              where info.product_id == id && info.size_name == temp2
            //                              select info).FirstOrDefault();


            //        format.SubStrings.SetSubString("Product", string.Format("号型:{0} 规格:{1}", sArray[0],sArray[1]));
            //        format.SubStrings.SetSubString("TiaoMa", entity.barcode.Trim());

            //        format.PrintSetup.IdenticalCopiesOfLabel = 1;
                    

            //        for(int index = 0;index < count;index++)
            //        {
            //            format.Print();
            //        }




            //        //BarcodeInfo entity = new BarcodeInfo();

            //        //entity.product_id = id;
            //        //entity.size_name = sArray[2];
            //        //entity.barcode = sArray[0];
            //        //entity.memo = string.Empty;
            //        //entity.lastamp = System.Guid.NewGuid();

            //        //ctx.BarcodeInfo.Add(entity);

            //        //ctx.SaveChanges();
                                            
            //    }

            //}

            //file.Close();


            //string line = string.Empty;

            //LabelFormatDocument format = engine.Documents.Open("d:\\Template\\定货会.btw");
 
            //System.IO.StreamReader file =
            //    new System.IO.StreamReader("c:\\11.txt", System.Text.Encoding.Default);

            //while ((line = file.ReadLine()) != null)
            //{
            //    string[] sArray = Regex.Split(line, "\t", RegexOptions.IgnoreCase);

            //    format.SubStrings.SetSubString("lb", sArray[0]);
            //   format.SubStrings.SetSubString("name", sArray[1]);
            //   format.SubStrings.SetSubString("cf", sArray[2]);
            //   format.SubStrings.SetSubString("jg",string.Format("￥{0:F2}", Convert.ToDecimal(sArray[3])));
            //    format.PrintSetup.IdenticalCopiesOfLabel = 1;

            //   format.Print();
            //}

            //file.Close();


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
            string str_ean13_type = string.Empty;
            
            LabelFormatDocument format = null;
            
            //先得到对应的规格号型
            foreach(var data in this.m_size_data_list)
            {
                if(data.Id == select)
                {
                    str_size_name = data.SizeName;
                    str_size_type = data.SizeType;

                    break;
                }
            }

            foreach(var data in this.m_ean13_data_list)
            {
                if(data.SizeName == str_size_name)
                {
                    str_ean13_type = data.BarcodeType.Trim();
                }
            }


            switch(type)
            {
                case PrintType.TagEAN13:
                case PrintType.TagCODE93:

                    if (type == PrintType.TagEAN13)
                    {
                        if (str_ean13_type == string.Empty) return;

                        format = engine.Documents.Open(this.m_tagEAN13_filename);
                    }
                    else
                    {
                        format = engine.Documents.Open(this.m_tagCODE93_filename);
                    }

                    format.SubStrings.SetSubString("PinMin", this.m_parntname);
                    format.SubStrings.SetSubString("HuoHao", this.m_huohao);

                    if (this.m_huohao.Substring(0, 1) != "L" && this.m_huohao.Substring(0, 1) != "W") //排除领带
                    {
                        format.SubStrings.SetSubString("GuiGe", str_size_name);
                        format.SubStrings.SetSubString("XingHao", str_size_type);
                    }
                    format.SubStrings.SetSubString("SafeData", this.m_safedata);
                    format.SubStrings.SetSubString("StandardData", this.m_standarddata);
                    format.SubStrings.SetSubString("JiaGe", string.Format("￥{0:F2}", Convert.ToDecimal(this.m_price)));
                    format.SubStrings.SetSubString("ChanDi", this.m_madeplace);
                    format.SubStrings.SetSubString("DengJi", this.m_dengji);
                    format.SubStrings.SetSubString("ChengFeng",this.BuildMaterialDataString(str_size_name));

                    if (type == PrintType.TagEAN13)
                    {
                        format.SubStrings.SetSubString("TiaoMa", str_ean13_type);

                        if (this.m_huohao.Substring(0, 1) != "L")
                            format.SubStrings.SetSubString("info",string.Format("货号:{0} 规格:{1}",this.m_huohao,str_size_name));
                        else
                            format.SubStrings.SetSubString("info", string.Format("货号:{0}", this.m_huohao));
                    }
                    else
                    {
                        format.SubStrings.SetSubString("TiaoMa", this.BuildBarcode(str_size_name));
                    }

                    if(this.PartName_Id == 21)
                    {
                        format.SubStrings.SetSubString("Colour", this.m_colordata);
                        format.SubStrings.SetSubString("Date", string.Format("{0}年{1}月", this.Gyear, this.Gmonth));
                    }

                    break;

                case PrintType.Wash:

                    format = engine.Documents.Open(this.m_wash_filename);

                    if (this.m_huohao.Substring(0, 1) != "L")
                    {
                        format.SubStrings.SetSubString("HuoHao", this.m_huohao);
                        format.SubStrings.SetSubString("GuiGe", str_size_name);
                        format.SubStrings.SetSubString("XingHao", str_size_type);
                        format.SubStrings.SetSubString("ChengFeng", this.BuildMaterialDataString(str_size_name));

                        if (this.m_ptemplate)
                        {
                            format.SubStrings.SetSubString("Template", this.m_template_data);
                        }
                    }
                    else
                    {
                        format.SubStrings.SetSubString("HuoHao", this.m_huohao);
                    }

                    

                    break;

                //case PrintType.TagEAN13:

                //    if (str_ean13_type == string.Empty) return;

                    
                //    format = engine.Documents.Open(this.m_tag2_filename);

                //    format.SubStrings.SetSubString("HaoXing",string.Format("货号:{0} 规格:{1}",this.m_huohao,str_size_name));
                //    format.SubStrings.SetSubString("TiaoMa", str_ean13_type);

                //    break;
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
            using (ProductContext ctx = new ProductContext())
            {
                string barcodePrefix = (from entity in ctx.PartName
                                        where entity.id == this.m_partname_id
                                        select entity.barcode).FirstOrDefault();

                return string.Format("{0}{1}{2}", barcodePrefix, this.m_huohao, size_name);
            }
        }

        /// <summary>
        /// 生成成份打印字符串
        /// </summary>
        /// <param name="str_size_name">规格</param>
        /// <returns>生成的字符串</returns>
        private string BuildMaterialDataString(string str_size_name)
        {
            StringBuilder str = new StringBuilder();

            foreach(MaterialDataInfo info in this.m_material_data_list)
            {
                if (info.Sel)
                {
                    str.Append(info.Type);
                    str.Append("\r\n");
                }
            }


            if (!string.IsNullOrEmpty(this.MaterialFillInfo.material_type))
            {
                foreach (MaterialFillInfoObject.MaterialFillData data in this.MaterialFillInfo.m_material_fill_list)
                {
                    if (data.SizeName == str_size_name)
                    {
                        str.Append(this.MaterialFillInfo.material_type);
                        str.Append(string.Format(" 充绒量:{0}g\r\n", data.Fill));
                    }
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

        public static bool CheckProductHuoHaoExist(string huohao)
        {
            using (ProductContext ctx = new ProductContext())
            {
                int count = (from product in ctx.ProductData
                             where product.huohao == huohao
                             select product).Count();

                if (count > 0)
                    return true;
                else
                    return false;

            }
        }

        public static List<string> HuoHaoList
        {
            get
            {
                List<string> list = new List<string>();

                using (ProductContext ctx = new ProductContext())
                {
                    var huohaos = from entity in ctx.ProductData
                                  select entity.huohao;

                    foreach (string str in huohaos)
                    {
                        list.Add(str);
                    }
                }

                return list;
            }
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

                if (CheckProductHuoHaoExist(this.m_huohao.Trim()))
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
                if(!string.IsNullOrEmpty(this.MaterialFillInfo.material_type))
                {
                    foreach(MaterialFillInfoObject.MaterialFillData data in this.MaterialFillInfo.m_material_fill_list)
                    {
                        if(data.Fill == "0")
                        {
                            result.Code = CodeType.Error;
                            result.Message = "填充规则数据制定不完整,请重新制定!";

                            return result;
                        }
                    }
                }

                ProductData info = new ProductData();

                info.huohao = this.m_huohao;
                info.partname_id = this.m_partname_id;
                info.dengji_id = this.m_dengji_id;
                info.madeplace_id = this.m_madeplace_id;
                info.price = this.m_price;
                info.safedata_id = this.m_safedata_id;
                info.standarddata_id = this.m_standarddata_id;
                info.pwash = this.m_pwash == true ? 1:0;
                info.pbad = this.m_pbad == true ? 1:0;
                info.tag_id = this.GetTagFileNameId();
                info.memo = this.m_memo;
                info.wash_id = this.GetWashFileNameId();
                info.color_id = this.m_color_id;
                info.gyear = this.m_gyear;
                info.gmonth = this.m_gmonth;
                info.lastamp = System.Guid.NewGuid();

                if(this.m_ptemplate)
                {
                    info.ptemplate = 1;
                    info.template_data = this.m_template_data;
                }
                               
                if(info.tag_id == 0)
                {
                    result.Code = CodeType.Error;
                    result.Message = "系统未能找到对应的吊牌模板文件,保存无法继续!";

                    return result;
                }

                if(info.wash_id == 0)
                {
                    if (this.m_partname_id == 21)
                        info.wash_id = 1;
                    else
                    {
                        result.Code = CodeType.Error;
                        result.Message = "系统未能找到对应的洗唛模板文件,保存无法继续!";

                        return result;
                    }
                   
                }

                using (ProductContext ctx = new ProductContext())
                {
                    ctx.ProductData.Add(info);

                    if(ctx.SaveChanges() == 0)
                    {
                        result.Code = CodeType.Error;
                        result.Message = "产品基本信息保存失败";

                        return result;
                    }
                }

                using (ProductContext ctx = new ProductContext())
                {
                    this.m_id = (from product in ctx.ProductData
                                 where product.huohao == this.m_huohao
                                 select product.id).FirstOrDefault();
                }

            
                int index = 1;

                foreach(MaterialDataInfo ob in this.m_material_data_list)
                {
                    using (ProductContext ctx = new ProductContext())
                    {
                        MaterialData entity = new MaterialData();
                        
                        entity.product_id = this.m_id;
                        entity.sel = ob.Sel;
                        entity.type = ob.Type;
                        entity.order_index = index++;
                        entity.memo = ob.Memo;
                        entity.lastamp = System.Guid.NewGuid();

                        ctx.MaterialData.Add(entity);

                        ctx.SaveChanges();
                    }
                }

                if(!string.IsNullOrEmpty(this.MaterialFillInfo.material_type))
                {
                    foreach(MaterialFillInfoObject.MaterialFillData fill in this.MaterialFillInfo.m_material_fill_list)
                    {
                        using (ProductContext ctx = new ProductContext())
                        {
                            MaterialFill entity = new MaterialFill();
                            entity.product_id = this.m_id;
                            entity.size_name = fill.SizeName;
                            entity.type = this.MaterialFillInfo.material_type;
                            entity.fill = fill.Fill;
                            entity.lastamp = System.Guid.NewGuid();

                            ctx.MaterialFill.Add(entity);

                            ctx.SaveChanges();
                        }
                    }
                }

                result.Code = CodeType.Ok;
                result.Message = "保存成功!";

                return result;
            }

            //Edit Save
            if(this.m_id > 0)
            {
                if (this.m_huohao.Trim() == string.Empty)
                {
                    result.Code = CodeType.Error;
                    result.Message = "[产品货号]不能为空或输入的不合法,无法保存!";

                    return result;
                }


                using (ProductContext ctx = new ProductContext())
                {
                    int count = (from product in ctx.ProductData
                                 where product.id == this.m_id && product.huohao == this.m_huohao
                                 select product).Count();

                    if(count > 1)
                    {
                        result.Code = CodeType.Error;
                        result.Message = "[产品货号]重复,无法保存!";

                        return result;
                    }

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
                if (!string.IsNullOrEmpty(this.MaterialFillInfo.material_type))
                {
                    foreach(MaterialFillInfoObject.MaterialFillData data in this.MaterialFillInfo.m_material_fill_list)
                    {
                        if(data.Fill == "0")
                        {
                            result.Code = CodeType.Error;
                            result.Message = "填充规则数据制定不完整,请重新制定!";

                            return result;
                        }
                    }
                }

                using (ProductContext ctx = new ProductContext())
                {
                    System.Guid entity_lastamp = (from product in ctx.ProductData
                                                  where product.id == this.m_id
                                                  select product.lastamp).FirstOrDefault();

                    if(entity_lastamp != this.m_lastamp)
                    {
                        result.Code = CodeType.Error;
                        result.Message = "当前编辑的记录已经变更,无法保存!";

                        return result;
                    }
                }


                using (ProductContext ctx = new ProductContext())
                {
                    ProductData info = (from entity in ctx.ProductData
                                        where entity.id == this.m_id
                                        select entity).FirstOrDefault();

                    info.huohao = this.m_huohao;
                    info.partname_id = this.m_partname_id;
                    info.dengji_id = this.m_dengji_id;
                    info.madeplace_id = this.m_madeplace_id;
                    info.price = this.m_price;
                    info.safedata_id = this.m_safedata_id;
                    info.standarddata_id = this.m_standarddata_id;
                    info.pwash = this.m_pwash == true ? 1:0;
                    info.pbad = this.m_pbad == true ?1:0;
                    info.memo = this.m_memo;
                    info.tag_id = this.GetTagFileNameId();
                    info.wash_id = this.GetWashFileNameId();
                    info.color_id = this.m_color_id;
                    info.gyear = this.m_gyear;
                    info.gmonth = this.m_gmonth;
                    info.lastamp = System.Guid.NewGuid();

                    if (this.m_ptemplate)
                    {
                        info.ptemplate = 1;
                        info.template_data = this.m_template_data;
                    }

                    if (info.tag_id == 0)
                    {
                        result.Code = CodeType.Error;
                        result.Message = "系统未能找到对应的吊牌模板文件,保存无法继续!";

                        return result;
                    }

                    if (info.wash_id == 0 )
                    {
                        if(this.m_partname_id == 21)
                        {
                            info.wash_id = 1;
                        }
                        else
                        {
                            result.Code = CodeType.Error;
                            result.Message = "系统未能找到对应的洗唛模板文件,保存无法继续!";

                            return result;
                        }
                       
                    }

                    if (ctx.SaveChanges() == 0)
                    {
                        result.Code = CodeType.Error;
                        result.Message = "产品基本信息保存失败";

                        return result;
                    }
                }

               

                //保存成份信息
              
                using (ProductContext ctx = new ProductContext())
                {
                    var mi = from entity in ctx.MaterialData
                             where entity.product_id == this.m_id
                             select entity;

                    foreach(var obj in mi)
                    {
                        ctx.MaterialData.Remove(obj);
                    }

                    ctx.SaveChanges();
                }

                int index = 1;

                foreach (MaterialDataInfo ob in this.m_material_data_list)
                {
                    using (ProductContext ctx = new ProductContext())
                    {
                        MaterialData entity = new MaterialData();
                        entity.product_id = this.m_id;
                        entity.sel = ob.Sel;
                        entity.type = ob.Type;
                        entity.order_index = index++;
                        entity.memo = ob.Memo;
                        entity.lastamp = System.Guid.NewGuid();

                        ctx.MaterialData.Add(entity);

                        ctx.SaveChanges();
                    }
                }

                ////////////////////////////////////////////////////////

                using (ProductContext ctx = new ProductContext())
                {
                    var mi = from entity in ctx.MaterialFill
                             where entity.product_id == this.m_id
                             select entity;

                    foreach (var obj in mi)
                    {
                        ctx.MaterialFill.Remove(obj);
                    }

                    ctx.SaveChanges();
                }

                if (!string.IsNullOrEmpty(this.MaterialFillInfo.material_type))
                {
                    foreach (MaterialFillInfoObject.MaterialFillData fill in this.MaterialFillInfo.m_material_fill_list)
                    {
                        using (ProductContext ctx = new ProductContext())
                        {
                            MaterialFill entity = new MaterialFill();
                            entity.product_id = this.m_id;
                            entity.size_name = fill.SizeName;
                            entity.type = this.MaterialFillInfo.material_type;
                            entity.fill = fill.Fill;
                            entity.lastamp = System.Guid.NewGuid();

                            ctx.MaterialFill.Add(entity);

                            ctx.SaveChanges();
                        }
                    }
                }

                result.Code = CodeType.Ok;
                result.Message = "保存成功!";

                return result;
            }

            return result;
        }
        
        public void UpdateEAN13Info(string m_sizename,string m_ean13,string m_memo)
        {
            bool bfind = false;
            
            foreach(var obj in this.m_ean13_data_list)
            {
                if(obj.SizeName == m_sizename)
                {
                    obj.BarcodeType = m_ean13;
                    bfind = true;
                    break;
                }
            }

            if(!bfind)
            {
                EAN13DataInfo info = new EAN13DataInfo();
                info.SizeName = m_sizename;
                info.BarcodeType = m_ean13;
                info.Memo = m_memo;

                this.m_ean13_data_list.Add(info);
            }
        }

        public void SaveEAN13Info()
        {
            using (ProductContext ctx = new ProductContext())
            {
                var data1 = from entity in ctx.BarcodeInfo
                            where entity.product_id == this.m_id
                            select entity;

                foreach ( var obj in data1)
                {
                    ctx.BarcodeInfo.Remove(obj);
                }

                ctx.SaveChanges();
            }

            foreach(EAN13DataInfo info in this.m_ean13_data_list )
            {
                using (ProductContext ctx = new ProductContext())
                {
                    BarcodeInfo entity = new BarcodeInfo();

                    entity.product_id = this.m_id;
                    entity.size_name = info.SizeName;
                    entity.barcode = info.BarcodeType;
                    entity.memo = info.Memo;
                    entity.lastamp = System.Guid.NewGuid();

                    ctx.BarcodeInfo.Add(entity);

                    ctx.SaveChanges();
                }
            }

        }
    }
}
