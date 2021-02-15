<template>
    <v-form @submit.prevent="crudManager.create">
        <v-text-field
            label="Name"
            v-model="crudManager.formObj.name"
        ></v-text-field>
        <v-btn type="submit" color="success">Submit</v-btn>
    </v-form>
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