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
    
    public partial class LineWrite
    {
        public double Summa { get; set; }
        public int Count { get; set; }
        public int NumberActWrite_FK_ { get; set; }
        public int CodTovara_FK_ { get; set; }
        public int ID { get; set; }
    
        public virtual Tovar Tovar { get; set; }
        public virtual Write Write { get; set; }
    }
}
