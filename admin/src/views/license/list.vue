<template>
  <div>
    <v-btn @click="crudManager.onAdd()">Add</v-btn>
    <v-data-table :headers="headers" :items="crudManager.list">
      <template v-slot:item.actions="{ item }">
        <v-btn @click="editItem(item)">edit</v-btn>
        <v-btn @click="deleteItem(item)">delete</v-btn>
      </template>
    </v-data-table>
  </div>
</template>

<script>
import { LicenseCrud } from "../../libs/license";

export default {
  data() {
    return {
      crudManager: new LicenseCrud(this),
      headers: [
        {
          text: "CustomerID",
          value: "customerID",
        },
        {
          text: "SiteID",
          value: "siteID",
        },
         {
          text: "ProductID",
          value: "productID",
        },
         {
          text: "CustomerName",
          value: "customerName",
        },
        {
          text: "DateTime",
          value: "dateTime",
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