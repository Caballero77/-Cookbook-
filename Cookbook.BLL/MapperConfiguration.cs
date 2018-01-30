namespace Cookbook.BLL
{
    using System;
    using System.Linq;

    using AutoMapper;

    using Cookbook.BLL.DataTransferObjects;
    using Cookbook.Common.Extensions;
    using Cookbook.DAL.Entities;
    using Cookbook.Mapper;

    /// <summary>
    ///     The mapper configuration.
    /// </summary>
    public class MapperConfiguration : MapperBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MapperConfiguration"/> class.
        /// </summary>
        /// <param name="configurationExpression">
        ///     The configuration expression.
        /// </param>
        public MapperConfiguration(IMapperConfigurationExpression configurationExpression)
            : base(configurationExpression)
        {
        }

        /// <summary>
        ///     The configure maps.
        /// </summary>
        /// <param name="configurationExpression">
        ///     The configuration expression.
        /// </param>
        protected override void ConfigureMaps(IMapperConfigurationExpression configurationExpression)
        {
            // Mapping from Recipe to RecipeShortInfoDTO
            configurationExpression.CreateMap<Recipe, RecipeShortInfoDTO>()
                .ForMember(uiDto => uiDto.CreationDate, dbDto => dbDto.UpdateTime)
                .ForMember(uiDto => uiDto.Description, dbDto => dbDto.RecipeInfo.Description)
                .ForMember(uiDto => uiDto.Title, opt => opt.MapFrom(dbDto => dbDto.RecipeInfo.Name))
                .ForMember(
                    uiDto => uiDto.ImageUrl,
                    opt => opt.MapFrom(dbDto => dbDto.Medias.Select(m => m.Url).FirstOrDefault()));

            // Mappings from Recipe to RecipeInfoDTO
            configurationExpression.CreateMap<Ingredient, IngredientDTO>()
                .ForMember(uiDto => uiDto.MeasuringUnit, opt => opt.MapFrom(dbDto => dbDto.MeasuringUnit.Name));

            configurationExpression.CreateMap<IngredientsGroup, IngredientsGroupDTO>();

            configurationExpression.CreateMap<Media, MediaDTO>()
                .ForMember(uiDto => uiDto.MediaType, opt => opt.MapFrom(dbDto => dbDto.MediaType.Name));

            configurationExpression.CreateMap<NutritionValue, NutritionValueDTO>()
                .ForMember(uiDto => uiDto.MeasuringUnit, dbDto => dbDto.MeasuringUnit.Name);

            configurationExpression.CreateMap<MeasuringUnit, MeasuringUnitDTO>();

            configurationExpression.CreateMap<CookingStep, CookingStepDTO>();

            configurationExpression.CreateMap<Recipe, RecipeInfoDTO>()
                .ForMember(uiDto => uiDto.Name, dbDto => dbDto.RecipeInfo.Name)
                .ForMember(uiDto => uiDto.PreparationTime, dbDto => dbDto.RecipeInfo.PreparationTime)
                .ForMember(uiDto => uiDto.CookTime, dbDto => dbDto.RecipeInfo.CookTime)
                .ForMember(uiDto => uiDto.Description, dbDto => dbDto.RecipeInfo.Description)
                .ForMember(uiDto => uiDto.Tip, dbDto => dbDto.RecipeInfo.Tip)
                .ForMember(uiDto => uiDto.ServingsCount, dbDto => dbDto.RecipeInfo.ServingsCount)
                .ForMember(uiDto => uiDto.CreationDate, dbDto => dbDto.RecipeInfo.CreationDate)
                .ForMember(uiDto => uiDto.IsHistoryItem, dbDto => dbDto.IsHistoryItem);

            // Mappings from RecipeInfoDTO to Recipe
            configurationExpression.CreateMap<RecipeInfoDTO, Recipe>()
                .IgnoreMembers(dbDto => dbDto.Id, dbDto => dbDto.PreviousVersion, dbDto => dbDto.IsHistoryItem)
                .ForPath(dbDto => dbDto.RecipeInfo.Name, uiDto => uiDto.Name)
                .ForPath(dbDto => dbDto.RecipeInfo.Description, uiDto => uiDto.Description)
                .ForPath(dbDto => dbDto.RecipeInfo.Tip, uiDto => uiDto.Tip)
                .ForPath(dbDto => dbDto.RecipeInfo.CookTime, uiDto => uiDto.CookTime)
                .ForPath(dbDto => dbDto.RecipeInfo.PreparationTime, uiDto => uiDto.PreparationTime)
                .ForPath(dbDto => dbDto.RecipeInfo.ServingsCount, uiDto => uiDto.ServingsCount)
                .ForPath(dbDto => dbDto.RecipeInfo.CreationDate, uiDto => uiDto.CreationDate);

            configurationExpression.CreateMap<IngredientsGroupDTO, IngredientsGroup>()
                .IgnoreMembers(dbDto => dbDto.Recipe, dbDto => dbDto.RecipeId, dbDto => dbDto.Id);

            configurationExpression.CreateMap<IngredientDTO, Ingredient>()
                .IgnoreMembers(
                    dbDto => dbDto.IngredientsGroup,
                    dbDto => dbDto.IngredientsGroupId,
                    dbDto => dbDto.Id,
                    dbDto => dbDto.MeasuringUnit);

            configurationExpression.CreateMap<MediaDTO, Media>()
                .IgnoreMembers(
                    dbDto => dbDto.MediaType,
                    dbDto => dbDto.Recipe,
                    dbDto => dbDto.RecipeId,
                    dbDto => dbDto.Id);

            configurationExpression.CreateMap<CookingStepDTO, CookingStep>()
                .IgnoreMembers(dbDto => dbDto.Recipe, dbDto => dbDto.RecipeId, dbDto => dbDto.Id);

            configurationExpression.CreateMap<NutritionValueDTO, NutritionValue>()
                .IgnoreMembers(
                    dbDto => dbDto.MeasuringUnit,
                    dbDto => dbDto.Recipe,
                    dbDto => dbDto.RecipeId,
                    dbDto => dbDto.Id);
        }
    }
}