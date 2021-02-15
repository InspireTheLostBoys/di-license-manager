import { CrudManager } from "./crud-manager";
import { Site } from '../models/site'

export class SiteCrud extends CrudManager {
    constructor(context) {
        super('site', Site, context)
    }
}