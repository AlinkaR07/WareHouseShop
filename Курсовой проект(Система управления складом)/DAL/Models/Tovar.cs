//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tovar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tovar()
        {
            this.LineWrite = new HashSet<LineWrite>();
            this.LineOrder = new HashSet<LineOrder>();
        }
    
        public int CodTovara { get; set; }
        public string Name { get; set; }
        public System.DateTime DateExpiration { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual CategoryTovara CategoryTovara { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LineWrite> LineWrite { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LineOrder> LineOrder { get; set; }
    }
}
