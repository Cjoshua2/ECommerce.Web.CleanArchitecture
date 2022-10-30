import { Directive } from '@angular/core';
import { Router } from '@angular/router';
import { Roles } from '../../core/constants/roles.constant';
import { PermissionException } from '../../core/exceptions/permission.exception';
import { assertIsPermissionError } from '../../core/guards/error-type-guard/error-type.guard';
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
    try {
      this._authorizationService.requireAnyPermissions([
        this._authorizationService.isLoggedIn(this.getUserId())
      ])

      if (this._authorizationService.isA(Roles.User)) {
        console.log('Redirecting to user page...')
      }
      else if (this._authorizationService.isA(Roles.Admin)) {
        console.log('Redirecting to admin page...')
      }
      else if (this._authorizationService.isA(Roles.Seller)) {
        console.log('Redirecting to seller page...')
      }

    }
    catch (err) {
      assertIsPermissionError(err)     
      this.router.navigate(['authentication/sign-in'])
    }   
  }

}
