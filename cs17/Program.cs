using System;
using System.Collections.Generic;
using System.Linq;

namespace cs17
{
    class Program
    {
        // Anoymous kiểu dữ liệu vô danh
        // object thuoc tinh chi doc
        class Sinhvien
        {
            public string hoten { get; set; }
            public double namsinh { get; set; }
            public string noisinh { get; set; }
        }
        static void Main(string[] args)
        {
            var sanpham = new
            {
                name = "iphone",
                id = 6
            };

            List<Sinhvien> cacsinhvien = new List<Sinhvien>() {
                new Sinhvien() {hoten="Nam", namsinh=2000, noisinh="BD"},
                new Sinhvien() {hoten="Dan", namsinh=2001, noisinh="VT"},
                new Sinhvien() {hoten="Long", namsinh=2003, noisinh="VP"},
                new Sinhvien() {hoten="Minh", namsinh=2003, noisinh="VP"},
            };
            // thực hiện truy vấn linq
            var kq = from sv in cacsinhvien
                     where sv.hoten.Contains("o")
                     select new
                     {
                         noisinh = sv.noisinh
                     };
            foreach (var student in kq)
            {
                Console.WriteLine(student.noisinh);
            }
            // Dynamic- kiểu dữ liệu động-ko cần gán giá trị liền
            dynamic tenbien1;
            //var a;  -- lỗi ngay
            var a = 41;
        }
    }
}
