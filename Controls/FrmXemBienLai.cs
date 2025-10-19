using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLLT.Controls
{
    // ====== Store dùng trong phiên để xem lại biên lai ======
    internal static class ReceiptStore
    {
        internal sealed class Receipt
        {
            public string InvoiceNo { get; set; } = "";
            public string MethodName { get; set; } = "Tiền mặt";
            public decimal Total { get; set; }
            public decimal Given { get; set; }
            public string PatientName { get; set; } = "...";
            public DataTable Lines { get; set; } = CreateLineTable();
            public DateTime CreatedAt { get; set; } = DateTime.Now;
        }

        private static readonly List<Receipt> _items = new List<Receipt>();
        private static readonly object _lock = new object();
        private static string _lastKey = ""; // mã HĐ gần nhất

        public static void Save(string invoiceNo, string method, decimal total, decimal given, string patient, DataTable lines)
        {
            if (string.IsNullOrWhiteSpace(invoiceNo)) return;
            var rec = new Receipt
            {
                InvoiceNo = invoiceNo.Trim(),
                MethodName = string.IsNullOrWhiteSpace(method) ? "Tiền mặt" : method,
                Total = total,
                Given = given,
                PatientName = string.IsNullOrWhiteSpace(patient) ? "..." : patient,
                Lines = lines != null ? lines.Copy() : CreateLineTable(),
                CreatedAt = DateTime.Now
            };
            lock (_lock)
            {
                // nếu đã có thì replace, không thì thêm
                var idx = _items.FindIndex(x => x.InvoiceNo.Equals(rec.InvoiceNo, StringComparison.OrdinalIgnoreCase));
                if (idx >= 0) _items[idx] = rec; else _items.Add(rec);
                _lastKey = rec.InvoiceNo;
            }
        }

        public static bool TryGetByInvoice(string invoiceNo, out Receipt r)
        {
            lock (_lock)
            {
                r = _items.FirstOrDefault(x => x.InvoiceNo.Equals(invoiceNo ?? "", StringComparison.OrdinalIgnoreCase));
                return r != null;
            }
        }

        public static bool TryGetLast(out Receipt r)
        {
            lock (_lock)
            {
                if (!string.IsNullOrEmpty(_lastKey))
                {
                    r = _items.FirstOrDefault(x => x.InvoiceNo.Equals(_lastKey, StringComparison.OrdinalIgnoreCase));
                    if (r != null) return true;
                }
                r = _items.OrderByDescending(x => x.CreatedAt).FirstOrDefault();
                return r != null;
            }
        }

        internal static DataTable CreateLineTable()
        {
            var t = new DataTable();
            t.Columns.Add("TenThuoc", typeof(string));
            t.Columns.Add("DVT", typeof(string));
            t.Columns.Add("SoLuong", typeof(int));
            t.Columns.Add("DonGia", typeof(decimal));
            t.Columns.Add("ThanhTien", typeof(decimal));
            return t;
        }
    }

    public partial class FrmXemBienLai : Form
    {
        private string _invoiceNo;
        private string _methodName;
        private decimal _total;
        private decimal _given;
        private string _patientName;
        private DataTable _lines;

        /// <summary>
        /// Gọi khi vừa thanh toán xong (đủ tham số).
        /// Tự động lưu vào ReceiptStore để xem lại/“Xem biên lai”.
        /// </summary>
        public FrmXemBienLai(string invoiceNo,
                             string methodName,
                             decimal total,
                             decimal given,
                             string patientName,
                             DataTable lines)
        {
            InitializeComponent();

            _invoiceNo = invoiceNo ?? "";
            _methodName = string.IsNullOrWhiteSpace(methodName) ? "Tiền mặt" : methodName;
            _total = total;
            _given = given;
            _patientName = string.IsNullOrWhiteSpace(patientName) ? "..." : patientName;
            _lines = lines ?? ReceiptStore.CreateLineTable();

            // Lưu vào store (để nút “Xem biên lai” và Lịch sử GD mở lại)
            ReceiptStore.Save(_invoiceNo, _methodName, _total, _given, _patientName, _lines);

            BindToUi();
        }

        /// <summary>
        /// Gọi từ nút “Xem biên lai” (FrmThuNgan) hoặc từ Lịch sử GD (truyền mã).
        /// - Nếu truyền "XemBL" hoặc rỗng => mở biên lai gần nhất.
        /// - Nếu truyền mã hợp lệ => mở đúng biên lai đó (nếu đã lưu trong phiên).
        /// </summary>
        public FrmXemBienLai(string invoiceNoOrCommand)
        {
            InitializeComponent();

            // default rỗng
            _invoiceNo = invoiceNoOrCommand ?? "";
            _methodName = "Tiền mặt";
            _total = 0m;
            _given = 0m;
            _patientName = "...";
            _lines = ReceiptStore.CreateLineTable();

            // Ưu tiên: nếu là lệnh xem gần nhất
            if (string.IsNullOrWhiteSpace(invoiceNoOrCommand) ||
                invoiceNoOrCommand.Equals("XemBL", StringComparison.OrdinalIgnoreCase) ||
                invoiceNoOrCommand.Equals("LAST", StringComparison.OrdinalIgnoreCase))
            {
                if (ReceiptStore.TryGetLast(out var last))
                    LoadFromReceipt(last);
            }
            else
            {
                if (ReceiptStore.TryGetByInvoice(invoiceNoOrCommand, out var r))
                    LoadFromReceipt(r);
            }

            BindToUi();
        }

        private void LoadFromReceipt(ReceiptStore.Receipt r)
        {
            _invoiceNo = r.InvoiceNo;
            _methodName = r.MethodName;
            _total = r.Total;
            _given = r.Given;
            _patientName = r.PatientName;
            _lines = r.Lines.Copy(); // copy để form chỉnh không ảnh hưởng store
        }

        private void BindToUi()
        {
            lbTitle.Text = $"Biên lai #{_invoiceNo}";
            lbDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            lbPatient.Text = _patientName;
            lbMethod.Text = _methodName;
            lbGiven.Text = _given.ToString("N0");
            lbTotal.Text = _total.ToString("N0") + "đ";

            // Map đúng cột
            dgvLines.AutoGenerateColumns = false;
            dgvLines.DataSource = _lines;

            dgvLines.DataBindingComplete -= DgvLines_DataBindingComplete;
            dgvLines.DataBindingComplete += DgvLines_DataBindingComplete;
            // đánh STT ngay lần đầu
            DgvLines_DataBindingComplete(dgvLines, null);
        }

        private void DgvLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvLines.Rows.Count; i++)
                dgvLines.Rows[i].Cells["colSTT"].Value = (i + 1).ToString();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            // In/preview lại
            ReceiptPrinter.ShowPreview(
                _lines,
                "PHÒNG KHÁM ABC",
                _invoiceNo,
                DateTime.Now,
                _patientName,
                _methodName,
                _total,
                _given
            );
        }

        private void btnDong_Click(object sender, EventArgs e) => Close();
    }
}
