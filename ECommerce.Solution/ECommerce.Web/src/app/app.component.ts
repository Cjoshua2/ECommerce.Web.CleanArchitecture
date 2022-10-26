import { Component } from '@angular/core';
import { CommonService } from './core/services/common.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private _commonService: CommonService) {
  }
  ngOnInit(): void {
    this._commonService.loadTheme()
  }
}
