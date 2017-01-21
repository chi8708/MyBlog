using Blog.Entity.Mapping;
using Blog.Service;
using Blog.Service.CondModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace Blog.Web.Controllers
{
    public class ArticleController : Controller
    {
        IArticleService articleBll = null;
        IArticleCategoryService catBll = null;
        public ArticleController(IArticleService articleBll,IArticleCategoryService catBll) 
        {
            this.articleBll = articleBll;
            this.catBll = catBll;
        }
        //
        // GET: /Article/
        public ActionResult Index(ArticleCond cond)
        {
            int count=0;
            ViewBag.Categories = catBll.LoadEntity(p => p.ParentId == "0").OrderBy(p=>p.Sort).ToList();
            var data = articleBll.GetPageWithCategory(cond, out count, p => p.CreateTime, false);
            ViewBag.PageList = new PagedList<Article>(data, cond.PageIndex,cond.PageSize, count);
            return View();
        }

        public async Task<ActionResult> Detail(string id) 
        {
            var data = articleBll.LoadEntity(p=>p.Id==id);
            if (data==null||data.Count()<=0)
            {
               return RedirectToAction("HttpError404", "Error");
            }
            var model = data.Single();
            await articleBll.UpdateArticleHit(model);
            return View(model);
        }
	}
}