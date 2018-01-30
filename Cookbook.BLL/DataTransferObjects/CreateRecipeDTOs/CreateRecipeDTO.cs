namespace Cookbook.BLL.DataTransferObjects.CreateRecipeDTOs
{
    using System;
    using System.Collections.Generic;

    public class CreateRecipeDTO
    {
        public string Name { get; set; }

        public int PreparationTime { get; set; }

        public int CookTime { get; set; }

        public string Description { get; set; }

        public string Tip { get; set; }

        public short ServingsCount { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<IngredientsGroupDTO> IngredientsGroups { get; set; }

        public ICollection<MediaDTO> Medias { get; set; }

        public ICollection<CookingStepDTO> CookingSteps { get; set; }

        public ICollection<NutritionValueDTO> NutritionValues { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}