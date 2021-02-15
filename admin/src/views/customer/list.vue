<template>
  <v-container>
    <v-btn @click="crudManager.onAdd()">Add</v-btn>
    <v-data-table :headers="headers" :items="crudManager.list">
      <template v-slot:item.actions="{ item }">
        <v-btn text @click="editItem(item)">edit</v-btn>
        <v-btn text @click="deleteItem(item)">delete</v-btn>
      </template>
    </v-data-table>
  </v-container>
</template>

<script>
import { CustomerCrud } from "../../libs/customer";

export default {
  name: "customers-list",
  data() {
    return {
      crudManager: new CustomerCrud(this),
      headers: [
        {
          text: "CustomerName",
          value: "customerName",
        },
        {
          text: "EmailAddress",
          value: "emailAddress",
        },
        {
          text: "AddressLine1",
          value: "addressLine1",
        },
        {
          text: "AddressLine2",
          value: "addressLine2",
        },
        {
          text: "City",
          value: "city",
        },
        {
          text: "ProvinceOrState",
          value: "provinceOrState",
        },
        ,
        {
          text: "PostalCode",
          value: "postalCode",
        },
        {
          text: "",
          value: "actions",
        },
      ],
    };
  },
  created() {
      console.log(this.crudManager)
  },
  methods: {
      editItem(item) {
          this.crudManager.onEdit(item);
      },
      deleteItem(item) {
          this.crudManager.delete(item);
      }
  }
};
</script>