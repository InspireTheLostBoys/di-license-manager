<template>
  <div>
    <v-text-field
      label="Customer Name"
      v-model="crudManager.formObj.customerName"
    ></v-text-field>
    <v-text-field
      label="Email Address"
      v-model="crudManager.formObj.emailAddress"
    ></v-text-field>
    <v-text-field
      label="Address Line 1"
      v-model="crudManager.formObj.addressLine1"
    ></v-text-field>
    <v-text-field
      label="Address Line 2"
      v-model="crudManager.formObj.addressLine2"
    ></v-text-field>
    <v-text-field
      label="City"
      v-model="crudManager.formObj.city"
    ></v-text-field>
    <v-text-field
      label="Province Or State"
      v-model="crudManager.formObj.provinceOrState"
    ></v-text-field>
    <v-text-field
      label="Postal Code"
      v-model="crudManager.formObj.postalCode"
    ></v-text-field>
    <v-btn type="submit" color="success">Submit</v-btn>
  </div>
</template>

<script>
export default {
  props: {
    crudManager: Object,
  },
};
</script>