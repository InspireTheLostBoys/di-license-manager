import { ModelBase } from './base'

export class Site extends ModelBase {
    id = 0;
    siteName = "";
    customerID = 0;

    constructor(dataObj) {
        super();
        this.mapData(dataObj);
    }
}