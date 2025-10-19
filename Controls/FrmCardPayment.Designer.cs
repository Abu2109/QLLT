using System.Windows.Forms;

namespace QLLT.Controls
{
    partial class FrmCardPayment
    {
        private System.ComponentModel.IContainer components = null;

        private Label labelTitle;
        private Label labelAmount;
        private Label lblAmount;
        private TextBox txtCard;
        private Label labelCard;
        private TextBox txtShown;
        private Label labelShown;
        private Button btnSimTap;
        private Button btnOk;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.labelCard = new System.Windows.Forms.Label();
            this.txtCard = new System.Windows.Forms.TextBox();
            this.labelShown = new System.Windows.Forms.Label();
            this.txtShown = new System.Windows.Forms.TextBox();
            this.btnSimTap = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(20, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(214, 19);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Thanh toán bằng thẻ (giả lập)";
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(22, 48);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(55, 13);
            this.labelAmount.TabIndex = 1;
            this.labelAmount.Text = "Số tiền (đ):";
            // 
            // lblAmount
            // 
            this.lblAmount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAmount.Location = new System.Drawing.Point(100, 43);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(180, 23);
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Text = "0 đ";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCard
            // 
            this.labelCard.AutoSize = true;
            this.labelCard.Location = new System.Drawing.Point(22, 86);
            this.labelCard.Name = "labelCard";
            this.labelCard.Size = new System.Drawing.Size(73, 13);
            this.labelCard.TabIndex = 3;
            this.labelCard.Text = "Số thẻ (giả lập):";
            // 
            // txtCard
            // 
            this.txtCard.Location = new System.Drawing.Point(100, 82);
            this.txtCard.Name = "txtCard";
            this.txtCard.Size = new System.Drawing.Size(262, 20);
            this.txtCard.TabIndex = 0;
            // 
            // labelShown
            // 
            this.labelShown.AutoSize = true;
            this.labelShown.Location = new System.Drawing.Point(22, 114);
            this.labelShown.Name = "labelShown";
            this.labelShown.Size = new System.Drawing.Size(148, 13);
            this.labelShown.TabIndex = 5;
            this.labelShown.Text = "Số thẻ sẽ hiển thị (sau khi tap):";
            // 
            // txtShown
            // 
            this.txtShown.Location = new System.Drawing.Point(176, 110);
            this.txtShown.Name = "txtShown";
            this.txtShown.ReadOnly = true;
            this.txtShown.Size = new System.Drawing.Size(186, 20);
            this.txtShown.TabIndex = 6;
            // 
            // btnSimTap
            // 
            this.btnSimTap.Location = new System.Drawing.Point(100, 142);
            this.btnSimTap.Name = "btnSimTap";
            this.btnSimTap.Size = new System.Drawing.Size(130, 27);
            this.btnSimTap.TabIndex = 1;
            this.btnSimTap.Text = "Giả lập quẹt thẻ / tap";
            this.btnSimTap.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(236, 142);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(60, 27);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Xác nhận";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(302, 142);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 27);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmCardPayment
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(384, 191);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnSimTap);
            this.Controls.Add(this.txtShown);
            this.Controls.Add(this.labelShown);
            this.Controls.Add(this.txtCard);
            this.Controls.Add(this.labelCard);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCardPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh toán thẻ (giả lập)";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
