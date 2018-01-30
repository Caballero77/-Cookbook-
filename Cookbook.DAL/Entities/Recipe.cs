namespace Cookbook.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    ///     The entity of recipe.
    /// </summary>
    public class Recipe : BaseEntity
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Recipe" /> class.
        /// </summary>
        public Recipe()
        {
            this.CookingSteps = new HashSet<CookingStep>();
            this.IngredientsGroups = new HashSet<IngredientsGroup>();
            this.Medias = new HashSet<Media>();
            this.NutritionValues = new HashSet<NutritionValue>();
        }

        /// <summary>
        ///     Gets or sets the cooking steps.
        /// </summary>
        public virtual ICollection<CookingStep> CookingSteps { get; set; }

        /// <summary>
        ///     Gets or sets the ingredients groups.
        /// </summary>
        public virtual ICollection<IngredientsGroup> IngredientsGroups { get; set; }

        /// <summary>
        ///     Gets or sets the medias.
        /// </summary>
        public virtual ICollection<Media> Medias { get; set; }

        /// <summary>
        ///     Gets or sets the nutrition values.
        /// </summary>
        public virtual ICollection<NutritionValue> NutritionValues { get; set; }

        /// <summary>
        ///     Gets or sets the previous version.
        /// </summary>
        public virtual Recipe PreviousVersion { get; set; }

        /// <summary>
        ///     Gets or sets the recipe info.
        /// </summary>
        public virtual RecipeInfo RecipeInfo { get; set; }

        /// <summary>
        ///     Indicates whatever this recipe is not lattest.
        /// </summary>
        public bool IsHistoryItem { get; set; } = false;

        /// <summary>
        ///     Gets or sets the update time.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime UpdateTime { get; set; } = DateTime.UtcNow;
    }
}