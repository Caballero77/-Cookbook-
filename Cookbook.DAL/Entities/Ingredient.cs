namespace Cookbook.DAL.Entities
{
    public class Ingredient: BaseEntity
    {
        public string Name { get; set; }

        public int MeasuringUnitValue { get; set; }

        public int IngredientsGroupId { get; set; }

        public int MeasuringUnitId { get; set; }

        public virtual IngredientsGroup IngredientsGroup { get; set; }

        public virtual MeasuringUnit MeasuringUnit { get; set; }
    }
}