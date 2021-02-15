import { CrudManager } from "./crud-manager";
import { AdminUser } from '../models/adminUser'

export class AdminUserCrud extends CrudManager {
    constructor(context) {
        super('adminUser', AdminUser, context)
    }
}