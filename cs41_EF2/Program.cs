using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace cs41_EF2
{
    class Program
    {
        static void CreateDatabase()
        {
            using var dbcontext = new ShopContext();
            var dbName = dbcontext.Database.GetDbConnection().Database;
            var kq = dbcontext.Database.EnsureCreated();
            if(kq)
                Console.WriteLine($"tao db {dbName} thành công");
        }
        static void DropDatabase()
        {
            using var dbcontext = new ShopContext();
            var dbName = dbcontext.Database.GetDbConnection().Database;
            var kq = dbcontext.Database.EnsureDeleted();
            if (kq)
                Console.WriteLine($"drop db: {dbName} thành công");
        }
        static void InsertDatabase()
        {
            using var dbcontext = new ShopContext();

            //Thêm category
            Category[] c1 = new Category[]
            {
                new Category(){Name="Dien thoai", Description="Cac loai dien thoai di dong"},
                new Category(){Name="Do uong", Description="Cac loai do uong"},
            };
            dbcontext.AddRange(c1);
            dbcontext.SaveChanges();

        }
        static void InsertProduct ()
        {
            using var dbcontext = new ShopContext();
            // thêm product
            var c1 = (from c in dbcontext.categories
                      where c.CateGoryID == 1
                      select c).FirstOrDefault();

            var c2 = (from c in dbcontext.categories
                      where c.CateGoryID == 2
                      select c).FirstOrDefault();

            Product[] p1 = new Product[]
            {
                new Product(){ProductName="Iphone 8",Price=1000, Category = c1},
                new Product(){ProductName="Samsung",Price=900, CateID= 1},
                new Product(){ProductName="Ruou Vang ABC",Price=500, Category = c2},
                new Product(){ProductName="Nokia Xyz",Price=600, Category = c1},
                new Product(){ProductName="Cafe ABC",Price=100, Category = c2},
                new Product(){ProductName="Nước ngọt",Price=50, Category = c2},
                new Product(){ProductName="Bia",Price=100, Category = c2},
            };
            dbcontext.AddRange(p1);
            dbcontext.SaveChanges();
        }
        static void Main(string[] args)
        {
            /*
             * 1)   Reference Navigation -> Foreign key( 1 nhiều)
             *      Collection Navigation -> Không tạo ra foreign key
             *      dùng Microsoft.EntityFrameworkCore.Proxies giúp làm 2 thằng trên nhanh
             * 2) InverseProperties    
             */

            DropDatabase();
            CreateDatabase();

            //InsertDatabase();
            //InsertProduct();



            //using var dbcontext = new ShopContext();

            //var ds_sp = dbcontext.products.ToList();
            //var ds_cate = dbcontext.categories.ToList(); j

            //var kq = ds_sp.Join(ds_cate, p => p.CategID, c => c.CateGoryID, 
            //    (p, c) => 
            //    new 
            //    { 
            //        tensp=p.ProductName,
            //        loaisp=c.Description
            //    }).ToList();

            //var kq = ( from p in dbcontext.products
            //         join c in dbcontext.categories
            //         on p.CategID equals c.CateGoryID
            //         select new
            //         {
            //             tensp = p.ProductName,
            //             loaisp = c.Description
            //         }).ToList();

            //foreach (var item in kq)
            //{
            //    Console.WriteLine(item.tensp+"--"+item.loaisp);
            //}

            //var kq_1 = ds_cate.GroupJoin(ds_sp, c => c.CateGoryID , p => p.CategID,(c,p)=>
            //new
            //{
            //   loaisp=c.Name,
            //   cacsp = p
            //});

            //foreach (var item in kq_1)
            //{
            //    Console.WriteLine(item.loaisp);
            //    foreach (var sp in item.cacsp)
            //    {
            //        Console.Write(sp+" ");
            //    }
            //    Console.WriteLine();
            //}

            /* dùng namesace .framworkcore.Proxier
            var e = dbcontext.Entry(product);
            e.Reference(e => e.Category).Load();

             Collection Navigation
            var e = dbcontext.Entry(category);
            e.Collection(e => e.Products).Load();
            */




        }
    }
}
