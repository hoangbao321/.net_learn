using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace cs32
{
    class Program
    {
        // Type - kiểu dữ liệu class struct int bool
        // Atribute: thuộc tính 1 phần cơ sở dữ liệu
        // bổ sung thuộc tính cho 1 lớp,phương thức,thong tin lấy ra sử dụng ở thời điểm thực thi
        // Reflection lớp type dùng cho kĩ thuật Reflec lấy thông tin ứng dụng tại thời điểm thực thi
        //[AttributeName(thamso)] : parathemet
        // ObsoleteAtribute : khi sử dụng ko có Atribute đằng sau làm gì
        /*
         * Mota
         *  -Thongtinchitiet
         */
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
        // Mota duoc su dung o dau ( lớp , property , method...)
        class MotaAttribute : Attribute
        {
            public string Thongtinchitiet { get; set; }
            public MotaAttribute(string _Thongtinchitiet)
            {
                Thongtinchitiet = _Thongtinchitiet;
            }
        }
        [Mota("Lop chua thong tin ve user tren he thongggg")]
        class User
        {
            [Mota("ten nguoi dung")]
            public string Name { get; set; }
            [Mota("tuoi nguoi dung")]
            public int Age { get; set; }
            [Mota("sdt nguoi dung")]
            public string Phonenumber { get; set; }
            [Mota("Email nguoi dung")]
            [Obsolete("tao dang test")]
            public string Email { get; set; }
            [Obsolete("method này ko nên sử dụng nữa, thay bằng showInfo, lỗi thời rồi")]
            // dotnet build sẽ cảnh báo
            [Mota("Method mới toanh")]
            public static void hello(string Name, int Age)
            {
                Console.WriteLine(Name + " " + Age);
            }
        }
        class User_2
        {
            //[Required(ErrorMessage ="Name phai thiet lap")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "ten phai dau tu 3 den 100 ki tu")]
            public string Name { get; set; }
            [Range(18, 80, ErrorMessage = "ten phai tu 18 -80")]
            public int Age { get; set; }
            [Phone]
            public string Phonenumber { get; set; }
            [EmailAddress(ErrorMessage = "Dia chi email sai cau truc")]
            public string Email { get; set; }
            public void hello(string Name, int Age)
            {
                Console.WriteLine(Name + " " + Age);
            }
        }
        class User_3
        {
            [Required(ErrorMessage = "chuoi phai dc thiet lap")]
            [StringLength(10, MinimumLength = 5, ErrorMessage = "chuoi phai dai")]
            public string Name { get; set; }

            //[Range(18,80,ErrorMessage ="tuoi phai nam trong khoang 18 80")]
            public int Age { get; set; }
            [Phone(ErrorMessage = "sdt chua dinh dang dung")]
            public string Phonenumber { get; set; }
            [Required(ErrorMessage = "phai co email")]
            [EmailAddress(ErrorMessage = "alalala")]
            public string Email { get; set; }
            public void hello(string Name, int Age)
            {
                Console.WriteLine(Name + " " + Age);
            }
        }
        enum hocluc
        {
            gioi = 5,
            kha,
            trungbinh
        }
        static void Main(string[] args)
        {
            //int a;
            //Type t1 = typeof(int);
            //int hl = (int)hocluc.kha;
            //Type t2 = typeof(string);
            //Console.WriteLine("kieu int: " + t1 + " kieu string: " + t2);

            //// Type c = a.GetType(); bị lỗi 
            //bool d = false;
            //Type d_get_type = d.GetType();
            //Console.WriteLine("d: " + d_get_type);

            //int[] e = { 1, 5, 6 };
            //Type e_type_of = e.GetType();
            //PropertyInfo[] info = e_type_of.GetProperties();
            //Console.WriteLine("-----------");
            //foreach (var item in info)
            //{
            //    Console.WriteLine("etypeof: "+item.GetValue(e) );
            //}

            //int[] f;
            //Type f_type_of = typeof(int[]);
            //Console.WriteLine("Name: " + f_type_of.Name + " FullName: " + f_type_of.FullName);

            //int[] f_1 = { 9, 8, 7 }; // f_1 có đối tượng
            //Type f_1_getType = f_1.GetType();
            //Console.WriteLine(f_1_getType.FullName);
            //Console.WriteLine("-----------property cac thuoc tinh");
            //f_1_getType.GetProperties().ToList().ForEach((PropertyInfo p) => Console.WriteLine(p.Name));

            //// những thuộc tính của f_1.Length, .Longlength
            //Console.WriteLine("-----------method các phương thức");
            //f_1_getType.GetMethods().ToList().ForEach((MethodInfo p) => Console.WriteLine(p.Name));

            //var f_2 = (int[])f_1.Clone();
            //f_2[1] = 5;
            //foreach (var item in f_2)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();

            //Console.WriteLine("----------truong du lieu");
            //User user = new User() { Name = "bao", Age = 26, Phonenumber = "09026222", Email = "@ngleh@gmail.com" };
            //Type user_prop = user.GetType();
            //Console.WriteLine("----------properties");
            //user_prop.GetProperties().ToList().ForEach(p => Console.WriteLine(p.Name));
            //var property = user.GetType().GetProperties();
            //foreach ( var  item  in property)
            //{
            //    string name = item.Name;
            //    var value = item.GetValue(user);
            //    Console.WriteLine(item.Name+"-"+value);
            //}

            // as
            //List<string> z = new();
            //object z_z = z;
            //List<int> z_z_z = (List<int>)z_z;
            //if( z_z_z != null)   Console.WriteLine("ok ko null");
            //else Console.WriteLine("sai roi");

            //Atribute
            User user = new User() { Name = "bao", Age = 26, Phonenumber = "a43", Email = "@ngleh@gmail.com" };

            // đọc cái attribute của lớp
            // true hay false chả thấy khác mẹ gì
            foreach (Attribute attr in user.GetType().GetCustomAttributes(false))
            {
                // Mota mota = (Mota)attr;
                MotaAttribute mota = attr as MotaAttribute;
                if (mota != null)
                {
                    Console.WriteLine($"{user.GetType().Name,10} : {mota.Thongtinchitiet}");
                }
            }

            foreach (Attribute attr in user.GetType().GetCustomAttributes(true))
            {
                MotaAttribute mota = attr as MotaAttribute;
                if (mota != null)
                {
                    Console.Write("ten class: " + user.GetType().Name);
                    Console.WriteLine("--ten lop Mota: " + mota.Thongtinchitiet);
                }
            }

            // Đọc Attribute của từng thuộc tính lớp
            foreach (PropertyInfo prop in user.GetType().GetProperties())
            {
                // Cách 1 
                Console.WriteLine("cach 1");
                foreach (var item in prop.GetCustomAttributes(true))
                {
                    MotaAttribute mota = item as MotaAttribute;
                    if (mota != null) Console.WriteLine(prop.Name + ": " + mota.Thongtinchitiet);
                }
                // Cách 2
                Console.WriteLine("cach 2");
                // GetCustomAttribute
                Console.WriteLine(prop.Name + ": " + prop.GetCustomAttribute<MotaAttribute>().Thongtinchitiet);
            }

            // Đọc Attribute của từng thuộc tính method
            // ko viết được luôn như phía trên vì GetMethods nó xét cả thuộc tính và method trong lớp
            foreach (var method in user.GetType().GetMethods())
            {
                // Cách 1 
                var cs = method.GetCustomAttribute<MotaAttribute>();
                if (cs != null)
                {
                    Console.WriteLine(method.GetCustomAttribute<MotaAttribute>().Thongtinchitiet);
                }
            }

            foreach (var m in user.GetType().GetMethods())
            {
                foreach (Attribute attr in m.GetCustomAttributes(false))
                {
                    MotaAttribute mota = attr as MotaAttribute;
                    if (mota != null)
                    {
                        Console.WriteLine($"{m.Name,10} : {mota.Thongtinchitiet}");
                    }
                }
            }

            // System.ComponentModel.DataAnotation
            //User_2 user_2 = new User_2() { Name = "bao", Age = 26, Phonenumber = "a43", Email = "@ngleh@gmail.com" };
            //ValidationContext context = new(user_2);
            //var result = new List<ValidationResult>();
            //// List kieu giao dien tu Icolection
            //bool kq = Validator.TryValidateObject(user_2, context, result, true);
            //if (kq == false)
            //{
            //    result.ToList().ForEach(er =>
            //    {
            //        Console.WriteLine(er.MemberNames.First());
            //        Console.WriteLine(er.ErrorMessage);
            //    });
            //}

            User_3 user_3 = new User_3() { Name = "bao", Age = 26, Phonenumber = "a43", Email = null };
            ValidationContext validation = new(user_3); // mo ta ngữ cảnh khi validation được thực hiện
            var result = new List<ValidationResult>(); // đưa kết quả sau khi check
            bool kq = Validator.TryValidateObject(user_3, validation, result); // check thông tin vào coi có khác với với atribute ko
            if (kq == false)
            {
                result.ToList().ForEach(er =>
                {
                    Console.WriteLine(er.ErrorMessage);
                    Console.WriteLine(er.MemberNames.First());
                });
            }
        }
    }
}
