using System;

namespace Lap2
{
    public class SanPham
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }

        public SanPham(string ma, string ten, decimal donGia, int soLuong)
        {
            Ma = ma ?? throw new ArgumentNullException(nameof(ma));
            Ten = ten ?? throw new ArgumentNullException(nameof(ten));
            if (donGia <= 0) throw new ArgumentException("Don gia phai > 0", nameof(donGia));
            if (soLuong < 0) throw new ArgumentException("So luong khong duoc am", nameof(soLuong));
            DonGia = donGia;
            SoLuong = soLuong;
        }

        public decimal ThanhTien()
        {
            return DonGia * SoLuong;
        }

        public override string ToString()
        {
            return $"{Ma} - {Ten} - {DonGia:N0} x {SoLuong}";
        }
    }
}
