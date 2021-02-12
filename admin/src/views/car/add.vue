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
import { CarCrud } from '../../libs/car'

export default {
    data() {
        return {
            crudManager: new CarCrud(this)
        }
    }
}
</script>