import { CrudManager } from "./crud-manager";
import { Recipient } from '../models/recipient'

export class RecipientCrud extends CrudManager {
    constructor(context) {
        super('recipient', Recipient, context)
    }
}