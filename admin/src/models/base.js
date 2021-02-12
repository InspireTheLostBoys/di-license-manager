export class ModelBase {
    constructor() {
    }

    mapData(dataObj) {
        if(dataObj != undefined && dataObj != null) {
            for(var prop in dataObj) {
                this[prop] = dataObj[prop];
            }
        }
    }

    static toList(dataObjList) {
        let retval = [];

        dataObjList.forEach(element => {
            retval.push(new this(element));
        });

        return retval;
    }
}