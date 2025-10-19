using System;
using System.Data;
using System.Data.SqlClient;

namespace QLLT.Utils
{
    public static class Db
    {
        // Thử lấy chuỗi kết nối từ System.Configuration.ConfigurationManager bằng reflection
        private static string TryGetConnStr(string name)
        {
            try
            {
                // Tải type "System.Configuration.ConfigurationManager" nếu có
                var cfgType = Type.GetType("System.Configuration.ConfigurationManager, System.Configuration");
                if (cfgType == null) return null;

                var propConnStrings = cfgType.GetProperty("ConnectionStrings");
                var coll = propConnStrings.GetValue(null, null); // static property

                // Gọi indexer: ConnectionStrings["name"]
                var idx = coll.GetType().GetMethod("get_Item", new[] { typeof(string) });
                var settings = idx.Invoke(coll, new object[] { name });
                if (settings == null) return null;

                var csProp = settings.GetType().GetProperty("ConnectionString");
                return csProp.GetValue(settings, null) as string;
            }
            catch
            {
                return null;
            }
        }

        public static SqlConnection GetOpenConnection()
        {
            // Ưu tiên đọc từ App.config (nếu project có reference System.Configuration),
            // nếu không có thì dùng biến môi trường QLLT_CS (nếu đã set),
            // cuối cùng ném lỗi hướng dẫn.
            var cs =
                TryGetConnStr("HospitalDB") ??
                TryGetConnStr("HospitalContextDB") ??
                TryGetConnStr("Model1") ??
                Environment.GetEnvironmentVariable("QLLT_CS");

            if (string.IsNullOrWhiteSpace(cs))
            {
                throw new InvalidOperationException(
                    "Không tìm thấy chuỗi kết nối.\n" +
                    "- Thêm connectionStrings HospitalDB/HospitalContextDB/Model1 trong App.config, hoặc\n" +
                    "- Set biến môi trường QLLT_CS chứa chuỗi kết nối SQL Server.\n" +
                    "Ví dụ: Data Source=YOURMACHINE\\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True");
            }

            var cn = new SqlConnection(cs);
            cn.Open();
            return cn;
        }

        public static SqlCommand Cmd(this SqlConnection cn, string sql, object param = null)
        {
            var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.Text };
            if (param != null)
            {
                foreach (var p in param.GetType().GetProperties())
                {
                    var name = "@" + p.Name;
                    var value = p.GetValue(param, null) ?? DBNull.Value;
                    cmd.Parameters.AddWithValue(name, value);
                }
            }
            return cmd;
        }

        public static T Scalar<T>(this SqlCommand cmd)
        {
            object val = cmd.ExecuteScalar();
            if (val == null || val == DBNull.Value) return default(T);
            return (T)Convert.ChangeType(val, typeof(T));
        }
    }
}
