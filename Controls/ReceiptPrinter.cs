using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace QLLT.Controls
{
    /// <summary>
    /// In/preview biên lai đơn giản từ DataTable.
    /// Gọi: ReceiptPrinter.ShowPreview(lines, clinicName, invoiceNo, date, patientName, methodName, total, given);
    /// </summary>
    public static class ReceiptPrinter
    {
        // Trạng thái cho lần in hiện tại
        private static DataTable _lines;
        private static string _clinicName;
        private static string _invoiceNo;
        private static DateTime _date;
        private static string _patientName;
        private static string _methodName;
        private static decimal _total;
        private static decimal _given;

        /// <summary>
        /// Mở PrintPreviewDialog biên lai.
        /// </summary>
        public static void ShowPreview(
            DataTable lines,
            string clinicName,
            string invoiceNo,
            DateTime date,
            string patientName,
            string methodName,
            decimal total,
            decimal given)
        {
            // Lưu trạng thái
            _lines = lines;
            _clinicName = clinicName ?? "PHÒNG KHÁM";
            _invoiceNo = invoiceNo ?? "";
            _date = date;
            _patientName = string.IsNullOrWhiteSpace(patientName) ? "..." : patientName;
            _methodName = string.IsNullOrWhiteSpace(methodName) ? "..." : methodName;
            _total = total;
            _given = given;

            // Tạo tài liệu in
            PrintDocument doc = new PrintDocument();
            doc.DocumentName = "Receipt";
            doc.PrintPage += Doc_PrintPage;

            // Preview
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = doc;
            dlg.Width = 900;
            dlg.Height = 700;
            dlg.ShowIcon = false;

            try { dlg.ShowDialog(); }
            catch
            {
                MessageBox.Show("Không xem trước được bản in. Vui lòng kiểm tra cài đặt in.",
                    "Print preview", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Dọn trạng thái
            _lines = null;
        }

        // ===================== Render =====================

        private static void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            RectangleF page = e.MarginBounds;

            float left = page.Left;
            float top = page.Top;
            float right = page.Right;

            using (Font fTitle = new Font("Segoe UI", 11f, FontStyle.Bold))
            using (Font fHeader = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            using (Font fBold = new Font("Segoe UI", 9f, FontStyle.Bold))
            using (Font fNorm = new Font("Segoe UI", 9f, FontStyle.Regular))
            using (Pen pen = new Pen(Color.Black, 1f))
            {
                float y = top;

                // --- Header phòng khám ---
                DrawText(g, _clinicName.ToUpperInvariant(), left, y, right - left, 18f, fTitle, StringAlignment.Near);
                y += 16;

                DrawText(g, "Địa chỉ: Đại học Hutech  -  ĐT: …", left, y, right - left, 16f, fNorm, StringAlignment.Near);
                y += 14;

                DrawText(g, "BIÊN LAI THU TIỀN", left, y, right - left, 18f, fHeader, StringAlignment.Near);
                y += 16;

                DrawText(g, "Số: " + (_invoiceNo ?? ""), left, y, (right - left) / 2f, 16f, fNorm, StringAlignment.Near);
                DrawText(g, "Ngày: " + _date.ToString("dd/MM/yyyy HH:mm"), left + (right - left) / 2f, y, (right - left) / 2f, 16f, fNorm, StringAlignment.Near);
                y += 14;

                DrawText(g, "Bệnh nhân: " + _patientName, left, y, right - left, 16f, fNorm, StringAlignment.Near);
                y += 14;

                // --- Bảng ---
                float tblLeft = left;
                float colSTT = 30f;  // STT
                float colTen = 260f;
                float colDvt = 60f;
                float colSl = 60f;
                float colGia = 90f;
                float colTt = 110f;

                // Header bảng
                float x = tblLeft;
                DrawCell(g, "STT", x, y, colSTT, 18, fBold, StringAlignment.Center); x += colSTT;
                DrawCell(g, "Tên thuốc", x, y, colTen, 18, fBold, StringAlignment.Near); x += colTen;
                DrawCell(g, "ĐVT", x, y, colDvt, 18, fBold, StringAlignment.Center); x += colDvt;
                DrawCell(g, "SL", x, y, colSl, 18, fBold, StringAlignment.Center); x += colSl;
                DrawCell(g, "Đơn giá", x, y, colGia, 18, fBold, StringAlignment.Far); x += colGia;
                DrawCell(g, "Thành tiền", x, y, colTt, 18, fBold, StringAlignment.Far);
                y += 18;

                DrawLine(g, tblLeft, y, tblLeft + colSTT + colTen + colDvt + colSl + colGia + colTt, y);
                y += 4;

                // Dòng dữ liệu
                int stt = 1;
                if (_lines != null)
                {
                    for (int i = 0; i < _lines.Rows.Count; i++)
                    {
                        DataRow r = _lines.Rows[i];

                        string ten = TryGetString(r, "TenThuoc");
                        string dvt = TryGetString(r, "DVT", "DonViTinh");
                        string sl = TryGetString(r, "SoLuong");
                        string gia = TryGetString(r, "DonGia");
                        string tt = TryGetString(r, "ThanhTien");

                        x = tblLeft;
                        DrawCell(g, stt.ToString(), x, y, colSTT, 18, fNorm, StringAlignment.Center); x += colSTT;
                        DrawCell(g, ten, x, y, colTen, 18, fNorm, StringAlignment.Near); x += colTen;
                        DrawCell(g, dvt, x, y, colDvt, 18, fNorm, StringAlignment.Center); x += colDvt;
                        DrawCell(g, sl, x, y, colSl, 18, fNorm, StringAlignment.Center); x += colSl;
                        DrawCell(g, FormatN0(gia), x, y, colGia, 18, fNorm, StringAlignment.Far); x += colGia;
                        DrawCell(g, FormatN0(tt), x, y, colTt, 18, fNorm, StringAlignment.Far);

                        y += 18;
                        stt++;
                    }
                }

                DrawLine(g, tblLeft, y, tblLeft + colSTT + colTen + colDvt + colSl + colGia + colTt, y);
                y += 10;

                // --- Tổng & phương thức ---
                DrawText(g, "Phương thức: " + _methodName, left, y, (right - left) / 2f, 16f, fNorm, StringAlignment.Near);
                DrawText(g, "Tổng tiền:  " + _total.ToString("N0") + "đ", left + (right - left) / 2f, y, (right - left) / 2f, 16f, fBold, StringAlignment.Near);
                y += 16;

                if (_given > 0)
                {
                    DrawText(g, "Khách đưa: " + _given.ToString("N0") + "đ", left, y, right - left, 16f, fNorm, StringAlignment.Near);
                    y += 16;

                    // >>> TIỀN THỐI (chỉ hiện khi Tiền mặt & đưa dư) <<<
                    if (IsCash(_methodName))
                    {
                        decimal change = _given - _total;
                        if (change > 0)
                        {
                            DrawText(g, "Tiền thối: " + change.ToString("N0") + "đ", left, y, right - left, 16f, fBold, StringAlignment.Near);
                            y += 16;
                        }
                    }
                }

                y += 10;
                DrawText(g, "Cám ơn Quý khách!", left, y, right - left, 16f, fNorm, StringAlignment.Near);
            }

            e.HasMorePages = false;
        }

        // ===================== Helpers =====================

        private static bool IsCash(string methodName)
        {
            if (string.IsNullOrEmpty(methodName)) return false;
            string s = methodName.Trim().ToLowerInvariant();
            // các biến thể có thể gặp
            return s.Contains("tiền mặt") || s.Contains("tien mat") || s.Contains("cash");
        }

        private static string TryGetString(DataRow r, params string[] names)
        {
            try
            {
                foreach (string n in names)
                {
                    if (r.Table.Columns.Contains(n))
                    {
                        object v = r[n];
                        if (v != null) return Convert.ToString(v);
                    }
                }
            }
            catch { }
            return "";
        }

        private static void DrawCell(Graphics g, string text, float x, float y, float w, float h, Font font, StringAlignment align)
        {
            DrawText(g, text, x, y, w, h, font, align);
            g.DrawRectangle(Pens.Black, x, y, w, h);
        }

        private static void DrawText(Graphics g, string text, float x, float y, float w, float h, Font font, StringAlignment align)
        {
            StringFormat fmt = new StringFormat();
            fmt.Alignment = align;
            fmt.LineAlignment = StringAlignment.Center;
            RectangleF rc = new RectangleF(x, y, w, h);
            g.DrawString(text ?? "", font, Brushes.Black, rc, fmt);
        }

        private static void DrawLine(Graphics g, float x1, float y1, float x2, float y2)
        {
            g.DrawLine(Pens.Black, x1, y1, x2, y2);
        }

        private static string FormatN0(object v)
        {
            try
            {
                decimal dv = Convert.ToDecimal(v);
                return dv.ToString("N0");
            }
            catch { return "0"; }
        }
    }
}
