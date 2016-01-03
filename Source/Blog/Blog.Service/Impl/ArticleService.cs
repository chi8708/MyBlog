using Blog.Entity.Mapping;
using Blog.IRepository;
using Blog.Repository;
using Blog.Repository.Impl;
using Blog.Service.CondModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Blog.Common;

namespace Blog.Service.Impl
{
    //部分类在同一个命名空间，这样一个文件对接口的实现将会影响另一个文件
    public partial class ArticleService :IArticleService
    {
        IArticleRepository dal = null;
        IArticleCategoryRepository catDal = null;
        IArticle_CategoryRepository art_catDal = null;
        public ArticleService() 
        {
            dal =new ArticleRepository();
            catDal = new ArticleCategoryRepository();
            art_catDal = new Article_CategoryRepository();
        }
        public List<Article> GetPageWithCategory<S>( ArticleCond cond, out int total, System.Linq.Expressions.Expression<Func<Article,S>> orderLambda, bool isAsc)
        {
            Expression<Func<Article,bool>> whereLambda=p=>true;
            if (!string.IsNullOrWhiteSpace(cond.CategoryId))
            {
                var artIds = art_catDal.LoadEntity(p => p.CategoryId == cond.CategoryId).Select(p=>p.ArticleId);
                whereLambda = whereLambda.And(p => artIds.Contains(p.Id));
            }
            //多次访问数据库 ，使用到遍历查询不要使用延迟加载，ToList（）减少查询次数，降低数据库压力
            var data = dal.LoadPageEntity(whereLambda, cond.PageIndex, cond.PageSize, out total, orderLambda, isAsc).ToList();

            return GetArticleListWithCategory(data);
        }

        public List<Article> GetArticleListWithCategory(List<Article> data)
        {
            var artId = data.Select(p => p.Id);

            var art_cats = art_catDal.LoadEntity(p => artId.Contains(p.ArticleId)).ToList();
            var art_catIds = art_cats.Select(p => p.CategoryId);
            var cats = catDal.LoadEntity(p => art_catIds.Contains(p.Id)).ToList();

            foreach (var item in data)
            {
                item.Categories = (from a in cats
                                   from b in art_cats
                                   where a.Id == b.CategoryId && b.ArticleId == item.Id
                                   select a).ToList();
            };

            return data.ToList();
        }


        public Article AddArticle(Article model,string categories)
        {
            
            model.CreateTime= model.EditeTime = DateTime.Now;
            using (TransactionScope ts = new TransactionScope())
            {
                model = dal.AddEntity(model);
                var cats = categories.Split(',');
                if (cats != null && cats.Count() > 0)
                {
                    cats.ToList().ForEach(p =>
                    {
                        art_catDal.AddEntity(new Article_Category { CategoryId = p, ArticleId = model.Id });
                    });
                }

                DBSession.SaveChanges();
                ts.Complete();
                return model;
            }
        }

        public bool EditeArticle(Article model, string categories) 
        {
            model.EditeTime = DateTime.Now;
            using (TransactionScope ts = new TransactionScope())
            {
                dal.UpdateEntity(model);
                var cats = categories.Split(',');
                if (cats != null && cats.Count() > 0)
                {
                    if (cats!=model.Categories.Select(p=>p.Id))
                    {
                        dal.DeleteArt_CatByArtId(model.Id);

                        cats.ToList().ForEach(p =>
                        {
                            art_catDal.AddEntity(new Article_Category { CategoryId = p, ArticleId = model.Id });
                        });
                    }
                }

                DBSession.SaveChanges();
                ts.Complete();
                return true;
            }
        }


        public async Task<bool> UpdateArticleHit(Article article)
        {
            return await dal.UpdateArticleHit(article);
        }
    }
}
