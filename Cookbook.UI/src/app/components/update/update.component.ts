import { Component, OnInit } from '@angular/core';
import Recipe from '../../domain/Recipe';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import RecipesService from '../../services/recipes.service';
import { CookingStep } from '../../domain/CookingStep';
import { NutritionValue } from '../../domain/NutritionValue';
import { MeasuringUnit } from '../../domain/MeasuringUnit';
import MeasuringUnitsService from '../../services/measuringUnits.service';
import { Ingredient } from '../../domain/Ingredient';
import { IngredientsGroup } from '../../domain/IngredientsGroup';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.sass']
})
export class UpdateComponent implements OnInit {
  private recipe: Recipe;
  private ingredientsMeasuringUnits: MeasuringUnit[];
  private nutritionMeasuringUnits: MeasuringUnit[];
  private newStep: CookingStep;
  private newNutrition: NutritionValue;
  private newGroup: IngredientsGroup;
  private newIngredients = {};

    constructor(
      private route: ActivatedRoute,
      private router: Router,
      private recipesService: RecipesService,
      private measuringUnitsService: MeasuringUnitsService
    ) { }

    private async save() {
      const newRecipe = await this.recipesService.saveRecipe(this.recipe);

      this.router.navigate(['recipe', newRecipe.Id]);
    }

    private addGroup(event: KeyboardEvent) {
      if (event.keyCode !== 13) {
        return;
      }
      this.recipe.IngredientsGroups.push(this.newGroup);

      this.newIngredients[this.newGroup.Name] =
        { Name: '',
          MeasuringUnit: this.ingredientsMeasuringUnits[0].Name,
          MeasuringUnitValue: 0
        } as Ingredient;

      this.newGroup = { Name: '', Ingredients: [] };
    }

    private addIngredient(event: KeyboardEvent, groupName: string) {
      if (event.keyCode !== 13) {
        return;
      }
      const ingredient = this.newIngredients[groupName];

      const selectedGroup = this.recipe.IngredientsGroups.find(group => group.Name === groupName);

      selectedGroup.Ingredients.push(ingredient);

      this.newIngredients[groupName] = { Name: '', MeasuringUnit: this.ingredientsMeasuringUnits[0].Name, MeasuringUnitValue: 0 };
    }

    private deleteIngredient(groupName: string, ingredientName: string) {
      const selectedGroup = this.recipe.IngredientsGroups.find(group => group.Name === groupName);

      selectedGroup.Ingredients = selectedGroup.Ingredients.filter(ingredient => ingredient.Name !== ingredientName);

      if (selectedGroup.Ingredients.length === 0) {
        this.deleteIngredientGroup(groupName);
      }
    }

    private deleteIngredientGroup(groupName: string) {
      this.recipe.IngredientsGroups = this.recipe.IngredientsGroups.filter(group => group.Name !== groupName);
    }

    private deleteStep(stepNumber: number) {
      this.recipe.CookingSteps = this.recipe.CookingSteps
        .filter(step => step.Number !== stepNumber)
        .map(step => {
          if (step.Number > stepNumber) {
            step.Number--;
          }
          return step;
        });
      this.newStep = { Number: this.recipe.CookingSteps.length + 1, Body: 'Type new step body'};
    }

    private deleteNutrition(id: number) {
      this.recipe.NutritionValues = this.recipe.NutritionValues.filter(nutrition => nutrition.Id !== id);
    }

    private addNewNutrition(event: KeyboardEvent) {
      if (event.keyCode === 13) {
        this.recipe.NutritionValues.push(this.newNutrition);

        this.newNutrition = {
          Id: this.recipe.NutritionValues.map(value => value.Id).sort((a, b) => b - a)[0] + 1,
          MeasuringUnit: this.nutritionMeasuringUnits[0].Name,
          MeasuringUnitId: this.nutritionMeasuringUnits[0].Id,
          Name: '',
          MeasuringUnitValue: 0
        };
      }
    }

    private addNewStep(event: KeyboardEvent) {
      if (event.keyCode === 13) {
        this.recipe.CookingSteps = this.recipe.CookingSteps
        .map(step => {
          if (step.Number >= this.newStep.Number) {
            step.Number++;
          }
          return step;
        });
        this.recipe.CookingSteps.push(this.newStep);
        this.recipe.CookingSteps = this.recipe.CookingSteps.sort((a, b) => a.Number - b.Number);
        this.newStep = { Number: this.recipe.CookingSteps.length + 1, Body: 'Type new step body'};
      }
      return false;
    }

    async ngOnInit() {
      this.route.paramMap
      .subscribe(async (params: ParamMap) => {
        this.recipe = await this.recipesService.getRecipe(+params.get('id'));

        const measuringUnits = await Promise.all([
          this.measuringUnitsService.getNutritionMeasuringUnits(),
          this.measuringUnitsService.getIngredientsMeasuringUnits()
        ]);

        this.nutritionMeasuringUnits = measuringUnits[0];
        this.ingredientsMeasuringUnits = measuringUnits[1];

        this.newStep = {
          Number: this.recipe.CookingSteps ? this.recipe.CookingSteps.length : 0 + 1,
          Body: 'Type new step body'
        };

        this.newNutrition = {
          Id: this.recipe.NutritionValues.map(value => value.Id).sort((a, b) => b - a)[0] + 1,
          MeasuringUnit: this.nutritionMeasuringUnits[0].Name,
          MeasuringUnitId: this.nutritionMeasuringUnits[0].Id,
          Name: '',
          MeasuringUnitValue: 0
        };

        this.newIngredients = this.recipe.IngredientsGroups
          .reduce((prev, current) => {
            prev[current.Name] = {
              Name: '',
              MeasuringUnit: this.ingredientsMeasuringUnits[0].Name,
              MeasuringUnitId: this.ingredientsMeasuringUnits[0].Id,
              MeasuringUnitValue: 0
            } as Ingredient;
            return prev;
          }, {});

          this.newGroup = { Name: '', Ingredients: [] };
      });
    }
}
