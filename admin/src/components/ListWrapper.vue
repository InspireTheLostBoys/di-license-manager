<template>
  <v-container>
    <h2>{{ header }}</h2>
    <input type="text" v-model="search" placeholder="Search endpoint..." />
    <slot name="search" v-bind:search="search" />
  </v-container>
</template>

<script>
export default {
  props: {
    header: String,
  },
  data: () => ({
    search: "",
  }),
};
</script>