<template>
  <v-container>
    <h1>INDEX PAGE</h1>
    <v-btn @click="goTo" color="success"> Add license</v-btn>

    <v-list>
      <v-list-item
        v-for="listItem in list"
        :key="listItem.id"
        @click="$router.push(listItem.path)"
      >
        <v-list-item-content>{{ listItem.title }}</v-list-item-content>
      </v-list-item>
    </v-list>
  </v-container>
</template>

<script>
export default {

  data: () => ({
    list: [
      { title: "Admin Users", path: "/adminUser" },
      { title: "Customers", path: "/customer" },
      { title: "Email Setings", path: "/email" },
      { title: "Licenses", path: "/license" },
      { title: "Products", path: "/product" },
      { title: "Recipients", path: "/recipient" },
      { title: "Sites", path: "/site" },
      
    ],
  }),
  
  methods: {
    goTo() {
      let self = this;
      self.$router.push("/new-or-existing-customer");
    },
  },
};
</script>