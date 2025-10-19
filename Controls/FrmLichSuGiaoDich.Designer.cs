using System.Windows.Forms;

namespace QLLT.Forms
{
    partial class FrmLichSuGiaoDich
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelTop;
        private Label lblTitle;
        private Label lblNgay;
        private DateTimePicker dtNgay;
        private CheckBox chkLocNgay;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblSoGD;
        private DataGridView dgv;
        private DataGridViewTextBoxColumn colMa;
        private DataGridViewTextBoxColumn colNgay;
        private DataGridViewTextBoxColumn colTong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblSoGD = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.chkLocNgay = new System.Windows.Forms.CheckBox();
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.lblNgay = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.colMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.AliceBlue;
            this.panelTop.Controls.Add(this.lblSoGD);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.lblSearch);
            this.panelTop.Controls.Add(this.chkLocNgay);
            this.panelTop.Controls.Add(this.dtNgay);
            this.panelTop.Controls.Add(this.lblNgay);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(12, 10, 12, 8);
            this.panelTop.Size = new System.Drawing.Size(860, 84);
            this.panelTop.TabIndex = 0;
            // 
            // lblSoGD
            // 
            this.lblSoGD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSoGD.AutoSize = true;
            this.lblSoGD.Location = new System.Drawing.Point(768, 14);
            this.lblSoGD.Name = "lblSoGD";
            this.lblSoGD.Size = new System.Drawing.Size(80, 13);
            this.lblSoGD.TabIndex = 6;
            this.lblSoGD.Text = "Số giao dịch: 0";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSearch.Location = new System.Drawing.Point(565, 45);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(210, 20);
            this.txtSearch.TabIndex = 5;
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(495, 48);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(67, 13);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Mã HĐ / tìm:";
            // 
            // chkLocNgay
            // 
            this.chkLocNgay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkLocNgay.AutoSize = true;
            this.chkLocNgay.Checked = true;
            this.chkLocNgay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLocNgay.Location = new System.Drawing.Point(252, 46);
            this.chkLocNgay.Name = "chkLocNgay";
            this.chkLocNgay.Size = new System.Drawing.Size(88, 17);
            this.chkLocNgay.TabIndex = 2;
            this.chkLocNgay.Text = "Lọc theo ngày";
            this.chkLocNgay.UseVisualStyleBackColor = true;
            // 
            // dtNgay
            // 
            this.dtNgay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtNgay.CustomFormat = "dd/MM/yyyy";
            this.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgay.Location = new System.Drawing.Point(148, 45);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(96, 20);
            this.dtNgay.TabIndex = 3;
            // 
            // lblNgay
            // 
            this.lblNgay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new System.Drawing.Point(108, 48);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(35, 13);
            this.lblNgay.TabIndex = 1;
            this.lblNgay.Text = "Ngày:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(130, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Lịch sử giao dịch";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMa,
            this.colNgay,
            this.colTong});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 84);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(860, 436);
            this.dgv.TabIndex = 1;
            // 
            // colMa
            // 
            this.colMa.DataPropertyName = "Ma";
            this.colMa.HeaderText = "Mã HĐ";
            this.colMa.FillWeight = 90F;
            // 
            // colNgay
            // 
            this.colNgay.DataPropertyName = "Ngay";
            this.colNgay.HeaderText = "Ngày";
            this.colNgay.DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" };
            this.colNgay.FillWeight = 110F;
            // 
            // colTong
            // 
            this.colTong.DataPropertyName = "Tong";
            this.colTong.HeaderText = "Tổng";
            this.colTong.DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" };
            // 
            // FrmLichSuGiaoDich
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(860, 520);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panelTop);
            this.Name = "FrmLichSuGiaoDich";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lịch sử giao dịch";
            this.Load += new System.EventHandler(this.FrmLichSuGiaoDich_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
