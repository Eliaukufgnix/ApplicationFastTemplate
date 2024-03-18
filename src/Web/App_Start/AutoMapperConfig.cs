using AutoMapper;
using Models;

namespace Web.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper RegisterAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile<AutoMapperProfile>();
                cfg.CreateMap<FuncDTO, Func>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}