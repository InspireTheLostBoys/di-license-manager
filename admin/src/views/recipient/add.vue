<template>
<v-container>
    <v-form @submit.prevent="crudManager.create">
        <v-text-field
            label="recipientName"
            v-model="crudManager.formObj.recipientName"
        ></v-text-field>
        <v-text-field
            label="siteID"
            v-model="crudManager.formObj.siteID"
        ></v-text-field>
        <v-text-field
            label="emailAddress"
            v-model="crudManager.formObj.emailAddress"
        ></v-text-field>
        <v-btn type="submit" color="success">Submit</v-btn>
    </v-form>
</v-container>
</template>

<script>
import { RecipientCrud } from '../../libs/recipient'

export default {
    data() {
        return {
            crudManager: new RecipientCrud(this)
        }
    }
}
</script>