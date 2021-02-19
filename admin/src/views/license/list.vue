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
import { LicenseCrud } from "../../libs/license";
import ListWrapper from '../../components/ListWrapper.vue'

export default {
  components: {
    ListWrapper
  },
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