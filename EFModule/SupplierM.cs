//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mondiland.EFModule
{
    using System;
    using System.Collections.Generic;
    
    public partial class SupplierM
    {
        public SupplierM()
        {
            this.SupplierD = new HashSet<SupplierD>();
            this.SupplierF = new HashSet<SupplierF>();
        }
    
        public int id { get; set; }
        public int class_id { get; set; }
        public string pym { get; set; }
        public string address { get; set; }
        public string name { get; set; }
        public string intact_name { get; set; }
        public string bank_name { get; set; }
        public string account { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string memo { get; set; }
        public System.Guid lastamp { get; set; }
    
        public virtual SupplierClass SupplierClass { get; set; }
        public virtual ICollection<SupplierD> SupplierD { get; set; }
        public virtual ICollection<SupplierF> SupplierF { get; set; }
    }
}
