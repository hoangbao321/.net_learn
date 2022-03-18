using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Product
{
    public string ID { get; set; }
    public string Name { get; set; }
}
public class ProductService
{
   
    List<Product> ds_sp = new List<Product>();
    public ProductService()
    {
        Console.WriteLine("is created");
        ds_sp.AddRange(new Product[] { 
            new Product(){ID="1",Name ="Iphone"},
            new Product(){ID="2",Name ="Ipad"},
            new Product(){ID="3",Name ="Macbook"},
        });
    }
    public Product FindSP(string productID)
    {
        var sp = from p in ds_sp
                 where p.ID == productID
                 select p;

        return sp.FirstOrDefault();
    }
}

