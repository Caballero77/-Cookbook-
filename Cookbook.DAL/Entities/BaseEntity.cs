namespace Cookbook.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    ///     The base type for database entities.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        ///     Gets or sets the primary key of entity, using identity(0,1).
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}