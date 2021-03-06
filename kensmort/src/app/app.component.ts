import {Component} from '@angular/core';
import {NavigationEnd, Router} from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent {
  title = 'Kensington Mortgages';
  currentPath = '/';
  constructor(private router: Router) {
    router.events.subscribe(val => {
      if (val instanceof NavigationEnd) {
        this.currentPath = val.url;
      }
    });
  }
}
