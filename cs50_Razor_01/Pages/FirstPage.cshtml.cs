using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cs50_Razor_01.Pages
{
    public class FirstPageModel : PageModel
    {
        //Post
        //Get
        //Get , Url?handler=Xyz
        public string title { get; set; } = "Hello 30/3/2022";
        public int x { get; set; }
        public void OnGet()
        {
            ViewData["title"] = "dasdasdasdad";
            ViewData["mydata"] = "Hello 30/3/2022";
            x = 5;
            Console.WriteLine("truy van get");
        }
     
        public void OnGetXyz()
        {
            ViewData["mydata"] = "Hello 30/3/2022 from Ongetxyz";
            Console.WriteLine("truy van get from Ongetxyz");
        }
        public string Welcome(string name)
        {
            return $"Chào mừng {name} đến website";
        }
    }
}
