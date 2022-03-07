using System;

namespace cs23
{
    public static class Extension
    {
        public static void Print(this string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            "hello".Print(ConsoleColor.DarkCyan);
            Console.WriteLine(5.Tinhbinhphuong());
            Console.WriteLine(7.Tinhbinhphuong());
            Console.WriteLine(8.Tinhbinhphuong());
        }
    }
}
