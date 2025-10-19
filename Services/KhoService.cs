using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using QLLT.HospitalContextDB;

namespace QLLT.Services
{
    public class KhoService
    {
        public Thuoc GetThuocById(int id)
        {
            using (var db = new Model1())
                return db.Thuocs.Include(t => t.DonViTinh).Include(t => t.NhomThuoc).FirstOrDefault(t => t.ThuocId == id);
        }

        public Thuoc GetThuocByMa(long maThuoc)
        {
            using (var db = new Model1())
                return db.Thuocs.Include(t => t.DonViTinh).Include(t => t.NhomThuoc).FirstOrDefault(t => t.MaThuoc == maThuoc);
        }

        public List<Thuoc> GetCatalog(int? nhomThuocId = null)
        {
            using (var db = new Model1())
            {
                var q = db.Thuocs.Include(t => t.DonViTinh).Include(t => t.NhomThuoc).Where(t => t.IsActive);
                if (nhomThuocId.HasValue) q = q.Where(t => t.NhomThuocId == nhomThuocId.Value);
                return q.OrderBy(t => t.NhomThuoc.TenNhom).ThenBy(t => t.TenThuoc).ToList();
            }
        }

        public bool ConDuHang(int thuocId, int soLuong)
        {
            using (var db = new Model1())
            {
                var t = db.Thuocs.Find(thuocId);
                if (t == null) return false;
                return t.TonKho >= soLuong;
            }
        }
    }
}
