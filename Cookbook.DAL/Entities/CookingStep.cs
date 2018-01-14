namespace Cookbook.DAL.Entities
{
    public class CookingStep: BaseEntity
    {
        public string Body { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public int? NextStepId { get; set; }

        public int? PreviousStepId { get; set; }

        public virtual CookingStep NextStep { get; set; }

        public virtual CookingStep PreviousStep { get; set; }
    }
}