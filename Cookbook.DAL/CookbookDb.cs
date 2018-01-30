namespace Cookbook.DAL
{
    using System.Data.Entity;

    using Cookbook.DAL.Entities;

    public class CookbookDb : DbContext
    {
        public CookbookDb()
            : base("name=CookbookDb")
        {
            Database.SetInitializer(new CookbookDbInitializer());
        }

        public virtual DbSet<Recipe> Recipes { get; set; }

        public virtual DbSet<Ingredient> Ingredients { get; set; }

        public virtual DbSet<CookingStep> CookingSteps { get; set; }

        public virtual DbSet<MeasuringUnit> MeasuringUnits { get; set; }

        public virtual DbSet<MeasuringUnitType> MeasuringUnitTypes { get; set; }

        public virtual DbSet<IngredientsGroup> IngredientsGroups { get; set; }

        public virtual DbSet<NutritionValue> NutritionValues { get; set; }

        public virtual DbSet<MediaType> MediaTypes { get; set; }

        public virtual DbSet<Media> Medias { get; set; }

        public virtual DbSet<RecipeInfo> RecipeInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ingredient>()
                .HasRequired(e => e.IngredientsGroup)
                .WithMany(e => e.Ingredients)
                .HasForeignKey(e => e.IngredientsGroupId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Ingredient>()
                .HasRequired(e => e.MeasuringUnit)
                .WithMany(e => e.Ingredients)
                .HasForeignKey(e => e.MeasuringUnitId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<MeasuringUnit>()
                .HasRequired(e => e.MeasuringUnitType)
                .WithMany(e => e.MeasuringUnits)
                .HasForeignKey(e => e.MeasuringUnitTypeId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<IngredientsGroup>()
                .HasRequired(e => e.Recipe)
                .WithMany(e => e.IngredientsGroups)
                .HasForeignKey(e => e.RecipeId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Media>()
                .HasRequired(e => e.Recipe)
                .WithMany(e => e.Medias)
                .HasForeignKey(e => e.RecipeId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Media>()
                .HasRequired(e => e.MediaType)
                .WithMany(e => e.Medias)
                .HasForeignKey(e => e.MediaTypeId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<NutritionValue>()
                .HasRequired(e => e.MeasuringUnit)
                .WithMany(e => e.NutritionValues)
                .HasForeignKey(e => e.MeasuringUnitId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<NutritionValue>()
                .HasRequired(e => e.Recipe)
                .WithMany(e => e.NutritionValues)
                .HasForeignKey(e => e.RecipeId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<RecipeInfo>()
                .HasRequired(e => e.Recipe)
                .WithRequiredPrincipal(e => e.RecipeInfo)
                .Map(e => e.MapKey("RecipeInfoId"))
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Recipe>()
                .HasOptional(e => e.PreviousVersion);
        }
    }
}