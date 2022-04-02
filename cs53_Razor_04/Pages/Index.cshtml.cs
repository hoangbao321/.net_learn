using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace cs53_Razor_04.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //public IActionResult OnGet()
        //{
            // PageModel: Partial, ViewComponent
            // Controller: Partialview,ViewComponent

            //return Partial("_Message");
            //return ViewComponent("ProductBox");
        //}

        public IActionResult OnPost()
        {
            var name = Request.Form["username"];
            var mess = new NLHBAO_messagePage.MessagePage.Message();
            mess.urlredirect = "/Privacy";
            mess.htmlcontent = $"cam on quy khach {name} ";
            mess.secondwait = 20;
            return ViewComponent("MessagePage", mess);
        }
    }
}
