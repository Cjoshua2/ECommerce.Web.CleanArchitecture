import { Component, OnInit } from '@angular/core';
import { CommonService } from '../../../../core/services/common.service';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.scss']
})
export class AuthenticationComponent implements OnInit {

  constructor(private _commonService: CommonService) { }

  ngOnInit(): void {
    this._commonService.loadTheme()
  }

  toggle() {
    this._commonService.toggleTheme()
  }
}
