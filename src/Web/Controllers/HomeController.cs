using Common;
using Models;
using Service;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        #region 构造函数

        private readonly ISysUserService sysUserService;
        private readonly IFuncService funcService;

        public HomeController(ISysUserService sysUserService, IFuncService funcService)
        {
            this.sysUserService = sysUserService;
            this.funcService = funcService;
        }

        #endregion 构造函数

        #region 页面

        #region 框架页面

        public ActionResult Index()
        {
            return View();
        }

        #endregion 框架页面

        #region 首页仪表盘页面
        public ActionResult DashBoard()
        {
            return View();
        }
        #endregion 首页仪表盘页面

        #region 登录页面

        public ActionResult Login()
        {
            return View();
        }

        #endregion 登录页面

        #region 注册页面

        public ActionResult SignUp()
        {
            return View();
        }

        #endregion 注册页面

        #endregion 页面

        #region 请求

        #region 登录验证
        public JsonResult LoginVerify(LoginVerifyDTO data)
        {
            try
            {
                SysUser result = sysUserService.LoginVerify(data);
                LoginUser = result.Account;
                return Json(ResultModel<SysUser>.Success(result, 0));
            }
            catch (Exception e)
            {
                return Json(ResultModel<SysUser>.Fail(e.Message));
            }
        }
        #endregion 登录验证

        #region 注销
        public JsonResult SignOut()
        {
            try
            {
                Session.Clear();
                return Json(ResultModel<string>.Success());
            }
            catch (Exception e)
            {
                return Json(ResultModel<string>.Fail(e.Message));
            }
        }
        #endregion 注销

        #region 递归生成功能菜单树

        /// <summary>
        /// 递归生成功能菜单树
        /// </summary>
        /// <returns></returns>
        public JsonResult RecursionBuildFuncTree()
        {
            try
            {
                List<FuncVO> menu = funcService.BuildFunc(funcService.GetAll(), "ROOT");
                return Json(menu);
            }
            catch (Exception e)
            {
                return Json(ResultModel<Func>.Fail(e.Message));
            }
        }

        #endregion 递归生成功能菜单树

        #endregion 请求
    }
}