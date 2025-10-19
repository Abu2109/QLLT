using System.Windows.Forms;

namespace QLLT.Utils
{
    public static class MessageBoxEx
    {
        public static void Info(string msg, string title = "Thông báo")
            => MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void Warn(string msg, string title = "Cảnh báo")
            => MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static void Error(string msg, string title = "Lỗi")
            => MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static bool YesNo(string msg, string title = "Xác nhận")
            => MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }
}
