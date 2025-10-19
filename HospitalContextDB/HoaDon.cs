namespace QLLT.HospitalContextDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            HoaDon_CT = new HashSet<HoaDon_CT>();
            Refunds = new HashSet<Refund>();
            ThanhToans = new HashSet<ThanhToan>();
        }

        public int HoaDonId { get; set; }

        public long MaHoaDon { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime NgayLap { get; set; }

        public int? BenhNhanId { get; set; }

        public int? NhanVienId { get; set; }

        public decimal TongTien { get; set; }

        [StringLength(20)]
        public string SoBHYT { get; set; }

        public bool IsRefunded { get; set; }

        public virtual BenhNhan BenhNhan { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon_CT> HoaDon_CT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Refund> Refunds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhToan> ThanhToans { get; set; }
    }
}
