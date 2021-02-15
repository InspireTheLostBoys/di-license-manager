import { ModelBase } from './base'

export class Product extends ModelBase {
    id = 0;
    supplier = "";
    productName = "";
    productDescription = "";
    productID = 0;
    dateTime = 0;

    constructor(dataObj) {
        super();
        this.mapData(dataObj);
    }
}