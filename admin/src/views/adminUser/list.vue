<template>
  <v-container>
    <ListWrapper header="Admin Users">
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
import { AdminUserCrud } from "../../libs/adminUser";
import ListWrapper from "../../components/ListWrapper.vue";
import List from "../../components/List.vue";

export default {
  name: "adminUsers-list",
  components: {
    ListWrapper,
    List,
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
  }
};
</script>