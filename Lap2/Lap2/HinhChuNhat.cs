using System;

namespace Lap2
{
    public class HinhChuNhat
    {
        private double _dai;
        private double _rong;

        public double ChieuDai
        {
            get => _dai;
            set
            {
                if (value <= 0) throw new ArgumentException("Chieu dai phai > 0");
                _dai = value;
            }
        }

        public double ChieuRong
        {
            get => _rong;
            set
            {
                if (value <= 0) throw new ArgumentException("Chieu rong phai > 0");
                _rong = value;
            }
        }

        public HinhChuNhat(double dai, double rong)
        {
            ChieuDai = dai;
            ChieuRong = rong;
        }

        public double ChuVi() => 2 * (ChieuDai + ChieuRong);
        public double DienTich() => ChieuDai * ChieuRong;

        public override string ToString() => $"HCN(dai={ChieuDai}, rong={ChieuRong})";
    }
}
