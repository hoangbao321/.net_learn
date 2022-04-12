using Microsoft.EntityFrameworkCore;
using System;

namespace cs43_EF4
{
    class Program
    {
        static void CreateDatabase()
        {
            using var dbcontext = new webContext();
            var dbname = dbcontext.Database.GetDbConnection().Database;
            var kq = dbcontext.Database.EnsureCreated();
            Console.WriteLine((kq==true)?$"{dbname} tao thanh cong" : "tao that bai"   );
        }
        static void DropDatabase()
        {
            using var dbcontext = new webContext();
            var dbname = dbcontext.Database.GetDbConnection().Database;
            var kq = dbcontext.Database.EnsureDeleted();
            Console.WriteLine((kq == true) ? $"{dbname} drop thanh cong" : "drop that bai");
        }
        static void Main(string[] args)
        {
            /*
             * Migration: cách thức tạo cập nhật viết code để biểu diễn Model xong cập nhật trên
             * database
             */

            /*
             * dotnet ef migrations add V0 (tạo 1 migration)
             * dotnet ef migrations list (liệt kê migration)
             * 
             * 
             * dotnet ef migrations remove (remove cái migrations mới nhất)
             * dotnet ef database update (create database)
             * dotnet ef database drop -f (drop database)
             * 
             * dotnet ef migrations script Name1 Name2 // xem câu truy vấn từ 1 -> 2
             * dotnet ef migrations script -o migrations.sql
             */


        }
    }
}
