using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cookbook.Controllers
{
    using Cookbook.DAL;
    using Cookbook.DAL.Entities;

    public class TestController : ApiController
    {
        private readonly CookbookDb context;

        public TestController(CookbookDb context)
        {
            this.context = context;
        }

        [HttpGet]
        public void TestMethod()

        {
            var newRecipe = new Recipe
                                {
                                    CookingSteps = new List<CookingStep>
                                                       {
                                                           new CookingStep { Body = "Test"}
                                                       },
                                    IngredientsGroups = new List<IngredientsGroup>
                                                            {
                                                                new IngredientsGroup
                                                                    {
                                                                        Name = "Main Group",
                                                                        Ingredients = new List<Ingredient>
                                                                                          {
                                                                                              new Ingredient
                                                                                                  {
                                                                                                      MeasuringUnit = this.context.MeasuringUnits.First(),
                                                                                                      Name = "Test",
                                                                                                      MeasuringUnitValue = 12
                                                                                                  }
                                                                                          }
                                                                    }
                                                            },
                                    RecipeInfo = new RecipeInfo
                                                     {
                                                         Name = "Test Recipe",
                                                         CookTime = TimeSpan.FromMinutes(20),
                                                         PreparationTime = TimeSpan.FromMinutes(30),
                                                         CreationDate = DateTime.UtcNow,
                                                         Description = "Test Test Test",
                                                         ServingsCount = 12,
                                                         Tip = "WTF",
                                                     },
                                    UpdateTime = DateTime.UtcNow
                                };

            this.context.Recipes.Add(newRecipe);
            this.context.SaveChanges();
        }
    }
}
