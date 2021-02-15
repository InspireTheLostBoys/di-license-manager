import { CrudManager } from "./crud-manager";
import { product } from '../models/product'

export class ProductCrud extends CrudManager {
    constructor(context) {
        super('product', product, context)
    }
}