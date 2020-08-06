import {Component, EventEmitter, Input, OnChanges, Output} from '@angular/core';
import {FormGroup} from '@angular/forms';
import {Skill, Candidate} from '../../../shared/candidate';
import {FormBuilderStaticService} from '../../../shared/formBuilder.static.service';
import {SkillService} from '../../../shared/skill.service';
import {AddCandidate, UpdateCandidate} from '../../../../store/actions';
import {NgRedux} from '@angular-redux/store';
import {IAppState} from '../../../../store/store';
import {CandidateService} from '../../../shared/candidate.service';
import * as _ from 'lodash';

@Component({
  selector: 'candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css']
})
export class CandidateComponent implements OnChanges {
  @Input()
  candidate: Candidate;
  @Output() cancelForm: EventEmitter<any> = new EventEmitter();
  @Output() addCandidate: EventEmitter<any> = new EventEmitter();
  form: FormGroup;
  skills: Skill[];
  constructor(private fbsService: FormBuilderStaticService,
              private skillService: SkillService,
              private candidateService: CandidateService,
              private ngRedux: NgRedux<IAppState>) {
   this.fbsService = fbsService;
   skillService.GetAllSkills().subscribe(skills => this.skills = skills);
  }

  ngOnChanges(): void {
    this.form = this.fbsService.getCandidateForm(this.candidate);
  }

  saveChanges() {
    const formId = this.candidate.id;
    const formValue = this.form.value;
    formValue.id = formId;
    if (!formId) {
      this.candidateService.CreateCandidate(formValue).subscribe((candidate) => {
        this.addSkillTags(candidate).subscribe(() => {
          this.ngRedux.dispatch(AddCandidate(formValue));
          this.addCandidate.emit();
        });
      });
    } else {
      this.candidateService.UpdateCandidate(formValue).subscribe(() => {
        this.updateSkillTags(this.candidate).subscribe();
        this.cancelForm.emit();
      });
      this.ngRedux.dispatch(UpdateCandidate(formValue));
    }
  }

  cancelChanges() {
    this.form.reset();
    this.cancelForm.emit();
  }

  addSkillTag(c: Skill) {
    const isPresent = this.form.controls.skills.value.indexOf(c.description) > -1;
    if (isPresent) {
      this.form.controls.skills
        .setValue(this.form.controls.skills.value.filter(cu => cu !== c.description));
    } else {
      this.form.controls.skills.value.push(c.description);
    }
  }

  isTagSelected = (c: Skill) => {
    return this.form.controls.skills.value.indexOf(c.description) > -1;
  }

  private addSkillTags(candidate: Candidate) {
    const skillTagIds = _.map(this.skills.filter(c => this.form.controls
      .skills.value.indexOf(c.description) > -1), 'id');
    return this.skillService.AddSkills(candidate.id, {skillTagIds});
  }

  private updateSkillTags(candidate: Candidate) {
    const skillTagIds = _.map(this.skills.filter(c => this.form.controls
      .skills.value.indexOf(c.description) > -1), 'id');
    return this.skillService.UpdateSkills(candidate.id, {skillTagIds});
  }
}
