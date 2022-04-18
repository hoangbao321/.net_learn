using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;


namespace cs55_Razor_06.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public int a { get; set; } = 5;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        //Onget OnPost tùy thuộc HTTP.Request
        // Onpost trả về IActionResult

        //  localhost... ?handle=xyz
        public void OnGetXyz()
        {
            Console.WriteLine("?handle=xyz");
        }

    }
}
