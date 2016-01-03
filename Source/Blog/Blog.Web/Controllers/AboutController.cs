using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class AboutController : Controller
    {
        //
        // GET: /Abount/
        public ActionResult Index(string Type="A")
        {
            return View();
        }
	}
}