import { CrudManager } from "./crud-manager";
import { Product } from '../models/product'

export class ProductCrud extends CrudManager {
    // afterCreateRoute = `/${this.endpoint}`;

    constructor(context) {
        super('product', Product, context)
    }

    afterCreate(response) {
        this.ctx.license_wizard().crud_product.list.push(response);
        this.ctx.$router.push('/license');
    }
}