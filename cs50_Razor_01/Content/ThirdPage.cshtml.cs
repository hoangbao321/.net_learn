using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cs50_Razor_01.Pages
{
    public class ThirdPageModel : PageModel
    {
        public int x { get; set; }
        public void OnGet()
        {
           x = 5;
        }
    }
}
