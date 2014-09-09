using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Configuration;

using Mondiland.Global;
using Mondiland.EFModule;

namespace Mondiland.Obj
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
        private System.Guid m_lastamp = System.Guid.Empty;

        public BindingList<SupplierFObject> SupplierFList = new BindingList<SupplierFObject>();
        public BindingList<SupplierDObject> SupplierDList = new BindingList<SupplierDObject>();

        public SupplierObject() { }

        public SupplierObject(int id)
        {
            using (ProductContext ctx = new ProductContext())
            {
                SupplierM info = (from entity in ctx.SupplierM
                                  where entity.id == id
                                  select entity).FirstOrDefault();

                this.m_id = info.id;
                this.Class_Id = info.class_id;
                this.m_name = info.name;
                this.m_intact_name = info.intact_name;
                this.m_pym = info.pym;
                this.m_bank_name = info.bank_name;
                this.m_account = info.account;
                this.m_phone = info.phone;
                this.m_fax = info.fax;
                this.m_address = info.address;
                this.m_memo = info.memo;
                this.m_lastamp = info.lastamp;

            }

            using (ProductContext ctx = new ProductContext())
            {
                var infos = from entity in ctx.SupplierF
                            where entity.supplier_id == id
                            select entity;

                foreach(SupplierF info in infos)
                {
                    SupplierFObject ob = new SupplierFObject();
                    ob.Id = info.id;
                    ob.Address = info.address;
                    ob.Contacts = info.contacts;
                    ob.Tel = info.tel;
                    ob.Fax = info.fax;
                    ob.Memo = info.memo;
                    ob.LasTamp = info.lastamp;

                    SupplierFList.Add(ob);

                }
                
            }

            using(ProductContext ctx = new ProductContext())
            {
                var infos = from entity in ctx.SupplierD
                            where entity.supplier_id == id
                            select entity;

                foreach(SupplierD info in infos)
                {
                    SupplierDObject ob = new SupplierDObject();
                    ob.Id = info.id;
                    ob.Name = info.name;
                    ob.Pym = info.pym;
                    ob.Phone = info.phone;
                    ob.Fax = info.fax;
                    ob.Email = info.email;
                    ob.QQ = info.qq;
                    ob.Address = info.address;
                    ob.Memo = info.memo;
                    ob.LasTamp = info.lastamp;

                    SupplierDList.Add(ob);
                }

            }
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

                using(ProductContext ctx = new ProductContext())
                {
                    this.Class_Name = (from entity in ctx.SupplierClass
                                       where entity.id == this.m_class_id
                                       select entity.name).FirstOrDefault();
                }

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
                SupplierM info = new SupplierM();

                info.class_id = this.m_class_id;
                info.pym = this.m_pym;
                info.name = this.m_name;
                info.intact_name = this.m_intact_name;
                info.bank_name = this.m_bank_name;
                info.account = this.m_account;
                info.phone = this.m_phone;
                info.fax = this.m_fax;
                info.address = this.m_address;
                info.memo = this.m_memo;
                info.lastamp = System.Guid.NewGuid();

                using(ProductContext ctx = new ProductContext())
                {
                    ctx.SupplierM.Add(info);

                    if(ctx.SaveChanges() > 0)
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

            }
            else
            {
                using(ProductContext ctx = new ProductContext())
                {
                    System.Guid lastamp = (from entity in ctx.SupplierM
                                           where entity.id == this.m_id
                                           select entity.lastamp).FirstOrDefault();

                    if(lastamp != this.m_lastamp)
                    {
                        result.Code = CodeType.Error;
                        result.Message = "当前编辑的记录已经变更,无法保存!";

                        return result;
                    }
                }

                using (ProductContext ctx = new ProductContext())
                {
                    SupplierM info = (from entity in ctx.SupplierM
                                      where entity.id == this.m_id
                                      select entity).FirstOrDefault();

                    info.id = this.m_id;
                    info.class_id = this.m_class_id;
                    info.pym = this.m_pym;
                    info.name = this.m_name;
                    info.intact_name = this.m_intact_name;
                    info.bank_name = this.m_bank_name;
                    info.account = this.m_account;
                    info.phone = this.m_phone;
                    info.fax = this.m_fax;
                    info.address = this.m_address;
                    info.memo = this.m_memo;
                    info.lastamp = System.Guid.NewGuid();

                    if(ctx.SaveChanges() == 0)
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

        public class SupplierDObject
        {
            private int m_id = 0;
            private int m_supplier_id = 0;
            private string m_pym = string.Empty;
            private string m_name = string.Empty;
            private string m_phone = string.Empty;
            private string m_fax = string.Empty;
            private string m_email = string.Empty;
            private string m_qq = string.Empty;
            private string m_address = string.Empty;
            private string m_memo = string.Empty;
            private System.Guid m_lastamp = System.Guid.Empty;

            public SupplierDObject() { }

            public SupplierDObject(int supplier_id)
            {
                this.m_supplier_id = supplier_id;
            }

            public int Id
            {
                get { return m_id; }
                set { m_id = value; }
            }

            public string Pym
            {
                get { return m_pym; }
                set { m_pym = value; }
            }

            public string Name
            {
                get { return m_name; }
                set
                {
                    m_name = value;

                    this.m_pym = ChineseToSpell.GetChineseSpell(this.m_name);
                }
            }

            public string Phone
            {
                get { return m_phone; }
                set { m_phone = value; }
            }

            public string Fax
            {
                get { return m_fax; }
                set { m_fax = value; }
            }

            public string Memo
            {
                get { return m_memo; }
                set { m_memo = value; }
            }

            public System.Guid LasTamp
            {
                get { return m_lastamp; }
                set { m_lastamp = value; }
            }

            public string Email
            {
                get { return m_email; }
                set { m_email = value; }
            }

            public string QQ
            {
                get { return m_qq; }
                set { m_qq = value; }
            }

            public string Address
            {
                get { return m_address; }
                set { m_address = value; }
            }

            public SaveResult Del()
            {
                SaveResult result = new SaveResult();

                using (ProductContext ctx = new ProductContext())
                {
                    SupplierD ob = (from entity in ctx.SupplierD
                                          where entity.id == this.m_id
                                          select entity).FirstOrDefault();

                    ctx.SupplierD.Remove(ob);

                    if(ctx.SaveChanges() == 0)
                    {
                        result.Code = CodeType.Error;
                        result.Message = "删除操作失败!";
                    }
                    else
                    {
                        result.Code = CodeType.Ok;
                        result.Message = "成功删除!";
                    }
                }


                return result;
            }

            /// <summary>
            /// 保存数据
            /// </summary>
            /// <returns></returns>
            public SaveResult Save()
            {
                SaveResult result = new SaveResult();

                if (string.IsNullOrEmpty(this.m_name))
                {
                    result.Code = CodeType.Error;
                    result.Message = "[联系人姓名]信息不能为空!";

                    return result;
                }

                //新增
                if(this.m_id == 0)
                {
                    SupplierD contract = new SupplierD();
                    contract.supplier_id = this.m_supplier_id;
                    contract.name = this.m_name;
                    contract.pym = this.m_pym;
                    contract.phone = this.m_phone;
                    contract.fax = this.m_fax;
                    contract.email = this.m_email;
                    contract.qq = this.m_qq;
                    contract.address = this.m_address;
                    contract.memo = this.m_memo;
                    contract.lastamp = System.Guid.NewGuid();

                    using (ProductContext ctx = new ProductContext())
                    {
                        ctx.SupplierD.Add(contract);

                        if (ctx.SaveChanges() == 0)
                        {
                            result.Code = CodeType.Error;
                            result.Message = "保存失败!";

                            return result;
                        }
                        else
                        {
                            result.Code = CodeType.Ok;
                            result.Message = "保存成功!";

                            return result;
                        }
                    }

                }
                else
                {
                    using (ProductContext ctx = new ProductContext())
                    {
                        SupplierD contract = (from entity in ctx.SupplierD
                                             where entity.id == this.m_id
                                             select entity).FirstOrDefault();

                        contract.name = this.m_name;
                        contract.pym = this.m_pym;
                        contract.phone = this.m_phone;
                        contract.fax = this.m_fax;
                        contract.email = this.m_email;
                        contract.qq = this.m_qq;
                        contract.address = this.m_address;
                        contract.memo = this.m_memo;
                        contract.lastamp = System.Guid.NewGuid();


                        if (ctx.SaveChanges() == 0)
                        {
                            result.Code = CodeType.Error;
                            result.Message = "保存失败!";

                            return result;
                        }
                        else
                        {
                            result.Code = CodeType.Ok;
                            result.Message = "保存成功!";

                            return result;
                        }

                    }

                }

            }

        }
        /// <summary>
        /// 工厂信息类
        /// </summary>
        public class SupplierFObject
        {
            private int m_id = 0;
            private int m_supplier_id = 0;
            private string m_address = string.Empty;
            private string m_contacts = string.Empty;
            private string m_tel = string.Empty;
            private string m_fax = string.Empty;
            private string m_memo = string.Empty;
            private System.Guid m_lastamp = System.Guid.Empty;

            public System.Guid LasTamp
            {
                get { return m_lastamp; }
                set { m_lastamp = value; }
            }

            public SupplierFObject() { }

            public SupplierFObject(int supplier_id)
            {
                this.m_supplier_id = supplier_id;
            }

            public int Id
            {
                get { return m_id; }
                set { m_id = value; }
            }

            public string Address
            {
                get { return m_address; }
                set { m_address = value; }
            }

            public string Contacts
            {
                get { return m_contacts; }
                set { m_contacts = value; }
            }

            public string Tel
            {
                get { return m_tel; }
                set { m_tel = value; }
            }

            public string Fax
            {
                get { return m_fax; }
                set { m_fax = value; }
            }

            public string Memo
            {
                get { return m_memo; }
                set { m_memo = value; }
            }

            public SaveResult Del()
            {
                SaveResult result = new SaveResult();

                using (ProductContext ctx = new ProductContext())
                {
                    SupplierF ob = (from entity in ctx.SupplierF
                                    where entity.id == this.m_id
                                    select entity).FirstOrDefault();

                    ctx.SupplierF.Remove(ob);

                    if (ctx.SaveChanges() == 0)
                    {
                        result.Code = CodeType.Error;
                        result.Message = "删除操作失败!";
                    }
                    else
                    {
                        result.Code = CodeType.Ok;
                        result.Message = "成功删除!";
                    }
                }


                return result;
            }


            /// <summary>
            /// 保存数据
            /// </summary>
            /// <returns></returns>
            public SaveResult Save()
            {
                SaveResult result = new SaveResult();

                if (string.IsNullOrEmpty(this.m_address))
                {
                    result.Code = CodeType.Error;
                    result.Message = "[工厂地址]信息不能为空!";

                    return result;
                }

                //新增
                if(this.Id == 0)
                {
                    SupplierF factory = new SupplierF();
                    factory.supplier_id = this.m_supplier_id;
                    factory.address = this.m_address;
                    factory.contacts = this.m_contacts;
                    factory.tel = this.m_tel;
                    factory.fax = this.m_fax;
                    factory.memo = this.m_memo;
                    factory.lastamp = System.Guid.NewGuid();

                    using(ProductContext ctx = new ProductContext())
                    {
                        ctx.SupplierF.Add(factory);

                        if(ctx.SaveChanges() == 0)
                        {
                            result.Code = CodeType.Error;
                            result.Message = "保存失败!";

                            return result;
                        }
                        else
                        {
                            result.Code = CodeType.Ok;
                            result.Message = "保存成功!";

                            return result;
                        }
                    }

                }
                else //编辑
                {
                    using(ProductContext ctx = new ProductContext())
                    {
                        SupplierF factory = (from entity in ctx.SupplierF
                                            where entity.id == this.m_id
                                            select entity).FirstOrDefault();

                        factory.address = this.m_address;
                        factory.contacts = this.m_contacts;
                        factory.tel = this.m_tel;
                        factory.fax = this.m_fax;
                        factory.memo = this.m_memo;
                        factory.lastamp = System.Guid.NewGuid();

                        if (ctx.SaveChanges() == 0)
                        {
                            result.Code = CodeType.Error;
                            result.Message = "保存失败!";

                            return result;
                        }
                        else
                        {
                            result.Code = CodeType.Ok;
                            result.Message = "保存成功!";

                            return result;
                        }

                    }
                }

            }
        }
        
    }
}
