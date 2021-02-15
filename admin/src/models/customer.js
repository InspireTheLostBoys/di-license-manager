import { ModelBase } from './base'

export class Customer extends ModelBase {
    id = 0;
    customerName = "";
    emailAddress = "";
    addressLine1 = "";
    addressLine2 = "";
    city = "";
    provinceOrState = "";
    postalCode = 0;

    constructor(dataObj) {
        super();
        this.mapData(dataObj);
    }
}