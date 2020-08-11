import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {PortfolioComponent} from './portfolio/portfolio.component';
import {ScenariosComponent} from './scenarios/scenarios.component';

const routes: Routes = [
  {
    path: '',
    component: PortfolioComponent
  },
  {
    path: 'scenarios',
    component: ScenariosComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
