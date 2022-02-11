using System;
using System.Linq;
using MyLib;
namespace cs_extensionmethod
{
    //extension method
    // lớp tĩnh
    static class ABC
    {
        public static void Print(this string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            "Xin".Print(ConsoleColor.DarkGreen);
            "Chao".Print(ConsoleColor.DarkMagenta);
            "Cac".Print(ConsoleColor.Cyan);
            "Ban".Print(ConsoleColor.DarkYellow);

            double a = 2.5;
            Console.WriteLine(a.Binhphuong());
            Console.WriteLine(a.Sin());
            Console.WriteLine(a.Canbachai());
        }
    }
}
