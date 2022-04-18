
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using cs55_Razor_06.Services;
using cs55_Razor_06.Model;
namespace cs55_Razor_06.Pages
{

    public class ProductPageModel : PageModel
    {

        //public void OnGet() 
        //{
        //    if(Request.RouteValues["id"] != null)
        //    {
        //        var id = int.Parse( Request.RouteValues["id"].ToString());
        //        ViewData["title"] = $"san pham co id: {id}";
        //    }
        //    else
        //    {
        //        ViewData["title"] = $"Danh sach san pham";
        //    }
        //}

        // lấy giá trị id luôn
        // ko cần Request.RouteValue["id"]
        //public readonly ProductServices productServices;
        //public ProductPageModel(ProductServices _productServices)
        //{
        //    productServices = _productServices;
        //}

        public ProductServices productServices { get; set; }
        public Product product { get; set; }
        public int data_from_RouteValue { get; set; }
        public ProductPageModel(ProductServices _productServices)
        {
            productServices = _productServices;
        }
        // localhost/5?sanpham=6
        // 6: Là san pham , id =5 
        // [FromRoute] 
        // [FromQuery]
        // [FromHeader]
        public void OnGet(int? id, [Bind("id","name")]Product sanpham )
        {
            //var data = this.Request.Headers.Select((headers) => $"{headers.Key}: {headers.Value}\n");
            //if (data != null)
            //{
            //    Console.WriteLine(string.Join("", data));
            //}
            Console.WriteLine($"sp_id: {sanpham.id}");
            if(sanpham.name!= null) Console.WriteLine($"sp_name: {sanpham.name}");
            else Console.WriteLine("ten null roi thang ngu ");

            
            if (id != null)
            {
                product = productServices.FindID(id.Value);
                if (product != null) ViewData["title"] = $"San pham co (id: {id}) ";
                else ViewData["title"] = $"Danh sách sản phẩm ";
            }
            else
            {
                ViewData["title"] = $"Danh sách sản phẩm";
            }
        }

        // ?handler=LastProduct1

        //public void OnGetLastProduct1()
        //{
        //    ViewData["title"] = $"Sản phẩm cuối";
        //    product = productServices.AllProduct().LastOrDefault();
        //}
        public IActionResult OnGetLastProduct1()
        {
            ViewData["title"] = $"Sản phẩm cuối";
            product = productServices.AllProduct().LastOrDefault();
            if (product != null)
            {
                return Page();
            }
            else
            {
                return this.Content("khong thay san pham");
            }
        }
        public IActionResult OnGetRemoveAll()
        {
            productServices.AllProduct().Clear();
            return RedirectToPage("ProductPage");
        }
        public IActionResult OnGetAddSP()
        {
            productServices.LoadProduct();
            return RedirectToPage("ProductPage");
        }

        // localhost/ProductPage/3?handler=DelSp
        public IActionResult OnPostDelSp(int? id)
        {
            if (id == null)
            {
                return Page();
            }
            else
            {
                var a = productServices.FindID((int)id);
                productServices.AllProduct().Remove(a);
            }
            return RedirectToPage("ProductPage", new { id = string.Empty });
        }
    }
}
