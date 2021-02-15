import { methods, callService } from '../libs/crud-manager'

import { CustomerCrud } from '../libs/customer'
import { SiteCrud } from '../libs/site'
import { ProductCrud } from '../libs/product'

import { License } from '../models/license'

class _LicenseWizard {
    ctx;
    crud_customer;
    crud_site;
    crud_product;

    // REQUIRED SELECTIONS
    customer = null;
    site = null;
    product = null;

    constructor() {
    }

    setCtx(ctx) {
        this.ctx = ctx;
        this.crud_customer = new CustomerCrud(this.ctx);
        this.crud_site = new SiteCrud(this.ctx);
        this.crud_product = new ProductCrud(this.ctx);
    }

    createLicense() {
        var license = new License();
        license.siteID = this.site;
        license.productID = this.product;

        callService(
            methods.post,
            'license',
            license
        )
        .then(response => {
            console.log(response.data);
        })
    }
}

export const LicenseWizard = new _LicenseWizard();