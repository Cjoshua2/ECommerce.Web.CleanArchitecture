import { PermissionResult } from "./authorization.service";

export interface IAuthorizationService {
  hasAccess(userRole: string, authorizedRoles: string[]): PermissionResult
  isLoggedIn(userId: number): PermissionResult
  isA(authorizedRole: string): PermissionResult
  requireAllPermissions(permissionResults: PermissionResult[]): void
  requireAnyPermissions(permissionResults: PermissionResult[]): void
}
