using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QLLT.Controls;
using QLLT.DTOs;

namespace QLLT.Forms
{
    public partial class FrmThuNgan : Form
    {
        private readonly BindingList<CartItem> _cart = new BindingList<CartItem>();

        public FrmThuNgan()
        {
            InitializeComponent();

            bsCart.DataSource = _cart;
            dgvCart.DataSource = bsCart;

            // kết nối UC
            ucChon.ItemChosen += OnItemChosen;
            ucPay.PaymentConfirmed += OnPaymentConfirmed;
            ucPay.PaymentCanceled += delegate { ShowChoose(); };

            // nút trái
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnXoaHet.Click += btnXoaHet_Click;
            btnHoanTat.Click += btnHoanTat_Click;

            // ba nút bên phải
            btnKiemTraThuoc.Click += (s, e) =>
            {
                using (var f = new FrmKiemTraThuoc()) f.ShowDialog(this);
            };
            btnLichSuGD.Click += (s, e) =>
            {
                using (var f = new FrmLichSuGiaoDich()) f.ShowDialog(this);
            };
            btnXemBienLai.Click += (s, e) =>
            {
                // mở form in BL trống (bạn có thể đổi thành nhập mã)
                using (var f = new FrmXemBienLai("XemBL"))
                    f.ShowDialog(this);
            };

            dgvCart.DataBindingComplete += (s, e) =>
            {
                for (int i = 0; i < dgvCart.Rows.Count; i++)
                    dgvCart.Rows[i].Cells["colSTT"].Value = (i + 1).ToString();
            };
        }

        private void FrmThuNgan_Load(object sender, EventArgs e) => ShowChoose();

        // ===== Chọn thuốc vào giỏ =====
        private void OnItemChosen(CartItem item)
        {
            var exist = _cart.FirstOrDefault(x => x.ThuocId == item.ThuocId);
            if (exist != null)
            {
                exist.AddQuantity(item.SoLuong);
                bsCart.ResetBindings(false);
                return;
            }
            _cart.Add(item);
        }

        private void btnThem_Click(object sender, EventArgs e)
            => MessageBox.Show("Bấm vào ô thuốc bên phải để thêm vào giỏ.", "Gợi ý");

        private void btnSua_Click(object sender, EventArgs e)
        {
            var row = bsCart.Current as CartItem;
            if (row == null) { MessageBox.Show("Chọn dòng để sửa."); return; }

            int qty = AskQuantity(row.SoLuong);
            if (qty <= 0) return;
            row.SetQuantity(qty);
            bsCart.ResetBindings(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var row = bsCart.Current as CartItem;
            if (row != null) _cart.Remove(row);
        }

        private void btnXoaHet_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0) return;
            if (MessageBox.Show("Xóa hết giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                _cart.Clear();
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0) { MessageBox.Show("Chưa có mặt hàng."); return; }
            ShowPay();
            ucPay.BindCart(_cart.ToList());
        }

        private void ShowChoose()
        {
            ucChon.Visible = true;
            ucPay.Visible = false;
            lbMode.Text = "Chọn thuốc";
            Text = "QLLT - Quản lý lễ tân & khám bệnh - [Thu ngân — Chọn thuốc]";
        }

        private void ShowPay()
        {
            ucChon.Visible = false;
            ucPay.Visible = true;
            lbMode.Text = "Thanh toán";
            Text = "QLLT - Quản lý lễ tân & khám bệnh - [Thu ngân — Thanh toán]";
        }

        // ===== nhận kết quả thanh toán =====
        private void OnPaymentConfirmed(PayRequest req)
        {
            // tạo số hóa đơn đơn giản (nếu bạn đã lưu DB thì thay bằng số DB)
            string invoiceId = (DateTime.Now.Ticks % 1_000_000).ToString();
            DataTable lines = BuildLinesTable();

            string methodText = MethodToText(req.PhuongThuc);
            string patientName = "...";

            using (var f = new QLLT.Controls.FrmXemBienLai(
                invoiceId, methodText, req.TongTien, req.TienKhachDua, patientName, lines))
            {
                f.ShowDialog(this);
            }

            try
            {
                ReceiptPrinter.ShowPreview(
                    lines, "PHÒNG KHÁM ABC", invoiceId, DateTime.Now,
                    patientName, methodText, req.TongTien, req.TienKhachDua);
            }
            catch { }

            // đẩy vào lịch sử (Form Lịch sử sẽ tự đọc store này)
            FrmLichSuGiaoDich.AddHistory(invoiceId, DateTime.Now, req.TongTien);

            _cart.Clear();
            bsCart.ResetBindings(false);
            ShowChoose();
        }

        private static string MethodToText(PaymentMethod m)
        {
            switch (m)
            {
                case PaymentMethod.TienMat: return "Tiền mặt";
                case PaymentMethod.Card: return "Card";
                case PaymentMethod.NganHang: return "Ngân hàng";
                case PaymentMethod.BHYT: return "BHYT";
            }
            return m.ToString();
        }

        private DataTable BuildLinesTable()
        {
            var tb = new DataTable();
            tb.Columns.Add("STT", typeof(int));
            tb.Columns.Add("TenThuoc", typeof(string));
            tb.Columns.Add("DVT", typeof(string));
            tb.Columns.Add("SoLuong", typeof(int));
            tb.Columns.Add("DonGia", typeof(decimal));
            tb.Columns.Add("ThanhTien", typeof(decimal));

            for (int i = 0; i < _cart.Count; i++)
            {
                var c = _cart[i];
                tb.Rows.Add(i + 1, c.TenThuoc, c.DonViTinh, c.SoLuong, c.DonGia, c.ThanhTien);
            }
            return tb;
        }

        // hỏi số lượng
        private int AskQuantity(int current)
        {
            using (Form f = new DialogNhapSoLuong())
            {
                try
                {
                    var p = f.GetType().GetProperty("Quantity") ?? f.GetType().GetProperty("SoLuong");
                    if (p != null && p.CanWrite) p.SetValue(f, current, null);
                }
                catch { }

                if (f.ShowDialog(this) != DialogResult.OK) return current;

                try
                {
                    var p = f.GetType().GetProperty("Quantity") ?? f.GetType().GetProperty("SoLuong");
                    if (p != null)
                    {
                        object v = p.GetValue(f, null);
                        if (v is int) return (int)v;
                        if (int.TryParse(Convert.ToString(v), out int iv)) return iv;
                    }
                }
                catch { }

                var nud = FindNud(f.Controls);
                if (nud != null) return (int)nud.Value;
            }
            return current;
        }

        private static NumericUpDown FindNud(Control.ControlCollection col)
        {
            foreach (Control c in col)
            {
                if (c is NumericUpDown n) return n;
                if (c.HasChildren)
                {
                    var k = FindNud(c.Controls);
                    if (k != null) return k;
                }
            }
            return null;
        }
    }
}
