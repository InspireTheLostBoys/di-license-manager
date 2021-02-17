<template>
  <v-container>
  <h2>Sites:</h2>
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
import { SiteCrud } from "../../libs/site";

export default {
  data() {
    return {
      crudManager: new SiteCrud(this),
      headers: [
        {
          text: "Name",
          value: "siteName",
        },
        {
          text: "Customer ID",
          value: "customerID",
        },
        {
          text: "",
          value: "actions",
          align: "end"
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