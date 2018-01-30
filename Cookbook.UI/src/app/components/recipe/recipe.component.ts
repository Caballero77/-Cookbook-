import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import Recipe from '../../domain/Recipe';
import RecipesService from '../../services/recipes.service';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.sass']
})
export class RecipeComponent implements OnInit {
  private recipe: Recipe;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private recipesService: RecipesService
  ) { }

  public async deleteRecipe() {
    const result = await this.recipesService.deleteRecipe(this.recipe.Id);

    if (result) {
      this.router.navigate(['recipes']);
    }
  }

   ngOnInit() {
    this.route.paramMap
      .subscribe(async (params: ParamMap) => {
        this.recipe = await this.recipesService.getRecipe(+params.get('id'));
      });
  }

}
