import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {ConfigStaticService} from '../../shared/config.static.service';
import {CandidateService} from '../../shared/candidate.service';
import {SkillService} from '../../shared/skill.service';
import {NgRedux} from '@angular-redux/store';
import {IAppState} from '../../../store/store';
import {DeleteCandidate, LoadCandidates} from '../../../store/actions';
import {Candidate} from '../../shared/candidate';
import {Ng2SmartTableComponent} from 'ng2-smart-table';
import * as _ from 'lodash';

@Component({
  selector: 'candidates-list',
  templateUrl: './candidates-list.component.html',
  styleUrls: ['./candidates-list.component.css']
})
export class CandidatesListComponent implements AfterViewInit {
  @ViewChild('table')
  smartTable: Ng2SmartTableComponent;
  selectedCandidate: Candidate;
  data: any[];
  settings = {
    hideSubHeader: true,
    pager: {
      display: true,
      perPage: 5
    },
    edit: {
      editButtonContent: '<span><i class="fa fa-edit" title="Edit"></i></span>'
    },
    delete: {
      deleteButtonContent: '<span class="delete"><i class="fa fa-trash" title="Delete"></i></span>'
    },
    actions: {
      position: 'right'
    },
    mode: 'external',
    columns: ConfigStaticService.tableConfig()
  };

  constructor(private candidateService: CandidateService,
              private skillService: SkillService,
              private ngRedux: NgRedux<IAppState>) {
    this.getAllCandidates();
    this.ngRedux.subscribe(() => {
      const state = this.ngRedux.getState();
      this.data = _.orderBy(state.candidates, ['id'], ['desc']);
    });
  }

  getAllCandidates = () => {
    this.candidateService.GetAllCandidates()
      .subscribe((data) => {
        this.data = _.orderBy(data, ['id'], ['desc']);
        this.ngRedux.dispatch(LoadCandidates(data));
      });
  }

  ngAfterViewInit(): void {
    this.smartTable.edit.subscribe( (selectedRow: any) => {
      this.selectedCandidate = selectedRow.data;
    });
    this.smartTable.delete.subscribe( (selectedRow: any) => {
      this.ngRedux.dispatch(DeleteCandidate(selectedRow.data));
      this.candidateService.DeleteCandidate(selectedRow.data.id).subscribe();
      this.skillService.DeleteSkills(selectedRow.data.id).subscribe();
    });
  }

  addNewCandidate = () => {
    this.selectedCandidate = new Candidate();
  }

  onFormCancel() {
    this.selectedCandidate = undefined;
  }

  onCandidateAdded() {
    this.selectedCandidate = undefined;
    this.getAllCandidates();
  }
}
