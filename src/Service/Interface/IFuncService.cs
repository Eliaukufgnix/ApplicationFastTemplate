using Models;

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
        bool Add(FuncDTO Entity);
    }
}