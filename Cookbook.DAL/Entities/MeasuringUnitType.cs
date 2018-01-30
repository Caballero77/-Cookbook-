namespace Cookbook.DAL.Entities
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    ///     The entity of measuring unit type.
    /// </summary>
    public class MeasuringUnitType : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the measuring units.
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<MeasuringUnit> MeasuringUnits { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}