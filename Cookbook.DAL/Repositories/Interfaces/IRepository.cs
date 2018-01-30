namespace Cookbook.DAL.Repositories.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Cookbook.DAL.Entities;

    public interface IRepository<T>
        where T : BaseEntity
    {
        /// <summary>
        ///     Returns all entities.
        /// </summary>
        /// <returns>
        ///     The <see cref="ICollection"/>.
        /// </returns>
        ICollection<T> Get();

        /// <summary>
        ///     Returns entities by expression.
        /// </summary>
        /// <param name="expression">
        ///     The expression.
        /// </param>
        /// <returns>
        ///     The <see cref="ICollection{T}"/>.
        /// </returns>
        ICollection<T> Get(Expression<Func<IQueryable<T>, ICollection<T>>> expression);

        /// <summary>
        ///     Get entity by id.
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        /// <returns>
        ///     The <see cref="T"/>.
        /// </returns>
        T Find(int id);

        /// <summary>
        ///     Get entity by id.
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        /// <returns>
        ///     The <see cref="T"/>.
        /// </returns>
        Task<T> FindAsync(int id);

        /// <summary>
        ///     Creates new entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        void Add(T entity);

        /// <summary>
        ///     Deletes entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        void Remove(T entity);

        /// <summary>
        ///     Deletes collection of entities.
        /// </summary>
        /// <param name="entities">
        ///     The entities.
        /// </param>
        void RemoveRange(ICollection<T> entities);

        /// <summary>
        ///     Save all changes.
        /// </summary>
        /// <returns>
        ///     The <see cref="Task{int}"/>.
        /// </returns>
        Task<int> SaveChangesAsync();
    }
}