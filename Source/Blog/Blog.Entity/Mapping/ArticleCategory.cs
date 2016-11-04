using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Mapping
{
    public class ArticleCategory:EntityBase
    {
 
        public string ParentId{ get; set; }

        [MaxLength(64),Required]
        public string Name { get; set; }

        public byte Level { get; set; }

        public int Sort { get; set; }
        public string Remark { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? EditeTime { get; set; }

    }
}
