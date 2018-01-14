namespace Cookbook.DAL
{
    using System.Collections.Generic;
    using System.Data.Entity;

    using Cookbook.DAL.Entities;

    public class CookbookDbInitializer: CreateDatabaseIfNotExists<CookbookDb>
    {
        protected override void Seed(CookbookDb context)
        {
            base.Seed(context);

            var measuringUnitTypes = new List<MeasuringUnitType>
                                         {
                                             new MeasuringUnitType
                                                 {
                                                     Name = "Ingredients",
                                                     Description = "Measuring unit types used for recipes and ingredients",
                                                     MeasuringUnits = new List<MeasuringUnit>
                                                                          {
                                                                              new MeasuringUnit { Name = "C", FullName = "Cup" },
                                                                              new MeasuringUnit { Name = "lb", FullName = "Pound" },
                                                                              new MeasuringUnit { Name = "oz", FullName = "Ounce" },
                                                                              new MeasuringUnit { Name = "pkg", FullName = "Package" },
                                                                              new MeasuringUnit { Name = "pt", FullName = "Pint" },
                                                                              new MeasuringUnit { Name = "qt", FullName = "Quart" },
                                                                              new MeasuringUnit { Name = "Tbsp", FullName = "Tablespoon" },
                                                                              new MeasuringUnit { Name = "tsp", FullName = "Teaspoon" }
                                                                          }
                                                 },
                                             new MeasuringUnitType
                                                 {
                                                     Name = "Nutrient" ,
                                                     Description = "Measuring unit types used for nutrition values",
                                                     MeasuringUnits = new List<MeasuringUnit>
                                                                          {
                                                                              new MeasuringUnit { Name = "g", FullName = "Gram" },
                                                                              new MeasuringUnit { Name = "mg", FullName = "Milligram" }
                                                                          }
                                                 } 
                                         };

            context.MeasuringUnitTypes.AddRange(measuringUnitTypes);

            var mediaTypes = new List<MediaType>
                                 {
                                     new MediaType { Name = "Photo" },
                                     new MediaType { Name = "Video" }
                                 };

            context.MediaTypes.AddRange(mediaTypes);

            context.SaveChanges();
        }
    }
}