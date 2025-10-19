namespace QLLT.HospitalContextDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InvoiceDetail")]
    public partial class InvoiceDetail
    {
        public long Id { get; set; }

        public long InvoiceId { get; set; }

        public int DrugId { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual Thuoc Thuoc { get; set; }
    }
}
