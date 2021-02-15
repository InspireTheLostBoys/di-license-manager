<template>
<v-container>
    <v-form @submit.prevent="crudManager.update">
       <v-text-field
            label="Product Name"
            v-model="crudManager.formObj.productName"
        ></v-text-field>
                <v-text-field
            label="Product Description"
            v-model="crudManager.formObj.productDescription"
        ></v-text-field>
                <v-text-field
            label="Supplier"
            v-model="crudManager.formObj.supplier"
        ></v-text-field>
                <v-text-field
            label="Date Created:"
            v-model="crudManager.formObj.dateTime"
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