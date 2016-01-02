using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Mapping
{
    public class Article_Category:EntityBase    
    {
        [Required,StringLength(32)]
        public string ArticleId { get; set; }

          [Required, StringLength(32)]
        public string CategoryId { get; set; }
    }

}
