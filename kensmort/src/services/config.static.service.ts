import { DatePipe } from '@angular/common';
export class ConfigStaticService {
  static tableConfig = () => {
    return {
      id: {
        title: 'ID'
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
  }
}
