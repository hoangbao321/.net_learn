using System;

namespace cs20
{
    public delegate void Showlog(string message);
    class Program
    {
        // delegate -biến kiểu tham chiếu được đến phương thức
        // gán được các phương thức
        public delegate int Tinh(int a, int b);
        static void info(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{s}");
            Console.ResetColor();
        }
        static void Warning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{s}");
            Console.ResetColor();
        }
        static void Warning(string s, int a)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{s}+{a}");
            Console.ResetColor();
        }
        static int Tich(int a, int b) => a * b;
        static void Tich_delegate(int a, int b, Showlog log) 
        {
            int kq = a * b;
            log?.Invoke($"kq tich delegate: {kq}");
        }
        static void Main(string[] args)
        {
            Tinh t;
            t = Tich;
            int ket_qua = t.Invoke(5, 6);
            Console.WriteLine(ket_qua);

            Showlog log = null; // += tích hợp 2 cái khỏi khai báo lại 
            log += info;
            log += Warning;
            log += info;
            log?.Invoke("tích hợp");// gọi các method được gán với log , ? ~ if (log != null)

            // Delegate kiểu action , func 
            // không cần tạo public delegate int ... , hay public delegate void ...
            Action action; //~ delegate void kieu()
            Action<string, int> action1; //~ delegate void kieu(string, int)
            Action<string> action2;// ~ delegate void kieu(string s)
            action2 = Warning;
            action2 += Warning;
            action2 += info;
            action2.Invoke("thông báo từ action");
            action1 = Warning;
            action1.Invoke("test string int", 2);

            Func<string> f1;
            Func<int,int,int> f2;
            f2 = Tich;
            int func = f2(5, 6);

            Tich_delegate(5, 6, null);
            Tich_delegate(7, 8, info);
            Tich_delegate(7, 9, Warning);
        }
    }
}
