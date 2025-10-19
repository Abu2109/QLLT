using System.Windows.Forms;
using System.Drawing;
using QLLT.Controls;

namespace QLLT.Forms
{
    partial class FrmThuNgan
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvCart;
        private BindingSource bsCart;
        private Panel pnlRight;
        private UcChonThuoc ucChon;
        private UcThanhToan ucPay;
        private Panel pnlBottom;

        private Label lbMode;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnXoaHet;
        private Button btnHoanTat;

        private Button btnKiemTraThuoc;
        private Button btnLichSuGD;
        private Button btnXemBienLai;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.bsCart = new System.Windows.Forms.BindingSource(this.components);
            this.pnlRight = new System.Windows.Forms.Panel();
            this.ucPay = new QLLT.Controls.UcThanhToan();
            this.ucChon = new QLLT.Controls.UcChonThuoc();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lbMode = new System.Windows.Forms.Label();
            this.btnXemBienLai = new System.Windows.Forms.Button();
            this.btnLichSuGD = new System.Windows.Forms.Button();
            this.btnKiemTraThuoc = new System.Windows.Forms.Button();
            this.btnHoanTat = new System.Windows.Forms.Button();
            this.btnXoaHet = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCart)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.AutoGenerateColumns = false;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvCart.Location = new System.Drawing.Point(0, 0);
            this.dgvCart.MultiSelect = false;
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(460, 606);
            this.dgvCart.TabIndex = 0;
            this.dgvCart.DataSource = this.bsCart;
            // columns
            var colSTT = new DataGridViewTextBoxColumn { HeaderText = "STT", Name = "colSTT", Width = 56, ReadOnly = true };
            var colTen = new DataGridViewTextBoxColumn { HeaderText = "Tên", DataPropertyName = "TenThuoc", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            var colDVT = new DataGridViewTextBoxColumn { HeaderText = "ĐVT", DataPropertyName = "DonViTinh", Width = 70 };
            var colSL = new DataGridViewTextBoxColumn { HeaderText = "Số lượng", DataPropertyName = "SoLuong", Width = 85 };
            var colGia = new DataGridViewTextBoxColumn { HeaderText = "Giá", DataPropertyName = "DonGia", Width = 95 };
            colGia.DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" };
            var colTT = new DataGridViewTextBoxColumn { HeaderText = "Thành tiền", DataPropertyName = "ThanhTien", Width = 120 };
            colTT.DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" };
            this.dgvCart.Columns.AddRange(colSTT, colTen, colDVT, colSL, colGia, colTT);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.ucPay);
            this.pnlRight.Controls.Add(this.ucChon);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(460, 0);
            this.pnlRight.Name = "pnlRight";
            // Thêm padding trên để thấy rõ các nút danh mục (fix “thụt”)
            this.pnlRight.Padding = new Padding(0, 10, 0, 0);
            this.pnlRight.Size = new System.Drawing.Size(720, 606);
            this.pnlRight.TabIndex = 1;
            // 
            // ucPay
            // 
            this.ucPay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPay.Location = new System.Drawing.Point(0, 10);
            this.ucPay.Margin = new Padding(0);
            this.ucPay.Name = "ucPay";
            this.ucPay.Size = new System.Drawing.Size(720, 596);
            this.ucPay.TabIndex = 1;
            this.ucPay.Visible = false;
            // 
            // ucChon
            // 
            this.ucChon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChon.Location = new System.Drawing.Point(0, 10);
            this.ucChon.Margin = new Padding(0);
            this.ucChon.Name = "ucChon";
            this.ucChon.Size = new System.Drawing.Size(720, 596);
            this.ucChon.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lbMode);
            this.pnlBottom.Controls.Add(this.btnXemBienLai);
            this.pnlBottom.Controls.Add(this.btnLichSuGD);
            this.pnlBottom.Controls.Add(this.btnKiemTraThuoc);
            this.pnlBottom.Controls.Add(this.btnHoanTat);
            this.pnlBottom.Controls.Add(this.btnXoaHet);
            this.pnlBottom.Controls.Add(this.btnXoa);
            this.pnlBottom.Controls.Add(this.btnSua);
            this.pnlBottom.Controls.Add(this.btnThem);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 606);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            // cao hơn để chứa nút to
            this.pnlBottom.Size = new System.Drawing.Size(1180, 60);
            this.pnlBottom.TabIndex = 2;
            // 
            // common button style
            //
            Font btnFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Size btnSize = new Size(98, 36); // to, dễ bấm
            int y = 12;

            // lbMode
            this.lbMode.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.lbMode.AutoSize = true;
            this.lbMode.Location = new System.Drawing.Point(1090, 20);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(70, 17);
            this.lbMode.Text = "Chọn thuốc";
            this.lbMode.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            // btnXemBienLai
            this.btnXemBienLai.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.btnXemBienLai.Location = new System.Drawing.Point(984, y);
            this.btnXemBienLai.Size = btnSize;
            this.btnXemBienLai.Font = btnFont;
            this.btnXemBienLai.Name = "btnXemBienLai";
            this.btnXemBienLai.TabIndex = 8;
            this.btnXemBienLai.Text = "Xem biên lai";
            this.btnXemBienLai.UseVisualStyleBackColor = true;

            // btnLichSuGD
            this.btnLichSuGD.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.btnLichSuGD.Location = new System.Drawing.Point(880, y);
            this.btnLichSuGD.Size = btnSize;
            this.btnLichSuGD.Font = btnFont;
            this.btnLichSuGD.Name = "btnLichSuGD";
            this.btnLichSuGD.TabIndex = 7;
            this.btnLichSuGD.Text = "Lịch sử GD";
            this.btnLichSuGD.UseVisualStyleBackColor = true;

            // btnKiemTraThuoc
            this.btnKiemTraThuoc.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.btnKiemTraThuoc.Location = new System.Drawing.Point(764, y);
            this.btnKiemTraThuoc.Size = new Size(112, 36);
            this.btnKiemTraThuoc.Font = btnFont;
            this.btnKiemTraThuoc.Name = "btnKiemTraThuoc";
            this.btnKiemTraThuoc.TabIndex = 6;
            this.btnKiemTraThuoc.Text = "Kiểm tra thuốc";
            this.btnKiemTraThuoc.UseVisualStyleBackColor = true;

            // btnHoanTat
            this.btnHoanTat.Location = new System.Drawing.Point(334, y);
            this.btnHoanTat.Size = btnSize;
            this.btnHoanTat.Font = btnFont;
            this.btnHoanTat.Name = "btnHoanTat";
            this.btnHoanTat.TabIndex = 5;
            this.btnHoanTat.Text = "Thanh toán";
            this.btnHoanTat.UseVisualStyleBackColor = true;

            // btnXoaHet
            this.btnXoaHet.Location = new System.Drawing.Point(226, y);
            this.btnXoaHet.Size = btnSize;
            this.btnXoaHet.Font = btnFont;
            this.btnXoaHet.Name = "btnXoaHet";
            this.btnXoaHet.TabIndex = 4;
            this.btnXoaHet.Text = "Xóa hết";
            this.btnXoaHet.UseVisualStyleBackColor = true;

            // btnXoa
            this.btnXoa.Location = new System.Drawing.Point(118, y);
            this.btnXoa.Size = btnSize;
            this.btnXoa.Font = btnFont;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;

            // btnSua
            this.btnSua.Location = new System.Drawing.Point(10, y);
            this.btnSua.Size = btnSize;
            this.btnSua.Font = btnFont;
            this.btnSua.Name = "btnSua";
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa SL";
            this.btnSua.UseVisualStyleBackColor = true;

            // btnThem
            this.btnThem.Location = new System.Drawing.Point(10 - 108, y); // sẽ bị override ngay sau
            // sắp xếp lại: Thêm | Sửa | Xóa | Xóa hết | Thanh toán
            this.btnThem.Location = new System.Drawing.Point(10, y);
            this.btnThem.Size = btnSize;
            this.btnThem.Font = btnFont;
            this.btnThem.Name = "btnThem";
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;

            // 
            // FrmThuNgan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 666);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.pnlBottom);
            this.Name = "FrmThuNgan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thu ngân — Chọn thuốc";
            this.Load += new System.EventHandler(this.FrmThuNgan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCart)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
