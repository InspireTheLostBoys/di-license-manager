<template>
  <v-container>
    <ListWrapper header="Email Settings">
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
import { EmailSettingsCrud } from "../../libs/emailSettings";
import ListWrapper from '../../components/ListWrapper.vue';
import List from "../../components/List.vue";

export default {
  components: {
    ListWrapper,
    List
  },
  data() {
    return {
      crudManager: new EmailSettingsCrud(this),
      headers: [
        {
          text: "License Expires In X Months",
          align: "center",
          value: "licenseExpiresInXMonths",
        },
        {
          text: "",
          value: "actions",
          align: "end",
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