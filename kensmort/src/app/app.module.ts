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

@NgModule({
  declarations: [
    AppComponent,
    PortfolioComponent,
    ScenariosComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    Ng2SmartTableModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatStepperModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  providers: [PortfolioService, LoanService],
  bootstrap: [AppComponent]
})
export class AppModule { }
