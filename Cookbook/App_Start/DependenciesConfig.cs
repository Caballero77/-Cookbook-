namespace Cookbook
{
    using System.Web.Http;

    using Cookbook.BLL.Services.Implementations;
    using Cookbook.BLL.Services.Interfaces;
    using Cookbook.DAL.Entities;
    using Cookbook.DAL.Repositories.Implementations;
    using Cookbook.Mapper;

    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;
    using Cookbook.DAL.Repositories.Interfaces;

    /// <summary>
    ///     The dependencies config.
    /// </summary>
    public static class DependenciesConfig
    {
        /// <summary>
        ///     The method for registration of dependencies.
        /// </summary>
        /// <param name="config">
        ///     The config. <see cref="HttpConfiguration"/>
        /// </param>
        public static void Register(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultLifestyle = new AsyncScopedLifestyle();

            var mapper = MapperInitializer.InitializeByAssembly(typeof(IRecipesService).Assembly);

            container.Register<IRecipesService, RecipesService>();
            container.Register<INutritionService, NutritionService>();
            container.Register<IMeasuringUnitsService, MeasuringUnitsService>();
            container.Register<IRepository<Recipe>, Repository<Recipe>>();
            container.Register<IRepository<RecipeInfo>, Repository<RecipeInfo>>();
            container.Register<IRepository<NutritionValue>, Repository<NutritionValue>>();
            container.Register<IRepository<MeasuringUnit>, Repository<MeasuringUnit>>();

            container.Register(() => mapper);

            container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}