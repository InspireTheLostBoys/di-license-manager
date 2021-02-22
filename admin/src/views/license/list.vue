<template>
  <v-container>
    <ListWrapper header="License">
      <template v-slot:search="params">
        <List
          :search="params.search"
          :headers="headers"
          :crudManager="crudManager"
        >
        </List>
      </template>
    </ListWrapper>
    <v-btn text @click="crudManager.onAdd()" class="mr-3">Add</v-btn>
    <v-btn class="primary" @click="$router.push('/')">Back</v-btn>
  </v-container>
</template>

<script>
import { LicenseCrud } from "../../libs/license";
import ListWrapper from '../../components/ListWrapper.vue';
import List from "../../components/List.vue";

export default {
  components: {
    ListWrapper,
    List
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