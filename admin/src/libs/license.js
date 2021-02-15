import { CrudManager } from "./crud-manager";
import { license } from '../models/license'

export class LicenseCrud extends CrudManager {
    constructor(context) {
        super('license', license, context)
    }
}