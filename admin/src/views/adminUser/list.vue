<template>
  <v-container>
    <ListWrapper header="Admin User">
      <template v-slot:search="params">
     
        <v-data-table
          :search="params.search"
          :headers="headers"
          :items="crudManager.list"
        >
          <template v-slot:item.actions="{ item }">
            <v-btn text @click="editItem(item)">edit</v-btn>
            <v-btn text @click="deleteItem(item)">delete</v-btn>
          </template>
        </v-data-table>
      </template>
    </ListWrapper>

    <v-btn @click="crudManager.onAdd()">Add</v-btn>

    <v-btn class="primary" @click="$router.push('/')">Back</v-btn>
  </v-container>
</template>

<script>
import { AdminUserCrud } from "../../libs/adminUser";
import ListWrapper from "../../components/ListWrapper.vue";

export default {
  name: "adminUsers-list",
  components: {
    ListWrapper,
  },
  data() {
    return {
      crudManager: new AdminUserCrud(this),
      headers: [
        {
          text: "First Name",
          value: "firstName",
        },
        {
          text: "Last Name",
          value: "lastName",
        },
        {
          text: "Email Address",
          value: "emailAddress",
        },
        {
          text: "Password",
          value: "password",
        },
        {
          text: "Active",
          value: "active",
        },
        {
          text: "LastLoggedInDateTime",
          value: "lastLoggedInDateTime",
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