import { ModelBase } from './base'

export class Recipient extends ModelBase {
    id = 0;
    siteID = 0;
    recipientName = "";
    emailAddress = "";

    constructor(dataObj) {
        super();
        this.mapData(dataObj);
    }
}