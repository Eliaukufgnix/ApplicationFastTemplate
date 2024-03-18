using Models;
using System.Collections.Generic;

namespace Service
{
    public interface IFuncService : IBaseService<Func>
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        bool AddFunc(FuncDTO Entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="reqData"></param>
        /// <returns></returns>
        bool UpdateFunc(FuncDTO reqData);

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="getFuncByWhere"></param>
        /// <returns></returns>
        List<Func> GetFuncByWhere(FuncDTO funcDTO);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool BatchRemove(string[] ids);
    }
}