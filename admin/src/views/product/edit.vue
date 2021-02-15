<template>
    <v-form @submit.prevent="crudManager.update">
        <v-text-field
            label="Name"
            v-model="crudManager.formObj.name"
        ></v-text-field>
        <v-btn type="submit" color="success">Submit</v-btn>
    </v-form>
</template>

<script>
import { ProductCrud } from '../../libs/product'

export default {
    data() {
        return {
            crudManager: new ProductCrud(this)
        }
    }
}
</script>