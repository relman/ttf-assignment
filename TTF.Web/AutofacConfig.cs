using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using TTF.Services;

namespace TTF.Web
{
    public class AutofacConfig
    {
        static ContainerBuilder _builder;

        public static ContainerBuilder RegisterComponents()
        {
            _builder = new ContainerBuilder();
            // Register Controllers
            _builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // Register Services
            _builder.RegisterType<MappingListService>()
                .As<IMappingListService>();
            _builder.RegisterType<ActivatorService>()
                .As<IActivatorService>();
            _builder.RegisterType<MappingFilterService>()
                .As<IMappingFilterService>();
            _builder.RegisterType<OutputFactory>()
                .As<IOutputFactory>();
            _builder.RegisterType<MappingService>()
                .As<IMappingService>();

            return _builder;
        }
    }
}
