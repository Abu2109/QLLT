using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using QLLT.HospitalContextDB;

namespace QLLT.Forms
{
    public partial class FrmLeTanBoard : Form
    {
        public FrmLeTanBoard()
        {
            InitializeComponent();
        }

        private void FrmLeTanBoard_Load(object sender, EventArgs e)
        {
            dgvUpcoming.AutoGenerateColumns = false;
            LoadTiles();
            LoadUpcoming();
        }

        // ====== Ô thống kê trên cùng ======
        private void LoadTiles()
        {
            using (var db = new Model1())
            {
                var today = DateTime.Today;

                // tổng lịch hẹn trong hôm nay (không tính Hủy)
                int lichHomNay = db.LichHens
                    .Where(x => DbFunctions.TruncateTime(x.ThoiGianBatDau) == today
                             && x.TrangThai != "Huy")
                    .Count();

                int choXacNhan = db.LichHens
                    .Where(x => DbFunctions.TruncateTime(x.ThoiGianBatDau) == today
                             && x.TrangThai == "Moi")
                    .Count();

                int daKham = db.LichHens
                    .Where(x => DbFunctions.TruncateTime(x.ThoiGianBatDau) == today
                             && x.TrangThai == "DaKham")
                    .Count();

                int huy = db.LichHens
                    .Where(x => DbFunctions.TruncateTime(x.ThoiGianBatDau) == today
                             && x.TrangThai == "Huy")
                    .Count();

                int tongBN = db.BenhNhans.Count();

                lblLichHomNayVal.Text = lichHomNay.ToString();
                lblChoXacNhanVal.Text = choXacNhan.ToString();
                lblDaKhamVal.Text = daKham.ToString();
                lblHuyVal.Text = huy.ToString();
                lblBenhNhanMoiVal.Text = tongBN.ToString();
            }
        }

        // ====== Bảng lịch sắp tới trong hôm nay ======
        private void LoadUpcoming()
        {
            using (var db = new Model1())
            {
                var now = DateTime.Now;
                var endOfDay = now.Date.AddDays(1);

                var baseList = db.LichHens.AsNoTracking()
                    .Where(x => x.ThoiGianBatDau >= now && x.ThoiGianBatDau < endOfDay)
                    .OrderBy(x => x.ThoiGianBatDau)
                    .Select(x => new
                    {
                        x.ThoiGianBatDau,
                        x.ThoiGianKetThuc,
                        BacSi = x.BacSi.HoTen,
                        BenhNhan = x.BenhNhan.HoTen,
                        x.TrangThai,
                        x.LyDo
                    })
                    .ToList(); // đưa ra bộ nhớ để format giờ

                var view = baseList.Select(x => new
                {
                    TimeStr = $"{x.ThoiGianBatDau:HH\\:mm} - {x.ThoiGianKetThuc:HH\\:mm}",
                    x.BacSi,
                    x.BenhNhan,
                    x.TrangThai,
                    x.LyDo
                })
                .ToList();

                dgvUpcoming.DataSource = view;
            }
        }

        // ====== Buttons chuyển form ======
        private void btnQLBenhNhan_Click(object sender, EventArgs e)
        {
            using (var f = new FrmQuanLyBenhNhan()) f.ShowDialog();
            LoadTiles();
            LoadUpcoming();
        }

        private void btnDatLich_Click(object sender, EventArgs e)
        {
            using (var f = new FrmDatLich()) f.ShowDialog();
            LoadTiles();
            LoadUpcoming();
        }

        private void btnDanhSachLich_Click(object sender, EventArgs e)
        {
            using (var f = new FrmDanhSachLich()) f.ShowDialog();
            LoadTiles();
            LoadUpcoming();
        }

        private void btnThuNgan_Click(object sender, EventArgs e)
        {
            // Có thể bạn chưa làm FrmThuNgan – khi có form thì mở như dưới:
            using (var f = new FrmThuNgan()) f.ShowDialog();
            LoadTiles();
            LoadUpcoming();
        }
    }
}
