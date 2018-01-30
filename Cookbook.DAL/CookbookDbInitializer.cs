namespace Cookbook.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

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
                                                                              new MeasuringUnit { Name = "mg", FullName = "Milligram" },
                                                                              new MeasuringUnit { Name = "kCal", FullName = "Kilo Calorie" },
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

            var C = context.MeasuringUnits.First(u => u.Name == "C");
            var lb = context.MeasuringUnits.First(u => u.Name == "lb");
            var oz = context.MeasuringUnits.First(u => u.Name == "oz");
            var pkg = context.MeasuringUnits.First(u => u.Name == "pkg");
            var pt = context.MeasuringUnits.First(u => u.Name == "pt");
            var qt = context.MeasuringUnits.First(u => u.Name == "qt");
            var Tbsp = context.MeasuringUnits.First(u => u.Name == "Tbsp");
            var tsp = context.MeasuringUnits.First(u => u.Name == "tsp");
            var g = context.MeasuringUnits.First(u => u.Name == "g");
            var mg = context.MeasuringUnits.First(u => u.Name == "mg");
            var kCal = context.MeasuringUnits.First(u => u.Name == "kCal");

            var recipe = new Recipe();
            var step1 = new CookingStep
                            {
                                Body = "Preheat oven to 375 ºF.",
                                Number = 1
                            };
            var step2 = new CookingStep
                            {
                                Body = "For the salsa, combine all ingredients and toss well.  Let sit for 10–15 minutes to marinate while preparing the seasoning and cooking the meat.",
                                Number = 2
                            };
            var step3 = new CookingStep
                            {
                                Body = "For the beef tenderloin seasoning, combine all ingredients.  Lightly oil the tenderloin and spread an even layer of the dry seasoning over the entire roast",
                                Number = 3
                            };
            var step4 = new CookingStep
                            {
                                Body = "Place the seasoned roast on a roasting or broiling pan and roast for 10–15 minutes (to a minimum internal temperature of 145 ºF).  Let cool for 5 minutes before carving into 16 slices (1 ounce each). ",
                                Number = 4
                            };
            var step5 = new CookingStep
                            {
                                Body = "Serve four slices of the tenderloin with ¼ cup salsa on the side.",
                                Number = 5
                            };

            recipe.CookingSteps = new List<CookingStep>(new []{ step1, step2, step3, step4, step5 });
            recipe.RecipeInfo = new RecipeInfo
                                    {
                                        CookTime = 30,
                                        CreationDate = DateTime.UtcNow,
                                        Description = "Latin American flavors come alive in this festive beef dish with fruity salsa",
                                        Name = "Cocoa-spiced beef tenderloin with pineapple salsa",
                                        PreparationTime = 20,
                                        ServingsCount = 4,
                                        Tip = "Just Do It",
                                    };

            recipe.IngredientsGroups = new List<IngredientsGroup>
                                           {
                                               new IngredientsGroup
                                                   {
                                                       Name = string.Empty,
                                                       Ingredients = new List<Ingredient>
                                                                         {
                                                                             new Ingredient
                                                                                 {
                                                                                     Name = "vegetable oil",
                                                                                     MeasuringUnitValue = 0.5,
                                                                                     MeasuringUnitId = Tbsp.Id
                                                                                 },
                                                                             new Ingredient
                                                                                 {
                                                                                     Name = "beef tenderloin roast",
                                                                                     MeasuringUnitValue = 16,
                                                                                     MeasuringUnitId = oz.Id
                                                                                 }
                                                                         }
                                                   },
                                               new IngredientsGroup
                                                   {
                                                       Name = "For salsa",
                                                       Ingredients = new List<Ingredient>
                                                                         {
                                                                             new Ingredient
                                                                                 {
                                                                                     Name = "canned diced pineapple, in fruit  juice, chopped into small pieces ",
                                                                                     MeasuringUnitValue = 0.5,
                                                                                     MeasuringUnitId = C.Id
                                                                                 },
                                                                             new Ingredient
                                                                                 {
                                                                                     Name = "red onion, minced ",
                                                                                     MeasuringUnitValue = 0.25,
                                                                                     MeasuringUnitId = C.Id
                                                                                 },
                                                                             new Ingredient
                                                                                 {
                                                                                     Name = "fresh cilantro, rinsed, dried,  and chopped (or substitute  ¼ tsp dried coriander)",
                                                                                     MeasuringUnitValue = 2,
                                                                                     MeasuringUnitId = tsp.Id
                                                                                 },
                                                                             new Ingredient
                                                                                 {
                                                                                     Name = "lemon juice",
                                                                                     MeasuringUnitValue = 1,
                                                                                     MeasuringUnitId = Tbsp.Id
                                                                                 }
                                                                         }
                                                   },
                                               new IngredientsGroup
                                                   {
                                                       Name = "For seasoning",
                                                       Ingredients = new List<Ingredient>
                                                                         {
                                                                             new Ingredient
                                                                                 {
                                                                                     Name = "ground black pepper",
                                                                                     MeasuringUnitValue = 1,
                                                                                     MeasuringUnitId = tsp.Id
                                                                                 },
                                                                             new Ingredient
                                                                                 {
                                                                                     Name = "ground coriander",
                                                                                     MeasuringUnitValue = 1,
                                                                                     MeasuringUnitId = tsp.Id
                                                                                 },
                                                                             new Ingredient
                                                                                 {
                                                                                     Name = "ground cinnamon",
                                                                                     MeasuringUnitValue = 1,
                                                                                     MeasuringUnitId = Tbsp.Id
                                                                                 },
                                                                             new Ingredient
                                                                                 {
                                                                                     Name = "ground allspice",
                                                                                     MeasuringUnitValue = 0.25,
                                                                                     MeasuringUnitId = tsp.Id
                                                                                 },
                                                                             new Ingredient
                                                                                 {
                                                                                     Name = "cocoa powder (unsweetened)",
                                                                                     MeasuringUnitValue = 1,
                                                                                     MeasuringUnitId = Tbsp.Id
                                                                                 },
                                                                             new Ingredient
                                                                                 {
                                                                                     Name = "chili powder",
                                                                                     MeasuringUnitValue = 2,
                                                                                     MeasuringUnitId = tsp.Id
                                                                                 },
                                                                             new Ingredient
                                                                                 {
                                                                                     Name = "salt",
                                                                                     MeasuringUnitValue = 0.25,
                                                                                     MeasuringUnitId = tsp.Id
                                                                                 }
                                                                         }
                                                   }
                                           };
            recipe.UpdateTime = DateTime.UtcNow;
            recipe.RecipeInfo.Tip = "Delicious with a side of rice and Grilled Romaine Lettuce With Caesar Dressing";
            recipe.RecipeInfo.ServingsCount = 4;
            recipe.NutritionValues = new List<NutritionValue>
                                         {
                                             new NutritionValue
                                                 {
                                                     Name = "calories",
                                                     MeasuringUnitId = kCal.Id,
                                                     MeasuringUnitValue = 215
                                                 },
                                             new NutritionValue
                                                 {
                                                     Name = "total fat",
                                                     MeasuringUnitId = g.Id,
                                                     MeasuringUnitValue = 9
                                                 },
                                             new NutritionValue
                                                 {
                                                     Name = "saturated fat",
                                                     MeasuringUnitId = g.Id,
                                                     MeasuringUnitValue = 3
                                                 },
                                             new NutritionValue
                                                 {
                                                     Name = "cholesterol",
                                                     MeasuringUnitId = mg.Id,
                                                     MeasuringUnitValue = 67
                                                 },
                                             new NutritionValue
                                                 {
                                                     Name = "sodium",
                                                     MeasuringUnitId = mg.Id,
                                                     MeasuringUnitValue = 226
                                                 },
                                             new NutritionValue
                                                 {
                                                     Name = "total fiber",
                                                     MeasuringUnitId = g.Id,
                                                     MeasuringUnitValue = 2
                                                 },
                                             new NutritionValue
                                                 {
                                                     Name = "protein",
                                                     MeasuringUnitId = g.Id,
                                                     MeasuringUnitValue = 25
                                                 },
                                             new NutritionValue
                                                 {
                                                     Name = "carbohydrates ",
                                                     MeasuringUnitId = g.Id,
                                                     MeasuringUnitValue = 9
                                                 },
                                             new NutritionValue
                                                 {
                                                     Name = "potassium",
                                                     MeasuringUnitId = mg.Id,
                                                     MeasuringUnitValue = 451
                                                 },
                                         };

            context.Recipes.Add(recipe);
            context.SaveChanges();

            recipe = context.Recipes.First();
            recipe.IsHistoryItem = true;

            context.SaveChanges();

            var newRecipe = context.Recipes
                .Include(r => r.RecipeInfo)
                .Include(r => r.IngredientsGroups)
                .Include("IngredientsGroups.Ingredients")
                .Include(r => r.Medias)
                .Include(r => r.NutritionValues)
                .Include(r => r.CookingSteps)
                .AsNoTracking().First();
            newRecipe.IsHistoryItem = false;
            newRecipe.RecipeInfo.Name = "New Name";
            newRecipe.PreviousVersion = recipe;

            context.Recipes.Add(newRecipe);

            context.SaveChanges();
        }
    }
}