namespace Cookbook.DAL.Entities
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    ///     The entity of ingredients group.
    /// </summary>
    public class IngredientsGroup : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the ingredients.
        /// </summary>
        public virtual ICollection<Ingredient> Ingredients { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the recipe.
        /// </summary>
        [JsonIgnore]
        public virtual Recipe Recipe { get; set; }

        /// <summary>
        ///     Gets or sets the recipe id.
        /// </summary>
        public int RecipeId { get; set; }
    }
}