using Blog.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public partial interface IArticleCommentRepository:IBaseRepository<ArticleComment>
    {
    }
}
