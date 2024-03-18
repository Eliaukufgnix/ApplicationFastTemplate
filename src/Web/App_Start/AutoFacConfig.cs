using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Models;
using System.Reflection;
using System.Web.Mvc;

namespace Web.App_Start
{
    public class AutoFacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            builder.RegisterType<ApplicationDBContext>().AsSelf();
            builder.Register(c => AutoMapperConfig.RegisterAutoMapper()).As<IMapper>().SingleInstance();
            Assembly repository = Assembly.Load("Repository");
            builder.RegisterAssemblyTypes(repository).Where(t => !t.IsAbstract).AsImplementedInterfaces().PropertiesAutowired();
            Assembly service = Assembly.Load("Service");
            builder.RegisterAssemblyTypes(service).Where(t => !t.IsAbstract).AsImplementedInterfaces().PropertiesAutowired();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}