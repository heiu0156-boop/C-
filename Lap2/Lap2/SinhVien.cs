using System;
using System.Collections.Generic;
using System.Linq;

namespace Lap2
{
    public class SinhVien
    {
        public string Id { get; set; }
        public string HoTen { get; set; }
        public string Lop { get; set; }
        public double Diem { get; set; }

        public SinhVien(string id, string hoTen, string lop, double diem)
        {
            Id = id;
            HoTen = hoTen;
            Lop = lop;
            Diem = diem;
        }

        public override string ToString()
        {
            return $"{Id} - {HoTen} - {Lop} - {Diem:F2}";
        }
    }

    public static class SinhVienManager
    {
        private static List<SinhVien> ds = new List<SinhVien>();

        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Quan ly Sinh Vien");
                Console.WriteLine("1. Them");
                Console.WriteLine("2. Sua");
                Console.WriteLine("3. Xoa");
                Console.WriteLine("4. Tim kiem");
                Console.WriteLine("5. Sap xep");
                Console.WriteLine("6. Thong ke");
                Console.WriteLine("0. Tro ve");
                Console.Write("Chon: ");
                var c = Console.ReadLine();
                switch (c)
                {
                    case "1": Them(); break;
                    case "2": Sua(); break;
                    case "3": Xoa(); break;
                    case "4": TimKiem(); break;
                    case "5": SapXep(); break;
                    case "6": ThongKe(); break;
                    case "0": return;
                    default: Console.WriteLine("Lua chon khong hop le"); Console.ReadKey(); break;
                }
            }
        }

        private static void Them()
        {
            Console.Clear();
            Console.Write("Ma SV: "); var id = Console.ReadLine();
            Console.Write("Ho ten: "); var ten = Console.ReadLine();
            Console.Write("Lop: "); var lop = Console.ReadLine();
            Console.Write("Diem: "); if (!double.TryParse(Console.ReadLine(), out var diem)) diem = 0;
            ds.Add(new SinhVien(id, ten, lop, diem));
            Console.WriteLine("Da them."); Console.ReadKey();
        }

        private static void Sua()
        {
            Console.Clear();
            Console.Write("Nhap ma SV can sua: "); var id = Console.ReadLine();
            var sv = ds.FirstOrDefault(x => x.Id == id);
            if (sv == null) { Console.WriteLine("Khong tim thay."); Console.ReadKey(); return; }
            Console.Write($"Ho ten ({sv.HoTen}): "); var ten = Console.ReadLine(); if (!string.IsNullOrWhiteSpace(ten)) sv.HoTen = ten;
            Console.Write($"Lop ({sv.Lop}): "); var lop = Console.ReadLine(); if (!string.IsNullOrWhiteSpace(lop)) sv.Lop = lop;
            Console.Write($"Diem ({sv.Diem}): "); var d = Console.ReadLine(); if (double.TryParse(d, out var diem)) sv.Diem = diem;
            Console.WriteLine("Da cap nhat."); Console.ReadKey();
        }

        private static void Xoa()
        {
            Console.Clear();
            Console.Write("Nhap ma SV can xoa: "); var id = Console.ReadLine();
            var sv = ds.FirstOrDefault(x => x.Id == id);
            if (sv == null) { Console.WriteLine("Khong tim thay."); Console.ReadKey(); return; }
            ds.Remove(sv);
            Console.WriteLine("Da xoa."); Console.ReadKey();
        }

        private static void TimKiem()
        {
            Console.Clear();
            Console.Write("Nhap tu khoa (ma/ten/lop): "); var kw = Console.ReadLine();
            var ketqua = ds.Where(x => x.Id.Contains(kw) || x.HoTen.Contains(kw) || x.Lop.Contains(kw)).ToList();
            if (!ketqua.Any()) { Console.WriteLine("Khong co ket qua."); Console.ReadKey(); return; }
            ketqua.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Enter de tiep tuc..."); Console.ReadKey();
        }

        private static void SapXep()
        {
            Console.Clear();
            Console.WriteLine("1. Theo ten");
            Console.WriteLine("2. Theo diem giam dan");
            Console.Write("Chon: "); var c = Console.ReadLine();
            if (c == "1") ds = ds.OrderBy(x => x.HoTen).ToList();
            else if (c == "2") ds = ds.OrderByDescending(x => x.Diem).ToList();
            Console.WriteLine("Da sap xep. Danh sach:");
            ds.ForEach(x => Console.WriteLine(x));
            Console.ReadKey();
        }

        private static void ThongKe()
        {
            Console.Clear();
            Console.WriteLine($"So luong: {ds.Count}");
            if (ds.Any())
            {
                Console.WriteLine($"Diem trung binh: {ds.Average(x => x.Diem):F2}");
                Console.WriteLine("Danh sach:");
                ds.ForEach(x => Console.WriteLine(x));
            }
            Console.ReadKey();
        }
    }
}
