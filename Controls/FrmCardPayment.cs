using System;
using System.Windows.Forms;

namespace QLLT.Controls
{
    public partial class FrmCardPayment : Form
    {
        /// <summary>Số tiền cần thanh toán (đọc-only, để hiển thị).</summary>
        public decimal Amount { get; private set; }

        /// <summary>Số thẻ mà người dùng “quẹt/tap” (giả lập).</summary>
        public string CardNumber { get; private set; }

        /// <summary>
        /// Khởi tạo form quẹt thẻ, truyền vào tổng tiền để hiển thị.
        /// </summary>
        public FrmCardPayment(decimal amount)
        {
            InitializeComponent();

            Amount = amount < 0 ? 0 : amount;
            lblAmount.Text = Amount.ToString("N0") + " đ";

            // wire events
            btnSimTap.Click += btnSimTap_Click;
            btnOk.Click += btnOk_Click;
            btnCancel.Click += delegate { DialogResult = DialogResult.Cancel; Close(); };

            // enter -> OK
            AcceptButton = btnOk;
            CancelButton = btnCancel;
        }

        private void btnSimTap_Click(object sender, EventArgs e)
        {
            // sinh 1 “PAN” giả lập 16 số
            var rnd = new Random();
            txtCard.Text = "4" + rnd.Next(1000, 9999)
                               + rnd.Next(1000, 9999)
                               + rnd.Next(1000, 9999)
                               + rnd.Next(1000, 9999);
            txtShown.Text = txtCard.Text;
            txtCard.Select(txtCard.TextLength, 0);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // bắt buộc có “thẻ”
            var pan = (txtCard.Text ?? "").Trim();
            if (pan.Length < 6)
            {
                MessageBox.Show("Vui lòng quẹt/chạm thẻ (giả lập) hoặc nhập số thẻ.",
                                "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCard.Focus();
                return;
            }

            CardNumber = pan;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
