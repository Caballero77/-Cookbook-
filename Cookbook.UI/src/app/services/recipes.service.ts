
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import RecipeShortInfo from '../domain/RecipeShortInfo';
import { SERVICE_URL } from '../common/constants';
import Recipe from '../domain/Recipe';
import { HttpParams } from '@angular/common/http';

@Injectable()
export default class RecipesService {
  constructor(private http: HttpClient) {}

  public async getRecipes(): Promise<RecipeShortInfo[]> {
    return this.http.get<RecipeShortInfo[]>(`${SERVICE_URL}/recipe`)
      .toPromise();
  }

  public async getRecipe(id: number): Promise<Recipe> {
    let params = new HttpParams();
    params = params.append('id', id.toString());
    return this.http.get<Recipe>(`${SERVICE_URL}/recipe`, { params })
      .toPromise();
  }

  public async saveRecipe(recipe: Recipe): Promise<Recipe> {
    return await this.http.put<Recipe>(`${SERVICE_URL}/recipe`, recipe)
      .toPromise();
  }

  public async getHistory(id: number): Promise<RecipeShortInfo[]> {
    return await this.http.get<RecipeShortInfo[]>(`${SERVICE_URL}/recipe/${id}/history`)
      .toPromise();
  }

  public async createRecipe(recipe: Recipe): Promise<Recipe> {
    return await this.http.post<Recipe>(`${SERVICE_URL}/recipe`, recipe)
      .toPromise();
  }

  public async createEmptyRecipe(): Promise<Recipe> {
    return await this.http.post<Recipe>(`${SERVICE_URL}/recipe/empty`, {})
      .toPromise();
  }

  public async deleteRecipe(id: number): Promise<boolean> {
    return await this.http.delete<boolean>(`${SERVICE_URL}/recipe/${id}`)
      .toPromise();
  }
}
