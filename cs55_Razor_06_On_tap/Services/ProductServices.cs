using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cs55_Razor_06.Model;

namespace cs55_Razor_06.Services
{
    public class ProductServices
    {
        private List<Product> ds_sp  = new List<Product>();
        public ProductServices()
        {
            Console.WriteLine("tạo dich vụ");
            LoadProduct();
        }
        public void LoadProduct()
        {
            ds_sp.AddRange(new Product[]
            {
                new Product()   {id=1,name="iphone" },
                new Product()   {id=2,name="motorola" },
                new Product()   {id=3,name="Samsung" },
                new Product()   {id=4,name="Oppo" },
            });
        }
        public List<Product> AllProduct() => ds_sp;
        public Product FindID(int id)
        {
            var qr = from sp in ds_sp
                     where sp.id == id
                     select sp;
            return qr.FirstOrDefault();
        }
    }
}
