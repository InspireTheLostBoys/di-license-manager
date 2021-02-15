import { CrudManager } from "./crud-manager";
import { Car } from '../models/car'

export class CarCrud extends CrudManager {
    constructor(context) {
        super('car', Car, context)
    }

    afterCreate() {
    }
}