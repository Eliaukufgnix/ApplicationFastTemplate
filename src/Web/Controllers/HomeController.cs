using Common;
using Models;
using Service;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        #region 构造函数

        private readonly IFuncService func;

        public HomeController(IFuncService func)
        {
            this.func = func;
        }

        #endregion 构造函数

        #region 页面

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #endregion 页面

        #region 请求

        #region 递归生成功能菜单树

        /// <summary>
        /// 递归生成功能菜单树
        /// </summary>
        /// <returns></returns>
        public JsonResult RecursionBuildFuncTree()
        {
            try
            {
                List<FuncVO> menu = func.BuildFunc(func.GetAll(), "ROOT");
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