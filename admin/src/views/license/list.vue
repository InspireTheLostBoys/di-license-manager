<template>
  <v-container>
    <v-btn @click="crudManager.onAdd()">Add</v-btn>
    <v-data-table :headers="headers" :items="crudManager.list">
      <template v-slot:item.actions="{ item }">
        <v-btn @click="editItem(item)">edit</v-btn>
        <v-btn @click="deleteItem(item)">delete</v-btn>
      </template>
    </v-data-table>
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
          text: "ProductID",
          value: "productID",
        },
        
        {
          text: "SiteID",
          value: "siteID",
        },
        
        {
          text: "AdminUserID",
          value: "adminUserID",
        },
        
        {
          text: "Email",
          value: "email",
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