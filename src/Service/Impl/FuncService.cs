using AutoMapper;
using Common.Utils;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class FuncService : BaseService<Func>, IFuncService
    {
        private readonly IMapper mapper;

        public FuncService(IBaseRepository<Func> repository, IMapper mapper) : base(repository)
        {
            this.mapper = mapper;
        }

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
            Func func = repository.FindByID(funcDTO.Id) ?? throw new Exception("未找到该数据信息！");
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

        public List<FuncVO> BuildFunc(List<Func> funcEntities, string parentId)
        {
            var menuItems = new List<FuncVO>();

            var childEntities = funcEntities.Where(e => e.ParentId == parentId).ToList();

            foreach (var entity in childEntities)
            {
                var menuItem = new FuncVO
                {
                    id = entity.Id,
                    title = entity.FuncName,
                    icon = entity.FuncIcon,
                    href = entity.FuncUrl,
                    children = BuildFunc(funcEntities, entity.Id)
                };
                if (menuItem.children.Count > 0)
                {
                    menuItem.type = "0";
                }
                else
                {
                    menuItem.type = "1";
                    menuItem.openType = "_iframe";
                }
                menuItems.Add(menuItem);
            }

            return menuItems;
        }
    }
}