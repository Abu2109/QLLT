using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using QLLT.Controls;

namespace QLLT.Forms
{
    public partial class FrmLichSuGiaoDich : Form
    {
        // ====== Store dùng chung toàn app (trong phiên chạy) ======
        private static readonly List<InvoiceRow> _store = new List<InvoiceRow>();
        public static event Action DataChanged;   // để form refresh khi có giao dịch mới

        // API công khai: Thu ngân gọi để thêm lịch sử
        public static void AddHistory(string ma, DateTime ngay, decimal tong)
        {
            if (string.IsNullOrWhiteSpace(ma)) return;
            lock (_store)
            {
                _store.Add(new InvoiceRow { Ma = ma.Trim(), Ngay = ngay, Tong = tong });
            }
            try { DataChanged?.Invoke(); } catch { /* ignore */ }
        }

        public FrmLichSuGiaoDich()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;

            // Sự kiện UI
            txtSearch.TextChanged += (s, e) => ApplyFilter();
            chkLocNgay.CheckedChanged += (s, e) => ApplyFilter();
            dtNgay.ValueChanged += (s, e) => ApplyFilter();

            // Double-click để xem biên lai
            dgv.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                var row = dgv.Rows[e.RowIndex].DataBoundItem as InvoiceRow;
                if (row == null) return;
                using (var f = new FrmXemBienLai(row.Ma))
                    f.ShowDialog(this);
            };

            // Lắng nghe khi có giao dịch mới
            DataChanged += OnDataChanged;
        }

        private void FrmLichSuGiaoDich_Load(object sender, EventArgs e)
        {
            // luôn hiển thị đúng hôm nay khi mở
            dtNgay.Value = DateTime.Today;
            chkLocNgay.Checked = true;
            ApplyFilter();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            DataChanged -= OnDataChanged; // hủy đăng ký để tránh leak
            base.OnFormClosed(e);
        }

        private void OnDataChanged() => this.BeginInvoke((Action)ApplyFilter);

        // ====== Filter & hiển thị ======
        private void ApplyFilter()
        {
            List<InvoiceRow> list;
            lock (_store)
            {
                IEnumerable<InvoiceRow> q = _store;

                if (chkLocNgay.Checked)
                {
                    var d = dtNgay.Value.Date;
                    q = q.Where(x => x.Ngay.Date == d);
                }

                var kw = txtSearch.Text.Trim();
                if (!string.IsNullOrEmpty(kw))
                    q = q.Where(x => x.Ma.IndexOf(kw, StringComparison.OrdinalIgnoreCase) >= 0);

                list = q.OrderByDescending(x => x.Ngay).ThenBy(x => x.Ma).ToList();
            }

            dgv.DataSource = new BindingList<InvoiceRow>(list);
            lblSoGD.Text = $"Số giao dịch: {list.Count}";
        }
    }

    public class InvoiceRow
    {
        public string Ma { get; set; }
        public DateTime Ngay { get; set; }
        public decimal Tong { get; set; }
    }
}
