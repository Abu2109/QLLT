using System;
using System.Collections.Concurrent;
using System.Data;

namespace QLLT
{
    /// <summary>Kho biên lai trong phiên chạy (RAM).</summary>
    public static class ReceiptStore
    {
        public sealed class ReceiptData
        {
            public string Ma { get; set; } = "";
            public DateTime Ngay { get; set; } = DateTime.Now;
            public string PhuongThuc { get; set; } = "";
            public decimal Tong { get; set; }
            public decimal KhachDua { get; set; }
            public string BenhNhan { get; set; } = "";
            public DataTable Lines { get; set; } = new DataTable();
        }

        private static readonly ConcurrentDictionary<string, ReceiptData> _map =
            new ConcurrentDictionary<string, ReceiptData>(StringComparer.OrdinalIgnoreCase);

        public static void Save(ReceiptData r) => _map[r.Ma] = r;

        public static bool TryGet(string ma, out ReceiptData r) => _map.TryGetValue(ma, out r);
    }
}
