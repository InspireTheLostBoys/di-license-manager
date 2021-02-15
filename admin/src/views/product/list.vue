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
import { ProductCrud } from "../../libs/product";

export default {
  data() {
    return {
      crudManager: new ProductCrud(this),
      headers: [
         {
          text: "Product Name",
          value: "productName",
        },
        {
          text: "Product Description",
          value: "productDescription",
        },
        {
          text: "Supplier",
          value: "supplier",
        }, 
         {
          text: "Product ID",
          value: "productID",
        },
        {
          text: "Date Time",
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