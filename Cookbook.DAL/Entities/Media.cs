namespace Cookbook.DAL.Entities
{
    public class Media: BaseEntity
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public int RecipeId { get; set; }

        public int MediaTypeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public virtual MediaType MediaType { get; set; }
    }
}