using Common;
using Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class FuncController : BaseController
    {
        #region 构造函数

        private readonly IFuncService funcService;

        public FuncController(IFuncService funcService)
        {
            this.funcService = funcService;
        }

        #endregion 构造函数

        #region 页面

        #region 首页页面

        public ActionResult Index()
        {
            return View();
        }

        #endregion 首页页面

        #region 详情页面

        public ActionResult Detail(string id = null)
        {
            ViewBag.Id = id;
            return View();
        }

        #endregion 详情页面

        #endregion 页面

        #region 请求

        #region 条件查询

        public JsonResult GetFuncByWhere(FuncDTO funcDTO)
        {
            try
            {
                List<Func> data = funcService.GetFuncByWhere(funcDTO);
                ResultModel<List<Func>> result = ResultModel<List<Func>>.Success(data, data.Count());
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(ResultModel<List<Func>>.Fail(e.Message));
            }
        }

        #endregion 条件查询

        #region 获取菜单数据列表

        public JsonResult GetFunc(int page, int limit)
        {
            try
            {
                List<Func> data = funcService.Pagination(page, limit, out int count);
                ResultModel<List<Func>> result = ResultModel<List<Func>>.Success(data, count);
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(ResultModel<Func>.Fail(e.Message));
            }
        }

        #endregion 获取菜单数据列表

        #region 获取单个数据详情信息

        public JsonResult GetFuncById(string Id)
        {
            try
            {
                Func data = funcService.FindByID(Id);
                ResultModel<Func> result = ResultModel<Func>.Success(data, 1);
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(ResultModel<Func>.Fail(e.Message));
            }
        }

        #endregion 获取单个数据详情信息

        #region 添加菜单数据

        public JsonResult AddFunc(FuncDTO reqData)
        {
            try
            {
                funcService.AddFunc(reqData);
                ResultModel<Func> result = ResultModel<Func>.Success();
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(ResultModel<Func>.Fail(e.Message));
            }
        }

        #endregion 添加菜单数据

        #region 删除菜单数据-单个

        public ActionResult Remove(string id)
        {
            try
            {
                funcService.RemoveByWhere(x => x.Id == id);
                ResultModel<Func> result = ResultModel<Func>.Success("删除成功");
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(ResultModel<Func>.Fail(e.Message));
            }
        }

        #endregion 删除菜单数据-单个

        #region 删除菜单数据-批量

        public JsonResult BatchRemove(string[] ids)
        {
            try
            {
                funcService.BatchRemove(ids);
                ResultModel<List<Func>> result = ResultModel<List<Func>>.Success("批量删除成功！");
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(ResultModel<Func>.Fail(e.Message));
            }
        }

        #endregion 删除菜单数据-批量

        #region 修改菜单数据

        public JsonResult UpdateFunc(FuncDTO reqData)
        {
            try
            {
                funcService.UpdateFunc(reqData);
                ResultModel<Func> result = ResultModel<Func>.Success();
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(ResultModel<Func>.Fail(e.Message));
            }
        }

        #endregion 修改菜单数据

        #region 绑定下拉框数据-父节点

        public JsonResult BindSelectDataPartentId()
        {
            try
            {
                List<Func> data = funcService.GetAll();
                List<SelectListItem> list = new List<SelectListItem>();
                foreach (var item in data)
                {
                    list.Add(new SelectListItem { Value = item.Id, Text = item.FuncName });
                }
                ResultModel<List<SelectListItem>> result = ResultModel<List<SelectListItem>>.Success(list, list.Count());
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(ResultModel<Func>.Fail(e.Message));
            }
        }

        #endregion 绑定下拉框数据-父节点

        #endregion 请求
    }
}