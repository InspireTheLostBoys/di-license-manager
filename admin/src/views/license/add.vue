<template>
<v-container>
    <v-form @submit.prevent="crudManager.create">
        <v-text-field
            label="Product ID"
            v-model="crudManager.formObj.productID"
        ></v-text-field>
        <v-text-field
            label="Site ID"
            v-model="crudManager.formObj.siteID"
        ></v-text-field>
        <v-text-field
            label="AdminUser ID"
            v-model="crudManager.formObj.adminUserID"
        ></v-text-field>
        <v-text-field
            label="Email"
            v-model="crudManager.formObj.email"
        ></v-text-field>
        <v-text-field
            label="Expiry Date"
            v-model="crudManager.formObj.expiryDate"
        ></v-text-field>
        <v-text-field
            label="Notes"
            v-model="crudManager.formObj.notes"
        ></v-text-field>
        <v-btn type="submit" color="success">Submit</v-btn>
    </v-form>
</v-container>
</template>

<script>
import { LicenseCrud } from '../../libs/license'

export default {
    data() {
        return {
            crudManager: new LicenseCrud(this)
        }
    }
}
</script>