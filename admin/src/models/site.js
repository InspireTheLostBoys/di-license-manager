import { ModelBase } from './base'

export class Site extends ModelBase {
    id = 0;
    name = "";
    customerID = 0;

    constructor(dataObj) {
        super();
        this.mapData(dataObj);
    }
}