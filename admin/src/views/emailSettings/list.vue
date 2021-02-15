<template>
  <v-container>
  <h2>Email Settings: </h2>
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
import { EmailSettingsCrud } from "../../libs/emailSettings";

export default {
  data() {
    return {
      crudManager: new EmailSettingsCrud(this),
      headers: [
        {
          text: "License Expires In X Months",
          value: "licenseExpiresInXMonths",
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