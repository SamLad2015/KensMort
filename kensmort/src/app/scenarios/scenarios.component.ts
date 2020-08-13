import { Component, OnInit } from '@angular/core';
import {ScenarioService} from '../../services/backend/scenario.service';
import {Scenario} from '../../services/backend/scenario';
import {LocalDataSource} from 'ng2-smart-table';
import {LoanService} from '../../services/backend/loan.service';

@Component({
  selector: 'app-scenarios',
  templateUrl: './scenarios.component.html',
  styleUrls: ['./scenarios.component.less']
})
export class ScenariosComponent implements OnInit {
  uploadedFile: any;
  processStarted: boolean;
  scenarios: Scenario[];
  processedLoans: LocalDataSource;
  loanCount: number;
  processedLoanCount = 0;
  progressBarValue = 0;
  loading = false;
  constructor(private scenarioService: ScenarioService,
              private loanService: LoanService) { }

  ngOnInit(): void {
    this.processedLoans = new LocalDataSource();
  }

  onFileSelect($event: any): void {
    this.uploadedFile = $event;
  }

  processScenarios(): void {
    this.scenarioService.Upload(this.uploadedFile[0]).subscribe(scenarios => {
      this.scenarios = scenarios;
      this.processStarted = true;
      this.loading = true;
      this.loanService.GetCount().subscribe(count => this.loanCount = count);
      this.addProcessedLoans();
    });
  }

  cancelFile(): void {
    this.uploadedFile = undefined;
  }

  addProcessedLoans(): void {
    this.loanService.GetProcessedLoans(this.processedLoanCount).subscribe(loanResponse => {
      this.processedLoanCount = loanResponse.processedLoanCount;
      this.progressBarValue = Math.round(this.processedLoanCount * 100 / this.loanCount);
      this.processedLoans.load(loanResponse.loans).then(() => {
          this.loading = false;
          if (this.loanCount > this.processedLoanCount) {
            this.addProcessedLoans();
          }
        }
      );
    });
  }
}
