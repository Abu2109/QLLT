using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QLLT.Controls
{
    public partial class DialogNhapBHYT : Form
    {
        public string MaBHYT { get; private set; } = "";
        public int Percent { get; private set; } = 80; // mặc định 80%

        public DialogNhapBHYT()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            // Sinh mã BHYT giả lập: 15 chữ số
            var rnd = new Random();
            MaBHYT = "";
            for (int i = 0; i < 15; i++) MaBHYT += rnd.Next(0, 10).ToString();

            txtMa.Text = MaBHYT;
            nudPercent.Value = Percent;

            btnOK.Click += delegate
            {
                Percent = (int)nudPercent.Value;
                MaBHYT = txtMa.Text.Trim();
                DialogResult = DialogResult.OK;
            };
            btnCancel.Click += delegate { DialogResult = DialogResult.Cancel; };
        }

        private void nudPercent_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
