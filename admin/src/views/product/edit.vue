<template>
<v-container>
    <v-form @submit.prevent="crudManager.update">
        <v-text-field
            label="productName"
            v-model="crudManager.formObj.productName"
        ></v-text-field>
        <v-text-field
            label="productSupplier"
            v-model="crudManager.formObj.productSupplier"
        ></v-text-field>
        <v-btn type="submit" color="success">Submit</v-btn>
    </v-form>
</v-container>
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