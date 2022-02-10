using System;

namespace cs_event
{
    class Program
    {
        /*
                Pulisher -> class -> phát sự kiện
                Subcriber -> class -> nhận sự kiện
        */

        // Khái báo delegate
        public delegate void Sukiennhapso(int x);
        // phát đi sự kiện publisher
        class Userinput
        {
            //public Sukiennhapso sukiennhapso;// trường dữ liệu, lúc này sẽ ko gán được
            public Sukiennhapso sukiennhapso { get; set; } // thuộc tínnh
            public void Input()
            {
                do
                {
                    Console.Write("nhap so: ");
                    string s = Console.ReadLine();
                    int i = Int32.Parse(s);
                    sukiennhapso?.Invoke(i);
                }
                while (true);
            }
        }
        class Tinhcan
        {
            public void Sub(Userinput input)
            {
                input.sukiennhapso += Can;
            }
            public void Can(int i)
            {
                Console.WriteLine($"can bac 2 cua so i là {Math.Sqrt(i)}");
            }
        }
        class Tinhbinhphuong
        {
            public void Sub(Userinput input)
            {
                input.sukiennhapso += null;
            }
            public void tinhbinhphuong(int i)
            {
                Console.WriteLine($"bac 2 cua so i là {i * i}");
            }
        }
        static void Main(string[] args)
        {
            //publisher 
            Userinput userinput = new Userinput();

            // biểu thức lamada gán cho biến kiểu delegate
            userinput.sukiennhapso += (x) =>
            {
                Console.WriteLine(x);
            };

            Tinhcan tinhcan = new Tinhcan();
            tinhcan.Sub(userinput);

            Tinhbinhphuong tinhbinhphuong = new Tinhbinhphuong();
            tinhbinhphuong.Sub(userinput);

            userinput.Input();
        }
    }
}
