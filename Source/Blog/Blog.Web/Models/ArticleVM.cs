using Blog.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft;

namespace Blog.Web.Models
{
    public class ArticleVM
    {
        public ArticleVM() 
        {
            if (string.IsNullOrWhiteSpace(Id))
            {
                Id = Guid.NewGuid().ToString("N");
            }
        }
        public string Id { get; set; }

        [Required(ErrorMessage="必填"), MaxLength(256)]
        public string Title { get; set; }

        [MaxLength(256)]
        public string SubTitle { get; set; }

        [Required(ErrorMessage = "必填")]
        public string Content { get; set; }

        public string KeyWord { get; set; }

        public int? Hit { get; set; }

        public int? Up { get; set; }

        public int? Down { get; set; }

        public DateTime? CreateTime { get; set; }
        public DateTime? EditeTime { get; set; }

        [MaxLength(16)]
        public string Editor { get; set; }

        [Required(ErrorMessage="选择类别")]
        public string Category { get; set; }
        public virtual List<ArticleCategoryVM> Categories { get; set; }
    }

    public class ArticleCategoryVM
    {
        public string Id { get; set; }
        public string ParentId{ get; set; }
        public string Name { get; set; }

        public byte Level { get; set; }

        public int Sort { get; set; }
        public string Remark { get; set; }
        
        public DateTime? CreateTime { get; set; }
        public DateTime? EditeTime { get; set; }
    }
}