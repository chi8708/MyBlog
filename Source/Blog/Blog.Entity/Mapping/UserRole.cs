using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Mapping
{
    public class UserRole:EntityBase
    {
        [Required]
        public string Name { get; set; }
        public string Remark { get; set; }
    }
}
