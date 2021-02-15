import { ModelBase } from './base'

export class License extends ModelBase {
    id = 0;
    customerID = 0;
    siteID = 0;
    productID = 0;
    customerName = "";
    dateTime = 0;

    constructor(dataObj) {
        super();
        this.mapData(dataObj);
    }
}