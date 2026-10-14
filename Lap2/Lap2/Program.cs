using System;
using System.Collections.Generic;

// 6. Lớp SanPham
// 7. Lớp TaiKhoanNganHang
// 8. Lớp NhanVien
// 9. Lớp HinhChuNhat
// 10. Ứng dụng quản lý sinh viên Console

namespace Lap2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. SanPham ");
                Console.WriteLine("2. TaiKhoanNganHang ");
                Console.WriteLine("3. NhanVien ");
                Console.WriteLine("4. HinhChuNhat ");
                Console.WriteLine("5. Quan ly SinhVien");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon: ");
                var key = Console.ReadLine();
                switch (key)
                {
                    case "1": DemoSanPham(); break;
                    case "2": DemoTaiKhoan(); break;
                    case "3": DemoNhanVien(); break;
                    case "4": DemoHinhChuNhat(); break;
                    case "5": SinhVienManager.Run(); break;
                    case "0": return;
                    default: Console.WriteLine("Lua chon khong hop le..."); Console.ReadKey(); break;
                }
            }
        }

        static void DemoSanPham()
        {
            Console.Clear();
            Console.Write("Ma san pham: "); var ma = Console.ReadLine();
            Console.Write("Ten san pham: "); var ten = Console.ReadLine();
            Console.Write("Don gia: "); decimal donGia = ReadDecimal();
            Console.Write("So luong: "); int soLuong = ReadInt();
            try
            {
                var sp = new SanPham(ma, ten, donGia, soLuong);
                Console.WriteLine(sp);
                Console.WriteLine($"Thanh tien: {sp.ThanhTien():N0}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }
            Console.WriteLine("Enter de tiep tuc..."); Console.ReadKey();
        }

        static void DemoTaiKhoan()
        {
            Console.Clear();
            Console.Write("So tai khoan: "); var so = Console.ReadLine();
            Console.Write("Ten chu tai khoan: "); var ten = Console.ReadLine();
            Console.Write("So du ban dau: "); decimal soDu = ReadDecimal();
            var acc = new TaiKhoanNganHang(so, ten, soDu);
            Console.WriteLine("Chon thao tac: 1-Nap, 2-Rut, 3-Chuyen");
            var c = Console.ReadLine();
            try
            {
                switch (c)
                {
                    case "1":
                        Console.Write("So tien nap: "); acc.NapTien(ReadDecimal());
                        Console.WriteLine("Nap tien thanh cong."); break;
                    case "2":
                        Console.Write("So tien rut: "); if (acc.RutTien(ReadDecimal())) Console.WriteLine("Rut thanh cong."); 
                        else Console.WriteLine("Khong du tien."); break;
                    case "3":
                        Console.Write("So tai khoan dich: "); var so2 = Console.ReadLine();
                        Console.Write("Ten chu tk dich: "); var ten2 = Console.ReadLine();
                        Console.Write("So tien chuyen: "); var amt = ReadDecimal();
                        var acc2 = new TaiKhoanNganHang(so2, ten2, 0);
                        if (acc.ChuyenTien(acc2, amt))
                        {
                            Console.WriteLine("Chuyen tien thanh cong.");
                            Console.WriteLine(acc);
                            Console.WriteLine(acc2);
                        }
                        else Console.WriteLine("Khong du tien de chuyen.");
                        break;
                    default: Console.WriteLine("Khong hop le."); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }
            Console.WriteLine("Trang thai tai khoan: "); Console.WriteLine(acc);
            Console.WriteLine("Enter de tiep tuc..."); Console.ReadKey();
        }

        static void DemoNhanVien()
        {
            Console.Clear();
            Console.Write("Ten nhan vien: "); var ten = Console.ReadLine();
            Console.Write("Luong co ban: "); var lcb = ReadDecimal();
            Console.Write("He so: "); var hs = ReadDecimal();
            Console.Write("Phu cap: "); var pc = ReadDecimal();
            try
            {
                var nv = new NhanVien(ten, lcb, hs, pc);
                Console.WriteLine(nv);
                Console.WriteLine($"Luong: {nv.TinhLuong():N0}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }
            Console.WriteLine("Enter de tiep tuc..."); Console.ReadKey();
        }

        static void DemoHinhChuNhat()
        {
            Console.Clear();
            Console.Write("Chieu dai: "); var dai = ReadDouble();
            Console.Write("Chieu rong: "); var rong = ReadDouble();
            try
            {
                var h = new HinhChuNhat(dai, rong);
                Console.WriteLine($"Chu vi: {h.ChuVi()}, Dien tich: {h.DienTich()}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }
            Console.WriteLine("Enter de tiep tuc..."); Console.ReadKey();
        }

        static decimal ReadDecimal()
        {
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out var v)) return v;
                Console.Write("Nhap so hop le: ");
            }
        }

        static int ReadInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out var v)) return v;
                Console.Write("Nhap so nguyen hop le: ");
            }
        }

        static double ReadDouble()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out var v)) return v;
                Console.Write("Nhap so hop le: ");
            }
        }
    }
}
