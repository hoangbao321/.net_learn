using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace cs33_DI
{
    interface Ihorn
    {
        public void Horn();
    }
    class LightHorn : Ihorn
    {
        public void Horn()
        {
            Console.WriteLine("beep -beep");
        }
    }
    class HeavyHorn : Ihorn
    {
        public void Horn()
        {
            Console.WriteLine("BEEP-BEEP");
        }
    }
    class CAR
    {
        Ihorn horn { get; set; }
        public CAR(Ihorn _horn)
        {
            this.horn = _horn;
        }
        public void Horn()
        {
            Console.WriteLine("Horn created in Car");
            horn.Horn();
        }
    }

    interface IClassB
    {
        public void ActionB();
    }
    interface IClassC
    {
        public void ActionC();
    }
    class ClassC : IClassC
    {
        public ClassC()
        {
            Console.WriteLine("Class C is created");
        }
        public void ActionC()
        {
            Console.WriteLine("Action in ClassC");
        }
    }
    class ClassC1 : IClassC
    {
        public ClassC1() => Console.WriteLine("ClassC1 is created");
        public void ActionC()
        {
            Console.WriteLine("Action in ClassC1");
        }
    }

    class ClassB : IClassB
    {
        // Phụ thuộc của ClassB là ClassC
        IClassC c_dependency;

        public ClassB(IClassC classC) => c_dependency = classC;

        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }
    class ClassB2 : IClassB
    {
        IClassC c_dependency;
        string message;
        public ClassB2(IClassC classc, string mgs)
        {
            c_dependency = classc;
            message = mgs;
            Console.WriteLine("ClassB2 is created");
        }
        public void ActionB()
        {
            Console.WriteLine(message);
            c_dependency.ActionC();
        }
    }

    class ClassA
    {
        //classB là dependency của classA
        IClassB b_dependency;
        public ClassA(IClassB classb) => b_dependency = classb;
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }


    class Horn
    {
        public int level;
        public Horn(int level) => this.level = level;
        public void Beep() => Console.WriteLine("beep - beep - beep ");
    }
    class Car
    {
        public Horn horn { get; set; }
        //inject bằng phương thức khởi tạo
        public Car(Horn _horn) => horn = _horn;
        public void Beep()
        {
            horn.Beep();
        }
    }
    class MyServiceOption
    {
        public string data1 { get; set; }
        public int data2 { get; set; }
    }
    class Service
    {
        public string data1 { get; set; }
        public int data2 { get; set; }
        // Tham số khởi tạo là IOptions, các tham số khởi tạo khác nếu có khai báo như bình thường
        // Myserviceoption khong phải là dependency mà nó chứa dữ liệu để tạo ra cái Myservice
        public Service( IOptions<MyServiceOption> option)
        {
            // Đọc được MyServiceOptions từ IOptions
            var _option = option.Value;
            data1 = _option.data1;
            data2 = _option.data2;
        }
        public void PrintInfo() => Console.WriteLine($"{data1}/{data2}");
    }
    class Program
    {
        public static ClassB2 CreateB2(IServiceProvider provider)
        {
            var b2 = new ClassB2(provider.GetService<IClassC>(), "thuc hien tai B2");
            return b2;
        }
        static void Main(string[] args)
        {
            Ihorn horn1 = new LightHorn();
            CAR cAR = new CAR(horn1);
            cAR.Horn();


            IClassC classC = new ClassC1();//new ClassC();
            IClassB classB = new ClassB(classC);
            ClassA classA = new ClassA(classB);
            classA.ActionA();


            // xây dựng dependency injection
            Horn horn = new Horn(5);
            Car car = new Car(horn);
            car.horn = horn;
            car.Beep();


            // thư viện Dependency Injection
            // Các dependency bây giờ chúng ta gọi là các service !
            // DI Container : ServiceCollection
            // ~ ServiceProvider  ~ Get service

            //Console.WriteLine("====");
            //var services = new ServiceCollection();

            // đăng kí dịch vu
            // IclassC , ClassC , ClassC1

            // Sigleton: 1 phiên bản tồn tại trong suốt vòng dời provider
            // tham số thứ 1 tên dịch vụ, tham số thứ 2 kiểu dịch vụ tạo ra 
            // dịch vụ IclassC , đối tượng classC

            //classA
            // IclassC, ClassC , classc1
            // Iclass B, classB, classB1, classB2

            //services.AddSingleton<ClassA, ClassA>();
            //services.AddSingleton<IClassB, ClassB2>(CreateB2);
            //services.AddSingleton<IClassC, ClassC>();
            //services.AddSingleton<string, string>();

            //var provider = services.BuildServiceProvider();

            //ClassA a = provider.GetService<ClassA>();
            //a.ActionA();

            ServiceCollection service = new ServiceCollection();

            // khởi tạo class Service
            service.AddSingleton<Service>();

            // khi vào class thì tiến hành config 
            //service.Configure<MyServiceOption>(
            //    (option) =>
            //    {
            //        option.data1 = "Xin chao cac ban";
            //        option.data2 = 2022;
            //    });
            //var provider = service.BuildServiceProvider();
            //Service a = provider.GetService<Service>();
            //a.PrintInfo();

            IConfigurationRoot configurationRoot;

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("cauhinh.json");
            configurationRoot = configurationBuilder.Build();

            var sectionMyserviceOption = configurationRoot.GetSection("MyServiceOption");

            //khi vào class thì tiến hành config
            service.Configure<MyServiceOption>(sectionMyserviceOption);
            
            var provider = service.BuildServiceProvider();
            Service a = provider.GetService<Service>();
            a.PrintInfo();



        }
    }
}
