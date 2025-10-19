using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using QLLT.HospitalContextDB;

namespace QLLT.Forms
{
    public partial class FrmDanhSachLich : Form
    {
        public FrmDanhSachLich()
        {
            InitializeComponent();
        }

        private void FrmDanhSachLich_Load(object sender, EventArgs e)
        {
            dgv.AutoGenerateColumns = false;
            dgv.DataError += (s, ev) => ev.Cancel = true;

            // mặc định 7 ngày gần đây
            dtpFrom.Value = DateTime.Today.AddDays(-7);
            dtpTo.Value = DateTime.Today.AddDays(7);

            // load combobox bác sĩ
            using (var db = new Model1())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;

                var bs = db.BacSis.AsNoTracking()
                          .OrderBy(x => x.HoTen)
                          .Select(x => new { x.BacSiId, x.HoTen })
                          .ToList();

                cboBacSi.Items.Clear();
                cboBacSi.Items.Add(new CboItem { Text = "(Tất cả)", Value = 0 });
                bs.ForEach(x => cboBacSi.Items.Add(new CboItem { Text = x.HoTen, Value = x.BacSiId }));
                cboBacSi.SelectedIndex = 0;
            }

            // trạng thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("(Tất cả)");
            cboTrangThai.Items.Add("Moi");
            cboTrangThai.Items.Add("XacNhan");
            cboTrangThai.Items.Add("DaKham");
            cboTrangThai.Items.Add("Huy");
            cboTrangThai.SelectedIndex = 0;

            LoadData();
        }

        private void btnTim_Click(object sender, EventArgs e) => LoadData();
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtKeyword.Clear();
            cboBacSi.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Today.AddDays(-7);
            dtpTo.Value = DateTime.Today.AddDays(7);
            LoadData();
        }

        private void LoadData()
        {
            var from = dtpFrom.Value.Date;
            var to = dtpTo.Value.Date.AddDays(1).AddTicks(-1); // inclusive end day
            int bacSiId = (cboBacSi.SelectedItem as CboItem)?.Value ?? 0;
            string trangThai = cboTrangThai.SelectedIndex == 0 ? null : cboTrangThai.Text;
            string kw = txtKeyword.Text?.Trim();

            using (var db = new Model1())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;

                var q = db.LichHens
                    .AsNoTracking()
                    .Where(x => x.ThoiGianBatDau >= from && x.ThoiGianBatDau <= to);

                if (bacSiId > 0) q = q.Where(x => x.BacSiId == bacSiId);
                if (!string.IsNullOrWhiteSpace(trangThai)) q = q.Where(x => x.TrangThai == trangThai);
                if (!string.IsNullOrWhiteSpace(kw))
                {
                    q = q.Where(x =>
                        x.BenhNhan.HoTen.Contains(kw) ||
                        x.LyDo.Contains(kw));
                }

                // Chỉ map ra fields cần dùng để tránh lazy load navigation
                var data = q
                    .OrderByDescending(x => x.ThoiGianBatDau)
                    .Select(x => new
                    {
                        x.LichHenId,
                        BacSiTen = x.BacSi.HoTen,
                        BenhNhanTen = x.BenhNhan.HoTen,
                        x.ThoiGianBatDau,
                        x.ThoiGianKetThuc,
                        x.TrangThai,
                        x.LyDo
                    })
                    .ToList();

                dgv.DataSource = data;
                lblCount.Text = $"Số lịch: {data.Count:n0}";
            }
        }

        private class CboItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() => Text;
        }
    }
}
