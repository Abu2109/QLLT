using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLLT.HospitalContextDB
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<BacSi> BacSis { get; set; }
        public virtual DbSet<BenhNhan> BenhNhans { get; set; }
        public virtual DbSet<DonViTinh> DonViTinhs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HoaDon_CT> HoaDon_CT { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual DbSet<LichHen> LichHens { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhomThuoc> NhomThuocs { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Refund> Refunds { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThanhToan> ThanhToans { get; set; }
        public virtual DbSet<Thuoc> Thuocs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BacSi>()
                .HasMany(e => e.LichHens)
                .WithRequired(e => e.BacSi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BenhNhan>()
                .HasMany(e => e.LichHens)
                .WithRequired(e => e.BenhNhan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonViTinh>()
                .HasMany(e => e.Thuocs)
                .WithRequired(e => e.DonViTinh1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.NgayLap)
                .HasPrecision(0);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.Refunds)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon_CT>()
                .Property(e => e.ThanhTien)
                .HasPrecision(30, 2);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.TotalAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.InvoiceDetails)
                .WithRequired(e => e.Invoice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InvoiceDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LichHen>()
                .Property(e => e.ThoiGianBatDau)
                .HasPrecision(0);

            modelBuilder.Entity<LichHen>()
                .Property(e => e.ThoiGianKetThuc)
                .HasPrecision(0);

            modelBuilder.Entity<NhomThuoc>()
                .HasMany(e => e.Thuocs)
                .WithRequired(e => e.NhomThuoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Refund>()
                .Property(e => e.NgayRefund)
                .HasPrecision(0);

            modelBuilder.Entity<ThanhToan>()
                .Property(e => e.NgayTao)
                .HasPrecision(0);

            modelBuilder.Entity<Thuoc>()
                .Property(e => e.GiaThuoc)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Thuoc>()
                .HasMany(e => e.HoaDon_CT)
                .WithRequired(e => e.Thuoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Thuoc>()
                .HasMany(e => e.InvoiceDetails)
                .WithRequired(e => e.Thuoc)
                .HasForeignKey(e => e.DrugId)
                .WillCascadeOnDelete(false);
        }
    }
}
