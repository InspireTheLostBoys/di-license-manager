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
        super();        //By calling the super() method in the constructor method, we call the parent's constructor method and get access to the parent's properties and methods:
        this.mapData(dataObj);
    }
}