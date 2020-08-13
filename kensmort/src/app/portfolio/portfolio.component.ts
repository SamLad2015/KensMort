import {Component, OnInit} from '@angular/core';
import {STEPPER_GLOBAL_OPTIONS} from '@angular/cdk/stepper';
import {PortfolioService} from '../../services/backend/portfolio.service';
import {Portfolio} from '../../services/backend/portfolio';
import {Category} from '../../services/backend/category';
import {LoanService} from '../../services/backend/loan.service';
import {Loan, LoanRequest} from '../../services/backend/loan';
import {ConfigStaticService} from '../../services/config.static.service';

@Component({
  selector: 'app-portfolio',
  templateUrl: './portfolio.component.html',
  styleUrls: ['./portfolio.component.less'],
  providers: [{
    provide: STEPPER_GLOBAL_OPTIONS, useValue: {displayDefaultIndicatorType: false}
  }]
})
export class PortfolioComponent implements OnInit {
  categories: Category[];
  portfolios: Portfolio[];
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
  source: Loan[];
  selectedDate: Date = new Date();
  today: Date = new Date();
  loading = false;
  constructor(private portfolioService: PortfolioService,
              private loanService: LoanService) { }

  ngOnInit(): void {
    this.portfolioService.GetAllCategories().subscribe(categories => this.categories = categories);
  }

  selectCategory = (c: Category) => {
    this.categories = this.categories.map(ct =>  {
      ct.selected = ct.id === c.id;
      return ct;
    });
  }

  loadPortfolios(): void {
    this.portfolioService
      .GetPortfolios(this.categories.find(c => c.selected).id)
      .subscribe(portfolios => {
            this.portfolios = portfolios.map(p => {
            p.selected = true;
            return p;
          });
      });
  }

  loadLoans(): void {
    this.loading = true;
    const req = new LoanRequest();
    req.portfolioIds = this.portfolios.filter(p => p.selected).map(p => p.id).join(',');
    req.cutOffDate = this.selectedDate.toUTCString();
    this.loanService.GetAllLoans(req).subscribe(loans => {
      this.source = loans;
      this.loading = false
    });
  }

  selectPortfolio(p: Portfolio): void {
    p.selected = !p.selected;
  }
}
