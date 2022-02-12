using System;
using System.IO;
namespace cs_exception
{
    class Program
    {
        static void Register(string name, int age)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("TEN KHAC RONG");
            }
            if (age < 18 || age >= 100)
            {
                Exception e = new Exception("tuoi phai lon hon 18 tuoi");
                throw e;
            }
            Console.WriteLine($"Xin chao {name} {age} ");
        }
        static void Main(string[] args)
        {
            //try
            //{
            //    Register("abc", 20);
            //}
            //catch (DivideByZeroException e1)
            //{
            //    Console.WriteLine(e1.Message);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            try
            {
                string path = "du_lieu\\1.txt";
                string s = File.ReadAllText(path);
                Console.WriteLine(s);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
