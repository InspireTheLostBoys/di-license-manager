<template>
  <v-container>
      <v-data-table
        :search="search"
        :items="crudManager.list"
        :headers="headers"
      >
      </v-data-table>
    
  </v-container>
</template>

<script>
export default {
  props: {
    search: String,
    crudManager: Object,
    headers: Array,
  },

  data: () => ({}),
};
</script>