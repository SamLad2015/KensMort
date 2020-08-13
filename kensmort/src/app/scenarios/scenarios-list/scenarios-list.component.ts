import {Component, Input, OnInit} from '@angular/core';
import {ConfigStaticService} from '../../../services/config.static.service';
import {Scenario} from '../../../services/backend/scenario';

@Component({
  selector: 'app-scenarios-list',
  templateUrl: './scenarios-list.component.html',
  styleUrls: ['./scenarios-list.component.less']
})
export class ScenariosListComponent implements OnInit {
  @Input()
  source: Scenario[];
  settings = {
    hideSubHeader: true,
    actions: false,
    pager: {
      display: true,
      perPage: 10
    },
    mode: 'external',
    columns: ConfigStaticService.tableConfig('scenarios')
  };
  constructor() { }

  ngOnInit(): void {
  }

}
