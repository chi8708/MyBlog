using Blog.Entity.Mapping;
using Blog.Service.CondModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service
{
    public partial interface IArticleService
    {
         List<Article> GetPageWithCategory<S>(ArticleCond cond, out int total, System.Linq.Expressions.Expression<Func<Article, S>> orderLambda, bool isAsc);

         Article AddArticle(Article model, string categories);

          List<Article> GetArticleListWithCategory(List<Article> data);

          bool EditeArticle(Article model, string categories);

          Task<bool> UpdateArticleHit(Article article);
    }
}
