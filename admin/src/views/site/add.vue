<template>
  <v-container>
      <v-form @submit.prevent="crudManager.create()">
        <v-text-field
          label="Site Name"
          v-model="crudManager.formObj.siteName"
        ></v-text-field>
        <v-text-field
          label="Customer ID"
          type="number"
          v-model="crudManager.formObj.customerID"
        ></v-text-field>
        <v-btn type="submit" color="success">Submit</v-btn>
      </v-form>
  </v-container>
</template>

<script>
import { SiteCrud } from "../../libs/site";

export default {
  data() {
    return {
      crudManager: this.license_wizard().crud_site
    };
  },
};
</script>