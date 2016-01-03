using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Areas.AdminConsole.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

        protected ActionResult ShowValidateMessage()
        {
            StringBuilder sb = new StringBuilder();
            //获取所有错误的Key
            List<string> Keys = ModelState.Keys.ToList();
            //获取每一个key对应的ModelStateDictionary

            foreach (var key in Keys)
            {
                var errors = ModelState[key].Errors.ToList();
                //将错误描述添加到sb中
                foreach (var error in errors)
                {
                    sb.AppendLine(error.ErrorMessage);
                }
            }
            return Json(new { Code = 0, Msg = sb.ToString() });
        }

        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        var url = filterContext.HttpContext.Request.Url;
        //        filterContext.HttpContext.Response.Redirect("/AdminConsole/Login?ReturnUrl=" + url);
        //    }
        //    base.OnActionExecuting(filterContext);
        //}
       
	}
}