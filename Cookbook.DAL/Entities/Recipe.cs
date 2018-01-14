namespace Cookbook.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Recipe: BaseEntity
    {
        public int RecipeInfoId { get; set; }

        public virtual RecipeInfo RecipeInfo { get; set; }

        public virtual ICollection<IngredientsGroup> IngredientsGroups { get; set; }

        public virtual ICollection<Media> Medias { get; set; }

        public virtual ICollection<CookingStep> CookingSteps { get; set; }

        public virtual ICollection<NutritionValue> NutritionValues { get; set; } 

        [Column(TypeName = "datetime")]
        public DateTime UpdateTime { get; set; }

        public virtual ICollection<Recipe> LastVersions { get; set; }
    }
}