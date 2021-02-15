<template>
<v-container>
    <v-form @submit.prevent="crudManager.update">
        <v-text-field
            label="license Expires In X Months"
            v-model="crudManager.formObj.licenseExpiresInXMonths"
        ></v-text-field>
        <v-btn type="submit" color="success">Submit</v-btn>
    </v-form>
</v-container>
</template>

<script>
import { EmailSettingsCrud } from '../../libs/emailSettings'

export default {
    data() {
        return {
            crudManager: new EmailSettingsCrud(this)
        }
    }
}
</script>