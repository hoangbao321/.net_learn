using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using cs56_Razor_07.Validations;
using Microsoft.AspNetCore.Mvc;

public class CustomerInfo
{
    [DisplayName("Tên của khách hàng")]
    [Required(AllowEmptyStrings =false,ErrorMessage ="phải nhập tên không được bỏ trống")]
    [StringLength(20,MinimumLength =3,ErrorMessage ="{0} phải dài {2} tới {1} ký tự" )]
    [ModelBinder(binderType:typeof(UserNameBinding))]
    public string CustomerName { get; set; }

    [DisplayName("Email")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "phải nhập địa chỉ Email của bạn")]
    [EmailAddress(ErrorMessage ="{0} phải đặt đúng định dạng Email")]
    public string Email { get; set; }

    [DisplayName("Năm sinh")]
    [Range(1970,2010,ErrorMessage ="{0} nằm trong {1} -> {2}")]
    [sochan]
    public int? YearOfBirth { get; set; }
}

