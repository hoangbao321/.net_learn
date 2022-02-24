using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
namespace cs30_linq
{
    class Program
    {
        class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public string[] Color { get; set; }
            public int Brand { get; set; }
            public Product(int _id, string _name, double _price, string[] color, int _brand)
            {
                Id = _id; Name = _name; Price = _price; Color = color; Brand = _brand;
            }
            // override định nghĩa lại , ToString() phải viết y chang vậy, kiểu trả về là kiểu string
            override public string ToString()
            {
                return $"{Id,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Color)}";
            }
        }
        class Brand
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        //  Linq : ngôn ngữ truy vấn tích hợp
        //  Nguồn dữ liệu: IEnumerable , IEnumeralbe <T> (Array , List, Stack ,Queue)// các phương thức này dùng để lọc 
        //  XML , SQL
        static void Main(string[] args)
        {
            List<Brand> brands = new List<Brand>()
            {
                new Brand(){Id =1 , Name = "Cong ty AAA"},
                new Brand(){Id =2 , Name = "Cong ty BBB"},
                new Brand(){Id =3 , Name = "Cong ty CCC"}
            };

            List<Product> products = new List<Product>()
            {
                new Product (1,     "Bàn trà",      400, new string[]{"Xám","Xanh" },        2 ),
                new Product (2,     "Tranh Treo",   400, new string[]{"Vàng","Xanh" },       1 ),
                new Product (3,     "Đèn chùm",     400, new string[]{"Xám","Xanh" },        2 ),
                new Product (4,     "Bàn học",      200, new string[]{"Đỏ","Xám","Xanh" },   1 ),
                new Product (5,     "Bàn trà",      300, new string[]{"Vàng","Xanh" },       2 ),
                new Product (6,     "Giường ngủ",   200, new string[]{"Tím" },        2 ),
                new Product (7,     "Tủ Áo",        300, new string[]{"Trắng","Xanh" },             4 ),
            };

            // lấy ra sản phẩm có giá 400 , tạo thành 1 sp mới có cú pháp khác 
            //var sp_gia_400 = from sp in products // dotnet hỗ trợ ra các câu truy vấn, gọi phương thức API, nguồn dữ liệu ở đây là product
            //                 where sp.Price == 400
            //                 select new
            //                 {
            //                     Name = sp.Name,
            //                     Id = sp.Id,
            //                 };

            // lấy ra sản phẩm có giá 400 , tạo thành 1 sp mới có cú pháp giống p 
            var sp_gia_400 = from sp in products where sp.Price == 400 select sp;
            foreach (var item in sp_gia_400)
            {
                Console.WriteLine(item.Name + " " + item.Price);
            }

            var c = products.Where(c => c.Brand == 2).Select(s => s.Name + " " + s.Price + " " + s.Id);
            Console.WriteLine("c.Brand == 2");
            foreach (var item in c)
            {
                Console.WriteLine(item);
            }

            var p_brand_2 = products.Where((p) => { return p.Brand == 2; }).Select(p => { return p.Brand + " " + string.Join(",", p.Color); });
            foreach (var item in p_brand_2)
            {
                Console.WriteLine(item);
            }

            //Select
            //Where 
            //SelectMany
            //Min Max Sum Avergae
            //Groupjoin
            //Take
            // Single or Singleordefault
            // Join
            //Groupby
            //Distinct
            //Any 
            //All
            //Cú pháp truy vấn Linq
            //var kq_qr_4 = from p in products
            //              group p by p.Price into p_qr
            //              orderby p_qr.Key descending
            //              let sl = "So luong la: " + p_qr.Count()
            //              select new
            //              {
            //                  Gia = p_qr.Key,
            //                  sp = p_qr.ToList(),
            //                  soluong = sl
            //              };

            //kq_qr_4.ToList().ForEach(p =>
            //{
            //    Console.WriteLine("giá: " + p.Gia + " " + p.soluong);
            //    p.sp.ToList().ForEach(x => Console.WriteLine(x)); //object.ToString() chạy vào cái hàm trên
            //});

            //Console.WriteLine("-----------------");
            //var kq_qr_5 = from p in products
            //              join brand in brands on p.Brand equals brand.Id
            //              select new
            //              {
            //                  ten = p.Name,
            //                  mausac = p.Color.ToList(),
            //                  thuonghieu = brand.Name
            //              };
            var kq = products.Select((p) =>
            {
                return p.Color;
            });

            //ko cần convert gì hết
            Console.WriteLine("---foreach");
            foreach (string[] item in kq)
            {
                foreach (var item_1 in item)
                {
                    Console.Write(item_1 + " ");
                }
                Console.WriteLine();
            }

            //covert to Array
            var ds = kq.ToArray();
            for (int i = 0; i < ds.Length; i++)
            {
                for (int j = 0; j < ds[i].Length; j++)
                {
                    Console.Write(ds[i][j]);
                }
                Console.WriteLine();
            }

            var kq_1 = products.Select(p =>
            {
                return new
                {
                    ten = p.Name,
                    mau_sac = p.Color
                };
            });
            foreach (var item in kq_1)
            {
                string chuoi = $"ten: {item.ten,-15} Mau:";
                foreach (var item_1 in item.mau_sac)
                {
                    chuoi += " ";
                    chuoi += item_1;
                }
                Console.WriteLine(chuoi);
            }

            //  Where
            Console.WriteLine("=====");
            var kq_2 = products.Where((p) =>
            {
                return p.Color.Contains("Xanh");
            });

            foreach (var item in kq_2)
            {
                string chuoi = $"ten: {item.Name,-15} Mau:";
                foreach (var item_1 in item.Color)
                {
                    chuoi += " ";
                    chuoi += item_1;
                }
                Console.WriteLine(chuoi);
            }

            // SelectMany
            //  var kq_3 = products.Select(p => p.Color);// generic <string[]>
            var kq_3 = products.SelectMany(p => p.Color); // trỏ vào kq_3 thì kiểu <string>
            foreach (var item in kq_3)
            {
                Console.WriteLine(item);
            }

            // Min Max Avg
            int[] num = { 1, 2, 4, 5, 6, 2, 8, 9 };
            Console.WriteLine("so chan lon nhat: " + num.Where(p => p % 2 == 0).Max());
            Console.WriteLine("tb cac so chan:" + num.Where(p => p % 2 == 0).Count());

            //var kq_s = products.Select(p => p.Price).Min();// làm hơi cồng kềnh
            var price_min = products.Min(p => p.Price);
            Console.WriteLine("gia nho nhat: " + price_min);
            var price_avg = products.Average(p => p.Price);

            //Join
            var join = products.Join(brands, p => p.Brand, b => b.Id, (pi, bo) =>
            {
                return new
                {
                    Ten = pi.Name,
                    Thuonghieu = bo.Name
                };
            });
            foreach (var item in join)
            {
                //Console.WriteLine(item.Ten + " " + item.Thuonghieu);  // kq:Bàn trà Cong ty BBB
                // Tranh Treo Cong ty AAA

                Console.WriteLine(item);
                //  kq trả về: { Ten = Bàn trà, Thuonghieu = Cong ty BBB }
                //  { Ten = Tranh Treo, Thuonghieu = Cong ty AAA }
                //  { Ten = Dèn chùm, Thuonghieu = Cong ty BBB }
                //  { Ten = Bàn h? c, Thuonghieu = Cong ty AAA }
                //  { Ten = Bàn trà, Thuonghieu = Cong ty BBB }
                //  { Ten = Giu ? ng ng ?, Thuonghieu = Cong ty BBB }
                //  { Ten = T ? Ao, Thuonghieu = Cong ty CCC }
            }

            // Groupjoin
            Console.WriteLine("---groupjoin");
            var kq_groupjoin = brands.GroupJoin(products, b => b.Id, p => p.Brand, (brand, pros) =>
                  {
                      return new
                      {
                          Tenth = brand.Name,
                          sp = pros
                      };
                  });
            foreach (var item in kq_groupjoin)
            {
                Console.WriteLine(item.Tenth);
                foreach (var sp in item.sp)
                {
                    Console.WriteLine(sp);
                }
            }

            //Take lấy 3 thằng đầu tiên
            Console.WriteLine("---take");
            var kq_take = products.Take(3);
            foreach (var item in kq_take)
            {
                Console.WriteLine(item.Name + " " + item.Brand + " " + item.Id + " " + item.Price + " ");
            }
            products.Take(2).ToList().ForEach(p => Console.WriteLine(p));

            //skip bỏ qua 3 thằng đầu tiên
            Console.WriteLine("---skip");
            products.Skip(3).ToList().ForEach(p => Console.WriteLine(p));


            // Oderby: sắp xếp tăng dần,  OrderbyDecending: sắp xếp giảm dần
            Console.WriteLine("---orderby");
            products.OrderBy(p => p.Price).ToList().ForEach(p => Console.WriteLine(p));

            // Reverse
            Console.WriteLine("---reverse");
            num.Reverse().ToList().ForEach(p => Console.WriteLine(p));

            //Groupby
            Console.WriteLine("---groupby");
            var kq_groupby = products.GroupBy(p => p.Brand);
            foreach (IGrouping<int, Product> item in kq_groupby)
            {
                Console.WriteLine("key: " + item.Key + " ");
                foreach (var i in item)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            // kq:
            //key: 2
            //  1      Bàn trà   400  2 Xám,Xanh   3     Dèn chùm   400  2 Xám,Xanh   5      Bàn trà   300  2 Vàng,Xanh   6   Giu? ng ng ? 500  2 Xám,Xanh
            //key: 1
            //  2   Tranh Treo   400  1 Vàng,Xanh   4      Bàn h?c   200  1 D ?,Xám,Xanh
            // key: 3
            //  7        T? Ao   600  3 Tr? ng

            // Distinct 
            products.SelectMany(p => p.Color).Distinct().ToList().ForEach(p => Console.WriteLine(p));
            //  kq
            //  Xám
            //  Xanh
            //  Vàng
            //  D?

            //Single ko trả về null or Single Default
            Console.WriteLine("----------single");
            var kq_single = products.SingleOrDefault(p => p.Brand == 5);
            if (kq_single == null) { Console.WriteLine("null roi"); }
            else { Console.WriteLine(kq_single.Name); }

            //Any: thuộc tính nào thỏa mãn hàm check >= 1 , return true false
            var kq_any = products.Any(p => p.Price == 700);
            Console.WriteLine(kq_any);

            //  All: tất cả cùng thỏa mãn
            var kq_all = products.All(p => p.Price > 100);
            Console.WriteLine(kq_all);

            // Count ở đây là phương thức chứ ko phải thuộc tính
            var kq_count = products.Count(p => p.Color.Length > 2);
            Console.WriteLine($"kq_count = {kq_count}");

            // câu 1 in ra ten, ten thuong hiệu sp giá trong khoang 300 400, giá giảm dần 
            Console.WriteLine("in ra ten sp giá trong khoang 300 400");
            Console.WriteLine("sap xep tùm lum");
            products.Where(p => p.Price >= 300 && p.Price <= 400).ToList().ForEach(p => Console.WriteLine(p.Brand + " " + p.Price));
            Console.WriteLine("----sap xep giam dan");
            products.Where(p => p.Price >= 300 && p.Price <= 400).OrderByDescending(p => p.Price).
               Join(brands, p => p.Brand, b => b.Id, (n, h) =>
               {
                   return new
                   {
                       Tensp = n.Name,
                       Tenth = h.Name,
                       Gia = n.Price
                   };
               }
               ).ToList().ForEach(z => Console.WriteLine(z)); ;

            // Cú pháp truy vấn Linq    
            /*
             * 1) Xác định nguồn: from tenphantu in IEnumrable 
             *   ... where, orderby 
             * 2) Lấy dữ liệu , group by
             */
            Console.WriteLine("------ truy vấn Linq");
            var kq_qr = from sp in products
                        select new
                        {
                            ten = sp.Name,
                            color = sp.Color
                        };

            foreach (var item in kq_qr)
            {
                string chuoi = item.ten + " ";
                foreach (var item_1 in item.color)
                {
                    chuoi += " ";
                    chuoi += item_1;
                }
                Console.WriteLine(chuoi);
            }


            int[] values = { 3, 2, 6, 2, 5 };
            string[] labels = { "A", "B", "A", "A", "B" };
            var searchLabel = "A";

            var results = labels.Zip(values, (label, value) => new { label, value })
                                .Where(x => x.label == searchLabel)
                                .Select(x => x.value);

            //.ToList().ForEach(p => Console.WriteLine(p)); ;

            // Console.WriteLine("dasdasdas");
            // products.Where( (p) =>
            // {
            //     p.Color.Select(x => x=="Xanh") ;
            //}).ToList().ForEach(p => Console.WriteLine(p));

            products.Select((p) =>
             {
                 foreach (var item in p.Color)
                 {
                     if (item == "Xanh")
                         return p;
                 }
                 return null;
             }).ToList().ForEach(p =>
             {
                 if (p != null) { Console.WriteLine(p); }
             }
            );

            var kqqqqqq = products.Where((p) =>
             {
                 foreach (var item in p.Color)
                 {
                     if (item == "Xanh")
                         return true;
                 }
                 return false;
             }); // chỉ có lưu thằng true ko lưu thằng false khác với select, vì chọn .Where

            var aaaaa = products.Select((p) =>
             {
                 foreach (var item in p.Color)
                 {
                     if (item == "Xanh")
                         return p;
                 }
                 return null;
             }); // lưu luôn thằng null vì là .Select

            Console.WriteLine("giá 400");
            var qr = from p in products
                     where p.Price == 400
                     select p;
            qr.ToList().ForEach(p => Console.WriteLine(p));
            //          1      Bàn trà   400  2 Xám,Xanh
            //          2   Tranh Treo   400  1 Vàng,Xanh
            //          3     Dèn chùm   400  2 Xám,Xanh
            var qr_1 = from p in products
                       where p.Price == 400
                       select new
                       {
                           ten = p.Name,
                           gia = p.Price
                       };
            qr_1.ToList().ForEach(p => Console.WriteLine(p));
            // { ten = Bàn trà, gia = 400 }
            //{ ten = Tranh Treo, gia = 400 }
            //{ ten = Dèn chùm, gia = 400 }

            Console.WriteLine("---giá nhỏ hơn 400 và có màu xanh");
            var kqqqqq = products.Where((p) =>
            {
                if (p.Price < 400)
                {
                    foreach (var item in p.Color)
                    {
                        if (item == "Xanh")
                            return true;
                    }
                }
                return false;
            });

            Console.WriteLine("select{}: ");
            var kq_qr_11 = from p in products
                           select $"{p.Brand} : {p.Name}";
            foreach (var item in kq_qr_11)
            {
                Console.WriteLine(item);
            }

            //truy vấn linq
            /*
             * 1) xác định nguồn from tenphantu in IEnumrables
             *          ...where , orderby, let tenbien = ????
             * 2) Lấy dữ liệu select, groupby
             */
            // chọn màu + giá < 400 
            var kq_qr_1 = from p in products
                          from color in p.Color
                          where p.Price < 400 && color == "Xanh"
                          orderby p.Price descending
                          select new
                          {
                              Ten = p.Name,
                              Gia = p.Price,
                              Cacmau = p.Color
                          };
            kq_qr_1.ToList().ForEach(p =>
            {
                Console.WriteLine(p.Ten + " " + p.Ten + " " + p.Gia + " " + string.Join(",", p.Cacmau));
            });

            // Nhóm sp theo giá from -> where -> orderby -> select 
            var kq_qr_2 = from p in products
                          where p.Price < 500
                          orderby p.Brand descending
                          group p by p.Brand;

            kq_qr_2.ToList().ForEach(p =>
            {
                Console.WriteLine("brand: " + p.Key);
                p.ToList().ForEach(x => Console.WriteLine(x));
            });

            // có lưu biến tạm, trong linq
            var kq_qr_3 = from p in products
                          group p by p.Price into p_br
                          orderby p_br.Key descending
                          select p_br;

            kq_qr_3.ToList().ForEach(p =>
            {
                Console.WriteLine("giá: " + p.Key);
                p.ToList().ForEach(p => Console.WriteLine(p)); //object.ToString() chạy vào cái hàm trên
            });


            var kq_qr_4 = from p in products
                          group p by p.Price into p_qr
                          orderby p_qr.Key descending
                          let sl = "So luong la: " + p_qr.Count() // let chú ý
                          select new
                          {
                              Gia = p_qr.Key,
                              sp = p_qr.ToList(),
                              soluong = sl
                          };
            kq_qr_4.ToList().ForEach(p =>
            {
                Console.WriteLine("giá: " + p.Gia + " " + p.soluong);
                p.sp.ToList().ForEach(x => Console.WriteLine(x)); //object.ToString() chạy vào cái hàm trên
            });

            var kq_10 = brands.GroupJoin(products, b => b.Id, b => b.Brand, (a, c) =>
                {
                    return new
                    {
                        ten = a.Name,
                        sp = c
                    };
                });
            kq_10.ToList().ForEach(c =>
            {
                Console.WriteLine(c.ten);
                c.sp.ToList().ForEach(c => Console.WriteLine(c));
            });

            Console.WriteLine("-----------------");
            products.Where((p) =>
           {
               foreach (var item in p.Color)
               {
                   if (item == "Xanh")
                       return true;
               }
               return false;
           })?.ToList().ForEach(x => Console.WriteLine(x));

            var qrr = from p in products
                      join brand in brands on p.Brand equals brand.Id into ax
                      from b in ax.DefaultIfEmpty()
                      select new
                      {
                          ten = p.Name,
                          gia = p.Price,
                          thuonghieu = (b != null) ? b.Name : "ko co thuong hiêu"
                      };
            qrr.ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}