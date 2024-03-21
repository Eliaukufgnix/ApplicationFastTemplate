using Common;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        protected static readonly string MS_LOGIN_USER_NAME_SESSION_KEY = "_loginUserName";
        protected static readonly string MS_LOGIN_USER_SESSION_KEY = "_loginUser";
        protected static readonly string MS_LOGIN_USER_TYPE_SESSION_KEY = "_loginUserType";

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 控制器名称
            string ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            // 动作名称
            string ActionName = filterContext.ActionDescriptor.ActionName;
            // session
            string LoginUserSession = filterContext.HttpContext.Session[MS_LOGIN_USER_SESSION_KEY] as string;
            string uri = ControllerName + "/" + ActionName;

            if (string.IsNullOrEmpty(LoginUserSession) && uri != "Home/Login" && uri != "Home/LoginVerify")
            {
                // 如果未登录，重定向到登录页面
                filterContext.Result = new RedirectResult("/Home/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }

        protected string LoginUser
        {
            get
            {
                return Session[MS_LOGIN_USER_SESSION_KEY] as string;
            }
            set
            {
                Session[MS_LOGIN_USER_SESSION_KEY] = value;
            }
        }
    }
}