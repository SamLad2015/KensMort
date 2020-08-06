import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { CandidateComponent } from './candidate.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {CandidateService} from '../../../shared/candidate.service';
import {SkillService} from '../../../shared/skill.service';
import {HttpClientModule} from '@angular/common/http';
import {NgReduxModule} from '@angular-redux/store';
import {FormBuilderStaticService} from '../../../shared/formBuilder.static.service';

describe('CandidateComponent', () => {
  let component: CandidateComponent;
  let fixture: ComponentFixture<CandidateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        ReactiveFormsModule,
        FormsModule,
        HttpClientModule,
        NgReduxModule
      ],
      providers: [
        CandidateService,
        SkillService,
        FormBuilderStaticService
      ],
      declarations: [ CandidateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CandidateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
});
