import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProcessedLoansListComponent } from './processed-loans-list.component';

describe('ProcessedLoansListComponent', () => {
  let component: ProcessedLoansListComponent;
  let fixture: ComponentFixture<ProcessedLoansListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProcessedLoansListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProcessedLoansListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
