namespace QLLT.HospitalContextDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Refund")]
    public partial class Refund
    {
        public int RefundId { get; set; }

        public long MaRefund { get; set; }

        public int HoaDonId { get; set; }

        [StringLength(300)]
        public string LyDo { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime NgayRefund { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
