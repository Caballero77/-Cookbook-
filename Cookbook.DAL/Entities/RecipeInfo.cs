namespace Cookbook.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using Newtonsoft.Json;

    /// <summary>
    ///     The entity of recipe info.
    /// </summary>
    public class RecipeInfo : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the cook time.
        /// </summary>
        public int CookTime { get; set; }

        /// <summary>
        ///     Gets or sets the creation date.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the preparation time.
        /// </summary>
        public int PreparationTime { get; set; }

        /// <summary>
        ///     Gets or sets the recipe.
        /// </summary>
        [JsonIgnore]
        public Recipe Recipe { get; set; }

        /// <summary>
        ///     Gets or sets the recipe id.
        /// </summary>
        public int RecipeId { get; set; }

        /// <summary>
        ///     Gets or sets the servings count.
        /// </summary>
        public short ServingsCount { get; set; }

        /// <summary>
        ///     Gets or sets the tip.
        /// </summary>
        public string Tip { get; set; }
    }
}