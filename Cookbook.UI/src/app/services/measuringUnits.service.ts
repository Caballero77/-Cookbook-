
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import RecipeShortInfo from '../domain/RecipeShortInfo';
import { SERVICE_URL } from '../common/constants';
import Recipe from '../domain/Recipe';
import { HttpParams } from '@angular/common/http';
import { MeasuringUnit } from '../domain/MeasuringUnit';

@Injectable()
export default class MeasuringUnitsService {
  constructor(private http: HttpClient) {}

  public async getNutritionMeasuringUnits(): Promise<MeasuringUnit[]> {
    return this.http.get<MeasuringUnit[]>(`${SERVICE_URL}/measuring-units/nutrition`)
      .toPromise();
  }

  public async getIngredientsMeasuringUnits(): Promise<MeasuringUnit[]> {
    return this.http.get<MeasuringUnit[]>(`${SERVICE_URL}/measuring-units/ingredients`)
      .toPromise();
  }
}
