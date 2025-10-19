using System.Windows.Forms;

namespace QLLT.Controls
{
    partial class UcThanhToan
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox grpBill;
        private Label lblTotal;
        private TextBox txtTotal;
        private Label lblGiven;
        private TextBox txtGiven;
        private Label lblChange;
        private TextBox txtChange;
        private Button btnDone;
        private Button btnCancel;

        private GroupBox grpMethod;
        private Button btnCash;
        private Button btnCard;
        private Button btnBank;
        private Button btnBHYT;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpBill = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.txtChange = new System.Windows.Forms.TextBox();
            this.lblChange = new System.Windows.Forms.Label();
            this.txtGiven = new System.Windows.Forms.TextBox();
            this.lblGiven = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.grpMethod = new System.Windows.Forms.GroupBox();
            this.btnBHYT = new System.Windows.Forms.Button();
            this.btnBank = new System.Windows.Forms.Button();
            this.btnCard = new System.Windows.Forms.Button();
            this.btnCash = new System.Windows.Forms.Button();
            this.grpBill.SuspendLayout();
            this.grpMethod.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBill
            // 
            this.grpBill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                   | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBill.Controls.Add(this.btnCancel);
            this.grpBill.Controls.Add(this.btnDone);
            this.grpBill.Controls.Add(this.txtChange);
            this.grpBill.Controls.Add(this.lblChange);
            this.grpBill.Controls.Add(this.txtGiven);
            this.grpBill.Controls.Add(this.lblGiven);
            this.grpBill.Controls.Add(this.txtTotal);
            this.grpBill.Controls.Add(this.lblTotal);
            this.grpBill.Location = new System.Drawing.Point(12, 12);
            this.grpBill.Name = "grpBill";
            this.grpBill.Size = new System.Drawing.Size(680, 120);
            this.grpBill.TabIndex = 0;
            this.grpBill.TabStop = false;
            this.grpBill.Text = "Thành tiền";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.Location = new System.Drawing.Point(584, 70);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 28);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnDone
            // 
            this.btnDone.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDone.Location = new System.Drawing.Point(584, 28);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(72, 28);
            this.btnDone.TabIndex = 6;
            this.btnDone.Text = "Hoàn tất";
            this.btnDone.UseVisualStyleBackColor = true;
            // 
            // txtChange
            // 
            this.txtChange.Location = new System.Drawing.Point(92, 82);
            this.txtChange.Name = "txtChange";
            this.txtChange.ReadOnly = true;
            this.txtChange.Size = new System.Drawing.Size(140, 20);
            this.txtChange.TabIndex = 5;
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Location = new System.Drawing.Point(18, 85);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(54, 13);
            this.lblChange.TabIndex = 4;
            this.lblChange.Text = "Tiền thối:";
            // 
            // txtGiven
            // 
            this.txtGiven.Location = new System.Drawing.Point(92, 52);
            this.txtGiven.Name = "txtGiven";
            this.txtGiven.ReadOnly = true;
            this.txtGiven.Size = new System.Drawing.Size(140, 20);
            this.txtGiven.TabIndex = 3;
            // 
            // lblGiven
            // 
            this.lblGiven.AutoSize = true;
            this.lblGiven.Location = new System.Drawing.Point(18, 55);
            this.lblGiven.Name = "lblGiven";
            this.lblGiven.Size = new System.Drawing.Size(60, 13);
            this.lblGiven.TabIndex = 2;
            this.lblGiven.Text = "Khách đưa:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(92, 24);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(140, 20);
            this.txtTotal.TabIndex = 1;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(18, 27);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(53, 13);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Tổng tiền:";
            // 
            // grpMethod
            // 
            this.grpMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                   | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMethod.Controls.Add(this.btnBHYT);
            this.grpMethod.Controls.Add(this.btnBank);
            this.grpMethod.Controls.Add(this.btnCard);
            this.grpMethod.Controls.Add(this.btnCash);
            this.grpMethod.Location = new System.Drawing.Point(12, 138);
            this.grpMethod.Name = "grpMethod";
            this.grpMethod.Size = new System.Drawing.Size(680, 66);
            this.grpMethod.TabIndex = 1;
            this.grpMethod.TabStop = false;
            this.grpMethod.Text = "Phương thức thanh toán";
            // 
            // btnBHYT
            // 
            this.btnBHYT.Location = new System.Drawing.Point(400, 24);
            this.btnBHYT.Name = "btnBHYT";
            this.btnBHYT.Size = new System.Drawing.Size(90, 28);
            this.btnBHYT.TabIndex = 3;
            this.btnBHYT.Text = "BHYT";
            this.btnBHYT.UseVisualStyleBackColor = true;
            // 
            // btnBank
            // 
            this.btnBank.Location = new System.Drawing.Point(273, 24);
            this.btnBank.Name = "btnBank";
            this.btnBank.Size = new System.Drawing.Size(90, 28);
            this.btnBank.TabIndex = 2;
            this.btnBank.Text = "Ngân hàng";
            this.btnBank.UseVisualStyleBackColor = true;
            // 
            // btnCard
            // 
            this.btnCard.Location = new System.Drawing.Point(150, 24);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(90, 28);
            this.btnCard.TabIndex = 1;
            this.btnCard.Text = "Card";
            this.btnCard.UseVisualStyleBackColor = true;
            // 
            // btnCash
            // 
            this.btnCash.Location = new System.Drawing.Point(24, 24);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(90, 28);
            this.btnCash.TabIndex = 0;
            this.btnCash.Text = "Tiền mặt";
            this.btnCash.UseVisualStyleBackColor = true;
            // 
            // UcThanhToan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.grpMethod);
            this.Controls.Add(this.grpBill);
            this.Name = "UcThanhToan";
            this.Size = new System.Drawing.Size(704, 220);
            this.grpBill.ResumeLayout(false);
            this.grpBill.PerformLayout();
            this.grpMethod.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
