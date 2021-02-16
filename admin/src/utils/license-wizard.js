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
        this.crud_customer.afterCreateRoute = "/customer-select"

        // console.log(this.crud_customer)

        this.crud_site = new SiteCrud(this.ctx);
        this.crud_site.afterCreateRoute = "/site-select"

        this.crud_product = new ProductCrud(this.ctx);
        this.crud_site.afterCreateRoute = "/license"

    }

    setCustomer(customer) {
        this.customer = customer;
        this.ctx.$router.push('/new-or-existing-site')
    }

    setSite(site) {
        this.site = site;
        this.ctx.$router.push('/new-or-existing-product')
    }

    setProduct(product) {
        this.product = product;
        this.ctx.$router.push('/license')
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