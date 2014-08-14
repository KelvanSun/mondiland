using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mondiland.BLL;
using Mondiland.BLLEntity;

namespace Mondiland.UI
{
    /// <summary>
    /// 产品对象类
    /// </summary>
    public class ProductObject
    {
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


        private decimal m_price = 0;
        private string m_memo = string.Empty;
        private bool m_pwash = false;
        private long m_lastamp = 0;
                
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

            this.m_id = product_info.Id;
            this.HuoHao = product_info.HuoHao;
            this.DengJi_Id = product_info.Dengji_Id;
            this.MadePlace_Id = product_info.MadePlace_Id;
            this.PartName_Id = product_info.PartName_Id;
            this.SafeData_Id = product_info.SafeData_Id;
            this.StandardData_Id = product_info.StandardData_Id;
            this.m_price = product_info.Price;
            this.m_memo = product_info.Memo;
            this.Pwash = product_info.Pwash > 0 ? true : false;
            this.Tag_Id = product_info.Tag_Id;
            this.Wash_Id = product_info.Wash_Id;
            this.m_lastamp = product_info.LasTamp;

        }

        /// <summary>
        /// 以产品货号构造
        /// </summary>
        /// <param name="huohao">产品货号</param>
        public ProductObject(string huohao)
        {
            BEProductDataInfo product_info = BLLFactory<BLLProductInfo>.Instance.ReadByHuoHao(huohao);

            this.m_id = product_info.Id;
            this.HuoHao = product_info.HuoHao;
            this.DengJi_Id = product_info.Dengji_Id;
            this.MadePlace_Id = product_info.MadePlace_Id;
            this.PartName_Id = product_info.PartName_Id;
            this.SafeData_Id = product_info.SafeData_Id;
            this.StandardData_Id = product_info.StandardData_Id;
            this.m_price = product_info.Price;
            this.m_memo = product_info.Memo;
            this.Pwash = product_info.Pwash > 0 ? true : false;
            this.Tag_Id = product_info.Tag_Id;
            this.Wash_Id = product_info.Wash_Id;
            this.m_lastamp = product_info.LasTamp;
        }
        
    }
}
