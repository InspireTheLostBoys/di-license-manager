import { CrudManager } from "./crud-manager";
import { Customer } from '../models/customer'

export class CustomerCrud extends CrudManager {
    constructor(context) {
        super('customer', Customer, context)
    }
}