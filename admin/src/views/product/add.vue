<template>
  <v-container>
    <v-form @submit.prevent="crudManager.create()">
      <v-text-field
        label="Product Name"
        v-model="crudManager.formObj.productName"
      ></v-text-field>
      <v-text-field
        label="Supplier"
        v-model="crudManager.formObj.productSupplier"
      ></v-text-field>

      <v-btn type="submit" @click="addLicense" color="success">Submit</v-btn>
    </v-form>
  </v-container>
</template>

<script>
import { ProductCrud } from "../../libs/product";

export default {
  data() {
    return {
      crudManager: this.license_wizard().crud_product,
      // addLicense: this.license_wizard().createLicense()
    };
  },
};
</script>