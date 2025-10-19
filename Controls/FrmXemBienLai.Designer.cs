using System.Windows.Forms;
using System.Drawing;

namespace QLLT.Controls
{
    partial class FrmXemBienLai
    {
        private System.ComponentModel.IContainer components = null;

        private Label lbTitle;
        private Label label1;
        private Label lbDate;
        private Label label2;
        private Label lbPatient;
        private Label label3;
        private Label lbMethod;
        private Label label4;
        private Label lbGiven;

        private DataGridView dgvLines;
        private Label lbFooterTotal;
        private Label lbTotal;
        private Button btnIn;
        private Button btnDong;

        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewTextBoxColumn colTen;
        private DataGridViewTextBoxColumn colDvt;
        private DataGridViewTextBoxColumn colSl;
        private DataGridViewTextBoxColumn colGia;
        private DataGridViewTextBoxColumn colTt;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lbTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbPatient = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbMethod = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbGiven = new System.Windows.Forms.Label();
            this.dgvLines = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDvt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbFooterTotal = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lbTitle.Location = new System.Drawing.Point(22, 12);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(109, 25);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Biên lai #...";
            // 
            // label1 (Ngày)
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 48);
            this.label1.Text = "Ngày:";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Location = new System.Drawing.Point(70, 48);
            this.lbDate.Text = "...";
            // 
            // label2 (Bệnh nhân)
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 68);
            this.label2.Text = "Bệnh nhân:";
            // 
            // lbPatient
            // 
            this.lbPatient.AutoSize = true;
            this.lbPatient.Location = new System.Drawing.Point(90, 68);
            this.lbPatient.Text = "...";
            // 
            // label3 (PT thanh toán)
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 48);
            this.label3.Text = "PT thanh toán:";
            // 
            // lbMethod
            // 
            this.lbMethod.AutoSize = true;
            this.lbMethod.Location = new System.Drawing.Point(445, 48);
            this.lbMethod.Text = "...";
            // 
            // label4 (Khách đưa)
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 68);
            this.label4.Text = "Khách đưa:";
            // 
            // lbGiven
            // 
            this.lbGiven.AutoSize = true;
            this.lbGiven.Location = new System.Drawing.Point(445, 68);
            this.lbGiven.Text = "...";
            // 
            // dgvLines
            // 
            this.dgvLines.AllowUserToAddRows = false;
            this.dgvLines.AllowUserToDeleteRows = false;
            this.dgvLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLines.AutoGenerateColumns = false;
            this.dgvLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colSTT, this.colTen, this.colDvt, this.colSl, this.colGia, this.colTt});
            this.dgvLines.Location = new System.Drawing.Point(27, 98);
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.ReadOnly = true;
            this.dgvLines.RowHeadersVisible = false;
            this.dgvLines.Size = new System.Drawing.Size(880, 360);
            this.dgvLines.TabIndex = 10;
            // 
            // Columns
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.FillWeight = 40;

            this.colTen.DataPropertyName = "TenThuoc";
            this.colTen.HeaderText = "TenThuoc";

            this.colDvt.DataPropertyName = "DVT";
            this.colDvt.HeaderText = "DVT";
            this.colDvt.FillWeight = 60;

            this.colSl.DataPropertyName = "SoLuong";
            this.colSl.HeaderText = "SoLuong";
            this.colSl.FillWeight = 70;

            this.colGia.DataPropertyName = "DonGia";
            this.colGia.HeaderText = "DonGia";
            this.colGia.DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" };

            this.colTt.DataPropertyName = "ThanhTien";
            this.colTt.HeaderText = "ThanhTien";
            this.colTt.DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" };
            // 
            // lbFooterTotal + lbTotal
            // 
            this.lbFooterTotal = new System.Windows.Forms.Label();
            this.lbFooterTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFooterTotal.AutoSize = true;
            this.lbFooterTotal.Location = new System.Drawing.Point(24, 470);
            this.lbFooterTotal.Text = "Tổng tiền:";
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(78, 470);
            this.lbTotal.Text = "0đ";
            // 
            // btnIn
            // 
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIn.Location = new System.Drawing.Point(740, 464);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 26);
            this.btnIn.TabIndex = 20;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(832, 464);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 26);
            this.btnDong.TabIndex = 21;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmXemBienLai
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(934, 504);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.lbFooterTotal);
            this.Controls.Add(this.dgvLines);
            this.Controls.Add(this.lbGiven);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbMethod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbPatient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTitle);
            this.Name = "FrmXemBienLai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xem biên lai";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
