using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLLT.DTOs;

namespace QLLT.Services
{
    public class HoaDonService
    {
        private readonly string _connStr;

        public HoaDonService(string connStr)
        {
            _connStr = connStr;
        }

        /*
        -- Chạy 1 lần trong SSMS nếu chưa có hoặc thiếu cột:
        IF OBJECT_ID('dbo.BienLaiTam','U') IS NULL
        BEGIN
            CREATE TABLE dbo.BienLaiTam(
                InvoiceId     BIGINT      NOT NULL,
                Ngay          DATETIME    NOT NULL,
                TenBN         NVARCHAR(100) NULL,
                PTTT          NVARCHAR(30)  NULL,
                TongTien      MONEY       NOT NULL,
                TienKhachDua  MONEY       NOT NULL,
                TenThuoc      NVARCHAR(200) NULL,
                SL            INT         NULL,
                DonGia        MONEY       NULL
            );
            CREATE INDEX IX_BienLaiTam_InvoiceId ON dbo.BienLaiTam(InvoiceId);
        END
        */

        /// <summary>
        /// Xóa dữ liệu tạm (an toàn khi ghi lại).
        /// </summary>
        public void ClearReceiptTemp(long invoiceId)
        {
            using (var cn = new SqlConnection(_connStr))
            using (var cmd = cn.CreateCommand())
            {
                cn.Open();
                cmd.CommandText = "DELETE dbo.BienLaiTam WHERE InvoiceId = @id";
                cmd.Parameters.AddWithValue("@id", invoiceId);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Ghi dữ liệu vào bảng tạm BienLaiTam (1 dòng/thuốc). 
        /// </summary>
        public void InsertReceiptTemp(
            long invoiceId,
            DateTime ngay,
            string tenBN,
            string pttt,
            decimal tongTien,
            decimal tienKhachDua,
            IEnumerable<CartItem> items)
        {
            using (var cn = new SqlConnection(_connStr))
            {
                cn.Open();
                using (var tx = cn.BeginTransaction())
                {
                    try
                    {
                        // Xóa cũ
                        using (var del = new SqlCommand("DELETE dbo.BienLaiTam WHERE InvoiceId = @id", cn, tx))
                        {
                            del.Parameters.AddWithValue("@id", invoiceId);
                            del.ExecuteNonQuery();
                        }

                        // Nếu không có item, vẫn ghi 1 dòng header để form còn đọc được header.
                        bool hasAny = false;
                        if (items != null)
                        {
                            foreach (var it in items)
                            {
                                hasAny = true;
                                using (var ins = new SqlCommand(@"
INSERT dbo.BienLaiTam(InvoiceId, Ngay, TenBN, PTTT, TongTien, TienKhachDua, TenThuoc, SL, DonGia)
VALUES(@id, @ngay, @bn, @pttt, @tong, @given, @ten, @sl, @gia);", cn, tx))
                                {
                                    ins.Parameters.AddWithValue("@id", invoiceId);
                                    ins.Parameters.AddWithValue("@ngay", ngay);
                                    ins.Parameters.AddWithValue("@bn", (object)(tenBN ?? "") ?? DBNull.Value);
                                    ins.Parameters.AddWithValue("@pttt", (object)(pttt ?? "") ?? DBNull.Value);
                                    ins.Parameters.AddWithValue("@tong", tongTien);
                                    ins.Parameters.AddWithValue("@given", tienKhachDua);
                                    ins.Parameters.AddWithValue("@ten", (object)(it.TenThuoc ?? "") ?? DBNull.Value);
                                    ins.Parameters.AddWithValue("@sl", it.SoLuong);
                                    ins.Parameters.AddWithValue("@gia", it.DonGia);
                                    ins.ExecuteNonQuery();
                                }
                            }
                        }

                        if (!hasAny)
                        {
                            using (var insHeader = new SqlCommand(@"
INSERT dbo.BienLaiTam(InvoiceId, Ngay, TenBN, PTTT, TongTien, TienKhachDua, TenThuoc, SL, DonGia)
VALUES(@id, @ngay, @bn, @pttt, @tong, @given, NULL, NULL, NULL);", cn, tx))
                            {
                                insHeader.Parameters.AddWithValue("@id", invoiceId);
                                insHeader.Parameters.AddWithValue("@ngay", ngay);
                                insHeader.Parameters.AddWithValue("@bn", (object)(tenBN ?? "") ?? DBNull.Value);
                                insHeader.Parameters.AddWithValue("@pttt", (object)(pttt ?? "") ?? DBNull.Value);
                                insHeader.Parameters.AddWithValue("@tong", tongTien);
                                insHeader.Parameters.AddWithValue("@given", tienKhachDua);
                                insHeader.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
