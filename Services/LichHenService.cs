using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using QLLT.HospitalContextDB;

namespace QLLT.Services
{
    public class LichHenService
    {
        public class LichHenFilter
        {
            public DateTime? From { get; set; }
            public DateTime? To { get; set; }
            public int? BacSiId { get; set; }
            public string TrangThai { get; set; } // 'Moi','XacNhan','DaKham','Huy'
        }

        public List<LichHen> GetList(LichHenFilter f)
        {
            using (var db = new Model1())
            {
                var q = db.LichHens
                          .Include(x => x.BenhNhan)
                          .Include(x => x.BacSi)
                          .AsQueryable();

                if (f?.From != null) q = q.Where(x => DbFunctions.TruncateTime(x.ThoiGianBatDau) >= DbFunctions.TruncateTime(f.From));
                if (f?.To != null) q = q.Where(x => DbFunctions.TruncateTime(x.ThoiGianBatDau) <= DbFunctions.TruncateTime(f.To));
                if (f?.BacSiId != null) q = q.Where(x => x.BacSiId == f.BacSiId);
                if (!string.IsNullOrWhiteSpace(f?.TrangThai)) q = q.Where(x => x.TrangThai == f.TrangThai);

                return q.OrderBy(x => x.ThoiGianBatDau).ToList();
            }
        }

        public bool IsOverlapped(int bacSiId, DateTime start, DateTime end, int? excludeId = null)
        {
            using (var db = new Model1())
            {
                var q = db.LichHens.Where(x => x.BacSiId == bacSiId);
                if (excludeId.HasValue) q = q.Where(x => x.LichHenId != excludeId.Value);
                return q.Any(x => !(x.ThoiGianKetThuc <= start || x.ThoiGianBatDau >= end));
            }
        }

        public LichHen Create(int benhNhanId, int bacSiId, DateTime start, int durationMinutes,
                              string lyDo = null, string trangThai = "Moi")
        {
            var end = start.AddMinutes(durationMinutes);
            if (IsOverlapped(bacSiId, start, end)) throw new InvalidOperationException("Bị trùng lịch.");

            using (var db = new Model1())
            {
                var lh = new LichHen
                {
                    MaLich = GenMaLich(db),
                    BenhNhanId = benhNhanId,
                    BacSiId = bacSiId,
                    ThoiGianBatDau = start,
                    ThoiGianKetThuc = end,
                    TrangThai = trangThai,
                    LyDo = lyDo
                };
                db.LichHens.Add(lh);
                db.SaveChanges();
                return lh;
            }
        }

        public void UpdateStatus(int lichHenId, string trangThai)
        {
            using (var db = new Model1())
            {
                var e = db.LichHens.Find(lichHenId);
                if (e == null) return;
                e.TrangThai = trangThai;
                db.SaveChanges();
            }
        }

        private long GenMaLich(Model1 db)
        {
            var ymd = DateTime.Now.ToString("yyyyMMdd");
            var max = db.LichHens.Where(x => x.MaLich.ToString().StartsWith(ymd))
                                 .Select(x => x.MaLich).DefaultIfEmpty(0).Max();
            var seq = (max % 100000) + 1;
            return long.Parse(ymd + seq.ToString("00000"));
        }
    }
}
