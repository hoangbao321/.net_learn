using System;
using System.Linq;

namespace cs_lambda
{
    class Program
    {
        /* 
         * lamda anoynomous func , method
            1)
        
            (tham số )=> biểu thức
            (int a , int b )=> biểu thức ;
            2)
            (tham số) => 
                    {
                        các biểu thức ;
                        return bieu thuc tra ve;
                    }   
         */
        public delegate void Showlog();
        public static void xinchao() => Console.WriteLine("xin chào");
        static void Main(string[] args)
        {
            Showlog log = null;
            log = xinchao;
            log.Invoke();

            // biểu thức lamda có tham số kiểu chuỗi
            // ko có kiểu trả về void vì vậy tương đương Action kiểu chuổi
            Action<string, string> thong_bao = (msg, a) => Console.WriteLine(msg + " " + a);
            thong_bao("dasd", "dasd");

            Func<int, int, int> tinh_toan;
            tinh_toan = (a, b) => a + b;

            int[] mang = new int[] { 1, 3, 45, -10, 20, 50 };

            var so_chan = mang.Select(a =>
            {
                return Math.Sqrt(a);
            }
            );
            foreach (var i in so_chan)
            {
                Console.WriteLine(i);
            }

            mang.ToList().ForEach(k =>
            {
                    if (k % 2 == 0)
                        Console.WriteLine(k);
            }
            );
            
            var a = mang.Select(k=> 
            {
                return Math.Sqrt(k);
            }
            );
            var test = mang.Select(k=> Math.Sqrt(k) );

            
        }
    }
}
