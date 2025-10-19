using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using QLLT.HospitalContextDB;

namespace QLLT.Services
{
    public class BenhNhanService
    {
        public List<BenhNhan> Search(string keyword, int take = 100)
        {
            keyword = (keyword ?? "").Trim();
            using (var db = new Model1())
            {
                var q = db.BenhNhans.AsQueryable();
                if (!string.IsNullOrEmpty(keyword))
                {
                    q = q.Where(x => x.HoTen.Contains(keyword) ||
                                     x.DienThoai.Contains(keyword) ||
                                     x.CMND.Contains(keyword));
                }
                return q.OrderBy(x => x.HoTen).Take(take).ToList();
            }
        }

        public BenhNhan Get(int id)
        {
            using (var db = new Model1()) return db.BenhNhans.Find(id);
        }

        public BenhNhan AddOrUpdate(BenhNhan m)
        {
            using (var db = new Model1())
            {
                if (m.BenhNhanId == 0)
                {
                    db.BenhNhans.Add(m);
                }
                else
                {
                    db.Entry(m).State = EntityState.Modified;
                }
                db.SaveChanges();
                return m;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new Model1())
            {
                var e = db.BenhNhans.Find(id);
                if (e == null) return false;
                db.BenhNhans.Remove(e);
                db.SaveChanges();
                return true;
            }
        }

        public int Count() { using (var db = new Model1()) return db.BenhNhans.Count(); }
    }
}
