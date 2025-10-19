using System.Windows.Forms;

namespace QLLT.Controls
{
    partial class FrmQRNganHang
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox picQR;
        private Button btnNew;
        private Button btnConfirm;
        private Button btnCancel;
        private Label lblTitle;
        private TextBox txtAmount;
        private Label lblBank;
        private Label lblAccName;
        private Label lblHint;
        private Panel panel1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picQR = new System.Windows.Forms.PictureBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.lblAccName = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1 (header)
            // 
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Height = 64;
            this.panel1.Padding = new Padding(12, 8, 12, 8);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.txtAmount);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Text = "Thanh toán QR Ngân hàng";
            this.lblTitle.Left = 12;
            this.lblTitle.Top = 12;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            // 
            // txtAmount
            // 
            this.txtAmount.ReadOnly = true;
            this.txtAmount.TextAlign = HorizontalAlignment.Right;
            this.txtAmount.Width = 220;
            this.txtAmount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.txtAmount.Top = 18;
            this.txtAmount.Left = 420;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            // 
            // picQR
            // 
            this.picQR.Location = new System.Drawing.Point(18, 90);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(240, 240);
            this.picQR.SizeMode = PictureBoxSizeMode.CenterImage;
            this.picQR.BorderStyle = BorderStyle.FixedSingle;
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Location = new System.Drawing.Point(280, 100);
            this.lblBank.Text = "ACB • 1234567890";
            // 
            // lblAccName
            // 
            this.lblAccName.AutoSize = true;
            this.lblAccName.Location = new System.Drawing.Point(280, 122);
            this.lblAccName.Text = "BENH VIEN ABC";
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Location = new System.Drawing.Point(280, 150);
            this.lblHint.Width = 300;
            this.lblHint.Text = "Mở app ngân hàng → Quét mã QR để thanh toán.";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(283, 188);
            this.btnNew.Size = new System.Drawing.Size(120, 32);
            this.btnNew.Text = "Tạo mã mới";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(283, 232);
            this.btnConfirm.Size = new System.Drawing.Size(120, 32);
            this.btnConfirm.Text = "Xác nhận đã quét";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(283, 276);
            this.btnCancel.Size = new System.Drawing.Size(120, 32);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmQRNganHang
            // 
            this.ClientSize = new System.Drawing.Size(660, 352);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picQR);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.lblAccName);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "QR Ngân hàng";
            this.Load += new System.EventHandler(this.FrmQRNganHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
