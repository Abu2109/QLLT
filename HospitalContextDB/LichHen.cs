namespace QLLT.HospitalContextDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichHen")]
    public partial class LichHen
    {
        public int LichHenId { get; set; }

        public long MaLich { get; set; }

        public int BenhNhanId { get; set; }

        public int BacSiId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ThoiGianBatDau { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ThoiGianKetThuc { get; set; }

        [Required]
        [StringLength(20)]
        public string TrangThai { get; set; }

        [StringLength(300)]
        public string LyDo { get; set; }

        [StringLength(300)]
        public string GhiChu { get; set; }

        public virtual BacSi BacSi { get; set; }

        public virtual BenhNhan BenhNhan { get; set; }
    }
}
