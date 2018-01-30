namespace Cookbook
{
    using System.Web.Http;

    /// <summary>
    ///     The web api configuration.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        ///     Web api configurations.
        /// </summary>
        /// <param name="config">
        ///     The config. <see cref="HttpConfiguration"/>
        /// </param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional } );
        }
    }
}
