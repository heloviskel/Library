using System;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace MyLibrary.Filter
{
    public class CustomAuthAttribute : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // если пользователь не принадлежит роли admin, то он перенаправляется на Home/About
            bool auth = filterContext.HttpContext.User.IsInRole("admin");
            if (!auth)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary {
                { "controller", "Home" }, { "action", "Index" }
                });
            }
        }
    }
    public class LocalAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.Request.IsLocal || base.AuthorizeCore(httpContext);
        }
    }
}