using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Mapping
{
    public class Article:EntityBase
    {
        [Required,MaxLength(256)]
        public string Title { get; set; }

        [MaxLength(256)]
        public string SubTitle { get; set; }

        [Required]
        public string Content { get; set; }

        public string KeyWord { get; set; }

        public int? Hit { get; set; }

        public int? Up { get; set; }

        public int? Down { get; set; }

        public DateTime? CreateTime { get; set; }
        public DateTime? EditeTime { get; set; }

        [MaxLength(16)]
        public string Editor { get; set; }

        [NotMapped]
        public virtual ICollection<ArticleCategory> Categories { get; set; }
    }
}
