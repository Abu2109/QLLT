using System.Windows.Forms;
using System.Drawing;

namespace QLLT.Forms
{
    partial class FrmLeTanBoard
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.tileLichHomNay = new System.Windows.Forms.Panel();
            this.lblLichHomNayVal = new System.Windows.Forms.Label();
            this.lblLichHomNay = new System.Windows.Forms.Label();
            this.tileChoXacNhan = new System.Windows.Forms.Panel();
            this.lblChoXacNhanVal = new System.Windows.Forms.Label();
            this.lblChoXacNhan = new System.Windows.Forms.Label();
            this.tileDaKham = new System.Windows.Forms.Panel();
            this.lblDaKhamVal = new System.Windows.Forms.Label();
            this.lblDaKham = new System.Windows.Forms.Label();
            this.tileHuy = new System.Windows.Forms.Panel();
            this.lblHuyVal = new System.Windows.Forms.Label();
            this.lblHuy = new System.Windows.Forms.Label();
            this.tileBenhNhanMoi = new System.Windows.Forms.Panel();
            this.lblBenhNhanMoiVal = new System.Windows.Forms.Label();
            this.lblBenhNhanMoi = new System.Windows.Forms.Label();
            this.grpUpcoming = new System.Windows.Forms.GroupBox();
            this.dgvUpcoming = new System.Windows.Forms.DataGridView();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLyDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQLBenhNhan = new System.Windows.Forms.Button();
            this.btnDatLich = new System.Windows.Forms.Button();
            this.btnDanhSachLich = new System.Windows.Forms.Button();
            this.btnThuNgan = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.table.SuspendLayout();
            this.tileLichHomNay.SuspendLayout();
            this.tileChoXacNhan.SuspendLayout();
            this.tileDaKham.SuspendLayout();
            this.tileHuy.SuspendLayout();
            this.tileBenhNhanMoi.SuspendLayout();
            this.grpUpcoming.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpcoming)).BeginInit();
            this.flowActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1000, 52);
            this.pnlTop.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12.5F);
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(225, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Bảng điều khiển lễ tân";
            // 
            // table
            // 
            this.table.ColumnCount = 5;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table.Controls.Add(this.tileLichHomNay, 0, 0);
            this.table.Controls.Add(this.tileChoXacNhan, 1, 0);
            this.table.Controls.Add(this.tileDaKham, 2, 0);
            this.table.Controls.Add(this.tileHuy, 3, 0);
            this.table.Controls.Add(this.tileBenhNhanMoi, 4, 0);
            this.table.Dock = System.Windows.Forms.DockStyle.Top;
            this.table.Location = new System.Drawing.Point(0, 52);
            this.table.Name = "table";
            this.table.Padding = new System.Windows.Forms.Padding(12, 8, 12, 4);
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.table.Size = new System.Drawing.Size(1000, 120);
            this.table.TabIndex = 1;
            // 
            // tileLichHomNay
            // 
            this.tileLichHomNay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.tileLichHomNay.Controls.Add(this.lblLichHomNayVal);
            this.tileLichHomNay.Controls.Add(this.lblLichHomNay);
            this.tileLichHomNay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileLichHomNay.Location = new System.Drawing.Point(20, 16);
            this.tileLichHomNay.Margin = new System.Windows.Forms.Padding(8);
            this.tileLichHomNay.Name = "tileLichHomNay";
            this.tileLichHomNay.Size = new System.Drawing.Size(179, 92);
            this.tileLichHomNay.TabIndex = 0;
            // 
            // lblLichHomNayVal
            // 
            this.lblLichHomNayVal.AutoSize = true;
            this.lblLichHomNayVal.Font = new System.Drawing.Font("Segoe UI Semibold", 22F);
            this.lblLichHomNayVal.ForeColor = System.Drawing.Color.White;
            this.lblLichHomNayVal.Location = new System.Drawing.Point(8, 34);
            this.lblLichHomNayVal.Name = "lblLichHomNayVal";
            this.lblLichHomNayVal.Size = new System.Drawing.Size(43, 50);
            this.lblLichHomNayVal.TabIndex = 0;
            this.lblLichHomNayVal.Text = "0";
            // 
            // lblLichHomNay
            // 
            this.lblLichHomNay.AutoSize = true;
            this.lblLichHomNay.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLichHomNay.ForeColor = System.Drawing.Color.White;
            this.lblLichHomNay.Location = new System.Drawing.Point(10, 10);
            this.lblLichHomNay.Name = "lblLichHomNay";
            this.lblLichHomNay.Size = new System.Drawing.Size(133, 21);
            this.lblLichHomNay.TabIndex = 1;
            this.lblLichHomNay.Text = "Lịch hẹn hôm nay";
            // 
            // tileChoXacNhan
            // 
            this.tileChoXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.tileChoXacNhan.Controls.Add(this.lblChoXacNhanVal);
            this.tileChoXacNhan.Controls.Add(this.lblChoXacNhan);
            this.tileChoXacNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileChoXacNhan.Location = new System.Drawing.Point(215, 16);
            this.tileChoXacNhan.Margin = new System.Windows.Forms.Padding(8);
            this.tileChoXacNhan.Name = "tileChoXacNhan";
            this.tileChoXacNhan.Size = new System.Drawing.Size(179, 92);
            this.tileChoXacNhan.TabIndex = 1;
            // 
            // lblChoXacNhanVal
            // 
            this.lblChoXacNhanVal.AutoSize = true;
            this.lblChoXacNhanVal.Font = new System.Drawing.Font("Segoe UI Semibold", 22F);
            this.lblChoXacNhanVal.ForeColor = System.Drawing.Color.White;
            this.lblChoXacNhanVal.Location = new System.Drawing.Point(8, 34);
            this.lblChoXacNhanVal.Name = "lblChoXacNhanVal";
            this.lblChoXacNhanVal.Size = new System.Drawing.Size(43, 50);
            this.lblChoXacNhanVal.TabIndex = 0;
            this.lblChoXacNhanVal.Text = "0";
            // 
            // lblChoXacNhan
            // 
            this.lblChoXacNhan.AutoSize = true;
            this.lblChoXacNhan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblChoXacNhan.ForeColor = System.Drawing.Color.White;
            this.lblChoXacNhan.Location = new System.Drawing.Point(10, 10);
            this.lblChoXacNhan.Name = "lblChoXacNhan";
            this.lblChoXacNhan.Size = new System.Drawing.Size(111, 21);
            this.lblChoXacNhan.TabIndex = 1;
            this.lblChoXacNhan.Text = "Chưa xác nhận";
            // 
            // tileDaKham
            // 
            this.tileDaKham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.tileDaKham.Controls.Add(this.lblDaKhamVal);
            this.tileDaKham.Controls.Add(this.lblDaKham);
            this.tileDaKham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileDaKham.Location = new System.Drawing.Point(410, 16);
            this.tileDaKham.Margin = new System.Windows.Forms.Padding(8);
            this.tileDaKham.Name = "tileDaKham";
            this.tileDaKham.Size = new System.Drawing.Size(179, 92);
            this.tileDaKham.TabIndex = 2;
            // 
            // lblDaKhamVal
            // 
            this.lblDaKhamVal.AutoSize = true;
            this.lblDaKhamVal.Font = new System.Drawing.Font("Segoe UI Semibold", 22F);
            this.lblDaKhamVal.ForeColor = System.Drawing.Color.White;
            this.lblDaKhamVal.Location = new System.Drawing.Point(8, 34);
            this.lblDaKhamVal.Name = "lblDaKhamVal";
            this.lblDaKhamVal.Size = new System.Drawing.Size(43, 50);
            this.lblDaKhamVal.TabIndex = 0;
            this.lblDaKhamVal.Text = "0";
            // 
            // lblDaKham
            // 
            this.lblDaKham.AutoSize = true;
            this.lblDaKham.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDaKham.ForeColor = System.Drawing.Color.White;
            this.lblDaKham.Location = new System.Drawing.Point(10, 10);
            this.lblDaKham.Name = "lblDaKham";
            this.lblDaKham.Size = new System.Drawing.Size(72, 21);
            this.lblDaKham.TabIndex = 1;
            this.lblDaKham.Text = "Đã khám";
            // 
            // tileHuy
            // 
            this.tileHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.tileHuy.Controls.Add(this.lblHuyVal);
            this.tileHuy.Controls.Add(this.lblHuy);
            this.tileHuy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileHuy.Location = new System.Drawing.Point(605, 16);
            this.tileHuy.Margin = new System.Windows.Forms.Padding(8);
            this.tileHuy.Name = "tileHuy";
            this.tileHuy.Size = new System.Drawing.Size(179, 92);
            this.tileHuy.TabIndex = 3;
            // 
            // lblHuyVal
            // 
            this.lblHuyVal.AutoSize = true;
            this.lblHuyVal.Font = new System.Drawing.Font("Segoe UI Semibold", 22F);
            this.lblHuyVal.ForeColor = System.Drawing.Color.White;
            this.lblHuyVal.Location = new System.Drawing.Point(8, 34);
            this.lblHuyVal.Name = "lblHuyVal";
            this.lblHuyVal.Size = new System.Drawing.Size(43, 50);
            this.lblHuyVal.TabIndex = 0;
            this.lblHuyVal.Text = "0";
            // 
            // lblHuy
            // 
            this.lblHuy.AutoSize = true;
            this.lblHuy.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHuy.ForeColor = System.Drawing.Color.White;
            this.lblHuy.Location = new System.Drawing.Point(10, 10);
            this.lblHuy.Name = "lblHuy";
            this.lblHuy.Size = new System.Drawing.Size(38, 21);
            this.lblHuy.TabIndex = 1;
            this.lblHuy.Text = "Hủy";
            // 
            // tileBenhNhanMoi
            // 
            this.tileBenhNhanMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.tileBenhNhanMoi.Controls.Add(this.lblBenhNhanMoiVal);
            this.tileBenhNhanMoi.Controls.Add(this.lblBenhNhanMoi);
            this.tileBenhNhanMoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileBenhNhanMoi.Location = new System.Drawing.Point(800, 16);
            this.tileBenhNhanMoi.Margin = new System.Windows.Forms.Padding(8);
            this.tileBenhNhanMoi.Name = "tileBenhNhanMoi";
            this.tileBenhNhanMoi.Size = new System.Drawing.Size(180, 92);
            this.tileBenhNhanMoi.TabIndex = 4;
            // 
            // lblBenhNhanMoiVal
            // 
            this.lblBenhNhanMoiVal.AutoSize = true;
            this.lblBenhNhanMoiVal.Font = new System.Drawing.Font("Segoe UI Semibold", 22F);
            this.lblBenhNhanMoiVal.ForeColor = System.Drawing.Color.White;
            this.lblBenhNhanMoiVal.Location = new System.Drawing.Point(8, 34);
            this.lblBenhNhanMoiVal.Name = "lblBenhNhanMoiVal";
            this.lblBenhNhanMoiVal.Size = new System.Drawing.Size(43, 50);
            this.lblBenhNhanMoiVal.TabIndex = 0;
            this.lblBenhNhanMoiVal.Text = "0";
            // 
            // lblBenhNhanMoi
            // 
            this.lblBenhNhanMoi.AutoSize = true;
            this.lblBenhNhanMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBenhNhanMoi.ForeColor = System.Drawing.Color.White;
            this.lblBenhNhanMoi.Location = new System.Drawing.Point(10, 10);
            this.lblBenhNhanMoi.Name = "lblBenhNhanMoi";
            this.lblBenhNhanMoi.Size = new System.Drawing.Size(130, 21);
            this.lblBenhNhanMoi.TabIndex = 1;
            this.lblBenhNhanMoi.Text = "Bệnh nhân (tổng)";
            // 
            // grpUpcoming
            // 
            this.grpUpcoming.Controls.Add(this.dgvUpcoming);
            this.grpUpcoming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUpcoming.Location = new System.Drawing.Point(0, 172);
            this.grpUpcoming.Name = "grpUpcoming";
            this.grpUpcoming.Padding = new System.Windows.Forms.Padding(12);
            this.grpUpcoming.Size = new System.Drawing.Size(1000, 377);
            this.grpUpcoming.TabIndex = 0;
            this.grpUpcoming.TabStop = false;
            this.grpUpcoming.Text = "Lịch sắp tới hôm nay";
            // 
            // dgvUpcoming
            // 
            this.dgvUpcoming.AllowUserToAddRows = false;
            this.dgvUpcoming.AllowUserToDeleteRows = false;
            this.dgvUpcoming.AllowUserToResizeRows = false;
            this.dgvUpcoming.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUpcoming.BackgroundColor = System.Drawing.Color.White;
            this.dgvUpcoming.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUpcoming.ColumnHeadersHeight = 29;
            this.dgvUpcoming.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colBS,
            this.colBN,
            this.colTT,
            this.colLyDo});
            this.dgvUpcoming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUpcoming.Location = new System.Drawing.Point(12, 34);
            this.dgvUpcoming.Name = "dgvUpcoming";
            this.dgvUpcoming.RowHeadersVisible = false;
            this.dgvUpcoming.RowHeadersWidth = 51;
            this.dgvUpcoming.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUpcoming.Size = new System.Drawing.Size(976, 331);
            this.dgvUpcoming.TabIndex = 0;
            // 
            // colTime
            // 
            this.colTime.DataPropertyName = "TimeStr";
            this.colTime.FillWeight = 110F;
            this.colTime.HeaderText = "Thời gian";
            this.colTime.MinimumWidth = 6;
            this.colTime.Name = "colTime";
            // 
            // colBS
            // 
            this.colBS.DataPropertyName = "BacSi";
            this.colBS.HeaderText = "Bác sĩ";
            this.colBS.MinimumWidth = 6;
            this.colBS.Name = "colBS";
            // 
            // colBN
            // 
            this.colBN.DataPropertyName = "BenhNhan";
            this.colBN.HeaderText = "Bệnh nhân";
            this.colBN.MinimumWidth = 6;
            this.colBN.Name = "colBN";
            // 
            // colTT
            // 
            this.colTT.DataPropertyName = "TrangThai";
            this.colTT.FillWeight = 90F;
            this.colTT.HeaderText = "Trạng thái";
            this.colTT.MinimumWidth = 6;
            this.colTT.Name = "colTT";
            // 
            // colLyDo
            // 
            this.colLyDo.DataPropertyName = "LyDo";
            this.colLyDo.FillWeight = 160F;
            this.colLyDo.HeaderText = "Lý do";
            this.colLyDo.MinimumWidth = 6;
            this.colLyDo.Name = "colLyDo";
            // 
            // flowActions
            // 
            this.flowActions.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowActions.Controls.Add(this.btnQLBenhNhan);
            this.flowActions.Controls.Add(this.btnDatLich);
            this.flowActions.Controls.Add(this.btnDanhSachLich);
            this.flowActions.Controls.Add(this.btnThuNgan);
            this.flowActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowActions.Location = new System.Drawing.Point(0, 549);
            this.flowActions.Name = "flowActions";
            this.flowActions.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.flowActions.Size = new System.Drawing.Size(1000, 71);
            this.flowActions.TabIndex = 2;
            // 
            // btnQLBenhNhan
            // 
            this.btnQLBenhNhan.Location = new System.Drawing.Point(15, 9);
            this.btnQLBenhNhan.Name = "btnQLBenhNhan";
            this.btnQLBenhNhan.Size = new System.Drawing.Size(160, 50);
            this.btnQLBenhNhan.TabIndex = 0;
            this.btnQLBenhNhan.Text = "Quản lý bệnh nhân";
            this.btnQLBenhNhan.Click += new System.EventHandler(this.btnQLBenhNhan_Click);
            // 
            // btnDatLich
            // 
            this.btnDatLich.Location = new System.Drawing.Point(181, 9);
            this.btnDatLich.Name = "btnDatLich";
            this.btnDatLich.Size = new System.Drawing.Size(100, 50);
            this.btnDatLich.TabIndex = 1;
            this.btnDatLich.Text = "Đặt lịch";
            this.btnDatLich.Click += new System.EventHandler(this.btnDatLich_Click);
            // 
            // btnDanhSachLich
            // 
            this.btnDanhSachLich.Location = new System.Drawing.Point(287, 9);
            this.btnDanhSachLich.Name = "btnDanhSachLich";
            this.btnDanhSachLich.Size = new System.Drawing.Size(140, 50);
            this.btnDanhSachLich.TabIndex = 2;
            this.btnDanhSachLich.Text = "Danh sách lịch";
            this.btnDanhSachLich.Click += new System.EventHandler(this.btnDanhSachLich_Click);
            // 
            // btnThuNgan
            // 
            this.btnThuNgan.Location = new System.Drawing.Point(433, 9);
            this.btnThuNgan.Name = "btnThuNgan";
            this.btnThuNgan.Size = new System.Drawing.Size(110, 50);
            this.btnThuNgan.TabIndex = 3;
            this.btnThuNgan.Text = "Thu ngân";
            this.btnThuNgan.Click += new System.EventHandler(this.btnThuNgan_Click);
            // 
            // FrmLeTanBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 620);
            this.Controls.Add(this.grpUpcoming);
            this.Controls.Add(this.table);
            this.Controls.Add(this.flowActions);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "FrmLeTanBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lễ tân Board";
            this.Load += new System.EventHandler(this.FrmLeTanBoard_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.table.ResumeLayout(false);
            this.tileLichHomNay.ResumeLayout(false);
            this.tileLichHomNay.PerformLayout();
            this.tileChoXacNhan.ResumeLayout(false);
            this.tileChoXacNhan.PerformLayout();
            this.tileDaKham.ResumeLayout(false);
            this.tileDaKham.PerformLayout();
            this.tileHuy.ResumeLayout(false);
            this.tileHuy.PerformLayout();
            this.tileBenhNhanMoi.ResumeLayout(false);
            this.tileBenhNhanMoi.PerformLayout();
            this.grpUpcoming.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpcoming)).EndInit();
            this.flowActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private Panel pnlTop;
        private Label lblTitle;
        private TableLayoutPanel table;

        private Panel tileLichHomNay;
        private Label lblLichHomNay;
        private Label lblLichHomNayVal;

        private Panel tileChoXacNhan;
        private Label lblChoXacNhan;
        private Label lblChoXacNhanVal;

        private Panel tileDaKham;
        private Label lblDaKham;
        private Label lblDaKhamVal;

        private Panel tileHuy;
        private Label lblHuy;
        private Label lblHuyVal;

        private Panel tileBenhNhanMoi;
        private Label lblBenhNhanMoi;
        private Label lblBenhNhanMoiVal;

        private GroupBox grpUpcoming;
        private DataGridView dgvUpcoming;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colBS;
        private DataGridViewTextBoxColumn colBN;
        private DataGridViewTextBoxColumn colTT;
        private DataGridViewTextBoxColumn colLyDo;

        private FlowLayoutPanel flowActions;
        private Button btnQLBenhNhan;
        private Button btnDatLich;
        private Button btnDanhSachLich;
        private Button btnThuNgan;
    }
}
