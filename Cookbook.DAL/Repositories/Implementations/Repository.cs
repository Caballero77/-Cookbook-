namespace Cookbook.DAL.Repositories.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    
    using Cookbook.DAL.Entities;
    using Cookbook.DAL.Repositories.Interfaces;

    /// <summary>
    ///     The repository.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        /// <summary>
        ///     The DbSet fot entities.
        /// </summary>
        private readonly DbSet<T> entities;

        /// <summary>
        ///     DbContext.
        /// </summary>
        private readonly DbContext db;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="db">
        ///     DbContext.
        /// </param>
        public Repository(CookbookDb db)
        {
            this.entities = db.Set<T>();
            this.db = db;
        }

        /// <summary>
        ///     Returns all entities.
        /// </summary>
        /// <returns>
        ///     The <see cref="ICollection"/>.
        /// </returns>
        public ICollection<T> Get() => this.entities.ToList();

        /// <summary>
        ///     Returns entities by expression.
        /// </summary>
        /// <param name="expression">
        ///     The expression.
        /// </param>
        /// <returns>
        ///     The <see cref="ICollection{T}"/>.
        /// </returns>
        public ICollection<T> Get(Expression<Func<IQueryable<T>, ICollection<T>>> expression)
        {
            var expressionFunc = expression.Compile();
            return expressionFunc(this.entities);
        }

        /// <summary>
        ///     Get entity by id.
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        /// <returns>
        ///     The <see cref="T"/>.
        /// </returns>
        public T Find(int id) => this.entities.Find(id);

        /// <summary>
        ///     Get entity by id.
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        /// <returns>
        ///     The <see cref="T"/>.
        /// </returns>
        public Task<T> FindAsync(int id) => this.entities.FindAsync(id);

        /// <summary>
        ///     Creates new entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        public void Add(T entity) => this.entities.Add(entity);

        /// <summary>
        ///     Deletes entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        public void Remove(T entity) => this.entities.Remove(entity);

        /// <summary>
        ///     Deletes collection of entities.
        /// </summary>
        /// <param name="entities">
        ///     The entities.
        /// </param>
        public void RemoveRange(ICollection<T> entities) => this.RemoveRange(entities);

        /// <summary>
        ///     Save all changes.
        /// </summary>
        /// <returns>
        ///     The <see cref="Task{int}"/>.
        /// </returns>
        public Task<int> SaveChangesAsync() => this.db.SaveChangesAsync();
    }
}