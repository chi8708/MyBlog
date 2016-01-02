using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Mapping
{
    public class UserInfo_Role:EntityBase
    {
         [Required, StringLength(32)]
        public string UserId { get; set; }

          [Required, StringLength(32)]
        public string RoleId { get; set; }
    }
}
