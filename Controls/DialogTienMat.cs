using System;
using System.Globalization;
using System.Windows.Forms;

namespace QLLT.Controls
{
    public partial class DialogTienMat : Form
    {
        public decimal SoTien { get; private set; } = 0m;

        private string _raw = "";
        private const int MAX_LEN = 12;

        public DialogTienMat()
        {
            InitializeComponent();
            KeyPreview = true;

            // phím tắt
            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) DialogResult = DialogResult.Cancel;
                else if (e.Control && e.KeyCode == Keys.Enter) btnNhap.PerformClick();
                else if (e.KeyCode == Keys.Back) Backspace();
                else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) Append(((int)e.KeyCode - (int)Keys.D0).ToString());
                else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) Append(((int)e.KeyCode - (int)Keys.NumPad0).ToString());
            };

            UpdateDisplay();
        }

        public void Configure(string title = null, string caption = null, decimal? preset = null)
        {
            if (!string.IsNullOrWhiteSpace(title)) Text = title;
            if (!string.IsNullOrWhiteSpace(caption)) lblCaption.Text = caption;
            if (preset.HasValue)
            {
                _raw = ((long)Math.Max(0, Math.Round(preset.Value, 0))).ToString();
                if (_raw == "0") _raw = "";
                UpdateDisplay();
            }
        }

        private void Append(string digit)
        {
            if (_raw.Length >= MAX_LEN) return;
            if (digit == "0" && _raw == "") return; // không cho 0 ở đầu
            _raw += digit;
            UpdateDisplay();
        }

        private void Backspace()
        {
            if (_raw.Length > 0)
            {
                _raw = _raw.Substring(0, _raw.Length - 1);
                UpdateDisplay();
            }
        }

        private void ClearAll()
        {
            _raw = "";
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (string.IsNullOrEmpty(_raw))
            {
                txtTien.Text = "0";
                SoTien = 0m;
            }
            else
            {
                if (long.TryParse(_raw, out long v))
                {
                    SoTien = v;
                    txtTien.Text = v.ToString("#,0", CultureInfo.GetCultureInfo("vi-VN"));
                }
                else
                {
                    SoTien = 0m;
                    txtTien.Text = "0";
                }
            }
        }

        // ====== event handlers wired từ Designer ======
        private void btnNum_Click(object sender, EventArgs e)
        {
            if (sender is Button b && b.Tag is string t) Append(t);
        }

        private void btnBack_Click(object sender, EventArgs e) => Backspace();
        private void btnClear_Click(object sender, EventArgs e) => ClearAll();
        private void btnNhap_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        // helper mở nhanh
        public static bool Show(IWin32Window owner, out decimal amount,
            string title = "Nhập tiền", string caption = "Số tiền:", decimal preset = 0m)
        {
            amount = 0m;
            using (var dlg = new DialogTienMat())
            {
                dlg.Configure(title, caption, preset);
                if (dlg.ShowDialog(owner) == DialogResult.OK)
                {
                    amount = dlg.SoTien;
                    return true;
                }
                return false;
            }
        }
    }
}
