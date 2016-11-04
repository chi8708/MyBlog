using Blog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {

        IArticleService articleBll;
        public HomeController(IArticleService bll)
        {
            if (bll != null)
            {
                this.articleBll = bll;
            }
        }
        //
        // GET: /AdminConsole/Article/
        public ActionResult Index()
        {
            int count = 0;
            var data = articleBll.LoadPageEntity(p => true, 1, 4,out count, p => p.CreateTime, false);
            ViewBag.Articles =data.ToList();
            return View();
        }
    }
}