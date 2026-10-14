using System;

namespace Lap2
{
    public class TaiKhoanNganHang
    {
        public string SoTaiKhoan { get; }
        public string TenChu { get; set; }
        public decimal SoDu { get; private set; }

        public TaiKhoanNganHang(string so, string ten, decimal soDu = 0)
        {
            SoTaiKhoan = so ?? throw new ArgumentNullException(nameof(so));
            TenChu = ten ?? throw new ArgumentNullException(nameof(ten));
            if (soDu < 0) throw new ArgumentException("So du khong duoc am", nameof(soDu));
            SoDu = soDu;
        }

        public void NapTien(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("So tien nap phai > 0", nameof(amount));
            SoDu += amount;
        }

        public bool RutTien(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("So tien rut phai > 0", nameof(amount));
            if (SoDu - amount < 0) return false;
            SoDu -= amount;
            return true;
        }

        public bool ChuyenTien(TaiKhoanNganHang toAcc, decimal amount)
        {
            if (toAcc == null) throw new ArgumentNullException(nameof(toAcc));
            if (amount <= 0) throw new ArgumentException("So tien phai > 0", nameof(amount));
            if (SoDu - amount < 0) return false;
            SoDu -= amount;
            toAcc.NapTien(amount);
            return true;
        }

        public override string ToString()
        {
            return $"{SoTaiKhoan} - {TenChu} - So du: {SoDu:N0}";
        }
    }
}
