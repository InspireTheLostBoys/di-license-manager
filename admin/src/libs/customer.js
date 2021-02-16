import { CrudManager } from "./crud-manager";
import { Customer } from '../models/customer'

export class CustomerCrud extends CrudManager {
    afterCreateRoute = `/${this.endpoint}`;

    constructor(context) {
        super('customer', Customer, context)
    }

    afterCreate(response) {
        this.ctx.license_wizard().crud_customer.list.push(response);
        this.ctx.$router.push(this.afterCreateRoute);
    }
}