import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PortfolioComponent } from './portfolio/portfolio.component';
import {MatStepperModule} from '@angular/material/stepper';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {PortfolioService} from '../services/backend/portfolio.service';
import {HttpClientModule} from '@angular/common/http';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import {LoanService} from '../services/backend/loan.service';
import {Ng2SmartTableModule} from 'ng2-smart-table';
import { ScenariosComponent } from './scenarios/scenarios.component';
import {AngularFileDragDropModule} from 'angular-file-drag-drop';
import {ScenarioService} from "../services/backend/scenario.service";
import { ScenariosListComponent } from './scenarios/scenarios-list/scenarios-list.component';
import { ProcessedLoansListComponent } from './scenarios/processed-loans-list/processed-loans-list.component';
import {MatProgressBarModule} from "@angular/material/progress-bar";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";

@NgModule({
  declarations: [
    AppComponent,
    PortfolioComponent,
    ScenariosComponent,
    ScenariosListComponent,
    ProcessedLoansListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    Ng2SmartTableModule,
    AngularFileDragDropModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatStepperModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatProgressBarModule,
    MatProgressSpinnerModule
  ],
  providers: [PortfolioService, LoanService, ScenarioService],
  bootstrap: [AppComponent]
})
export class AppModule { }
