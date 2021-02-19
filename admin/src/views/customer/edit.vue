<template>
  <v-container>
    <v-form @submit.prevent="crudManager.update">
      <v-text-field
        label="customer Name"
        v-model="crudManager.formObj.customerName"
      ></v-text-field>
      <v-text-field
        label="email Address"
        v-model="crudManager.formObj.emailAddress"
      ></v-text-field>
      <v-text-field
        label="address Line 1"
        v-model="crudManager.formObj.addressLine1"
      ></v-text-field>
      <v-text-field
        label="address Line 2"
        v-model="crudManager.formObj.addressLine2"
      ></v-text-field>
      <v-text-field
        label="city"
        v-model="crudManager.formObj.city"
      ></v-text-field>
      <v-text-field
        label="province Or State"
        v-model="crudManager.formObj.provinceOrState"
      ></v-text-field>
      <v-text-field
        label="postal Code"
        v-model="crudManager.formObj.postalCode"
      ></v-text-field>

      <v-btn type="submit" color="success">Submit</v-btn>
    </v-form>
  </v-container>
</template>

<script>
import { CustomerCrud } from "../../libs/customer";

export default {
  data() {
    return {
      crudManager: new CustomerCrud(this),
    };
  },
};
</script>