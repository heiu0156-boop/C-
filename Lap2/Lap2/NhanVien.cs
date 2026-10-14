using System;

namespace Lap2
{
    public class NhanVien
    {
        public string Ten { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal HeSo { get; set; }
        public decimal PhuCap { get; set; }

        public NhanVien(string ten, decimal luongCoBan, decimal heSo, decimal phuCap)
        {
            Ten = ten ?? throw new ArgumentNullException(nameof(ten));
            if (luongCoBan < 0) throw new ArgumentException("Luong co ban phai >= 0", nameof(luongCoBan));
            if (heSo <= 0) throw new ArgumentException("He so phai > 0", nameof(heSo));
            if (phuCap < 0) throw new ArgumentException("Phu cap phai >= 0", nameof(phuCap));
            LuongCoBan = luongCoBan;
            HeSo = heSo;
            PhuCap = phuCap;
        }

        public decimal TinhLuong()
        {
            return LuongCoBan * HeSo + PhuCap;
        }

        public override string ToString()
        {
            return $"{Ten} - LCB: {LuongCoBan:N0} - HS: {HeSo} - Phu cap: {PhuCap:N0}";
        }
    }
}
