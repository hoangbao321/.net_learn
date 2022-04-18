using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


public class Usercontact
{
    ///Contact.html?userID=dasd&Email=231&Username=23123
    //[BindProperty(SupportsGet =true)]

    [BindProperty(SupportsGet = true)]
    [FromQuery]
    [DisplayName("ur id")]
    [Range(1, 100, ErrorMessage = "nhap sai roi")]
    public int userID { get; set; }

    [BindProperty]
    [EmailAddress(ErrorMessage = "vui long co ki tu @, Emaiul sai định dạng")]
    public string Email { get; set; }

    [BindProperty]
    [DisplayName("Ten UserName của bạn")]
    [StringLength(3)]
    public string Username { get; set; }
}
