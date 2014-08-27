using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Configuration;

using Mondiland.BLL;
using Mondiland.BLLEntity;
using Mondiland.Global;

namespace Mondiland.UI
{
    public class SupplierObject
    {
        private int m_id = 0;
        private int m_class_id = 0;
        private string m_class_name = string.Empty;
        private string m_pym = string.Empty;
        private string m_name = string.Empty;
        private string m_intact_name = string.Empty;
        private string m_bank_name = string.Empty;
        private string m_account = string.Empty;
        private string m_phone = string.Empty;
        private string m_fax = string.Empty;
        private string m_address = string.Empty;
        private string m_memo = string.Empty;
        private long m_lastamp = 0;

        public SupplierObject() { }

        public SupplierObject(int id)
        {
            BESupplierMInfo info = BLLFactory<BLLSupplierInfo>.Instance.ReadSupplierMInfoByPrimaryKey(id);

            this.m_id = info.Id;
            this.Class_Id = info.Class_Id;
            this.m_name = info.Name;
            this.m_intact_name = info.Intact_Name;
            this.m_pym = info.Pym;
            this.m_bank_name = info.Bank_Name;
            this.m_account = info.Account;
            this.m_phone = info.Phone;
            this.m_fax = info.Fax;
            this.m_address = info.Address;
            this.m_memo = info.Memo;
            this.m_lastamp = info.LasTamp;

        }

        public enum CodeType
        {
            Ok,
            Error,
        }
        //保存返回信息
        public class SaveResult
        {
            public CodeType Code;
            public string Message = string.Empty;
        }

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        /// <summary>
        /// 供应商对应的分类ID
        /// </summary>
        public int Class_Id
        {
            get { return m_class_id; }
            set 
            { 
                m_class_id = value;

                this.Class_Name = BLLFactory<BLLSupplierInfo>.Instance.GetSupplierClassName(this.m_class_id);
            }
        }

        /// <summary>
        /// 供应商分类名称
        /// </summary>
        public string Class_Name
        {
            get { return m_class_name; }
            set { m_class_name = value; }
        }

        /// <summary>
        /// 拼音码
        /// </summary>
        public string Pym
        {
            get { return m_pym; }
            set { m_pym = value; }
        }

        /// <summary>
        /// 供应商简称
        /// </summary>
        public string Name
        {
            get { return m_name; }
            set 
            { 
                m_name = value;

                this.m_pym = ChineseToSpell.GetChineseSpell(this.m_name + this.m_intact_name);
            }
        }

        /// <summary>
        /// 供应商全称
        /// </summary>
        public string Intact_Name
        {
            get { return m_intact_name; }
            set 
            { 
                m_intact_name = value;
                this.m_pym = ChineseToSpell.GetChineseSpell(this.m_name + this.m_intact_name);
            }
        }

        /// <summary>
        /// 供应商开户行名称
        /// </summary>
        public string Bank_Name
        {
            get { return m_bank_name; }
            set { m_bank_name = value; }
        }

        /// <summary>
        /// 供应商帐号
        /// </summary>
        public string Account
        {
            get { return m_account; }
            set { m_account = value; }
        }

        /// <summary>
        /// 公司电话
        /// </summary>
        public string Phone
        {
            get { return m_phone; }
            set { m_phone = value; }
        }

        /// <summary>
        /// 公司地址
        /// </summary>
        public string Address
        {
            get { return m_address; }
            set { m_address = value; }
        }

        /// <summary>
        /// 公司传真
        /// </summary>
        public string Fax
        {
            get { return m_fax; }
            set { m_fax = value; }
        }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Memo
        {
            get { return m_memo; }
            set { m_memo = value; }
        }


        
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        public SaveResult Save()
        {
            SaveResult result = new SaveResult();

           
            if(this.m_class_id == 0)
            {
                result.Code = CodeType.Error;
                result.Message = "[供应商分类]信息不能为空!";

                return result;
            }

            if(this.m_name.Trim() == string.Empty)
            {
                result.Code = CodeType.Error;
                result.Message = "[供应商简称]信息不能为空!";

                return result;
            }

            if(this.m_intact_name.Trim() == string.Empty)
            {
                result.Code = CodeType.Error;
                result.Message = "[供应商全称]信息不能为空!";

                return result;
            }

            //新增操作
            if (this.m_id == 0)
            {

                BESupplierMInfo info = new BESupplierMInfo();

                info.Class_Id = this.m_class_id;
                info.Pym = this.m_pym;
                info.Name = this.m_name;
                info.Intact_Name = this.m_intact_name;
                info.Bank_Name = this.m_bank_name;
                info.Account = this.m_account;
                info.Phone = this.m_phone;
                info.Fax = this.m_fax;
                info.Address = this.m_address;
                info.Memo = this.m_memo;

                if (BLLFactory<BLLSupplierInfo>.Instance.AddSupplierM(info))
                {
                    result.Code = CodeType.Ok;
                    result.Message = "保存成功!";

                    return result;
                }
                else
                {
                    result.Code = CodeType.Error;
                    result.Message = "保存失败!";

                    return result;
                }
            }
            else
            {
                if (BLLFactory<BLLSupplierInfo>.Instance.UpdateCheckLastamp(this.m_id, this.m_lastamp))
                {
                    result.Code = CodeType.Error;
                    result.Message = "当前编辑的记录已经变更,无法保存!";

                    return result;
                }

                BESupplierMInfo info = new BESupplierMInfo();

                info.Id = this.m_id;
                info.Class_Id = this.m_class_id;
                info.Pym = this.m_pym;
                info.Name = this.m_name;
                info.Intact_Name = this.m_intact_name;
                info.Bank_Name = this.m_bank_name;
                info.Account = this.m_account;
                info.Phone = this.m_phone;
                info.Fax = this.m_fax;
                info.Address = this.m_address;
                info.Memo = this.m_memo;

                if (!BLLFactory<BLLSupplierInfo>.Instance.UpdateSupplierM(info))
                {
                    result.Code = CodeType.Error;
                    result.Message = "保存失败!";

                    return result;
                }

                result.Code = CodeType.Ok;
                result.Message = "保存成功!";

                return result;

            }
        }
    }
}
