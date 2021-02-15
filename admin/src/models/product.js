import { ModelBase } from './base'

export class Product extends ModelBase {
    id = 0;
    productSupplier = "";
    productName = "";

    constructor(dataObj) {
        super();
        this.mapData(dataObj);
    }
}