using Blog.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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


        public async Task<bool> UpdateArticleHit(Article article)
        {
          
            var db = new DBSession().CurrentEFContext;
            var entry = db.Entry<Article>(article);
            article.Hit = article.Hit ?? 0;
            article.Hit += 1;
            //entry.State = EntityState.Unchanged;//**如果使用 Attach 就不需要这句
            entry.Property(p => p.Hit).IsModified = true; 
           return await db.SaveChangesAsync()>0;
        }
    }
}
