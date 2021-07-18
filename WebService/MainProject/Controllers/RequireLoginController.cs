using MainProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MainProject.Controllers
{
    public class RequireLoginController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (UserLogin)Session[CMConst.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Login", action = "Index", area = "" })
                    );
            }
            else
            {
                UserLogin u = (UserLogin)Session[CMConst.USER_SESSION];
                ViewBag.UserName = u.UserName;
            }
        }
    }
}
