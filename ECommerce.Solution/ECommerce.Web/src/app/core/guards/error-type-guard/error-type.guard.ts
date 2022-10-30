import { PermissionException } from "../../exceptions/permission.exception";

export function assertIsPermissionError(error: unknown): asserts error is PermissionException {
  if (!(error instanceof PermissionException)) {
    throw error
  }
}
