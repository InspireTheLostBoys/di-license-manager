import { ModelBase } from './base'

export class AdminUser extends ModelBase {
    id = 0;
    firstName = "";
    lastName = "";
    emailAddress = "";
    password = "";
    active = false;
    lastLoggedInDateTime = new Date();
    
    constructor(dataObj) {
        super();
        this.mapData(dataObj);
    }
}