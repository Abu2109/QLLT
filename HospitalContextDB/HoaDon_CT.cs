namespace QLLT.HospitalContextDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HoaDon_CT
    {
        [Key]
        public int HoaDonCtId { get; set; }

        public int HoaDonId { get; set; }

        public int ThuocId { get; set; }

        public int SoLuong { get; set; }

        public decimal DonGia { get; set; }

        public decimal GiamBHYT { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? ThanhTien { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual Thuoc Thuoc { get; set; }
    }
}
