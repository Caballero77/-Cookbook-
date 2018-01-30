namespace Cookbook.Mapper
{
    using AutoMapper;

    /// <summary>
    ///     The base class for mapper configuration classes.
    /// </summary>
    public abstract class MapperBase : Profile
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MapperBase"/> class.
        /// </summary>
        /// <param name="configurationExpression">
        ///     The configuration expression.
        /// </param>
        protected MapperBase(IMapperConfigurationExpression configurationExpression) => this.ConfigureMaps(configurationExpression);

        /// <summary>
        ///     The maps configuration method.
        /// </summary>
        /// <param name="configurationExpression">
        ///     The configuration expression.
        /// </param>
        protected abstract void ConfigureMaps(IMapperConfigurationExpression configurationExpression);
    }
}