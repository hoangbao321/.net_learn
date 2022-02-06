using cs15;
using System;


namespace cs15
{
    class Program
    {
        static void Main(string[] args)
        {
            product sp = new product();
            sp.name = "iphone";
            sp.description = "aaa";
            sp.id = 5;
            sp.abc();
            sp.manufactory = new product.Manufactory();
            sp.manufactory.name = "ccc";
            Console.WriteLine(sp.manufactory.name);
        }
    }
}
