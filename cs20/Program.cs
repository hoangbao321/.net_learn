using System;

namespace cs20
{
    public delegate void Showlog(string message);
    class Program
    {
        // delegate -biến kiểu tham chiếu được đến phương thức
        // gán được các phương thức
        static void Xinchao(string s) => Console.WriteLine($"xin chao {s}");
        static int tong(int a, int b) => a + b;

        static void tong_delegate_thamso(int a, int b, showlog log)
        {
            int kq = a + b;
            log?.Invoke($"msg: {kq}");
        }
        // có khai báo
        public delegate void showlog(string msg);
        static void Xinchao_cokhaibao(string s) => Console.WriteLine($"xin chao {s}");
        class Student : IDisposable
        {
            public string name;
            public Student(string name)
            {
                this.name = name;
                Console.WriteLine($"khoi tao: {name}");
            }
            public void thongbao() => Console.WriteLine("thong bao " + name);
            public void Dispose()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Huy " + name);
                Console.ResetColor();
            }
            //~Student()
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("Huy " +name);
            //    Console.ResetColor();
            //}
        }
        static void Test()
        {
            using Student std = new Student("Sinh vien a");
            Console.WriteLine("1");
            Console.WriteLine("2");
            Console.WriteLine("3");
        }
        public delegate int Tinh(int a, int b);
        static int tinh_tong(int a, int b) => a + b;
        public static void log_paramethes(string s, Showlog g)
        {
            int kq = 100 + 100;
            g?.Invoke($"{s} {kq}");
        }

        class Dulieunhapso : EventArgs
        {
            public int dulieunhap { get; set; }
            public Dulieunhapso(int _dulieunhap)
            {
                dulieunhap = _dulieunhap;
            }
        }
        // publisher đăng kí nhận sự kiện
        class User
        {
            public event EventHandler sukiennhapso;
            public void Input()
            {
                Console.WriteLine("Xin mời thi chu nhap so");
                int a = int.Parse(Console.ReadLine());
                // là nơi phát đi sự kiện này 
                sukiennhapso.Invoke(this, new Dulieunhapso(a));
            }
        }
        // đăng kí sự kiện nhập số 
        class TinhCan
        {
            public void Sub(User user)
            {
                user.sukiennhapso += User_sukiennhapso;
            }
            // event handler thì ( object sender , EventArg e)
            public void User_sukiennhapso(object sender, EventArgs e)
            {
                Dulieunhapso so = (Dulieunhapso)e;
                int a = so.dulieunhap;
                Console.WriteLine(a);
            }
        }
        static void Main(string[] args)
        {

            Action<string, string> thongbao = (s, y) => Console.WriteLine(s + y);

            log_paramethes("ditcumonudql1", null);
            log_paramethes("ditcumonudql1", Xinchao);

            Tinh tinh_1 = null;
            tinh_1 += tong;
            var kq_1 = tinh_1(5, 6);
            Console.WriteLine("kq : " + kq_1);

            Action<string, int> f2; // ~delegate void Kieu(string, int);
            Action<string> f1; // ~delegate void Kieu (string)
            f1 = Xinchao;
            f1.Invoke("bảo");

            Showlog log = null;
            log = Xinchao_cokhaibao;
            log.Invoke("bảo có khai báo");

            Func<int, int, int> tinh; // ~delegate int Kieu( int , int ) 
            tinh = tong;
            int kq = tinh.Invoke(5, 6);
            Console.WriteLine(kq);

            Func<string, int, double> kieu; // ~delegate double Kieu (string,int) 

            tong_delegate_thamso(5, 6, Xinchao);

            //for (int i = 0; i < 100000; i++)
            //{
            //    Student std = new Student($"sinh vien {i}");
            //    std = null;
            //}

            Test(); // Huy boi disposle khi ra khỏi hàm

            using Student std = new Student("Sinh vien a");
            std.thongbao();

            Console.WriteLine("helloooooooo");
            //thong bao Sinh vien a
            //helloooooooo
            //Huy Sinh vien a

            tong_delegate_thamso(5, 6, null);

        }
    }
}



