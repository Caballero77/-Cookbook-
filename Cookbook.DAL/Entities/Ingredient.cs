namespace Cookbook.DAL.Entities
{
    using Newtonsoft.Json;

    /// <summary>
    ///     The entity of ingredient.
    /// </summary>
    public class Ingredient : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the ingredients group.
        /// </summary>
        [JsonIgnore]
        public virtual IngredientsGroup IngredientsGroup { get; set; }

        /// <summary>
        ///     Gets or sets the ingredients group id.
        /// </summary>
        public int IngredientsGroupId { get; set; }

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
    }
}