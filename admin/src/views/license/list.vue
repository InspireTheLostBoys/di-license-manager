<template>
  <v-container>
  <h2>Licenses: </h2>
    <v-btn disabled @click="crudManager.onAdd()">Add</v-btn>
    <v-data-table :headers="headers" :items="crudManager.list">
      <template v-slot:item.actions="{ item }">
        <v-btn disabled text @click="editItem(item)">edit</v-btn>
        <v-btn disabled text @click="deleteItem(item)">delete</v-btn>
      </template>
    </v-data-table>
    <v-btn class="primary" @click="$router.push('/')">Back</v-btn>
  </v-container>
</template>

<script>
import { LicenseCrud } from "../../libs/license";

export default {
  data() {
    return {
      crudManager: new LicenseCrud(this),
      headers: [
        {
          text: "Product ID",
          value: "productID",
        },
        
        {
          text: "Site ID",
          value: "siteID",
        },
        {
          text: "Admin User ID",
          value: "adminUserID",
        },
        
        {
          text: "ExpiryDate",
          value: "expiryDate",
        },
        
        {
          text: "Notes",
          value: "notes",
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