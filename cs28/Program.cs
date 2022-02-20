using System;
using System.IO;
using System.Text;

namespace cs28
{
    class Program
    {
        static void ListfileDirectory(string filepath)
        {
            string[] file = Directory.GetFiles(filepath);
            foreach (var item in file)
            {
                Console.WriteLine(item);
            }
            string[] directories = Directory.GetDirectories(filepath);
            foreach (var item in directories)
            {
                Console.WriteLine(item);
                ListfileDirectory(item);
            }
        }
        class Product
        {
            public int Id { get; set; }
            public double Price { get; set; }
            public string Name { get; set; }
            public void Save(Stream stream)
            {
                //int -> 4 bytes
                byte[] byte_id = BitConverter.GetBytes(Id);
                stream.Write(byte_id, 0, 4);

                //double -> 8 byte
                byte[] byte_price = BitConverter.GetBytes(Price);
                stream.Write(byte_price, 0, 8);

                byte[] bytes_name = Encoding.UTF8.GetBytes(Name);
                var bytes_length = BitConverter.GetBytes(bytes_name.Length);
                stream.Write(bytes_length, 0, 4);
                stream.Write(bytes_name, 0, bytes_name.Length);
            }
            public void Restore(Stream stream)
            {
                //int -> 4 bytes
                byte[] bytes_id = new byte[4];
                stream.Read(bytes_id,0,4);
                Id = BitConverter.ToInt32(bytes_id, 0);

                //double -> 8 byte
                byte[] byte_price = new byte[8];
                stream.Read(byte_price, 0, 8);
                Price = BitConverter.ToDouble(byte_price, 0);
                
                //Length dòng chữ
                byte[] bytes_length = new byte[4];
                stream.Read(bytes_length, 0, 4);
                int s_Length = BitConverter.ToInt32(bytes_length,0);
                // đọc string
                byte[] bytes_Name = new byte[s_Length];
                stream.Read(bytes_Name, 0, s_Length);
                Name = Encoding.UTF8.GetString(bytes_Name, 0, s_Length);
            }
        }
        static void Main(string[] args)
        {
            //string path = "Abc";
            ////Directory.Delete("du_lieu"); // xóa folder tên du_lieu
            ////Directory.CreateDirectory(path);//tạo folder tên ABC
            //if (Directory.Exists(path))
            //{
            //    Console.WriteLine($"{path} -ton tai");
            //}
            //else Console.WriteLine($"{path}-ko ton tai");

            //string path_1 = "obj";
            //// liệt kê toàn bộ file trong
            //// file có file bên trong thì ko gọi 
            //string[] file = Directory.GetFiles(path_1);
            //Console.WriteLine("-------Get files");
            //foreach (var item in file)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("---------get directories--");
            //string[] directories = Directory.GetDirectories(path_1);
            //foreach (var item in directories)
            //{
            //    Console.WriteLine(item);
            //}

            //string path = "obj";
            //ListfileDirectory(path);

            Console.WriteLine(Path.DirectorySeparatorChar);
            var path = Path.Combine("dir1", "dir2", "text.txt");
            path = Path.ChangeExtension(path, "md");

            Console.WriteLine(Path.GetDirectoryName(path)); //dir1\dir2
            Console.WriteLine(Path.GetFileName(path)); // text.md
            Console.WriteLine(Path.GetExtension(path)); // .md
            var path_1 = "abc\\New folder\\text.txt"; // đường dẫn tương đối ráp với lệnh pwd (cmd line) ra đường dẫn tuyệt đối
            Console.WriteLine(Path.GetFullPath(path_1)); // D:\.net_learn\cs28\abc\New folder\text.txt


            string filename = "du_lieu\\dangnhap.txt"; // phải tạo folder dữ liệu trước mới tạo file bên trong được
            string content = "Hoàng Bảo, Xin chào các bạn\n Hello Hello";
            File.WriteAllText(filename, content);

            string[] noi_dung = File.ReadAllLines(filename);
            foreach (var nd in noi_dung)
            {
                Console.WriteLine(nd);
            }

            //Stream
            //string path_2 = "data.txt";
            //using var stream = new FileStream(path_2, FileMode.Create);

            //byte[] buffer = { 1, 2, 3, 4 };
            //int offset = 0;
            //int count = 4;
            //stream.Write(buffer, offset, count);

            //// Doc du lieu tu 1 stream dang mo
            //int sobytedocduoc = stream.Read(buffer, offset, count);

            ////int double -> bytes
            //int abc = 251231;
            //byte [] byte_abc = BitConverter.GetBytes(abc);
            ////byte to int
            //int a  = BitConverter.ToInt32(byte_abc, 0);

            //string s = "ABC";
            //var bytes_s = Encoding.UTF8.GetBytes(s);

            Product product = new Product();
            //{
            //    Id = 1,
            //    Price = 5.1,
            //    Name = "abc"
            //};
            string path_2 = "data.txt"; //D:\.net_learn\cs28\data.txt
            //using var stream = new FileStream(path_2, FileMode.Create);
            //product.Save(stream);
            using var stream = new FileStream(path_2, FileMode.Open);
            product.Restore(stream);
            Console.WriteLine(product.Name + " " + product.Id + " " + product.Price);
        }
    }
}
