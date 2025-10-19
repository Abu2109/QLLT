using System.Windows.Forms;

namespace QLLT.Controls
{
    partial class DialogNhapBHYT
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblMa;
        private TextBox txtMa;
        private Label lblPercent;
        private NumericUpDown nudPercent;
        private Button btnOK;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMa = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.lblPercent = new System.Windows.Forms.Label();
            this.nudPercent = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercent)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(16, 18);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(69, 16);
            this.lblMa.TabIndex = 5;
            this.lblMa.Text = "Mã BHYT:";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(90, 15);
            this.txtMa.Name = "txtMa";
            this.txtMa.ReadOnly = true;
            this.txtMa.Size = new System.Drawing.Size(200, 22);
            this.txtMa.TabIndex = 4;
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(16, 50);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(86, 16);
            this.lblPercent.TabIndex = 3;
            this.lblPercent.Text = "% thanh toán:";
            // 
            // nudPercent
            // 
            this.nudPercent.Location = new System.Drawing.Point(90, 48);
            this.nudPercent.Name = "nudPercent";
            this.nudPercent.Size = new System.Drawing.Size(80, 22);
            this.nudPercent.TabIndex = 2;
            this.nudPercent.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.nudPercent.ValueChanged += new System.EventHandler(this.nudPercent_ValueChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(134, 84);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 26);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(218, 84);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 26);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DialogNhapBHYT
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(308, 124);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nudPercent);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.lblMa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogNhapBHYT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BHYT";
            ((System.ComponentModel.ISupportInitialize)(this.nudPercent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
