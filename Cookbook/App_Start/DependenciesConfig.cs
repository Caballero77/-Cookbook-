namespace Cookbook
{
    using System.Web.Http;

    using Cookbook.DAL;

    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;

    public static class DependenciesConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultLifestyle = new AsyncScopedLifestyle();

            container.Register<CookbookDb>();

            container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}