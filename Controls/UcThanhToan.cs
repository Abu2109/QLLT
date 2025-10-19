using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using QLLT.DTOs;

namespace QLLT.Controls
{
    public partial class UcThanhToan : UserControl
    {
        public event Action<PayRequest> PaymentConfirmed;
        public event Action PaymentCanceled; // <-- NEW: báo cho cha để quay lại chọn thuốc

        private decimal _subTotal = 0m;     // tổng trước giảm
        private decimal _bhytDiscount = 0m; // số tiền BHYT giảm
        private decimal _given = 0m;        // tiền khách đưa (hoặc đã quẹt/chuyển)
        private PaymentMethod _method = PaymentMethod.TienMat;

        public UcThanhToan()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            // nút phương thức
            btnCash.Click += delegate { OnCash(); };
            btnCard.Click += delegate { OnCard(); };
            btnBank.Click += delegate { OnBank(); };
            btnBHYT.Click += delegate { OnBHYT(); };

            // nút hành động
            btnDone.Click += delegate { DoConfirm(); };
            btnCancel.Click += delegate { OnCancel(); }; // <-- đổi hành vi: chỉ báo hủy, KHÔNG clear

            UpdateBoxes();
        }

        /// <summary>Gắn giỏ hàng để tính tổng.</summary>
        public void BindCart(System.Collections.Generic.IList<CartItem> items)
        {
            _subTotal = (items != null) ? items.Sum(i => i.ThanhTien) : 0m;
            _bhytDiscount = 0m;
            // _given không reset ở đây để nếu quay về từ Hủy rồi vào lại
            // vẫn cho phép set lại; nhưng để trải nghiệm ổn định ta set về 0
            _given = 0m;
            _method = PaymentMethod.TienMat;
            UpdateBoxes();
        }

        // ================== Chọn phương thức ==================
        private void OnCash()
        {
            _method = PaymentMethod.TienMat;
            _given = 0m;

            try
            {
                using (Form f = new DialogTienMat())
                {
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        decimal amount = ReadDecimalFromForm(f, "Amount", "SoTien");
                        if (amount < 0) amount = 0;
                        _given = amount;
                    }
                }
            }
            catch { /* không có form -> giữ _given = 0 */ }

            Recalc();
        }

        private void OnCard()
        {
            _method = PaymentMethod.Card;

            try
            {
                using (var f = new FrmCardPayment(GrandTotal()))
                {
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        // coi như quẹt đủ số tiền phải trả
                        _given = GrandTotal();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch { /* không có form -> bỏ qua */ }

            Recalc();
        }

        private void OnBank()
        {
            _method = PaymentMethod.NganHang;

            try
            {
                using (Form f = new FrmQRNganHang())
                    f.ShowDialog(this);
            }
            catch { /* không có form -> bỏ qua */ }

            // coi như chuyển khoản đủ
            _given = Math.Max(0m, _subTotal - _bhytDiscount);
            Recalc();
        }

        private void OnBHYT()
        {
            _method = PaymentMethod.BHYT;

            try
            {
                using (Form f = new DialogNhapBHYT())
                {
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        decimal percent = ReadDecimalFromForm(f, "Percent", "TyLe", "TiLe");
                        if (percent < 0) percent = 0;
                        if (percent > 100) percent = 100;

                        _bhytDiscount = Math.Round(_subTotal * (percent / 100m), 0,
                            MidpointRounding.AwayFromZero);
                    }
                }
            }
            catch
            {
                _bhytDiscount = 0m;
            }

            _given = 0m;
            Recalc();
        }

        // ================== Confirm / Cancel ==================
        private void DoConfirm()
        {
            decimal grand = GrandTotal();
            decimal given = _given;

            if (_method == PaymentMethod.TienMat ||
                _method == PaymentMethod.Card ||
                _method == PaymentMethod.NganHang)
            {
                if (given < grand)
                {
                    MessageBox.Show(
                        "Khách chưa thanh toán đủ.\n" +
                        $"Cần: {grand:N0}  |  Đã thanh toán: {given:N0}",
                        "Thiếu tiền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var req = new PayRequest
            {
                TongTien = grand,
                PhuongThuc = _method,
                TienKhachDua = given
            };

            string err;
            if (!req.IsValid(out err))
            {
                MessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var handler = PaymentConfirmed;
            if (handler != null) handler(req);
        }

        // NEW: nút Hủy – chỉ báo về form cha, KHÔNG đụng giỏ
        private void OnCancel()
        {
            var handler = PaymentCanceled;
            if (handler != null) handler();
        }

        // ================== Tính toán/hiển thị ==================
        private void Recalc() => UpdateBoxes();

        private void UpdateBoxes()
        {
            decimal grand = GrandTotal();
            decimal change = 0m;

            if (_method == PaymentMethod.TienMat && _given > grand)
                change = _given - grand;

            txtTotal.Text = grand.ToString("N0");
            txtGiven.Text = _given.ToString("N0");
            txtChange.Text = change.ToString("N0");
        }

        private decimal GrandTotal()
        {
            var g = _subTotal - _bhytDiscount;
            if (g < 0) g = 0;
            return g;
        }

        // đọc property decimal/number từ dialog (nhiều tên dự phòng)
        private decimal ReadDecimalFromForm(object form, params string[] propCandidates)
        {
            try
            {
                foreach (var pn in propCandidates)
                {
                    var p = form.GetType().GetProperty(pn);
                    if (p != null)
                    {
                        object v = p.GetValue(form, null);
                        decimal dv;
                        if (v is decimal) return (decimal)v;
                        if (v is int) return Convert.ToDecimal((int)v);
                        if (decimal.TryParse(Convert.ToString(v), out dv)) return dv;
                    }
                }

                // Fallback: NumericUpDown đầu tiên
                Form f = form as Form;
                if (f != null)
                {
                    var nud = FindNud(f.Controls);
                    if (nud != null) return nud.Value;
                }
            }
            catch { }
            return 0m;
        }

        private NumericUpDown FindNud(Control.ControlCollection col)
        {
            foreach (Control c in col)
            {
                var n = c as NumericUpDown;
                if (n != null) return n;
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
