import { CrudManager } from "./crud-manager";
import { Site } from '../models/site'

export class SiteCrud extends CrudManager {
    // afterCreateRoute = `/${this.endpoint}`;

    constructor(context) {
        super('site', Site, context)
    }

    afterCreate(response) {
        this.ctx.license_wizard().crud_site.list.push(response);
        this.ctx.$router.push('/site-select');
    }
}