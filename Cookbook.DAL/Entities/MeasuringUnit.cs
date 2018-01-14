namespace Cookbook.DAL.Entities
{
    using System.Collections.Generic;
    using System.Collections.Specialized;

    public class MeasuringUnit: BaseEntity
    {
        public string Name { get; set; }

        public string FullName { get; set; }

        public int MeasuringUnitTypeId { get; set; }

        public virtual MeasuringUnitType MeasuringUnitType { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }

        public virtual ICollection<NutritionValue> NutritionValues { get; set; }
    }
}