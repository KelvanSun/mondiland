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
    
    public partial class MaterialData
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public string type { get; set; }
        public int order_index { get; set; }
        public System.Guid lastamp { get; set; }
    
        public virtual ProductData ProductData { get; set; }
    }
}