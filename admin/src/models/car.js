import { ModelBase } from './base'

export class Car extends ModelBase {
    id = 0;
    name = "";

    constructor(dataObj) {
        super();
        this.mapData(dataObj);
    }
}