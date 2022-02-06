using System;
using System.Collections.Generic;

namespace cs16
{
    public class product
    {
        public class Manufactory
        {
            public string name { get; set; }
            public int id { get; set; }
        }
        public Manufactory manu;
    }
    class san_pham<A>
    {
        public A id { get; set; }
        public san_pham(A id)
        {
            this.id = id;
        }
        public void Printinf()
        {
            Console.WriteLine($"id {this.id}");
        }
    }
    class Program
    {
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        static void Main(string[] args)
        {
            //san_pham a = new san_pham(5);
            //san_pham b = new san_pham(6);
            //Swap(ref a, ref b);
            //Console.WriteLine(a.id+" " +b.id);

            san_pham<double> sanpham1 = new san_pham<double>(5);
            Console.WriteLine(sanpham1.id);
            sanpham1.Printinf();
            san_pham<string> sanpham2 = new san_pham<string>("a1");
            Console.WriteLine(sanpham2.id);
            sanpham2.Printinf();
            List<int> list1 = new List<int>();
        }
    }
}
