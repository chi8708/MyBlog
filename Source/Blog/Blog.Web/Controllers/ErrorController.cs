using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web
{
    public class ErrorController : Controller
    {
        
        public ActionResult Index(string error)
        {
            //ViewData["Title"] = "WebSite 网站内部错误";
            //ViewData["Description"] = error;
            ViewBag.Message = "访问中发生了错误";
            ViewBag.Description = error;
            return View("Error");
        }
        public ActionResult HttpError404(string error)
        {
            //ViewData["Title"] = "HTTP 404- 无法找到文件";
            //ViewData["Description"] = error;
            ViewBag.Message = "HTTP 404- 无法找到文件";
            ViewBag.Description = error;

            return View();
        }
        public ActionResult HttpError500(string error)
        {
            ViewBag.Message = "HTTP 500 - 内部服务器错误";
            ViewBag.Description = error; 
            return View();
        }
        public ActionResult General(string error)
        { 
            ViewBag.Message = "HTTP 发生错误";
            ViewBag.Description = error; 
            return View("Error");
        }  


    }
}
