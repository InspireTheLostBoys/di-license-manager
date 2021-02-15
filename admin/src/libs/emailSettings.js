import { CrudManager } from "./crud-manager";
import { EmailSettings } from '../models/emailSettings'

export class EmailSettingsCrud extends CrudManager {
    constructor(context) {
        super('email', EmailSettings, context)      //(end-point, model, vue-context)
    }
}