using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace QLLT.Controls
{
    public partial class FrmQRNganHang : Form
    {
        public decimal Amount { get; set; } = 0m;        // số tiền cần thanh toán
        public string BankName { get; set; } = "ACB";    // chỉ để hiển thị
        public string AccountName { get; set; } = "BENH VIEN ABC";
        public string AccountNo { get; set; } = "1234567890";
        public string PaymentRef { get; private set; }   // mã tham chiếu giao dịch (giả lập)

        public FrmQRNganHang()
        {
            InitializeComponent();
        }

        private void FrmQRNganHang_Load(object sender, EventArgs e)
        {
            txtAmount.Text = Amount.ToString("N0") + " đ";
            lblBank.Text = $"{BankName} • {AccountNo}";
            lblAccName.Text = AccountName;
            GenerateQr(); // tạo ảnh QR giả lập
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            GenerateQr();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // giả lập đã quét QR thành công
            PaymentRef = "QR" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void GenerateQr()
        {
            // Tạo ảnh bitmap đơn giản có “mã giả” + số tiền (minh họa)
            int w = 240, h = 240;
            Bitmap bmp = new Bitmap(w, h, PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                // kẻ ô mô phỏng QR
                using (Brush b = new SolidBrush(Color.Black))
                {
                    Random rnd = new Random(Guid.NewGuid().GetHashCode());
                    for (int y = 0; y < h; y += 12)
                        for (int x = 0; x < w; x += 12)
                            if (rnd.NextDouble() > 0.6) g.FillRectangle(b, x, y, 10, 10);
                }

                // khung viền
                using (Pen p = new Pen(Color.Black, 4))
                    g.DrawRectangle(p, 2, 2, w - 4, h - 4);

                // “payload” giả lập
                string payload = $"PAY:{AccountNo}|AMT:{Amount:0}|TS:{DateTime.Now:HHmmss}";
                using (Font f = new Font("Consolas", 8, FontStyle.Bold))
                using (Brush b = new SolidBrush(Color.DarkBlue))
                {
                    var size = g.MeasureString(payload, f);
                    g.FillRectangle(Brushes.White, 4, h - size.Height - 6, size.Width + 4, size.Height + 2);
                    g.DrawString(payload, f, b, 6, h - size.Height - 4);
                }
            }

            picQR.Image = bmp;
            lblHint.Text = "Mở app ngân hàng → Quét mã QR để thanh toán.";
        }
    }
}
