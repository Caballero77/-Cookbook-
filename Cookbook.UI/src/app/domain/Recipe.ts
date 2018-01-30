import { IngredientsGroup } from './IngredientsGroup';
import { Media } from './Media';
import { CookingStep } from './CookingStep';
import { NutritionValue } from './NutritionValue';

class Recipe {
  Id: number;
  Name: string;
  PreparationTime: number;
  CookTime: number;
  Description: string;
  Tip: string;
  ServingsCount: number;
  CreationDate: Date;
  IngredientsGroups: IngredientsGroup[];
  Medias: Media[];
  CookingSteps: CookingStep[];
  NutritionValues: NutritionValue[];
}

export default Recipe;
