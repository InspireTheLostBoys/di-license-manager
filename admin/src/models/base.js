export class ModelBase {
    constructor() {
    }

    // link back end to front end
    mapData(dataObj) {
        if (dataObj != undefined && dataObj != null) {
            for (var prop in dataObj) {
                this[prop] = dataObj[prop];     //set F-end = to B-end
            }
        }
    }

    //get crud via axios call
    static toList(dataObjList) {
        let retval = [];

        dataObjList.forEach(element => {
            retval.push(new this(element));     //Push data into retval[]
        });

        return retval;
    }


    //THIS HAS BEEN SPLIT INTO 2 SEPERATE METHODS.DET THE DATA AND THEN PUSH INTO A LIST :: =>

    // getCustomers() {
    //     let self = this;
    //1)
    //     self.get("Customers").then((r) => {
    //       self.customers = [];
    
    //2)
    //       r.data.forEach((customer) => {
    //         self.customers.push({
    //           id: customer.id,
    //           customerName: customer.customerName,
    //           customerEmail: customer.customerEmail,
    //         });
    //       });
    //       console.log(this.$store.state.customers);
    //     });
    //   }




}