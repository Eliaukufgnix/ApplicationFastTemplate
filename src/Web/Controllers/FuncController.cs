using Common;
using Models;
using Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class FuncController : Controller
    {
        private readonly IFuncService func;

        public FuncController(IFuncService func)
        {
            this.func = func;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

        public JsonResult GetFunc(int page, int limit)
        {
            List<Func> data = func.Pagination(page, limit, out int count);
            ResultModel<List<Func>> result = ResultModel<List<Func>>.Success(data, count);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddFunc(FuncDTO funcDto)
        {
            ResultModel<Func> result = func.Add(funcDto) == true ? ResultModel<Func>.Success() : ResultModel<Func>.Fail();
            return Json(result);
        }
    }
}