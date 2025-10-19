using System.Windows.Forms;
using System.Drawing;

namespace QLLT.Forms
{
    partial class FrmDatLich
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblSearchBN = new System.Windows.Forms.Label();
            this.txtSearchBN = new System.Windows.Forms.TextBox();
            this.btnSearchBN = new System.Windows.Forms.Button();
            this.lblBenhNhan = new System.Windows.Forms.Label();
            this.cboBenhNhan = new System.Windows.Forms.ComboBox();
            this.lblBacSi = new System.Windows.Forms.Label();
            this.cboBacSi = new System.Windows.Forms.ComboBox();
            this.lblNgay = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.lblGio = new System.Windows.Forms.Label();
            this.dtpGio = new System.Windows.Forms.DateTimePicker();
            this.lblThoiLuong = new System.Windows.Forms.Label();
            this.numThoiLuong = new System.Windows.Forms.NumericUpDown();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.flowBtns = new System.Windows.Forms.FlowLayoutPanel();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnMoi = new System.Windows.Forms.Button();
            this.grpTrung = new System.Windows.Forms.GroupBox();
            this.dgvTrung = new System.Windows.Forms.DataGridView();
            this.colLH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThoiLuong)).BeginInit();
            this.flowBtns.SuspendLayout();
            this.grpTrung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrung)).BeginInit();
            this.SuspendLayout();
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lblSearchBN);
            this.grpInfo.Controls.Add(this.txtSearchBN);
            this.grpInfo.Controls.Add(this.btnSearchBN);
            this.grpInfo.Controls.Add(this.lblBenhNhan);
            this.grpInfo.Controls.Add(this.cboBenhNhan);
            this.grpInfo.Controls.Add(this.lblBacSi);
            this.grpInfo.Controls.Add(this.cboBacSi);
            this.grpInfo.Controls.Add(this.lblNgay);
            this.grpInfo.Controls.Add(this.dtpNgay);
            this.grpInfo.Controls.Add(this.lblGio);
            this.grpInfo.Controls.Add(this.dtpGio);
            this.grpInfo.Controls.Add(this.lblThoiLuong);
            this.grpInfo.Controls.Add(this.numThoiLuong);
            this.grpInfo.Controls.Add(this.lblLyDo);
            this.grpInfo.Controls.Add(this.txtLyDo);
            this.grpInfo.Controls.Add(this.lblTrangThai);
            this.grpInfo.Controls.Add(this.cboTrangThai);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.grpInfo.Location = new System.Drawing.Point(0, 0);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Padding = new System.Windows.Forms.Padding(12);
            this.grpInfo.Size = new System.Drawing.Size(1073, 172);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Đặt lịch khám";
            // 
            // lblSearchBN
            // 
            this.lblSearchBN.AutoSize = true;
            this.lblSearchBN.Location = new System.Drawing.Point(43, 32);
            this.lblSearchBN.Name = "lblSearchBN";
            this.lblSearchBN.Size = new System.Drawing.Size(64, 21);
            this.lblSearchBN.TabIndex = 0;
            this.lblSearchBN.Text = "Tìm BN:";
            // 
            // txtSearchBN
            // 
            this.txtSearchBN.Location = new System.Drawing.Point(114, 29);
            this.txtSearchBN.Name = "txtSearchBN";
            this.txtSearchBN.Size = new System.Drawing.Size(340, 29);
            this.txtSearchBN.TabIndex = 1;
            // 
            // btnSearchBN
            // 
            this.btnSearchBN.Location = new System.Drawing.Point(456, 29);
            this.btnSearchBN.Name = "btnSearchBN";
            this.btnSearchBN.Size = new System.Drawing.Size(73, 29);
            this.btnSearchBN.TabIndex = 2;
            this.btnSearchBN.Text = "Tìm";
            this.btnSearchBN.UseVisualStyleBackColor = true;
            this.btnSearchBN.Click += new System.EventHandler(this.btnSearchBN_Click);
            // 
            // lblBenhNhan
            // 
            this.lblBenhNhan.AutoSize = true;
            this.lblBenhNhan.Location = new System.Drawing.Point(20, 63);
            this.lblBenhNhan.Name = "lblBenhNhan";
            this.lblBenhNhan.Size = new System.Drawing.Size(87, 21);
            this.lblBenhNhan.TabIndex = 3;
            this.lblBenhNhan.Text = "Bệnh nhân:";
            // 
            // cboBenhNhan
            // 
            this.cboBenhNhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBenhNhan.Location = new System.Drawing.Point(114, 61);
            this.cboBenhNhan.Name = "cboBenhNhan";
            this.cboBenhNhan.Size = new System.Drawing.Size(415, 29);
            this.cboBenhNhan.TabIndex = 4;
            // 
            // lblBacSi
            // 
            this.lblBacSi.AutoSize = true;
            this.lblBacSi.Location = new System.Drawing.Point(539, 32);
            this.lblBacSi.Name = "lblBacSi";
            this.lblBacSi.Size = new System.Drawing.Size(52, 21);
            this.lblBacSi.TabIndex = 5;
            this.lblBacSi.Text = "Bác sĩ:";
            // 
            // cboBacSi
            // 
            this.cboBacSi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBacSi.Location = new System.Drawing.Point(599, 29);
            this.cboBacSi.Name = "cboBacSi";
            this.cboBacSi.Size = new System.Drawing.Size(300, 29);
            this.cboBacSi.TabIndex = 6;
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new System.Drawing.Point(543, 64);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(50, 21);
            this.lblNgay.TabIndex = 7;
            this.lblNgay.Text = "Ngày:";
            // 
            // dtpNgay
            // 
            this.dtpNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(599, 61);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(120, 29);
            this.dtpNgay.TabIndex = 8;
            // 
            // lblGio
            // 
            this.lblGio.AutoSize = true;
            this.lblGio.Location = new System.Drawing.Point(734, 64);
            this.lblGio.Name = "lblGio";
            this.lblGio.Size = new System.Drawing.Size(38, 21);
            this.lblGio.TabIndex = 9;
            this.lblGio.Text = "Giờ:";
            // 
            // dtpGio
            // 
            this.dtpGio.CustomFormat = "HH:mm";
            this.dtpGio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGio.Location = new System.Drawing.Point(779, 61);
            this.dtpGio.Name = "dtpGio";
            this.dtpGio.ShowUpDown = true;
            this.dtpGio.Size = new System.Drawing.Size(80, 29);
            this.dtpGio.TabIndex = 10;
            // 
            // lblThoiLuong
            // 
            this.lblThoiLuong.AutoSize = true;
            this.lblThoiLuong.Location = new System.Drawing.Point(882, 64);
            this.lblThoiLuong.Name = "lblThoiLuong";
            this.lblThoiLuong.Size = new System.Drawing.Size(89, 21);
            this.lblThoiLuong.TabIndex = 11;
            this.lblThoiLuong.Text = "Thời lượng:";
            // 
            // numThoiLuong
            // 
            this.numThoiLuong.Location = new System.Drawing.Point(974, 62);
            this.numThoiLuong.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.numThoiLuong.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numThoiLuong.Name = "numThoiLuong";
            this.numThoiLuong.Size = new System.Drawing.Size(60, 29);
            this.numThoiLuong.TabIndex = 12;
            this.numThoiLuong.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Location = new System.Drawing.Point(57, 97);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(50, 21);
            this.lblLyDo.TabIndex = 13;
            this.lblLyDo.Text = "Lý do:";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(114, 94);
            this.txtLyDo.Multiline = true;
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(785, 40);
            this.txtLyDo.TabIndex = 14;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(25, 141);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(82, 21);
            this.lblTrangThai.TabIndex = 15;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Location = new System.Drawing.Point(114, 138);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(180, 29);
            this.cboTrangThai.TabIndex = 16;
            // 
            // flowBtns
            // 
            this.flowBtns.Controls.Add(this.btnKiemTra);
            this.flowBtns.Controls.Add(this.btnLuu);
            this.flowBtns.Controls.Add(this.btnMoi);
            this.flowBtns.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowBtns.Location = new System.Drawing.Point(0, 172);
            this.flowBtns.Name = "flowBtns";
            this.flowBtns.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.flowBtns.Size = new System.Drawing.Size(1073, 59);
            this.flowBtns.TabIndex = 3;
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(13, 9);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(120, 44);
            this.btnKiemTra.TabIndex = 0;
            this.btnKiemTra.Text = "Kiểm tra trùng";
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(139, 9);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(110, 44);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "Lưu lịch hẹn";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnMoi
            // 
            this.btnMoi.Location = new System.Drawing.Point(255, 9);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(88, 44);
            this.btnMoi.TabIndex = 2;
            this.btnMoi.Text = "Làm mới";
            this.btnMoi.Click += new System.EventHandler(this.btnMoi_Click);
            // 
            // grpTrung
            // 
            this.grpTrung.Controls.Add(this.dgvTrung);
            this.grpTrung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTrung.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.grpTrung.Location = new System.Drawing.Point(0, 231);
            this.grpTrung.Name = "grpTrung";
            this.grpTrung.Padding = new System.Windows.Forms.Padding(12);
            this.grpTrung.Size = new System.Drawing.Size(1073, 319);
            this.grpTrung.TabIndex = 2;
            this.grpTrung.TabStop = false;
            this.grpTrung.Text = "Các lịch trùng (cùng bác sĩ)";
            // 
            // dgvTrung
            // 
            this.dgvTrung.AllowUserToAddRows = false;
            this.dgvTrung.AllowUserToDeleteRows = false;
            this.dgvTrung.AllowUserToResizeRows = false;
            this.dgvTrung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTrung.BackgroundColor = System.Drawing.Color.White;
            this.dgvTrung.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTrung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLH,
            this.colBS,
            this.colBN,
            this.colBD,
            this.colKT});
            this.dgvTrung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrung.Location = new System.Drawing.Point(12, 34);
            this.dgvTrung.Name = "dgvTrung";
            this.dgvTrung.ReadOnly = true;
            this.dgvTrung.RowHeadersVisible = false;
            this.dgvTrung.RowHeadersWidth = 51;
            this.dgvTrung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrung.Size = new System.Drawing.Size(1049, 273);
            this.dgvTrung.TabIndex = 0;
            // 
            // colLH
            // 
            this.colLH.DataPropertyName = "LichHenId";
            this.colLH.FillWeight = 60F;
            this.colLH.HeaderText = "Mã LH";
            this.colLH.MinimumWidth = 6;
            this.colLH.Name = "colLH";
            this.colLH.ReadOnly = true;
            // 
            // colBS
            // 
            this.colBS.DataPropertyName = "BacSiTen";
            this.colBS.FillWeight = 120F;
            this.colBS.HeaderText = "Bác sĩ";
            this.colBS.MinimumWidth = 6;
            this.colBS.Name = "colBS";
            this.colBS.ReadOnly = true;
            // 
            // colBN
            // 
            this.colBN.DataPropertyName = "BenhNhanTen";
            this.colBN.FillWeight = 140F;
            this.colBN.HeaderText = "Bệnh nhân";
            this.colBN.MinimumWidth = 6;
            this.colBN.Name = "colBN";
            this.colBN.ReadOnly = true;
            // 
            // colBD
            // 
            this.colBD.DataPropertyName = "ThoiGianBatDau";
            this.colBD.FillWeight = 110F;
            this.colBD.HeaderText = "Bắt đầu";
            this.colBD.MinimumWidth = 6;
            this.colBD.Name = "colBD";
            this.colBD.ReadOnly = true;
            // 
            // colKT
            // 
            this.colKT.DataPropertyName = "ThoiGianKetThuc";
            this.colKT.FillWeight = 110F;
            this.colKT.HeaderText = "Kết thúc";
            this.colKT.MinimumWidth = 6;
            this.colKT.Name = "colKT";
            this.colKT.ReadOnly = true;
            // 
            // FrmDatLich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 550);
            this.Controls.Add(this.grpTrung);
            this.Controls.Add(this.flowBtns);
            this.Controls.Add(this.grpInfo);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "FrmDatLich";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đặt lịch khám";
            this.Load += new System.EventHandler(this.FrmDatLich_Load);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThoiLuong)).EndInit();
            this.flowBtns.ResumeLayout(false);
            this.grpTrung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblSearchBN;
        private System.Windows.Forms.TextBox txtSearchBN;
        private System.Windows.Forms.Button btnSearchBN;
        private System.Windows.Forms.Label lblBenhNhan;
        private System.Windows.Forms.ComboBox cboBenhNhan;
        private System.Windows.Forms.Label lblBacSi;
        private System.Windows.Forms.ComboBox cboBacSi;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Label lblGio;
        private System.Windows.Forms.DateTimePicker dtpGio;
        private System.Windows.Forms.Label lblThoiLuong;
        private System.Windows.Forms.NumericUpDown numThoiLuong;
        private System.Windows.Forms.Label lblLyDo;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;

        private System.Windows.Forms.FlowLayoutPanel flowBtns;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnMoi;

        private System.Windows.Forms.GroupBox grpTrung;
        private System.Windows.Forms.DataGridView dgvTrung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKT;
    }
}
