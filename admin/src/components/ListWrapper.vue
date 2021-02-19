<template>
  <v-container>
    <h2>Customers:</h2>
    <input type="text" v-model="search" placeholder="Search title.." />
    <slot name="search" v-bind:search="search" />
  </v-container>
</template>

<script>
export default {
  data: () => ({
    search: "",
  }),
};
</script>