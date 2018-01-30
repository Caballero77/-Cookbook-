namespace Cookbook.DAL.Entities
{
    /// <summary>
    ///     The entity of cooking step.
    /// </summary>
    public class CookingStep : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the body of cooking step.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///     Gets or sets the recipe id.
        /// </summary>
        public int RecipeId { get; set; }

        /// <summary>
        ///     Gets or sets the recipe.
        /// </summary>
        public Recipe Recipe { get; set; }

        /// <summary>
        ///     Gets or sets the number of cooking number.
        /// </summary>
        public int Number { get; set; }
    }
}