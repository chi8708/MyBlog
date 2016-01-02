using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Mapping
{
    public class VUserInfoRole:EntityBase
    {
        public virtual UserInfo UserInfo { get; set; }

        public virtual VUserInfoRole Role { get; set; }
    }
}
