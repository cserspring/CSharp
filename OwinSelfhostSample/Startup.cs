namespace OwinSelfhostSample
{
    using Owin;
    using System.Web.Http;

    class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for Self-Host
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}
