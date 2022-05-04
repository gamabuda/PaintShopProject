//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PaintShopProject.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Order = new HashSet<Order>();
        }
    
        public System.Guid ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Volume { get; set; }
        public System.Guid ColorID { get; set; }
        public System.Guid BrandID { get; set; }
        public System.Guid DiluentID { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual Color Color { get; set; }
        public virtual Diluent Diluent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}