namespace QLLT.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuChucNang;
        private System.Windows.Forms.ToolStripMenuItem mnuBenhNhan;
        private System.Windows.Forms.ToolStripMenuItem mnuDSHen;
        private System.Windows.Forms.ToolStripMenuItem mnuDatLich;
        private System.Windows.Forms.ToolStripMenuItem mnuLeTanBoard;
        private System.Windows.Forms.ToolStripMenuItem mnuThuNgan;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChucNang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBenhNhan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDSHen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatLich = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLeTanBoard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThuNgan = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuChucNang});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1200, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(71, 20);
            this.mnuHeThong.Text = "Hệ thống";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(93, 22);
            this.mnuExit.Text = "Thoát";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuChucNang
            // 
            this.mnuChucNang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBenhNhan,
            this.mnuDSHen,
            this.mnuDatLich,
            this.mnuLeTanBoard,
            this.mnuThuNgan});
            this.mnuChucNang.Name = "mnuChucNang";
            this.mnuChucNang.Size = new System.Drawing.Size(77, 20);
            this.mnuChucNang.Text = "Chức năng";
            // 
            // mnuBenhNhan
            // 
            this.mnuBenhNhan.Name = "mnuBenhNhan";
            this.mnuBenhNhan.Size = new System.Drawing.Size(156, 22);
            this.mnuBenhNhan.Text = "Quản lý bệnh nhân";
            this.mnuBenhNhan.Click += new System.EventHandler(this.mnuBenhNhan_Click);
            // 
            // mnuDSHen
            // 
            this.mnuDSHen.Name = "mnuDSHen";
            this.mnuDSHen.Size = new System.Drawing.Size(156, 22);
            this.mnuDSHen.Text = "Danh sách lịch";
            this.mnuDSHen.Click += new System.EventHandler(this.mnuDSHen_Click);
            // 
            // mnuDatLich
            // 
            this.mnuDatLich.Name = "mnuDatLich";
            this.mnuDatLich.Size = new System.Drawing.Size(156, 22);
            this.mnuDatLich.Text = "Đặt lịch";
            this.mnuDatLich.Click += new System.EventHandler(this.mnuDatLich_Click);
            // 
            // mnuLeTanBoard
            // 
            this.mnuLeTanBoard.Name = "mnuLeTanBoard";
            this.mnuLeTanBoard.Size = new System.Drawing.Size(156, 22);
            this.mnuLeTanBoard.Text = "Lễ tân board";
            this.mnuLeTanBoard.Click += new System.EventHandler(this.mnuLeTanBoard_Click);
            // 
            // mnuThuNgan
            // 
            this.mnuThuNgan.Name = "mnuThuNgan";
            this.mnuThuNgan.Size = new System.Drawing.Size(156, 22);
            this.mnuThuNgan.Text = "Thu ngân";
            this.mnuThuNgan.Click += new System.EventHandler(this.mnuThuNgan_Click);
            // 
            // FrmMain
            // 
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menu;
            this.Controls.Add(this.menu);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QLLT - Quản lý lễ tân & khám bệnh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
