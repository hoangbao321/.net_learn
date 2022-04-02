using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace NLHBao
{
    //[ViewComponent]
    public class ProductBox : ViewComponent
    {
        /* b1:
        *     Invoke(object a) trả về chuỗi , hoặc ViewComponentresult
        *     InvokeAsync()
        *  b2:
        *      Kế thừa viewcomponnent
        *      
        */
        private List<Product> ds_product { get; set; }
        public ProductBox( ProductServices product_sv)
        {
            ds_product = product_sv.ds_product;
        }
        public IViewComponentResult Invoke(bool sapxep = true)
        {
            List<Product> _product = ds_product;
            if (sapxep == true)
            {
                _product = ds_product.OrderByDescending(p => p.Price).ToList();
            }

            //phuong thức này sẽ mở và thi hành file Default.cshtml
            return View<List<Product>>(_product);
        }
    }
}
