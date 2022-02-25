using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using XTL_Utils_alabala;
namespace cs31
{
    public class Root_1
    {
        public /*List<Dictionary<string, float>> */ Dictionary<string, float>  [] data { get; set; }
    }
    // Root_1
    //{
    //  "data": [
    //    {
    //      "A": 3.96
    //    },
    //    {
    //    "A": 3.96
    //    },
    //    {
    //    "A": 3.96
    //    }
    //  ]
    //}
    public class Root_2
    {
        public float Id { get; set; }
    }

    // Root_2
    //[
    //  {
    //    "Id": 3.96
    //  },
    //  {
    //    "Id": 3.96
    //  },
    //  {
    //    "Id": 3.96
    //  }
    //]
    public class Root_5
    {
        public G[] data;
    }
    public class G
    {
        public float A;
    }
    //{
    //  "data": [
    //    {
    //      "A": 3.96
    //    },
    //    {
    //    "A": 3.96
    //    },
    //    {
    //    "A": 3.96
    //    }
    //  ]
    //}
    class Program
    {
        // dotnet restore: thêm 1 hay loại bỏ hoặc package bị lỗi  => để kiểm tra phục hồi
        // trong quá trình tải thư viện bị lỗi khiến dự án ko chính xác nữa
        // dotnet add tenduan.csproj tenthuviencanthamchieuden
        // gõ lên pwd=> tenduan.csproj : D:\.net_learn\cs31\cs31.csproj
        // tenthuvienthamchieu: D:\.net_learn\Utils\Utils.csproj
        class Root_3
        {
            public ProductB[] sp1;
            public ProductB[] sp2;
        }
        class ProductB
        {
            public float Name { get; set; }
            public float So { get; set; }
        }
        //{
        //  "sp1": 
        //  [
        //    {
        //      "Name": 3.96,
        //      "So": 1
        //    },
        //    {
        //      "Name": 3.96,
        //      "So": 2
        //    }
        //  ],
        //  "sp2":
        //  [
        //    {
        //      "Name": 3.96,
        //      "So": 3
        //    }
        //  ]
        //}
        class Root_4
        {
            public float Name { get; set; }
            public float[] So { get; set; }
        }
        //        [
        //  {
        //    "Name": 3.96,
        //    "So": [
        //      1,
        //      2
        //    ]
        //    },
        //  {
        //    "Name": 3.96,
        //    "So": [
        //      1,
        //      2
        //    ]
        //}
        //]
        class Product
        {
            public string Name { get; set; }
            public DateTime Expiry { get; set; }
            public string[] Size { get; set; }
        }
        static void Main(string[] args)
        {
            string json = @"
            {
                ""Name"":""Dien thoai iphone"",
                ""Expiry"": ""2021-1-30T00:00:00"",
                ""Size"" :[""Large"",""Small""]
            }";

            var sp = JsonConvert.DeserializeObject<Product>(json);
            Console.WriteLine(sp.Name+" "+sp.Expiry+" "+string.Join(",",sp.Size));

            var chuoi = Utils.NumberToText(1222232);
            Console.WriteLine(chuoi);
            Utils.Hello();


          
            //Product product = new Product();
            //product.Name = "Apple";
            //product.Expiry = new DateTime(2008,12,28);
            //product.Sizes = new string[] { "Small" };

            //var s = JsonConvert.SerializeObject(product);
            //Console.WriteLine(s);

            //string path = ".\\data.json";
            //var file = new StreamReader(path);
            //var content = file.ReadToEnd();
            //var sp = JsonConvert.DeserializeObject<Root_1>(content);
            //var l = sp.data.ToArray();
            //for (int i = 0; i < l.Length; i++)
            //{
            //    foreach (KeyValuePair<string, float> item in l[i])
            //    {
            //        Console.WriteLine(item.Key);
            //    }
            //}

            //string path = ".\\data.json";
            //var file = new StreamReader(path);
            //var content = file.ReadToEnd();
            //var sp_2 = JsonConvert.DeserializeObject<Root_2[]>(content);

            //string path = ".\\data.json";
            //var file = new StreamReader(path);
            //var content = file.ReadToEnd();
            //var sp_2 = JsonConvert.DeserializeObject<Root_3>(content);

            //foreach (var item in sp_2.sp2)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //string path = ".\\data.json";
            //var file = new StreamReader(path);
            //var content = file.ReadToEnd();
            //var sp_2 = JsonConvert.DeserializeObject<Root_4[]>(content);
            //foreach (var item in sp_2)
            //{
            //    Console.WriteLine(item.Name);
            //    foreach (var item_1 in item.So)
            //    {
            //        Console.WriteLine(item_1);
            //    }
            //}

            //string path = ".\\data.json";
            //var file = new StreamReader(path);
            //var content = file.ReadToEnd();
            //var sp_2 = JsonConvert.DeserializeObject<Root_5>(content);


            //Dictionary<string, ProductA> sp = new()
            //{
            //    ["c"] = new ProductA() { Name = "3", Code = 4 }
            //};
            //sp.Add("A", new ProductA() { Name = "3", Code = 4 });
            //sp.Add("B", new ProductA() { Name = "3", Code = 4 });

        }
    }
}
