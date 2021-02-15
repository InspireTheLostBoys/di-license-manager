import Axios from 'axios'

export class CrudManager {
    ctx;
    endpoint;
    formObj;
    defaultModel;
    list = [];

    constructor(endpoint, defaultModel, context) {
        this.endpoint = endpoint;
        this.defaultModel = defaultModel;
        this.formObj = new this.defaultModel();
        this.ctx = context;
        this.getData();
    }

    onAdd() {
        console.log(this)
        this.ctx.$router.push(`/${this.endpoint}/add`);
    }

    onEdit(item) {
        this.ctx.$router.push(`/${this.endpoint}/edit/${item.id}`);
    }

    getData() {
        callService(
            methods.get,
            this.endpoint
        )
        .then(response => {
            this.list = this.defaultModel.toList(response);
            CheckEdit(this)
        })
        .catch(err => {
            console.log(err);
        })
    }

    create() {
        callService(
            methods.post,
            this.endpoint,
            this.formObj
        )
        .then(response => {
            this.ctx.$router.push(`/${this.endpoint}`);
        })
        .catch(err => {
            console.log(err);
        })
    }

    update() {
        callService(
            methods.put,
            this.endpoint,
            this.formObj
        )
        .then(response => {
            this.ctx.$router.push(`/${this.endpoint}`);
        })
        .catch(err => {
            console.log(err);
        })
    }

    delete(dataObj) {
        callService(
            methods.delete,
            this.endpoint + '?id=' + dataObj.id
        )
        .then(response => {
            this.list.splice(this.list.indexOf(dataObj), 1);
        })
        .catch(err => {
            console.log(err);
        })
    }
}

const methods = {
    get: "get",
    post: "post",
    put: "put",
    delete: "delete"
}

function callService(method, endpoint, formObj) {
    return new Promise((res, rej) => {
        Axios[method]('http://localhost:50211/' + endpoint, formObj)
            .then(r => {
                res(r.data);
            })
            .catch(e => {
                rej(e);
            })
    })
}

function CheckEdit(ctrl) {
    let params = ctrl.ctx.$route.params;

    if(params != undefined && params != null) {
        let obj = ctrl.list.find(item => {
            return item.id == params.id;
        })

        ctrl.formObj = new ctrl.defaultModel(obj);
    }
}