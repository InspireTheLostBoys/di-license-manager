import { ModelBase } from './base'

export class License extends ModelBase {
    id = 0;
    productID = 0;
    siteID = 0;
    adminUserID = 0;
    expiryDate = new Date();
    notes = "";

    constructor(dataObj) {
        super();
        this.mapData(dataObj);
    }
}