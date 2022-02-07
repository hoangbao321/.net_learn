using System;

namespace cs18
{
    class Program
    {
        class Abc
        {
            public void Xinchao() => Console.WriteLine("xin chào c#");
            public void Abcinfo() => Console.WriteLine("info C#"); 
        }
        static void Main(string[] args)
        {
            // null sử dụng cho kiểu tham chiếu
            int? age;
            age = null;
            int a = 10;
            if (age != null)
            {
                int _age = (int)age;
            }
        }
    }
}
