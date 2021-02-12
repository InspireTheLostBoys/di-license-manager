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
import { CarCrud } from "../../libs/car";

export default {
  data() {
    return {
      crudManager: new CarCrud(this),
      headers: [
        {
          text: "Name",
          value: "name",
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