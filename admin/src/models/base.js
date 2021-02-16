export class ModelBase {
    constructor() {
    }

    // link back end to front end
    mapData(dataObj) {
        if (dataObj != undefined && dataObj != null) {
            for (var prop in dataObj) {
                this[prop] = dataObj[prop];
            }
        }
    }

    //get crud via axios call
    static toList(dataObjList) {
        let retval = [];

        dataObjList.forEach(element => {
            retval.push(new this(element));
        });

        return retval;
    }
}