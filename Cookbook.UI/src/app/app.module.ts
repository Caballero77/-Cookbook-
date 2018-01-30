import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/main/home.component';
import { HeaderComponent } from './components/header/header.component';
import { RecipesComponent } from './components/recipes/recipes.component';
import { RecipeComponent } from './components/recipe/recipe.component';
import RecipesService from './services/recipes.service';
import { UpdateComponent } from './components/update/update.component';
import MeasuringUnitsService from './services/measuringUnits.service';

const appRoutes: Routes = [
  { path: 'recipes', component: RecipesComponent },
  { path: 'recipe/:id', component: RecipeComponent },
  { path: 'update/:id', component: UpdateComponent },
  { path: 'history/:id', component: RecipesComponent},
  { path: '', redirectTo: '/recipes', pathMatch: 'full' }
];

@NgModule({
  declarations: [
    HomeComponent,
    HeaderComponent,
    RecipesComponent,
    RecipeComponent,
    UpdateComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    )
  ],
  providers: [RecipesService, MeasuringUnitsService],
  bootstrap: [HomeComponent]
})
export class AppModule { }
