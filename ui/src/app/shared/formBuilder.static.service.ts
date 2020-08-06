import {FormBuilder, Validators} from '@angular/forms';
import {Candidate} from './candidate';
import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class FormBuilderStaticService {
  constructor(private fb: FormBuilder) { }
  getCandidateForm = (candidate: Candidate) => {
    return this.fb.group({
      name: [candidate && candidate.name ? candidate.name : '', Validators.required],
      position: [candidate && candidate.position ? candidate.position : '', Validators.required],
      skills: [candidate && candidate.skills ? candidate.skills : [], Validators.required],
      available: [candidate && candidate.available ? candidate.available : false, Validators.required],
      contract: [candidate && candidate.contract ? candidate.contract : false, Validators.required],
      match: [candidate && candidate.match ? candidate.match : 0, Validators.required]
    });
  }
}
