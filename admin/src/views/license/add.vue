<template>
<v-container>
    <v-form @submit.prevent="crudManager.create">
        <v-text-field
            label="ProductID"
            v-model="crudManager.formObj.productID"
        ></v-text-field>
        <v-text-field
            label="SiteID"
            v-model="crudManager.formObj.siteID"
        ></v-text-field>
        <v-text-field
            label="AdminUserID"
            v-model="crudManager.formObj.adminUserID"
        ></v-text-field>
        <v-text-field
            label="Email"
            v-model="crudManager.formObj.email"
        ></v-text-field>
        <v-text-field
            label="ExpiryDate"
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