namespace Cookbook.BLL.DataTransferObjects.CreateRecipeDTOs
{
    using System.Collections.Generic;

    public class IngredientsGroupDTO
    {
        public string Name { get; set; }

        public virtual ICollection<IngredientDTO> Ingredients { get; set; }
    }
}