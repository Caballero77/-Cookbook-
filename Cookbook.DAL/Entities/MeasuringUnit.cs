namespace Cookbook.DAL.Entities
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    ///     The entity of measuring unit.
    /// </summary>
    public class MeasuringUnit : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the ingredients.
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Ingredient> Ingredients { get; set; }

        /// <summary>
        ///     Gets or sets the measuring unit type.
        /// </summary>
        public virtual MeasuringUnitType MeasuringUnitType { get; set; }

        /// <summary>
        ///     Gets or sets the measuring unit type id.
        /// </summary>
        public int MeasuringUnitTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the nutrition values.
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<NutritionValue> NutritionValues { get; set; }
    }
}