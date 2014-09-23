using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mondiland.EFModule;
using Mondiland.Global;

namespace Mondiland.Obj
{
    public class StoreObject
    {
        private int m_id = 0;
        private string m_name = string.Empty;
        private string m_address = string.Empty;
        private string m_manager = string.Empty;
        private string m_manager_phone = string.Empty;
        private string m_phone = string.Empty;
        private string m_memo = string.Empty;
        private System.Guid m_lastamp = System.Guid.Empty;

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public string Address
        {
            get { return m_address; }
            set { m_address = value; }
        }

        public string Manager
        {
            get { return m_manager; }
            set { m_manager = value; }
        }

        public string ManagerPhone
        {
            get { return m_manager_phone; }
            set { m_manager_phone = value; }
        }

        public string Phone
        {
            get { return m_phone; }
            set { m_phone = value; }
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

        public SaveResult Del()
        {
            SaveResult result = new SaveResult();

            using (ProductContext ctx = new ProductContext())
            {
                StoresInfo ob = (from entity in ctx.StoresInfo
                                where entity.id == this.m_id
                                select entity).FirstOrDefault();

                ctx.StoresInfo.Remove(ob);

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

        public SaveResult Save()
        {
            SaveResult result = new SaveResult();

            if(this.m_name.Trim() == string.Empty)
            {
                result.Code = CodeType.Error;
                result.Message = "[店名]信息不能为空!";

                return result;
            }

            if(this.Address.Trim() == string.Empty)
            {
                result.Code = CodeType.Error;
                result.Message = "[地址]信息不能为空!";

                return result;
            }

            if(this.m_id == 0)
            {
                StoresInfo info = new StoresInfo();

                info.name = this.m_name;
                info.address = this.m_address;
                info.manager = this.m_manager;
                info.manager_phone = this.m_manager_phone;
                info.phone = this.m_phone;
                info.memo = this.Memo;
                info.lastamp = System.Guid.NewGuid();

                using(ProductContext ctx = new ProductContext())
                {
                    ctx.StoresInfo.Add(info);

                    if (ctx.SaveChanges() > 0)
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
                using (ProductContext ctx = new ProductContext())
                {
                    System.Guid lastamp = (from entity in ctx.StoresInfo
                                           where entity.id == this.m_id
                                           select entity.lastamp).FirstOrDefault();

                    if (lastamp != this.m_lastamp)
                    {
                        result.Code = CodeType.Error;
                        result.Message = "当前编辑的记录已经变更,无法保存!";

                        return result;
                    }
                }

                using (ProductContext ctx = new ProductContext())
                {
                    StoresInfo info = (from entity in ctx.StoresInfo
                                      where entity.id == this.m_id
                                      select entity).FirstOrDefault();

                    info.name = this.m_name;
                    info.address = this.m_address;
                    info.manager = this.m_manager;
                    info.manager_phone = this.m_manager_phone;
                    info.phone = this.m_phone;
                    info.memo = this.Memo;
                    info.lastamp = System.Guid.NewGuid();

                    if(ctx.SaveChanges() == 0)
                    {
                        result.Code = CodeType.Error;
                        result.Message = "保存失败!";

                        return result;
                    }

                    result.Code = CodeType.Ok;
                    result.Message = "保存成功!";

                    this.m_lastamp = info.lastamp;

                    return result;

                }
            }
        }
    }
}
