namespace Cookbook.BLL.DataTransferObjects.CreateRecipeDTOs
{
    using AutoMapper;

    using Cookbook.Common.Extensions;
    using Cookbook.DAL.Entities;
    using Cookbook.Mapper;
    public class MapperConfiguration: MapperBase
    {
        public MapperConfiguration(IMapperConfigurationExpression configurationExpression)
            : base(configurationExpression)
        {
        }

        protected override void ConfigureMaps(IMapperConfigurationExpression configurationExpression)
        {
            configurationExpression.CreateMap<CreateRecipeDTO, Recipe>()
                .ForPath(dbDto => dbDto.RecipeInfo.Name, uiDto => uiDto.Name)
                .ForPath(dbDto => dbDto.RecipeInfo.CookTime, uiDto => uiDto.CookTime)
                .ForPath(dbDto => dbDto.RecipeInfo.PreparationTime, uiDto => uiDto.PreparationTime)
                .ForPath(dbDto => dbDto.RecipeInfo.CreationDate, uiDto => uiDto.CreationDate)
                .ForPath(dbDto => dbDto.RecipeInfo.Description, uiDto => uiDto.Description)
                .ForPath(dbDto => dbDto.RecipeInfo.ServingsCount, uiDto => uiDto.ServingsCount)
                .ForPath(dbDto => dbDto.RecipeInfo.Tip, uiDto => uiDto.Tip)
                .IgnoreMembers(
                    dbDto => dbDto.PreviousVersion,
                    dbDto => dbDto.Id,
                    dbo => dbo.IsHistoryItem);

            configurationExpression.CreateMap<IngredientsGroupDTO, IngredientsGroup>()
                .IgnoreMembers(dbDto => dbDto.Recipe, dbDto => dbDto.RecipeId, dbDto => dbDto.Id);

            configurationExpression.CreateMap<IngredientDTO, Ingredient>()
                .IgnoreMembers(
                    dbDto => dbDto.IngredientsGroup,
                    dbDto => dbDto.IngredientsGroupId,
                    dbDto => dbDto.MeasuringUnit,
                    dbDto => dbDto.Id);

            configurationExpression.CreateMap<MediaDTO, Media>()
                .IgnoreMembers(
                    dbDto => dbDto.RecipeId,
                    dbDto => dbDto.MediaType,
                    dbDto => dbDto.Recipe,
                    dbDto => dbDto.Id);

            configurationExpression.CreateMap<CookingStepDTO, CookingStep>()
                .IgnoreMembers(
                    dbDto => dbDto.Recipe,
                    dbDto => dbDto.RecipeId,
                    dbDto => dbDto.Id);

            configurationExpression.CreateMap<NutritionValueDTO, NutritionValue>()
                .IgnoreMembers(
                    dbDto => dbDto.MeasuringUnit,
                    dbDto => dbDto.Recipe,
                    dbDto => dbDto.RecipeId,
                    dbDto => dbDto.Id);
        }
    }
}