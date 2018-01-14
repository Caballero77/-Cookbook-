namespace Cookbook.DAL.Entities
{
    using System.Collections.Generic;

    public class IngredientsGroup: BaseEntity
    {
        public string Name { get; set; }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}