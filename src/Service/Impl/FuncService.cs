using AutoMapper;
using Common.Utils;
using Models;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class FuncService : BaseService<Func>, IFuncService
    {
        private readonly IMapper mapper;

        public FuncService(IBaseRepository<Func> repository, IMapper mapper) : base(repository)
        {
            this.mapper = mapper;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public bool AddFunc(FuncDTO funcDTO)
        {
            if (repository.GetAny(x => x.Id == funcDTO.Id))
            {
                throw new Exception("数据id不可重复！");
            }
            Func func = mapper.Map<FuncDTO, Func>(funcDTO);
            func.CreateUser = "admin";
            func.CreateDate = DateTimeHelper.GetDateNowInt();
            func.CreateTime = DateTimeHelper.GetTimeNowInt();
            func.LogUser = "admin";
            func.LogDate = DateTimeHelper.GetDateNowInt();
            func.LogTime = DateTimeHelper.GetTimeNowInt();
            return repository.Add(func);
        }

        public bool UpdateFunc(FuncDTO funcDTO)
        {
            if (!repository.GetAny(x => x.Id == funcDTO.Id))
            {
                throw new Exception("未找到该数据信息！");
            }
            Func func = repository.FindByID(funcDTO.Id);
            // 使用 AutoMapper 更新 FuncDTO 的属性到已存在的 Func 实体
            mapper.Map(funcDTO, func);
            func.LogUser = "admin";
            func.LogDate = DateTimeHelper.GetDateNowInt();
            func.LogTime = DateTimeHelper.GetTimeNowInt();

            return repository.Update(func);
        }

        public List<Func> GetFuncByWhere(FuncDTO funcDTO)
        {
            List<Func> list = repository.GetAllByWhere();
            if (!string.IsNullOrEmpty(funcDTO.Id))
            {
                list = repository.GetAllByWhere(x => x.Id == funcDTO.Id);
            }
            if (!string.IsNullOrEmpty(funcDTO.FuncName))
            {
                list = repository.GetAllByWhere(x => x.FuncName.Contains(funcDTO.FuncName));
            }
            if (!string.IsNullOrEmpty(funcDTO.FuncUrl))
            {
                list = repository.GetAllByWhere(x => x.FuncUrl.Contains(funcDTO.FuncUrl));
            }
            if (!string.IsNullOrEmpty(funcDTO.FuncIcon))
            {
                list = repository.GetAllByWhere(x => x.FuncIcon.Contains(funcDTO.FuncIcon));
            }
            if (!string.IsNullOrEmpty(funcDTO.ParentId))
            {
                list = repository.GetAllByWhere(x => x.ParentId.Contains(funcDTO.ParentId));
            }
            return list;
        }

        public bool BatchRemove(string[] ids)
        {
            List<Func> funcs = new List<Func>();
            foreach (var item in ids)
            {
                Func func = repository.FindByID(item);
                funcs.Add(func);
            }
            return repository.RemoveRange(funcs);
        }
    }
}