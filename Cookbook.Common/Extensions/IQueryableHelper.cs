namespace Cookbook.Common.Extensions
{
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.Caching;
    using System.Xml;

    /// <summary>
    ///     The <c>IQueryable</c> helper.
    /// </summary>
    public static class QueryableHelper
    {
        /// <summary>
        ///     The include all method.
        /// </summary>
        /// <param name="query">
        ///     The query.
        /// </param>
        /// <typeparam name="T">
        ///     Type.
        /// </typeparam>
        /// <returns>
        ///     The <see cref="IQueryable{T}"/>.
        /// </returns>
        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> query)
            where T : class
        {
            var type = query.GetType();

            var properties = type.GetProperties();
            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.GetGetMethod().IsVirtual
                    && properties.Any(property => property.Name == propertyInfo.Name + "Id"))
                {
                    query = query.Include(propertyInfo.Name);
                }
            }

            return query;
        }
    }
}