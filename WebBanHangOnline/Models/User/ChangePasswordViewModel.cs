using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.User
{
    public class ChangePasswordViewModel
    {
        [Required]
        [MinLength(5)]
        public string OldPassword { get; set; }
        [Required]
        [MinLength(5)]
        public string NewPassword { get; set; }
    }
}