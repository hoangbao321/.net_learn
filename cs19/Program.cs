using System;
using System.Linq;
using System.Collections.Generic;

namespace cs19
{
    class Program
    {
        class Student
        {
            public void Xinchao()
            {
                Console.WriteLine("hello");
            }
        }
        //virtual method
        abstract class product
        {
            protected double price { get; set; }
            //public void productinfo()
            //{
            //    Console.WriteLine($"gia san pham {price}");
            //}
            void Abc() => Console.WriteLine("sdsa");
            int tong(int a, int b) => a + b;
            public void Test() => productinfo();
            public abstract void productinfo();
        }
        abstract class iphone : product
        {
            public override void productinfo()
            {
                Console.WriteLine($"gia san pham abstract: {price}");
            }
            public iphone() => price = 50;
            //override - nạp chồng phương thức 
            //public override void productinfo()
            //{
            //    Console.WriteLine("dt iphone");
            //    base.productinfo();
            //}
            public void test_2() => xinchao();
            public abstract void xinchao();
        }
        class a : iphone
        {
            public override void xinchao()
            {
                Console.WriteLine("hellsssssso");
            }
        }
        // interface 
        interface Icongthuc
        {
            public double chuvi();
            public double dientich();
        }
        interface Idientich
        {
            public double dientich_2();
        }
        //triển khai 
        class Hinhchunhat:Icongthuc,Idientich
        {
            public double a { get; set; }
            public double b { get; set; }
            public Hinhchunhat(double a , double b)
            {
                this.a = a;
                this.b = b;
            }
            public double chuvi() => a + b;

            public double dientich() => a * b;

            public double dientich_2() => 2 * a + 2 * b;
           
        }
        class Hinhtron: Icongthuc
        {
            public double r { get; set; }
            public Hinhtron(double r)
            {
                this.r = r;
            }
            public double chuvi() => r * Math.PI;
            public double dientich() => r * r * Math.PI;
        }
        static void Main(string[] args)
        {
            Student sv1 = new Student();
            var sv2 = sv1;
            sv1 = null; // ko tham chiếu đến ai 
            sv2.Xinchao();//sv2 vẫn bình thường

            //iphone a = new iphone();
            //a.Test();

            a A = new a();
            A.test_2();

            Icongthuc h = new Hinhchunhat(5.7,5.8); // new Hinhtron(5.5);
            Console.WriteLine(h.chuvi()+" "+h.dientich());

            Idientich g = new Hinhchunhat(5.7, 5.8);


            iphone dt = new a();
            dt.Test();
        }
    }
}
