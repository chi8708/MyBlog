using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Web.Models
{
    public class AccountVW
    {
        [Required(ErrorMessage="用户名必填")]
        public string UserName { get; set; }

       [Required(ErrorMessage = "密码必填")]
        public string Password { get; set; }
    }
}