using System;
using System.Windows.Forms;

namespace QLLT
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Form khởi động của ứng dụng
            Application.Run(new Forms.FrmMain());
            // Nếu muốn chạy thẳng Lễ tân board:
            // Application.Run(new Forms.FrmLeTanBoard());
        }
    }
}
