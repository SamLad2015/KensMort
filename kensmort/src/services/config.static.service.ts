import { DatePipe } from '@angular/common';
export class ConfigStaticService {
  static tableConfig = (source) => {
    if (source === 'loans') {
      return {
        id: {
          title: 'Loan Id'
        },
        balance: {
          title: 'Balance'
        },
        wac: {
          title: 'WAC'
        },
        btl: {
          title: 'BTL'
        },
        loanEndDate: {
          title: 'End Date',
          valuePrepareFunction: (date) => {
            const datepipe = new DatePipe('en-gb');
            const raw = new Date(date);
            return datepipe.transform(raw, 'dd/MM/yyyy');
          }
        }
      };
    } else {
      return {
        id: {
          title: 'Scenario Id'
        },
        month: {
          title: 'Month'
        },
        rate: {
          title: 'Rate'
        },
        hpi: {
          title: 'HPI'
        }
      };
    }
  }
}
