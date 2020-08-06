import { Injectable } from '@angular/core';
import {CheckboxComponent} from '../components/check-box.component';

@Injectable({
  providedIn: 'root'
})

export class ConfigStaticService {
  static tableConfig = () => {
    return {
      id: {
        title: 'ID'
      },
      name: {
        title: 'Name'
      },
      position: {
        title: 'Position'
      },
      skills: {
        title: 'Skills'
      },
      contract: {
        title: 'Contract Jobs',
        type: 'custom',
        renderComponent: CheckboxComponent,
        attr: {
          class: 'check-box'
        }
      },
      available: {
        title: 'Available Immediately',
        type: 'custom',
        renderComponent: CheckboxComponent,
        attr: {
          class: 'check-box'
        }
      },
      match: {
        title: 'Match'
      }
    };
  }
}
