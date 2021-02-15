import { CrudManager } from "./crud-manager";
import { Product } from '../models/product'

export class ProductCrud extends CrudManager {
    constructor(context) {
        super('product', Product, context)
    }
}