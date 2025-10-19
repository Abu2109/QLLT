namespace QLLT.DTOs
{
    public enum PaymentMethod { TienMat = 0, Card = 1, NganHang = 2, BHYT = 3 }

    public class PayRequest
    {
        public long MaHoaDon { get; set; }
        public decimal TongTien { get; set; }
        public PaymentMethod PhuongThuc { get; set; }

        public decimal TienKhachDua { get; set; }
        public decimal TienThoi => PhuongThuc == PaymentMethod.TienMat && TienKhachDua > TongTien
            ? TienKhachDua - TongTien : 0m;

        public string CardRef { get; set; }
        public string BankRef { get; set; }
        public string SoBHYT { get; set; }
        public string GhiChu { get; set; }

        public bool IsValid(out string error)
        {
            error = null;
            if (TongTien < 0) { error = "Tổng tiền không hợp lệ."; return false; }
            if (PhuongThuc == PaymentMethod.TienMat && TienKhachDua < 0)
            { error = "Tiền khách đưa không hợp lệ."; return false; }
            if (PhuongThuc == PaymentMethod.BHYT && string.IsNullOrWhiteSpace(SoBHYT))
            { error = "Vui lòng nhập số BHYT."; return false; }
            return true;
        }
    }
}
