﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFModule
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProductEntities : DbContext
    {
        public ProductEntities()
            : base("name=ProductEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Dengji> Dengji { get; set; }
        public virtual DbSet<dtproperties> dtproperties { get; set; }
        public virtual DbSet<GroupInfo> GroupInfo { get; set; }
        public virtual DbSet<GroupMenu> GroupMenu { get; set; }
        public virtual DbSet<MadePlace> MadePlace { get; set; }
        public virtual DbSet<MaterialData> MaterialData { get; set; }
        public virtual DbSet<MaterialFill> MaterialFill { get; set; }
        public virtual DbSet<MenuInfo> MenuInfo { get; set; }
        public virtual DbSet<PartName> PartName { get; set; }
        public virtual DbSet<ProductData> ProductData { get; set; }
        public virtual DbSet<SafeData> SafeData { get; set; }
        public virtual DbSet<SizeClass> SizeClass { get; set; }
        public virtual DbSet<SizeData> SizeData { get; set; }
        public virtual DbSet<StandardData> StandardData { get; set; }
        public virtual DbSet<SupplierClass> SupplierClass { get; set; }
        public virtual DbSet<SupplierD> SupplierD { get; set; }
        public virtual DbSet<SupplierM> SupplierM { get; set; }
        public virtual DbSet<TagPrintTemplate> TagPrintTemplate { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserMenuFavorites> UserMenuFavorites { get; set; }
        public virtual DbSet<WashPrintTemplate> WashPrintTemplate { get; set; }
    }
}
