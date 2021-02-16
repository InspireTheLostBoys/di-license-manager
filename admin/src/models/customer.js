import { ModelBase } from './base'

export class Customer extends ModelBase {
    id = 0;
    customerName = "";
    name = "";
    emailAddress = "";
    addressLine1 = "";
    addressLine2 = "";
    city = "";
    provinceOrState = "";
    postalCode = 0;
    dateTime = new Date();

    constructor(dataObj) {
        super();
        this.mapData(dataObj);
    }
}