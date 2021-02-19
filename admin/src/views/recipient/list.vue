<template>
  <v-container>
    <ListWrapper>
      <template v-slot:search="params">
        <v-data-table
          :search="params.search"
          :headers="headers"
          :items="crudManager.list"
        >
          <template v-slot:item.actions="{ item }">
            <v-btn disabled text @click="editItem(item)">edit</v-btn>
            <v-btn disabled text @click="deleteItem(item)">delete</v-btn>
          </template>
        </v-data-table>
      </template>
    </ListWrapper>
    <v-btn class="primary" @click="crudManager.onAdd()">Add</v-btn>
    <v-btn class="primary" @click="$router.push('/')">Back</v-btn>
  </v-container>
</template>

<script>
import { RecipientCrud } from "../../libs/recipient";
import ListWrapper from "../../components/ListWrapper.vue";

export default {
  components: {
    ListWrapper,
  },
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