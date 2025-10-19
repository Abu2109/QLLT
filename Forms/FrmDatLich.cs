using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using QLLT.HospitalContextDB;

namespace QLLT.Forms
{
    public partial class FrmDatLich : Form
    {
        public FrmDatLich()
        {
            InitializeComponent();
        }

        private void FrmDatLich_Load(object sender, EventArgs e)
        {
            dgvTrung.AutoGenerateColumns = false;
            dgvTrung.DataError += (s, ev) => ev.Cancel = true;

            dtpNgay.Value = DateTime.Today;
            dtpGio.Value = DateTime.Today.AddHours(9);
            numThoiLuong.Value = 15;

            LoadBacSi();
            LoadTrangThai();
            LoadBenhNhan("");
        }

        private void LoadBacSi()
        {
            using (var db = new Model1())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;

                var ds = db.BacSis.AsNoTracking()
                                  .OrderBy(x => x.HoTen)
                                  .Select(x => new { x.BacSiId, x.HoTen })
                                  .ToList();
                cboBacSi.DisplayMember = "HoTen";
                cboBacSi.ValueMember = "BacSiId";
                cboBacSi.DataSource = ds;
            }
        }

        private void LoadTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] { "Moi", "XacNhan", "DaKham", "Huy" });
            cboTrangThai.SelectedIndex = 0;
        }

        private void LoadBenhNhan(string keyword)
        {
            using (var db = new Model1())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;

                keyword = (keyword ?? "").Trim();
                IQueryable<BenhNhan> q = db.BenhNhans.AsNoTracking();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    q = q.Where(x => x.HoTen.Contains(keyword)
                                  || x.DienThoai.Contains(keyword)
                                  || x.CMND.Contains(keyword));
                }

                var ds = q.OrderBy(x => x.HoTen)
                          .Take(100)
                          .Select(x => new { x.BenhNhanId, Display = x.HoTen + " - " + (x.DienThoai ?? "") })
                          .ToList();

                cboBenhNhan.DisplayMember = "Display";
                cboBenhNhan.ValueMember = "BenhNhanId";
                cboBenhNhan.DataSource = ds;
            }
        }

        // ====== Helpers ======
        private DateTime GetBatDau() => dtpNgay.Value.Date
                                              .AddHours(dtpGio.Value.Hour)
                                              .AddMinutes(dtpGio.Value.Minute);
        private DateTime GetKetThuc() => GetBatDau().AddMinutes((int)numThoiLuong.Value);

        // ====== Events ======
        private void btnSearchBN_Click(object sender, EventArgs e) => LoadBenhNhan(txtSearchBN.Text);

        private void btnKiemTra_Click(object sender, EventArgs e) => KiemTraTrung();

        private void KiemTraTrung()
        {
            if (cboBacSi.SelectedItem == null) { MessageBox.Show("Chọn bác sĩ."); return; }

            int bacSiId = (int)cboBacSi.SelectedValue;
            DateTime batDau = GetBatDau();
            DateTime ketThuc = GetKetThuc();

            using (var db = new Model1())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;

                var list = db.LichHens.AsNoTracking()
                    .Where(x => x.BacSiId == bacSiId &&
                                !(x.ThoiGianKetThuc <= batDau || x.ThoiGianBatDau >= ketThuc))
                    .Select(x => new
                    {
                        x.LichHenId,
                        BacSiTen = x.BacSi.HoTen,
                        BenhNhanTen = x.BenhNhan.HoTen,
                        x.ThoiGianBatDau,
                        x.ThoiGianKetThuc
                    })
                    .OrderBy(x => x.ThoiGianBatDau)
                    .ToList();

                dgvTrung.DataSource = list;

                if (list.Count == 0)
                    MessageBox.Show("Không có lịch trùng!", "Kiểm tra trùng",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Có {list.Count} lịch trùng thời gian.", "Kiểm tra trùng",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboBenhNhan.SelectedItem == null) { MessageBox.Show("Chọn bệnh nhân."); return; }
            if (cboBacSi.SelectedItem == null) { MessageBox.Show("Chọn bác sĩ."); return; }

            int benhNhanId = (int)cboBenhNhan.SelectedValue;
            int bacSiId = (int)cboBacSi.SelectedValue;
            DateTime batDau = GetBatDau();
            DateTime ketThuc = GetKetThuc();
            string lyDo = txtLyDo.Text?.Trim();
            string trangThai = cboTrangThai.Text;

            using (var db = new Model1())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;

                bool overlap = db.LichHens.Any(x => x.BacSiId == bacSiId &&
                                 !(x.ThoiGianKetThuc <= batDau || x.ThoiGianBatDau >= ketThuc));

                if (overlap &&
                    MessageBox.Show("Phát hiện lịch trùng. Bạn vẫn muốn lưu?",
                        "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;

                var lh = new LichHen
                {
                    BenhNhanId = benhNhanId,
                    BacSiId = bacSiId,
                    ThoiGianBatDau = batDau,
                    ThoiGianKetThuc = ketThuc,
                    TrangThai = trangThai,
                    LyDo = lyDo,
                    GhiChu = null
                };

                db.LichHens.Add(lh);
                db.SaveChanges();
            }

            MessageBox.Show("Lưu lịch hẹn thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            KiemTraTrung();
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtSearchBN.Clear();
            txtLyDo.Clear();
            if (cboBenhNhan.Items.Count > 0) cboBenhNhan.SelectedIndex = 0;
            if (cboBacSi.Items.Count > 0) cboBacSi.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;
            dtpNgay.Value = DateTime.Today;
            dtpGio.Value = DateTime.Today.AddHours(9);
            numThoiLuong.Value = 15;
            dgvTrung.DataSource = null;
        }
    }
}
