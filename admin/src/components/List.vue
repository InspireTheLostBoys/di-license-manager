<template>
  <v-container>
    <v-data-table :search="search" :items="crudManager.list" :headers="headers">
      <template v-slot:item.actions="{ item }">
        <v-btn text @click="comfirmDelete(item)">Delete</v-btn>
      </template>
    </v-data-table>
    <deleteModal ref="deleteModal" :delete="crudManager.delete"></deleteModal>
  </v-container>
</template>

<script>
import deleteModal from "./deleteModal.vue";
export default {
  components: {
    deleteModal,
  },
  props: {
    search: String,
    crudManager: Object,
    headers: Array,
  },

  methods: {
    // comfirmDelete(item){
    //   this.$refs.deleteModal.show(val => {
    //     if (val){
    //       this.crudManager.delete(item)
    //     }
    //   })
    // }
    comfirmDelete(item) {
      this.$refs.deleteModal.show(this.crudManager, item);
    },
  },
};
</script>