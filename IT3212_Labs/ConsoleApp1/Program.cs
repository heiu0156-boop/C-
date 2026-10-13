using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Chọn chức năng:");
                Console.WriteLine("6 - Giải phương trình bậc hai");
                Console.WriteLine("7 - Thống kê dãy số");
                Console.WriteLine("8 - In các số nguyên tố <= n");
                Console.WriteLine("9 - Đọc số từ 0 đến 99");
                Console.WriteLine("10 - Vẽ hình bằng ký tự");
                Console.WriteLine("0 - Thoát");
                Console.Write("Lựa chọn: ");
                string choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "6": SolveQuadratic(); break;
                    case "7": SequenceStatistics(); break;
                    case "8": PrintPrimesUpToN(); break;
                    case "9": ReadNumber0To99(); break;
                    case "10": DrawShapesMenu(); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
        }

        // 6. Giải phương trình bậc hai
        static void SolveQuadratic()
        {
            Console.Write("Nhập a: ");
            double a = ReadDouble();
            Console.Write("Nhập b: ");
            double b = ReadDouble();
            Console.Write("Nhập c: ");
            double c = ReadDouble();

            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0) Console.WriteLine("Phương trình có vô số nghiệm");
                    else Console.WriteLine("Phương trình vô nghiệm");
                }
                else
                {
                    double x = -c / b;
                    Console.WriteLine($"Phương trình có nghiệm duy nhất x = {x:F2}");
                }
            }
            else
            {
                double delta = b * b - 4 * a * c;
                if (delta < 0) Console.WriteLine("Phương trình vô nghiệm");
                else if (delta == 0)
                {
                    double x = -b / (2 * a);
                    Console.WriteLine($"Phương trình có nghiệm kép x = {x:F2}");
                }
                else
                {
                    double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    Console.WriteLine($"Phương trình có hai nghiệm phân biệt x1 = {x1:F2}, x2 = {x2:F2}");
                }
            }
        }

        // 7. Thống kê dãy số
        static void SequenceStatistics()
        {
            Console.Write("Nhập số lượng phần tử n: ");
            int n = ReadInt(min: 1);
            long sum = 0;
            int max = int.MinValue;
            int min = int.MaxValue;
            int evenCount = 0;
            for (int i = 1; i <= n; i++)
            {
                Console.Write($"a[{i}] = ");
                int v = ReadInt();
                sum += v;
                if (v > max) max = v;
                if (v < min) min = v;
                if (v % 2 == 0) evenCount++;
            }
            double avg = (double)sum / n;
            Console.WriteLine($"Tổng = {sum}");
            Console.WriteLine($"Trung bình = {avg:F2}");
            Console.WriteLine($"Số lớn nhất = {max}");
            Console.WriteLine($"Số nhỏ nhất = {min}");
            Console.WriteLine($"Số chẵn = {evenCount}");
        }

        // 8. In các số nguyên tố không vượt quá n
        static void PrintPrimesUpToN()
        {
            Console.Write("Nhập n: ");
            int n = ReadInt(min: 2);
            Console.WriteLine($"Các số nguyên tố <= {n}:");
            for (int i = 2; i <= n; i++)
            {
                if (IsPrime(i)) Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        static bool IsPrime(int x)
        {
            if (x < 2) return false;
            if (x == 2) return true;
            if (x % 2 == 0) return false;
            int r = (int)Math.Sqrt(x);
            for (int i = 3; i <= r; i += 2)
                if (x % i == 0) return false;
            return true;
        }

        // 9. Đọc số từ 0 đến 99 (sử dụng switch)
        static void ReadNumber0To99()
        {
            Console.Write("Nhập số (0-99): ");
            int x = ReadInt(min: 0, max: 99);
            if (x == 0) { Console.WriteLine("không"); return; }
            int tens = x / 10;
            int ones = x % 10;
            string result = "";
            switch (tens)
            {
                case 0: result = ""; break;
                case 1: result = "mười"; break;
                case 2: result = "hai mươi"; break;
                case 3: result = "ba mươi"; break;
                case 4: result = "bốn mươi"; break;
                case 5: result = "năm mươi"; break;
                case 6: result = "sáu mươi"; break;
                case 7: result = "bảy mươi"; break;
                case 8: result = "tám mươi"; break;
                case 9: result = "chín mươi"; break;
            }
            if (tens == 0)
            {
                result = ReadOnes(ones);
            }
            else if (tens == 1)
            {
                if (ones == 0) result = "mười";
                else if (ones == 5) result = "mười lăm";
                else result = "mười " + ReadOnes(ones);
            }
            else
            {
                if (ones == 0) {}
                else if (ones == 1) result += " mốt"; 
                else if (ones == 4) result += " bốn"; 
                else if (ones == 5) result += " lăm";
                else result += " " + ReadOnes(ones);
            }
            Console.WriteLine(result.Trim());
        }

        static string ReadOnes(int d)
        {
            switch (d)
            {
                case 0: return "không";
                case 1: return "một";
                case 2: return "hai";
                case 3: return "ba";
                case 4: return "bốn";
                case 5: return "năm";
                case 6: return "sáu";
                case 7: return "bảy";
                case 8: return "tám";
                case 9: return "chín";
                default: return "";
            }
        }

        // 10. Vẽ hình bằng ký tự
        static void DrawShapesMenu()
        {
            Console.WriteLine("1 - Tam giác vuông đặc");
            Console.WriteLine("2 - Tam giác vuông rỗng");
            Console.WriteLine("3 - Hình vuông rỗng");
            Console.Write("Lựa chọn: ");
            string c = Console.ReadLine();
            switch (c)
            {
                case "1": DrawFilledRightTriangle(); break;
                case "2": DrawHollowRightTriangle(); break;
                case "3": DrawHollowSquare(); break;
                default: Console.WriteLine("Không hợp lệ"); break;
            }
        }

        static void DrawFilledRightTriangle()
        {
            Console.Write("Chiều cao: ");
            int h = ReadInt(min: 1);
            for (int i = 1; i <= h; i++)
            {
                Console.WriteLine(new string('*', i));
            }
        }

        static void DrawHollowRightTriangle()
        {
            Console.Write("Chiều cao: ");
            int h = ReadInt(min: 1);
            for (int i = 1; i <= h; i++)
            {
                if (i == 1) Console.WriteLine("*");
                else if (i == h) Console.WriteLine(new string('*', h));
                else Console.WriteLine("*" + new string(' ', i - 2) + "*");
            }
        }

        static void DrawHollowSquare()
        {
            Console.Write("Kích thước cạnh: ");
            int n = ReadInt(min: 1);
            for (int i = 1; i <= n; i++)
            {
                if (i == 1 || i == n) Console.WriteLine(new string('*', n));
                else Console.WriteLine("*" + new string(' ', n - 2) + "*");
            }
        }

        // Helper input readers
        static int ReadInt(int? min = null, int? max = null)
        {
            while (true)
            {
                string s = Console.ReadLine();
                if (int.TryParse(s, out int v))
                {
                    if ((min.HasValue && v < min.Value) || (max.HasValue && v > max.Value))
                    {
                        Console.WriteLine($"Vui lòng nhập số trong khoảng {min ?? int.MinValue} - {max ?? int.MaxValue}:");
                        continue;
                    }
                    return v;
                }
                Console.WriteLine("Giá trị không hợp lệ, nhập lại:");
            }
        }

        static double ReadDouble()
        {
            while (true)
            {
                string s = Console.ReadLine();
                if (double.TryParse(s, out double v)) return v;
                Console.WriteLine("Giá trị không hợp lệ, nhập lại:");
            }
        }
    }
}