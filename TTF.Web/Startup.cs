using Autofac.Integration.WebApi;
using Owin;
using System.Web.Http;

namespace TTF.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.MapHttpAttributeRoutes();

            var builder = AutofacConfig.RegisterComponents();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseAutofacWebApi(config);

            appBuilder.UseWebApi(config);
        }
    }
}
