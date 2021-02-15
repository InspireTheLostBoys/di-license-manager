import { ModelBase } from './base'

export class EmailSettings extends ModelBase {
    id = 0;
    licenseExpiresInXMonths = 0;

    constructor(dataObj) {
        super();
        this.mapData(dataObj);
    }
}