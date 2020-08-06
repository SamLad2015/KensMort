import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CandidatesListComponent } from './candidates-list.component';
import {HttpClientModule} from '@angular/common/http';
import {NgReduxModule} from '@angular-redux/store';
import {CandidateService} from '../../shared/candidate.service';
import {SkillService} from '../../shared/skill.service';

describe('CandidatesListComponent', () => {
  let component: CandidatesListComponent;
  let fixture: ComponentFixture<CandidatesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientModule,
        NgReduxModule
      ],
      providers: [
        CandidateService,
        SkillService
      ],
      declarations: [ CandidatesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CandidatesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
});
