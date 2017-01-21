using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Mapping
{
    public class ArticleComment:EntityBase
    {
        [Required, StringLength(32)]
        public string UserId { get; set; }

        [Required, StringLength(32)]
        public string ArticleId { get; set; }

        [Required,MaxLength(1024)]
        public string Content { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? EditeTime { get; set; }


    }
}
