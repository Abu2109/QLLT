using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLLT.Services
{
    /// <summary>
    /// Các hàm làm việc với bảng Thuốc.
    /// </summary>
    public class DonThuocService
    {
        // ĐỔI LẠI CHO PHÙ HỢP MÁY BẠN
        private readonly string _connStr =
            @"Data Source=LAPTOP-2M0DQDG7\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True;TrustServerCertificate=True";

        public DonThuocService() { }
        public DonThuocService(string connStr) { if (!string.IsNullOrEmpty(connStr)) _connStr = connStr; }

        /// <summary>Top 100 thuốc (cho lưới/tra cứu).</summary>
        public DataTable GetTopThuoc(string keyword)
        {
            using (var cn = new SqlConnection(_connStr))
            using (var cmd = cn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT TOP(100)
       t.ThuocId      AS [ThuocId],
       t.MaThuoc      AS [Ma],
       t.TenThuoc     AS [Ten],
       t.DonViTinh    AS [DVT],
       t.SoLuongTon   AS [TonKho],
       t.GiaThuoc     AS [Gia]
FROM dbo.Thuoc t WITH (NOLOCK)
WHERE (@kw = '' OR t.TenThuoc LIKE @kwLike OR CONVERT(varchar(50),t.MaThuoc) LIKE @kwLike)
ORDER BY t.TenThuoc;";
                var kw = (keyword ?? string.Empty).Trim();
                cmd.Parameters.AddWithValue("@kw", kw);
                cmd.Parameters.AddWithValue("@kwLike", "%" + kw + "%");

                var dt = new DataTable();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>Kiểm tra tất cả ThuocId trong danh sách có tồn tại không (trả về id nào không tồn tại).</summary>
        public List<int> FindMissingThuocIds(IEnumerable<int> thuocIds)
        {
            var missing = new List<int>();
            if (thuocIds == null) return missing;

            // gom thành bảng tạm (table-valued) đơn giản bằng chuỗi IN
            var ids = new List<int>(thuocIds);
            if (ids.Count == 0) return missing;

            using (var cn = new SqlConnection(_connStr))
            using (var cmd = cn.CreateCommand())
            {
                // tạo @ids dạng "1,2,3"
                var inList = string.Join(",", ids);
                cmd.CommandText = @"
SELECT x.Id
FROM (SELECT CAST(value AS int) AS Id FROM string_split(@inList,',')) x
LEFT JOIN dbo.Thuoc t ON t.ThuocId = x.Id
WHERE t.ThuocId IS NULL;";
                cmd.Parameters.AddWithValue("@inList", inList);
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read()) missing.Add(Convert.ToInt32(rd[0]));
                }
            }
            return missing;
        }

        /// <summary>Lấy thông tin một thuốc theo ThuocId (null nếu không có).</summary>
        public DataRow GetThuocById(int thuocId)
        {
            using (var cn = new SqlConnection(_connStr))
            using (var cmd = cn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT TOP(1) ThuocId, MaThuoc, TenThuoc, DonViTinh, SoLuongTon, GiaThuoc
FROM dbo.Thuoc WITH (NOLOCK)
WHERE ThuocId = @id;";
                cmd.Parameters.AddWithValue("@id", thuocId);

                var dt = new DataTable();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }
    }
}
