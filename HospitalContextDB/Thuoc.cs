namespace QLLT.HospitalContextDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Thuoc")]
    public partial class Thuoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thuoc()
        {
            HoaDon_CT = new HashSet<HoaDon_CT>();
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        public int ThuocId { get; set; }

        public long MaThuoc { get; set; }

        [Required]
        [StringLength(150)]
        public string TenThuoc { get; set; }

        public int NhomThuocId { get; set; }

        public int DonViTinhId { get; set; }

        public decimal GiaBan { get; set; }

        public int TonKho { get; set; }

        public bool IsActive { get; set; }

        [Required]
        [StringLength(50)]
        public string DonViTinh { get; set; }

        public int SoLuongTon { get; set; }

        [Column(TypeName = "money")]
        public decimal GiaThuoc { get; set; }

        public virtual DonViTinh DonViTinh1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon_CT> HoaDon_CT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }

        public virtual NhomThuoc NhomThuoc { get; set; }
    }
}
