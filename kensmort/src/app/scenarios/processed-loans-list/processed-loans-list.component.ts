import {Component, Input} from '@angular/core';
import {ConfigStaticService} from '../../../services/config.static.service';
import {LocalDataSource} from 'ng2-smart-table';

@Component({
  selector: 'app-processed-loans-list',
  templateUrl: './processed-loans-list.component.html',
  styleUrls: ['./processed-loans-list.component.less']
})
export class ProcessedLoansListComponent {
  @Input()
  source: LocalDataSource;
  @Input()
  loading: boolean;
  settings = {
    hideSubHeader: true,
    actions: false,
    pager: {
      display: true,
      perPage: 10
    },
    mode: 'external',
    columns: ConfigStaticService.tableConfig('loans')
  };
  constructor() {}
}
