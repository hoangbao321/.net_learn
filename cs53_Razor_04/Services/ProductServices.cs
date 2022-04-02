using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLHBao;


public class ProductServices
{
    public List<Product> ds_product { get; set; } = new List<Product>()
    {
                new Product() { Name = "Iphone X", Description = "dien thoai iphone 10", Price = 30 },
                new Product() { Name = "Samsung X10", Description = "dien thoai Samsung", Price =29 },
                new Product() { Name = "Hweiwa", Description = "dien thoai Huwai", Price = 32 },
                new Product() { Name = "Hweiwa", Description = "dien thoai Huwai", Price = 33 },
    };
}

