using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace cs56_Razor_07.Pages
{
    public class ContactModel : PageModel
    {
        /* 
        *   C1 : tránh customerInfo = null 
        *   [BindProperty(SupportsGet =true)]
        *   public CustomerInfo customerInfo { get; set; }
        *   C2:
        *   public CustomerInfo customerInfo { get; set; } = new();
        */

        //C3: nhưng khi cái này = null thì ko cho hiện cái thông tin, khỏi null niếc gì
        public CustomerInfo customerInfo { get; set; }
        public static int Tinhtong(int a) => a + 25;
        public string thongbao { get; set; }

        private readonly IWebHostEnvironment env;
        public ContactModel(IWebHostEnvironment _env)
        {
            env = _env;
        }


        //[BindProperty]
        //[DataType(DataType.Upload)]
        //[Required(ErrorMessage = "Chon 1 file Upload")]
        //[CheckFileExtensions(Extensions = "jpg,png,gif")]
        //[DisplayName("File upload")]
        //public IFormFile Fileupload { get; set; }

        [BindProperty]
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Chon file upload")]
        [CheckFileExtensions(Extensions = "jpg,png,gif")]
        [DisplayName("file Uploads")]
        public IFormFile[] Fileuploads { get; set; }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            if (ModelState.IsValid)// phù hợp
            {
                if (Fileuploads != null)
                {
                    /* C1
                    var file_name = Fileupload.FileName;
                    string filepath = @$"wwwroot/uploads/{file_name}";
                    FileInfo file = new FileInfo(filepath);
                    if (file.Exists==false)
                    {
                        using (var stream = new FileStream(filepath, FileMode.CreateNew))
                        {
                            Fileupload.CopyTo(stream);
                        }
                    }
                    */

                    //if (Fileupload != null)
                    //{
                    //    var filepath = Path.Combine(env.WebRootPath, "uploads", Fileupload.FileName);
                    //    FileInfo file = new FileInfo(filepath);
                    //    if (file.Exists == false)
                    //    {
                    //        using (var stream = new FileStream(filepath, FileMode.CreateNew))
                    //        {
                    //            Fileupload.CopyTo(stream);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        thongbao = "File đã tồn tại";
                    //    }
                    //}
                }
                thongbao = "";
                if (Fileuploads.Count() > 0)
                {
                    foreach (var file in Fileuploads)
                    {
                        var filepath_1 = Path.Combine(env.WebRootPath, "uploads", file.FileName);
                        FileInfo file_1 = new FileInfo(filepath_1);
                        if (file_1.Exists == false)
                        {
                            using (var stream = new FileStream(filepath_1, FileMode.CreateNew))
                            {
                                file.CopyTo(stream);
                            }
                        }
                        else
                        {
                            thongbao += $"File  {file.FileName} đã tồn tại\n";
                        }
                    }
                }

            }

        }
    }
}


