import { BaseComponent } from "../../modules/base.component";
import { PermissionException } from "../exceptions/permission.exception";
import { IAuthorizationService } from "./authorization.interface";

export class AuthorizationService extends BaseComponent implements IAuthorizationService {
  isA(authorizedRole: string): PermissionResult {
    let errorMessage = undefined
    let userRole = this.getRoleCode()

    let authorized = userRole === authorizedRole

    if (!authorized)
      errorMessage = 'Unauthorized role'

    return <PermissionResult>{
      hasAccess: authorized,
      errorMsg: errorMessage
    }
  }
  isLoggedIn(userId: number): PermissionResult {
    //check if user is currently logged in
    return <PermissionResult>{
      hasAccess: true,
      errorMsg: undefined
    }
  }
  hasAccess(userRole: string, authorizedRoles: string[]): PermissionResult {
    let errorMessage = undefined
    let authorized = authorizedRoles.some(role => role === userRole)
    if (!authorized)
      errorMessage = 'Unauthorized role'

    return <PermissionResult>{
      hasAccess: authorized,
      errorMsg: errorMessage
    }
  }

  /*
   * All permissions should be authorized
   */
  requireAllPermissions(permissionResults: PermissionResult[]): void {
    if (permissionResults.some(result => !result.hasAccess)) {
      throw new PermissionException(permissionResults.map(error => error.errorMsg).join(","))
    }
  }
  /*
   * All permissions doesn't have to be authorized
   */
  requireAnyPermissions(permissionResults: PermissionResult[]): void {
    if (permissionResults.every(result => !result.hasAccess)) {
      throw new PermissionException(permissionResults.map(error => error.errorMsg).join(","))
    }
  }
}


export interface PermissionResult {
  hasAccess: boolean
  errorMsg?: string
}
