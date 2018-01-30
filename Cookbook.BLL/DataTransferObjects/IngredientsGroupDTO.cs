namespace Cookbook.BLL.DataTransferObjects
{
    using System.Collections.Generic;

    public class IngredientsGroupDTO
    {
        public string Name { get; set; }

        public virtual ICollection<IngredientDTO> Ingredients { get; set; }
    }
}