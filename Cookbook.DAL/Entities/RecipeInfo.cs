namespace Cookbook.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RecipeInfo: BaseEntity
    {
        public string Name { get; set; }

        public TimeSpan PreparationTime { get; set; }

        public TimeSpan CookTime { get; set; }

        public string Description { get; set; }

        public string Tip { get; set; }

        public short ServingsCount { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}