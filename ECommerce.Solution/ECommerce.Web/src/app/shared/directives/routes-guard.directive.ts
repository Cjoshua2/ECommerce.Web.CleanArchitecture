import { Directive } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorizationService } from '../../core/services/authorization.service';
import { BaseComponent } from '../../modules/base.component';

@Directive({
  selector: '[appRoutesGuard]'
})
export class RoutesGuardDirective extends BaseComponent {

  constructor(private router: Router,
    private _authorizationService: AuthorizationService) {
    super()
    //create authorization service
    //check if the user is logged in, redirect to dedicated page, otherwise redirect to login page
    this._authorizationService.requireAnyPermissions([
      this._authorizationService.isLoggedIn(this.getUserId())
    ])

    this.router.navigate(['authentication/sign-in'])
  }

}
