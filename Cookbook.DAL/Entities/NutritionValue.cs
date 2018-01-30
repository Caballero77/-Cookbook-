namespace Cookbook.DAL.Entities
{
    using Newtonsoft.Json;

    /// <summary>
    ///     The entity of nutrition value.
    /// </summary>
    public class NutritionValue : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the measuring unit.
        /// </summary>
        public virtual MeasuringUnit MeasuringUnit { get; set; }

        /// <summary>
        ///     Gets or sets the measuring unit id.
        /// </summary>
        public int MeasuringUnitId { get; set; }

        /// <summary>
        ///     Gets or sets the measuring unit value.
        /// </summary>
        public double MeasuringUnitValue { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the recipe.
        /// </summary>
        [JsonIgnore]
        public Recipe Recipe { get; set; }

        /// <summary>
        ///     Gets or sets the recipe id.
        /// </summary>
        public int RecipeId { get; set; }
    }
}