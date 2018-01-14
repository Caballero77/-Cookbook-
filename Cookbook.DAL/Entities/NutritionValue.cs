namespace Cookbook.DAL.Entities
{
    public class NutritionValue: BaseEntity
    {
        public string Name { get; set; }

        public int MeasuringUnitId { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public virtual MeasuringUnit MeasuringUnit { get; set; }
    }
}