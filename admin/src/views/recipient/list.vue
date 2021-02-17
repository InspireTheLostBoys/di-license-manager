<template>
  <v-container>
    <h2>Recipients:</h2>
    <v-btn @click="crudManager.onAdd()">Add</v-btn>
    <v-data-table :headers="headers" :items="crudManager.list">
      <template v-slot:item.actions="{ item }">
        <v-btn text @click="editItem(item)">edit</v-btn>
        <v-btn text @click="deleteItem(item)">delete</v-btn>
      </template>
    </v-data-table>
    <v-btn class="primary" @click="$router.push('/')">Back</v-btn>
  </v-container>
</template>

<script>
import { RecipientCrud } from "../../libs/recipient";

export default {
  data() {
    return {
      crudManager: new RecipientCrud(this),
      headers: [
        {
          text: "Name",
          value: "recipientName",
        },
        {
          text: "siteID",
          value: "siteID",
        },
        ,
        {
          text: "emailAddress",
          value: "emailAddress",
        },
        {
          text: "",
          value: "actions",
        },
      ],
    };
  },
  created() {
    console.log(this.crudManager);
  },
  methods: {
    editItem(item) {
      this.crudManager.onEdit(item);
    },
    deleteItem(item) {
      this.crudManager.delete(item);
    },
  },
};
</script>