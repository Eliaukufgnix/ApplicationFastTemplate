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

        bool UpdateFunc(FuncDTO reqData);
    }
}