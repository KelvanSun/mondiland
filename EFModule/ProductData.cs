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
    
    public partial class ProductData
    {
        public ProductData()
        {
            this.MaterialData = new HashSet<MaterialData>();
            this.MaterialFill = new HashSet<MaterialFill>();
        }
    
        public int id { get; set; }
        public int partname_id { get; set; }
        public string huohao { get; set; }
        public int safedata_id { get; set; }
        public int standarddata_id { get; set; }
        public decimal price { get; set; }
        public int madeplace_id { get; set; }
        public int dengji_id { get; set; }
        public int tag_id { get; set; }
        public int wash_id { get; set; }
        public string memo { get; set; }
        public int pwash { get; set; }
        public int pbad { get; set; }
        public System.Guid lastamp { get; set; }
        public string gyear { get; set; }
        public string gmonth { get; set; }
        public Nullable<int> color_id { get; set; }
        public int ptemplate { get; set; }
        public string template_data { get; set; }
        public int wash_u { get; set; }
    
        public virtual Dengji Dengji { get; set; }
        public virtual MadePlace MadePlace { get; set; }
        public virtual ICollection<MaterialData> MaterialData { get; set; }
        public virtual ICollection<MaterialFill> MaterialFill { get; set; }
        public virtual PartName PartName { get; set; }
        public virtual SafeData SafeData { get; set; }
        public virtual StandardData StandardData { get; set; }
        public virtual TagPrintTemplate TagPrintTemplate { get; set; }
        public virtual WashPrintTemplate WashPrintTemplate { get; set; }
        public virtual ColorData ColorData { get; set; }
    }
}
