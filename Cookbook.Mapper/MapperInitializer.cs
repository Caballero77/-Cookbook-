namespace Cookbook.Mapper
{
    using System;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;
    using AutoMapper.Configuration;

    /// <summary>
    ///     The mapper initialization helper.
    /// </summary>
    public class MapperInitializer
    {
        /// <summary>
        ///     The initialize by assembly.
        /// </summary>
        /// <param name="assembly">
        ///     The assembly.
        /// </param>
        /// <returns>
        ///     The <see cref="IMapper"/>.
        /// </returns>
        public static IMapper InitializeByAssembly(Assembly assembly)
        {
            var mapperConfigurationExpression = new MapperConfigurationExpression();
            var profileType = typeof(MapperBase);

            var profiles = assembly
                .GetTypes()
                .Where(t =>
                    profileType.IsAssignableFrom(t)
                    && t.GetConstructor(new[] { typeof(MapperConfigurationExpression) }) != null)
                .Select(map => Activator.CreateInstance(map, mapperConfigurationExpression))
                .OfType<MapperBase>();

            foreach (var mapperBase in profiles)
            {
                mapperConfigurationExpression.AddProfile(mapperBase);
            }

            var config = new MapperConfiguration(mapperConfigurationExpression);

            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        }
    }
}