using System;
using System.Collections.Generic;
using System.Linq;

namespace cs26
{
    class product
    {
        public int id;
        public string name;
        public product(int _id)
        {
            id = _id;
        }
    }
    enum Hocluc
    {
        kem,
        gioi,
        kha = 100,
        trungbinh
    };
    class Animal
    {
        public void info()
        {
            Console.WriteLine("animal 10 chân");
        }
    }
    class Cat : Animal
    {
        public new void info()
        {
            Console.WriteLine("cat có 4 chân");
        }
    }
    class Lophoc
    {
        public string tenlop { get; set; }
        public hocsinh[] hs;
        public class hocsinh
        {
            public string ho_ten { get; set; }
        }
    }
    class Sinhvien
    {
        public int id;
        public string ten;
    }

    interface Icongthuc
    {

        public int Chuvi();
        public int Dientich();
    }
    class Hinhchunhat : Icongthuc
    {
        public int cd { get; set; }
        public int cr { get; set; }
        public Hinhchunhat(int _cd, int _cr)
        {
            cd = _cd;
            cr = _cr;
        }
        public int Chuvi() => cd + cr;
        public int Dientich() => cd * cr;
    }
    class Hinhtamgiac : Icongthuc
    {
        public int cd { get; set; }
        public int cr { get; set; }
        public Hinhtamgiac(int _cd, int _cr)
        {
            cd = _cd;
            cr = _cr;
        }
        public int Chuvi() => cd + cr;
        public int Dientich() => cd * cr;
    }
    public delegate void Showlog(string msg);
    class A
    {
        public Showlog showlog { get; set; }
    }
    class Vector
    {
        double x;
        double y;
        public Vector(double _x, double _y)
        {
            x = _x;
            y = _y;
        }
        public void Info()
        {
            Console.WriteLine($"x={x}, y={y}");
        }
        //indexer
        public static Vector operator +(Vector a, Vector b)
        {
            double x = Math.Abs(a.x + b.x);
            double y = Math.Abs(a.y + b.y);
            Vector c = new Vector(x, y);
            return c;
        }
        public double this[int index]
        {
            set
            {
                switch (index)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    default:
                        throw new("khong co");
                }
            }
            get
            {
                switch (index)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    default:
                        throw new("may cut ");
                }
            }
        }
    }
    class Sanpham
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int ID { get; set; }
        public string Origin { get; set; }
    }
    class Program
    {
        static int Tong(int a, int b) => a + b;
        static double Tich(int a) => a * 3.14;
        static void Info(int a, int b, Showlog log)
        {
            int kq = a + b;
            log?.Invoke($"kq : {kq}");
        }
        static void Thongbao(string s) => Console.WriteLine(s);
        static void Main(string[] args)
        {
            SortedList<string, Sanpham> products = new();
            products["sp1"] = new Sanpham() { Name = "iphone X", Price = 100, ID = 1, Origin = "China" };
            products["sp2"] = new Sanpham() { Name = "Oppo", Price = 101, ID = 2, Origin = "China" };
            products["sp3"] = new Sanpham() { Name = "MSI", Price = 99, ID = 3, Origin = "Japan" };
            products["sp4"] = new Sanpham() { Name = "Lenovo", Price = 103, ID = 4, Origin = "China" };
            products.Add("sp5", new Sanpham() { Name = "Nitro5", Price = 95, ID = 5, Origin = "Acer" });

            foreach (KeyValuePair<string, Sanpham>item  in products)
            {
                var key = item.Key;
                var value = item.Value;
                Console.WriteLine(key+" "+value.Name);
            }

            for (int i = 0; i < products.Keys.Count; i++)
            {
                var sp = products[ products.Keys[i] ] ; // duyệt sản phẩm qua key
                Console.WriteLine(sp.Name );
            }

            for (int i = 0; i < products.Values.Count; i++)
            {
                var sp = products.Values[i]; // duyệt sản phẩm qua từng sản phẩm
                
            }
            products.Remove("sp3");// remove = key
            products.RemoveAt(0);


            List<Sanpham> ds_sp = new List<Sanpham>()
            {
                new Sanpham(){Name = "iphone X", Price =100, ID=1, Origin="China"},
                new Sanpham(){Name = "Oppo", Price =101, ID=2, Origin="China"},
                new Sanpham(){Name = "MSI", Price =99 , ID=3, Origin="Japan"},
                new Sanpham(){Name = "Lenovo", Price =103, ID=4, Origin="China"},
            };

            ds_sp.Sort((p1, p2) =>
            {
               if (p1.Price == p2.Price) return 0;
               if (p1.Price > p2.Price) return 1;
               return -1;
            });

            foreach (var item in ds_sp)
            {
                Console.WriteLine(item.Name + " " + item.Price);
            }

            // return IEnumreable
            var p = ds_sp.Where(x =>
            {
                return x.Origin == "China";
            });
            // return List
            var p1 = ds_sp.FindAll(x =>
            {
                return x.Origin == "China";
            });

            foreach (var item in p)
            {
                Console.Write(item.ID + " ");
            }
            for (int i = 0; i < p1.Count; i++)
            {
                Console.Write(p1[i].ID + " ");
            }

            //Vector a = new Vector(5.5, 6.5);
            //a[0] = 5;
            //a[1] = 10;
            //a.Info();
            //Vector c = a + a;
            //c.Info();
            //Console.WriteLine(5.Tinhbinhphuong());

            #region

            //Icongthuc hcn = new Hinhchunhat(5, 6);
            //Icongthuc htg = new Hinhtamgiac(7, 8);

            //var sinhvien = new
            //{
            //    ten="a",
            //    sinhnam=1989
            //};
            //Console.WriteLine(sinhvien.ten+" "+sinhvien.sinhnam);
            //List<Sinhvien> sv = new List<Sinhvien>()
            //{ 
            //    new Sinhvien(){id=1,ten="a"},
            //    new Sinhvien(){id=2,ten="b"},
            //};

            //var kq = from s in sv
            //         where s.ten == "a" && s.id == 1
            //         select new
            //         {
            //             ten = s.ten
            //         };
            //foreach (var item in kq)
            //{
            //    Console.WriteLine($"{item.ten}");
            //}

            //Lophoc lh = new();
            //lh.tenlop = "abc";
            //lh.hs = new Lophoc.hocsinh[3];
            //for (int i = 0; i < lh.hs.Length; i++)
            //{
            //    lh.hs[i] = new Lophoc.hocsinh();
            //    lh.hs[i].ho_ten = "a";
            //}

            //Cat cat = new Cat();
            //cat.info();

            //Animal animal = new();


            //Hocluc hocluc = new Hocluc();
            //hocluc = Hocluc.kha;
            //int so = (int)hocluc;

            //switch(hocluc)
            //{
            //    case Hocluc.kem:
            //        Console.WriteLine("hoc luc kem ");
            //        break;

            //}

            //int a = 5;
            //int b = 6;
            //int c = -1;
            //int max = (a > b) ? (a > c) ? a : c : (b > c) ? b : c;
            //if (a > b)
            //{
            //    if (a > c)
            //    {
            //        max = a;
            //    }
            //    else
            //    {
            //        max = c;
            //    }
            //}
            //else //a <b
            //{
            //    if (b > c)
            //    {
            //        max = b;
            //    }
            //    else // b< c
            //    {
            //        max = c;
            //    }
            //}
            //Console.WriteLine(max);

            //string s = "dasdas \t dsadas";
            //Console.WriteLine(s);

            // INTESETION SORT
            //int[] a = new int[] { 1, -1, -2, -5, 2, 0 };
            //for (int i = 1; i < a.Length; i++)
            //{
            //    int x = a[i];
            //    while (i >= 1 && x < a[i - 1])
            //    {
            //        a[i] = a[i - 1];
            //        a[i - 1] = x;
            //        i--;
            //    }
            //}
            //foreach (var item in a)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //// BINARY SEARCH 
            //int index = Class1.Binary_search(a, 0, a.Length - 1, 10);
            //Console.WriteLine("vị trí: "+index);
            #endregion
        }
    }
}
