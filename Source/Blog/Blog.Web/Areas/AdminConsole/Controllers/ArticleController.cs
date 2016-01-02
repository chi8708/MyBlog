using Blog.Common;
using Blog.Entity.Mapping;
using Blog.Service;
using Blog.Service.CondModel;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;
using System.Transactions;
using System.Text;
using AutoMapper;

namespace Blog.Web.Areas.AdminConsole.Controllers
{
    public class ArticleController : BaseController
    {
        IArticleService bll;
        IArticleCategoryService catBll;
        IArticle_CategoryService art_catBll;
        public ArticleController(IArticleService bll, IArticleCategoryService catBll, IArticle_CategoryService art_catBll)
        {
            if (bll != null)
            {
                this.bll = bll;
                this.catBll = catBll;
                this.art_catBll = art_catBll;
            }
        }
        //
        // GET: /AdminConsole/Article/
        public ActionResult Index(ArticleCond cond)
        {
            int count = 0;
            var data = bll.GetPageWithCategory(p => true, cond.PageIndex, cond.PageSize, out count, p => p.CreateTime, false);
            ViewBag.PageList = new PagedList<Article>(data, cond.PageIndex, cond.PageSize, count);
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Cats = GetCategories();

            return View();
        }

        private List<ArticleCategory> GetCategories()
        {
            return catBll.LoadEntity(p => p.IsDeleted == false).OrderBy(p => p.Sort).ToList();
        }

        [HttpPost]
        public ActionResult Add(ArticleVM viewModel, FormCollection form)
        {

            if (!ModelState.IsValid)
            {
                return ShowValidateMessage();
            }
            var cats = form["Category"].Split(',');
            var model = viewModel.MapTo<Article>();
            model.CreateTime = model.EditeTime = DateTime.Now;
            bll.AddArticle(model, form["Category"]);

            return Json(new { Code = 1, Msg = "添加成功", RedirectUrl = "/AdminConsole/Article/Index" });


        }

        public ActionResult Edite(string id)
        {
            ViewBag.Cats = GetCategories();

            var model = bll.LoadEntity(p => p.IsDeleted == false && p.Id == id).Single();
            model = bll.GetArticleListWithCategory(new List<Article>() { model }).Single();
            
            ArticleVM viewModel=new ArticleVM();
             Mapper.CreateMap<Article,ArticleVM>().ForMember("Categories",p=>p.Ignore());
             viewModel= Mapper.Map<ArticleVM>(model);
             viewModel.Categories =model.Categories.MapToList<ArticleCategoryVM>();
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edite(ArticleVM viewModel, FormCollection form)
        {
            if (!ModelState.IsValid)
            {
                return ShowValidateMessage();
            }
            var cats = form["Category"].Split(',');
            var model = viewModel.MapTo<Article>();
            model.EditeTime = DateTime.Now;
            bll.EditeArticle(model, form["Category"]);

            return Json(new { Code = 1, Msg = "编辑成功", RedirectUrl = "/AdminConsole/Article/Index" });
        }

        [HttpPost]
        public ActionResult Delete(FormCollection form, string[] ids) 
        {
            if (ids==null||ids.Length<=0)
            {
             return Json(new { Code = 0, Msg = "删除项不能为空"});
            }
            List<Article> articles = new List<Article>();
            foreach (var id in ids)
            {
                articles.Add(new Article() { Id = id});
            }
            bll.BatchDelteEntity(articles);
            return Json(new { Code = 1, Msg = "删除成功", RedirectUrl = "/AdminConsole/Article/Index" });

        }

       
        public ActionResult CategoryList()
        {
            return View();
        }
    }
}