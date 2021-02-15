import { CrudManager } from "./crud-manager";
import { License } from '../models/license'

export class LicenseCrud extends CrudManager {
    constructor(context) {
        super('license', License, context)
    }
}