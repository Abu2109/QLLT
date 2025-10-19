using System;
using System.Linq;
using System.Windows.Forms;
using QLLT.HospitalContextDB;
using QLLT.Services;

namespace QLLT.Forms
{
    public partial class FrmQuanLyBenhNhan : Form
    {
        private readonly BenhNhanService _svc = new BenhNhanService();
        private int _currentId = 0;

        public FrmQuanLyBenhNhan()
        {
            InitializeComponent();
        }

        private void FrmQuanLyBenhNhan_Load(object sender, EventArgs e)
        {
            dgv.AutoGenerateColumns = false;
            dgv.DataError += (s, ev) => { ev.Cancel = true; };

            cmbGioiTinh.SelectedIndex = 0;
            if (dtpNgaySinh.Value.Year < 1900) dtpNgaySinh.Value = new DateTime(2005, 1, 1);

            LoadList();
        }

        private void LoadList(string kw = null)
        {
            var data = _svc.Search(kw, 300);  // service: AsNoTracking + tắt proxy/lazy
            dgv.DataSource = data;
            lblTong.Text = $"Tổng: {data.Count:n0}";
        }

        private void btnSearch_Click(object sender, EventArgs e) => LoadList(txtSearch.Text);

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;
            var row = dgv.CurrentRow.DataBoundItem as BenhNhan;
            if (row == null) return;

            _currentId = row.BenhNhanId;
            txtHoTen.Text = row.HoTen;
            cmbGioiTinh.SelectedItem = string.IsNullOrWhiteSpace(row.GioiTinh) ? "Nam" : row.GioiTinh;
            dtpNgaySinh.Value = row.NgaySinh ?? new DateTime(2005, 1, 1);
            txtDienThoai.Text = row.DienThoai;
            txtCMND.Text = row.CMND;
            txtDiaChi.Text = row.DiaChi;
        }

        private void btnMoi_Click(object sender, EventArgs e) => ClearForm();

        private void ClearForm()
        {
            _currentId = 0;
            txtHoTen.Clear();
            cmbGioiTinh.SelectedIndex = 0;
            dtpNgaySinh.Value = new DateTime(2005, 1, 1);
            txtDienThoai.Clear();
            txtCMND.Clear();
            txtDiaChi.Clear();
            txtHoTen.Focus();
            dgv.ClearSelection();
        }

        private void btnThem_Click(object sender, EventArgs e) => ClearForm();

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var bn = new BenhNhan
            {
                BenhNhanId = _currentId,
                HoTen = txtHoTen.Text.Trim(),
                GioiTinh = cmbGioiTinh.Text,
                NgaySinh = dtpNgaySinh.Value.Date,
                DienThoai = txtDienThoai.Text.Trim(),
                CMND = txtCMND.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim()
            };

            // Sinh MaBenhNhan nếu thêm mới
            using (var db = new Model1())
            {
                if (bn.BenhNhanId == 0)
                {
                    var maxMa = db.BenhNhans.Select(x => (long?)x.MaBenhNhan).DefaultIfEmpty(0).Max() ?? 0;
                    bn.MaBenhNhan = maxMa + 1;
                }
                else
                {
                    var old = db.BenhNhans.Find(bn.BenhNhanId);
                    bn.MaBenhNhan = old?.MaBenhNhan ?? 0;
                }
            }

            _svc.AddOrUpdate(bn);
            LoadList(txtSearch.Text);
            SelectRowById(bn.BenhNhanId);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_currentId == 0 || dgv.CurrentRow == null) return;

            if (MessageBox.Show($"Xóa bệnh nhân “{txtHoTen.Text.Trim()}”?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _svc.Delete(_currentId);
                    ClearForm();
                    LoadList(txtSearch.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên.");
                txtHoTen.Focus(); return false;
            }
            if (cmbGioiTinh.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn Giới tính.");
                cmbGioiTinh.Focus(); return false;
            }
            return true;
        }

        private void SelectRowById(int id)
        {
            if (id <= 0) return;
            foreach (DataGridViewRow r in dgv.Rows)
            {
                if (r.DataBoundItem is BenhNhan bn && bn.BenhNhanId == id)
                {
                    r.Selected = true;
                    dgv.CurrentCell = r.Cells["colHoTen"];
                    break;
                }
            }
        }
    }
}
