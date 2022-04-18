using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace cs55_Razor_06.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Usercontact usercontact { get; set; }=new Usercontact();

        private readonly ILogger<ContactModel> logger;
        public ContactModel(ILogger<ContactModel> _logger)
        {
            logger = _logger;
            logger.LogInformation("init contact");
        }
        public void OnGet([FromQuery]int? userID)
        {
            Console.WriteLine(this.usercontact.Email);
        }
    }
}
