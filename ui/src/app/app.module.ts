import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

/* Http client module */
import { HttpClientModule } from '@angular/common/http';

/* Service */
import { CandidateService } from './shared/candidate.service';

/* Forms module */
import {FormsModule, ReactiveFormsModule} from '@angular/forms';


/* Components */
import { CandidatesListComponent } from './components/candidates-list/candidates-list.component';
import {Ng2SmartTableModule} from 'ng2-smart-table';
import {CheckboxComponent} from './components/check-box.component';
import { NgRedux, NgReduxModule } from '@angular-redux/store';
import { IAppState, rootReducer, INITIAL_STATE } from '../store/store';
import { CandidateComponent } from './components/candidates-list/candidate/candidate.component';
import {FormBuilderStaticService} from './shared/formBuilder.static.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    CandidatesListComponent,
    CheckboxComponent,
    CandidateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    Ng2SmartTableModule,
    NgReduxModule,
    FormsModule,
    BrowserAnimationsModule
  ],
  providers: [CandidateService, FormBuilderStaticService],
  bootstrap: [AppComponent]
})

export class AppModule {
  constructor(ngRedux: NgRedux<IAppState>) {
    ngRedux.configureStore(rootReducer, INITIAL_STATE);
  }
}
