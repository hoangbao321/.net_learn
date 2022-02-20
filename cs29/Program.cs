using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;

namespace cs29
{
    class Program
    {
        //asynchronous (multi thread)
        static void Dosomething(int seconds, string msg, ConsoleColor color)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{msg,20}.....start");
                Console.ResetColor();
            }
            for (int i = 1; i <= seconds; i++)
            {
                lock (Console.Out)
                {
                    // khóa toàn bộ Console thực hiện xong mới cho xài Console
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{msg,20} {i}");
                    Console.ResetColor();
                }
                Thread.Sleep(1000); // 1000 mil s =1s}
            }
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{msg,20}.....End");
                Console.ResetColor();
            }
        }
        static async Task Task2()
        {
            Task t2 = new Task(() =>
            {
               Dosomething(10, "T2", ConsoleColor.Green);
            }); // ()=> {}
            t2.Start();
            //t2.Wait(); // phải chờ cho t2 hoàn thành, nhưng làm vậy ở mỗi task sẽ khiến chạy hết t2 xong tới t3 làm vậy thì cần
                         // gì làm task cho mắc công => dùng async await
            await t2; // đợi thằng t2 làm xong, ko có giá trị trả về ở task
            Console.WriteLine("t2 Đã Hoàn Thành");
        }

        static async Task Task3()
        {
            Task t3 = new Task( (object ob) =>
            {
                string tacvu = (string)ob;
                Dosomething(6, tacvu, ConsoleColor.DarkCyan);
            }, "T3"); //(object ob) lấy string t3 argument
            t3.Start();
            await t3; // đợi thằng này làm xong
            Console.WriteLine("t3 Đã hoàn thành");
        }

        // asyn/await 
        static async Task Abc()
        {
            Task task = new Task(() =>
            {
                // cac chỉ thị
            });
            task.Start();
            await File.WriteAllTextAsync("1.txt", "haha");
            //.. 
        }

        // nếu ko có async thì nó sẽ trả về 1 cái task, return t4;
        // có async thì sẽ trả về 1 kiểu dữ liệu là kết quả của task
        static async Task<string> Task4()
        {
            Task<string> t4 = new Task<string>(() =>
            {
                Dosomething(8, "t4", ConsoleColor.DarkBlue);
                return "T4 fromddddd T4";
            });
            t4.Start();
            var kq_t4 = await t4;
            Console.WriteLine("t4 hoan thanh");
            return kq_t4;
        }
        static async Task<string> Task5()
        {
            Task<string> t5 = new Task<string>((object obj) =>
            {
               string tacvu = (string)obj;
               Dosomething(15, tacvu, ConsoleColor.Green);
               return $"{obj} from {obj}";
            }, "t5");
            t5.Start();
            var kq_t5 = await t5;
            Console.WriteLine("t5 bla bla");
            return kq_t5;
        }
        static async Task<string> Getweb(string url)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage kq = await httpClient.GetAsync(url);
            var content = await kq.Content.ReadAsStringAsync();
            return content;
        }
        static async Task Main(string[] args)
        {
            // synchronous lập trình 1 luồng
            // asynchrnous bất đồng bộ song song với nhau
            // Task demo: Task trong hàm main
            // delegate void ko trả về kết quả

            //Task t2 = new Task(
            // () =>
            // {
            //     Dosomething(10, "T2", ConsoleColor.Green);
            // });

            //t2.Start(); //thread
            //t3.Start(); //thread

            //Dosomething(10, "T1", ConsoleColor.Red);// 3 cái dosomething gần nhau thì làm lần lượt từ trên xuống dưới
            //Task.WaitAll(t2, t3);

            //Console.WriteLine("Press any key");
            //Console.ReadKey();




            // viết method
            // Task ko có value trả về
            //Task t2 = Task2();
            //Task t3 = Task3();
            //Dosomething(10, "T1", ConsoleColor.Red); // thằng này chạy thread chính 
            //// Task.WaitAll(t2, t3); // thay bằng await t2, await t3
            //await t2;
            //await t3;
            //Console.WriteLine("Press any key");
            //Console.ReadKey();




            // Task có dữ liệu trả về  kiểu string nhưng ko viết method riêng
            // ,delegate có kiểu trả về tương ứng với kiểu trả về của task
            //Task<string> t4 = new Task<string>( ()=>
            //{
            //    Dosomething(12, "T4", ConsoleColor.Blue);
            //    return "Return from T4";
            //}); //()=> return string;

            //Task<string> t5 = new Task<string>( (object ob)=> 
            //{
            //    string tacvu = (string)ob;
            //    Dosomething(14, tacvu, ConsoleColor.DarkGreen);
            //    return $"Return from {tacvu} ";
            //},"T5");

            //t4.Start();
            //t5.Start();

            //Dosomething(10, "T1", ConsoleColor.Red); // thằng này chạy thread chính hàm main

            //// vì chỗ hàm main có async rồi thì dùng await
            //// nếu ko có thì Task.WaitAll(t4,t5);
           
            //await t4;
            //await t5;

            //string kq_t4 = t4.Result; // kết quả của cái Task t4
            //string kq_t5 = t5.Result; // kết quả của cái Task t5

            //Console.WriteLine(kq_t4);
            //Console.WriteLine(kq_t5);

            //Console.WriteLine("Press any key");
            //Console.ReadKey();




            // Viết method T4 có trả về giá trị chuỗi string
            Task<string> T4 = Task4();
            Task<string> T5 = Task5();
            Dosomething(10, "T1", ConsoleColor.Red); // thằng này chạy thread chính hàm main

            var kq_t4 = await T4; // await t4,t5 để chắc chắn press any key ở cuối cùng
            var kq_t5 = await T5;

            Console.WriteLine(kq_t4);
            Console.WriteLine(kq_t5);

            Console.WriteLine("Press any key");
            Console.ReadKey();




            //Task<string> getweb = Getweb("https://xuanthulab.net");
            //Dosomething(10, "T1", ConsoleColor.Red); // thằng này chạy thread chính hàm main
            //string noidung = await getweb;
            //Console.WriteLine(noidung);
            //Console.WriteLine("Press any key");
            //Console.ReadKey();
        }
    }
}
