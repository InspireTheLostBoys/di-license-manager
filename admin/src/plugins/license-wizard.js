import Vue from 'vue';

import { LicenseWizard } from '../utils/license-wizard'

Vue.use({
    install(VUE) {
        VUE.prototype.license_wizard = function() {
            return LicenseWizard;
        }

        VUE.prototype.setLicenseWizardCtx = function(ctx) {
            LicenseWizard.setCtx(ctx);
        }
    }
});
