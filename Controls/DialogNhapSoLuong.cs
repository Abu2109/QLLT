using System;
using System.Windows.Forms;

namespace QLLT.Controls
{
    /// <summary>
    /// Hộp thoại nhập số lượng (NumericUpDown).
    /// </summary>
    public partial class DialogNhapSoLuong : Form
    {
        /// <summary>Số lượng người dùng chọn.</summary>
        public int SoLuong { get; private set; } = 1;

        public DialogNhapSoLuong()
        {
            InitializeComponent();

            // Phím tắt
            KeyPreview = true;
            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) DialogResult = DialogResult.Cancel;
                if (e.Control && e.KeyCode == Keys.Enter) btnOK.PerformClick();
            };
        }

        /// <summary>
        /// Thiết lập mặc định hiển thị (tiêu đề, nhãn, min/max/step, giá trị hiện tại).
        /// Gọi trước khi ShowDialog nếu cần.
        /// </summary>
        public void Configure(string title = null, string caption = null,
                              int? min = null, int? max = null,
                              int? step = null, int? current = null)
        {
            if (!string.IsNullOrWhiteSpace(title)) this.Text = title;
            if (!string.IsNullOrWhiteSpace(caption)) lblCaption.Text = caption;

            if (min.HasValue) nudQty.Minimum = min.Value;
            if (max.HasValue) nudQty.Maximum = max.Value;
            if (step.HasValue && step.Value > 0) nudQty.Increment = step.Value;

            if (current.HasValue)
            {
                var val = current.Value;
                if (val < nudQty.Minimum) val = (int)nudQty.Minimum;
                if (val > nudQty.Maximum) val = (int)nudQty.Maximum;
                nudQty.Value = val;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SoLuong = (int)nudQty.Value;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Helper mở nhanh dialog và trả về số lượng (true nếu người dùng bấm Đồng ý).
        /// </summary>
        public static bool Show(IWin32Window owner, out int soLuong,
                                string title = "Nhập số lượng",
                                string caption = "Số lượng:",
                                int min = 1, int max = 1000,
                                int step = 1, int current = 1)
        {
            soLuong = current;
            using (var dlg = new DialogNhapSoLuong())
            {
                dlg.Configure(title, caption, min, max, step, current);
                if (dlg.ShowDialog(owner) == DialogResult.OK)
                {
                    soLuong = dlg.SoLuong;
                    return true;
                }
                return false;
            }
        }
    }
}
