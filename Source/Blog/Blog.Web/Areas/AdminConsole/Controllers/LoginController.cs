using Blog.Service;
using Blog.Service.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog.Web.Areas.AdminConsole.Controllers
{
    public class LoginController : Controller
    {
        IUserInfoService bll = null;

        public LoginController(IUserInfoService bll)
        {
            this.bll = bll;
        }
        //
        // GET: /AdminConsole/Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Index(FormCollection collection)
        {
            var userName = collection["UserName"];
            var pwd = collection["Password"];
            //var isRemberMe = collection["isRemberMe"];
            //var captcha = collection["captcha"];

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(pwd))
                return Json(new { Code = 0, Msg = "验证数据不完整！" });

            try
            {

                pwd = Blog.Common.MD5Encode.MD5(Blog.Common.MD5Encode.MD5(pwd));
                var model = bll.LoadEntity(m => m.UserName.Equals(userName) && m.Password.Equals(pwd)&&m.Status==1).SingleOrDefault();

                if (null != model)
                {

                    #region 写入用户数据
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.UserName, DateTime.Now, DateTime.Now.Add(FormsAuthentication.Timeout), true, FormsAuthentication.FormsCookiePath);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                    cookie.Domain = FormsAuthentication.CookieDomain;
                    cookie.Path = ticket.CookiePath;
                    Response.Cookies.Add(cookie);
                    #endregion

                    Session["logOnAdministrator"] = model;

                    return Json(new { Code = 1, Msg = "提示：登录成功！", RedirectNow = true, RedirectUrl = string.IsNullOrEmpty(collection["ReturnUrl"]) ? Url.Action("Index", "Home") : collection["ReturnUrl"] });
                }
                else
                {
                    return Json(new { Result = 0, Msg = "提示：登录名或密码错误，请重新登录！", });
                }
            }

            catch (Exception e)
            {
                return Json(new { Code = 0, Msg = e.Message });
            }

        }
    }
}