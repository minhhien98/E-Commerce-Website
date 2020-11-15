using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.Authentication
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Tài khoản:")]
        public string UserName { get; set; }
        [Required]
        [Display(Name ="Mật khẩu:")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}