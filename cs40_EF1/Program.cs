using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;

namespace cs40_EF1
{
    class Program
    {
        static void CreateDatabase()
        {
            using var dbcontext = new ProductDbContext();
            var dbname = dbcontext.Database.GetDbConnection().Database;
            var kq = dbcontext.Database.EnsureCreated();

            if (kq)
            {
                Console.WriteLine($"tao kq thanh cong");
            }
            else
            {
                Console.WriteLine("tao kq ko thanh cong");
            }
        }
        static void DropDatabase()
        {
            using var dbcontext = new ProductDbContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;
            var kq = dbcontext.Database.EnsureDeleted();

            if (kq)
            {
                Console.WriteLine($"xoa database thanh cong");
            }
            else
            {
                Console.WriteLine("xoa database ko thanh cong");
            }
        }
        static void InsertDatabase()
        {
            using var dbcontext = new ProductDbContext();

            var ds_product = new Product[]
            {
                new Product() {ProductID= 1,    ProductName= "San pham 1",     Provider = "Cong ty 1" },
                new Product() {ProductID= 2,    ProductName= "San pham 2",     Provider = "Cong ty 2" },
                new Product() {ProductID= 3,    ProductName= "San pham 3",     Provider = "Cty A" },
                new Product() {ProductID= 4,    ProductName= "San pham 4",     Provider = "Cty B" },
                new Product() {ProductID= 5,    ProductName= "San pham 5",     Provider = "Cty C" },
            };

            dbcontext.AddRange(ds_product);
            // cập nhật vào db
            int number_row = dbcontext.SaveChanges();

            Console.WriteLine($"{number_row} so dong anh huong");
        }
        static void ReadProduct()
        {
            using var dbcontext = new ProductDbContext();

            //Linq
            var products = dbcontext.products.ToList();

            var product_id_4 = (from p in dbcontext.products.ToList()
                                where p.Provider=="Cty B"
                                select p).FirstOrDefault();

            Console.WriteLine((product_id_4 != null) ? product_id_4 : "ko co gia tri thoa");
        }
        static void RenameProduct(int id, string newName)
        {
            using var dbcontext = new ProductDbContext();
            var product = (from p in dbcontext.products.ToList()
                           where p.ProductID == id
                           select p).FirstOrDefault();

            if (product != null)
            {
                // DBcontext bắt đầu theo dõi đối tượng Model: Product này luôn
                // theo dõi sự thay đổi của Model: Product

                //lệnh này là đăng xuất ko theo dõi nữa
                //EntityEntry<Product> entry = dbcontext.Entry(product);
                //entry.State = EntityState.Detached;
                product.ProductName = newName;
                int dong = dbcontext.SaveChanges();
                Console.WriteLine($"da cap nhat {dong} dong du lieu");
            }
        }
        static void DeleteProduct (int id )
        {
            using var dbcontext = new ProductDbContext();
            var ds_sp = dbcontext.products.ToList();

            var product = (from p in ds_sp
                           where p.ProductID == id
                           select p).ToList();
            int dong = 0;
            if (product != null)
            {
                dong = product.Count();
                foreach (var item in product)
                {
                    dbcontext.Remove(item);
                }
            }
            dbcontext.SaveChanges();
            Console.WriteLine(dong+"dong bi anh huong");
        }
        static void Main(string[] args)
        {
            // ánh xạ đơn vị csdl vào code 
            // Entitiy dữ liệu thật
            // Entity (Database, Table)
            // Database( MSSQL) : data01
            // trong EF đối tượng biểu diễn 1 cơ sở dữ liệu kế thừa từ DbContext
            // --product

            /*  Tạo xóa database
             *   CreateDatabase();
             *   DropDatabase();
             */


            /*  Insert, Select, Update, Delete
             * InsertDatabase();
             * DeleteProduct();
             * ReadProduct();
             */
            RenameProduct(4, "Sam sung");
        }
    }
}
