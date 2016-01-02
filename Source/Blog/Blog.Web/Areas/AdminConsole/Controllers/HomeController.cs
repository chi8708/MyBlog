using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Areas.AdminConsole.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /AdminConsole/Home/
        public ActionResult Index()
        {
            return View();
        }
	}
}