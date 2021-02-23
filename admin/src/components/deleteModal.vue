<template>
  <v-row justify="center">
    <v-dialog persistent max-width="500" v-model="dialog">
      <v-card>
        <v-card-text class="headline"
          >Are you sure you want to delete this record?</v-card-text
        >
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="primary" text @click="dialog=false">Cancel</v-btn>
          <v-btn color="primary" text @click="onConfirm">OK</v-btn>
          <v-spacer></v-spacer>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script>
export default {
//   props: {
//     crudManager: Object,
//   },
  data() {
    return {
      dialog: false,
      crudManager: null,
      item: null
      // afterReturn: null,
    };
  },

  methods: {
    // show(afterReturn){
    //   this.afterReturn = afterReturn;
    //   this.dialog = true;
    // },

    show(crudManager, item) {
      this.crudManager = crudManager;
      this.item = item
      this.dialog = true;
    },

    // onSelect(val) {
    //   this.afterReturn(val);
    //   this.dialog = false;
    // },

    onConfirm() {
      this.crudManager.delete(this.item);
      this.dialog = false;
    },
  },
};
</script>