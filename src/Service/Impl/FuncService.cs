using Models;
using Repository;

namespace Service
{
    public class FuncService : BaseService<Func>, IFuncService
    {
        public FuncService(IBaseRepository<Func> repository) : base(repository)
        {
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public bool Add(FuncDTO funcDTO)
        {
            Func func = new Func();
            func.Id = funcDTO.Id;
            func.FuncPara = funcDTO.FuncPara;
            func.FuncName = funcDTO.FuncName;
            func.FuncUrl = funcDTO.FuncUrl;
            func.FuncIcon = funcDTO.FuncIcon;
            func.PartentId = funcDTO.PartentId;
            return repository.Add(func);
        }
    }
}