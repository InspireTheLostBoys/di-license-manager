<template>
  <v-container>
      <v-form @submit.prevent="crudManager.update">
        <v-text-field
          label="Site Name"
          v-model="crudManager.formObj.siteName"
        ></v-text-field>

        <v-text-field
          label="customerID"
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
      crudManager: new SiteCrud(this),
    };
  },
};
</script>