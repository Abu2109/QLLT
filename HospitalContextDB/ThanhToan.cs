namespace QLLT.HospitalContextDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThanhToan")]
    public partial class ThanhToan
    {
        public int ThanhToanId { get; set; }

        public int HoaDonId { get; set; }

        [Required]
        [StringLength(20)]
        public string PhuongThuc { get; set; }

        public decimal SoTien { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime NgayTao { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
