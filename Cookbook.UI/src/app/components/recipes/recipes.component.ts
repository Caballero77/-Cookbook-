import { Component, OnInit } from '@angular/core';
import RecipesService from '../../services/recipes.service';
import RecipeShortInfo from '../../domain/RecipeShortInfo';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { UrlSegment } from '@angular/router/src/url_tree';
import Recipe from '../../domain/Recipe';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.sass']
})
export class RecipesComponent implements OnInit {
  private recipes: RecipeShortInfo[];
  private isRecipeHistory: boolean;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private recipesService: RecipesService
  ) { }

  public async createRecipe() {
    const newRecipe = await this.recipesService.createEmptyRecipe();

    this.router.navigate(['recipe', newRecipe.Id]);
  }

  async ngOnInit() {
    let { isRecipeHistory } = this;
    this.route.url.subscribe(async url => {
      isRecipeHistory = url.some(urlSegment => urlSegment.path === 'history');

      if (!isRecipeHistory) {
        this.recipes = await this.recipesService.getRecipes();
      } else {
        this.route.paramMap.subscribe(async (params: ParamMap) => {
          this.recipes = await this.recipesService.getHistory(+params.get('id'));
        });
      }
    });
  }
}
