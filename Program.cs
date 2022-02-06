using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using hoc_json;
using System.Text;



//public class Root
//{
//    public string source_code { get; set; }
//    public string code { get; set; }
//    public string name { get; set; }
//    public List<Dictionary<string,float>> data { get; set; }
//}
public class Zzz
{
    public int ccc { get; set; }
    public int SubValue { get; set; }
}

public class C
{
    public int Value { get; set; }
    public List<Zzz> zzz { get; set; }
}

public class Root
{
    public int a { get; set; }
    public string b { get; set; }
    public List<C> c { get; set; }
}
class Count
{
    public int c = 1;
}
class Student : IDisposable
{
    public string name;
    public Student(string name)
    {
        this.name = name;
        Console.WriteLine($"khoi tao: {name}");
    }

    public void Dispose()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine($"huy {name}");
        Console.ResetColor();
    }
    //~Student()
    //{
    //    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    //    Console.WriteLine($"huy {name}");
    //    Console.ResetColor();
    //}
}
class Animal
{
    public Animal()
    {
        Console.WriteLine("khoi tao lop animal");
    }
    public Animal(string abc)
    {
        Console.WriteLine($"khoi tao lop animal contructor {abc}");
    }
    public int Leg { get; set; }
    public float Weight { get; set; }
    public void Showleg ()
    {
        Console.WriteLine($"so chan: {Leg}");
    }
}
class Cat : Animal
{
    public string Food;
    public Cat(string s) : base(s)
    {
        this.Leg = 4;
        this.Food = "Mouse";
        this.Showleg();
        Console.WriteLine($"khoi tao lop cat {s}");
    }

    public void Eat()
    {
        Console.WriteLine($"thuc an loai meo: {Food}");
    }
    public new void Showleg()
    {
        Console.WriteLine($"loai meo co so chan: {Leg}");
    }
    public void Showinfo()
    {
        base.Showleg();
        Showleg();
    }
}
class Program
{
    #region
    static void dem(Count A)
    {
        A.c++;
    }
    static void binh_phuong(int a, ref int kq)
    {
        kq = a * a;
        Console.WriteLine(kq);
    }
    static void Test()
    {
        using Student sv = new Student("ten");
    }
    #endregion
    static void Main(string[] args)
    {
        Cat cat = new Cat();
        




        //string file_parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        //string file_path = file_parent + "\\Du_lieu\\file_1.json";
        //StreamReader f = new StreamReader(file_path);
        //string content = f.ReadLine();
        //f.Close();
        //var my_list = JsonConvert.DeserializeObject<Root>(content);
        //Console.WriteLine(my_list.data.Count);
        //foreach ( var item in my_list.data)
        //{
        //    foreach (KeyValuePair<string, float> a in item)
        //    {
        //        Console.WriteLine(a.Key+" "+a.Value);
        //    }
        //}

        //string file_parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        //string file_path = file_parent + "\\Du_lieu\\file_2.json";
        //StreamReader f = new StreamReader(file_path);
        //string content = f.ReadLine();
        //f.Close();
        //var my_list = JsonConvert.DeserializeObject<Root>(content);

        //var z = new Zzz() { ccc = 2, SubValue = 4 };
        //var c = new C
        //{
        //    Value = 5,
        //    zzz = new List<Zzz>(),
        //};
        //c.zzz.Add(z);
        //my_list.c.Add(c);

        //// học dictionary
        //List<array> matran = new();
        //array arr = new array();
        //arr.A = new int[3] { 4, 5, 6 };
        //matran.Add(new array() { A = new int[3] { 4, 5, 6 } });

        //List<array_1> matran_1 = new();
        //array_1 arr_1 = new array_1();
        ////arr_1.A = new Dictionary<string, int>();
        ////arr_1.A.Add("Bao", 1);
        ////matran_1.Add(arr_1);

        //matran_1.Add(new array_1() { A = new Dictionary<string, int> { { "bao", 1 }, { "bao_1", 1 } } });
        //for (int i = 0; i < matran_1.Count; i++)
        //{
        //    for (int j = 0; j < matran_1[i].A.Count; j++)
        //    {
        //        var element = matran_1[i].A.ElementAt(j);
        //        Console.WriteLine(element.Key + " " + element.Value);
        //    }
        //}
    }
}
