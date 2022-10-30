export class PermissionException extends Error {
  constructor(errorMessage: string) {
    super(errorMessage)
  }
}
