using Blog.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Impl
{
    public partial class ArticleRepository:IArticleRepository
    {
        public bool DeleteArt_CatByArtId(string articleId)
        {
            var db=new DBSession().CurrentEFContext;
            var set = db.Set<Article_Category>();
            
            var data=set.Where(p=>p.ArticleId==articleId);
            set.RemoveRange(data);
            db.SaveChanges();
            return true;
        }
    }
}
