using System;
using System.Windows.Forms;

namespace QLLT.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void OpenChild<T>() where T : Form, new()
        {
            foreach (Form f in MdiChildren)
                if (f is T) { f.Activate(); return; }

            var frm = new T { MdiParent = this, WindowState = FormWindowState.Maximized };
            frm.Show();
        }

        private void mnuBenhNhan_Click(object sender, EventArgs e) => OpenChild<FrmQuanLyBenhNhan>();
        private void mnuDSHen_Click(object sender, EventArgs e) => OpenChild<FrmDanhSachLich>();
        private void mnuDatLich_Click(object sender, EventArgs e) => OpenChild<FrmDatLich>();
        private void mnuLeTanBoard_Click(object sender, EventArgs e) => OpenChild<FrmLeTanBoard>();
        private void mnuThuNgan_Click(object sender, EventArgs e) => OpenChild<FrmThuNgan>();
        private void mnuExit_Click(object sender, EventArgs e) => Close();
    }
}
