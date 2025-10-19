using System;

namespace QLLT.DTOs
{
    public class CartItem
    {
        public int ThuocId { get; set; }
        public long MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string DonViTinh { get; set; }
        public string NhomThuoc { get; set; }

        public int SoLuong { get; private set; } = 1;
        public decimal DonGia { get; set; }
        public decimal GiamBHYT { get; private set; } = 0m;

        public decimal ThanhTien => Math.Max(0m, (SoLuong * DonGia) - GiamBHYT);

        public CartItem() { }
        public CartItem(int thuocId, long maThuoc, string ten, string dvt, decimal gia, string nhom = null, int sl = 1)
        {
            ThuocId = thuocId; MaThuoc = maThuoc; TenThuoc = ten; DonViTinh = dvt; DonGia = gia; NhomThuoc = nhom;
            SetQuantity(sl);
        }

        public void SetQuantity(int qty) { SoLuong = qty < 1 ? 1 : qty; }
        public void AddQuantity(int delta) => SetQuantity(SoLuong + delta);

        public void ApplyBHYTPercent(decimal percent)
        {
            if (percent <= 0) { GiamBHYT = 0; return; }
            if (percent > 1) percent = 1;
            GiamBHYT = Math.Round(SoLuong * DonGia * percent, 0, MidpointRounding.AwayFromZero);
        }
        public void ApplyBHYTAmount(decimal amount)
        {
            var max = SoLuong * DonGia;
            if (amount < 0) amount = 0;
            if (amount > max) amount = max;
            GiamBHYT = amount;
        }
    }
}
