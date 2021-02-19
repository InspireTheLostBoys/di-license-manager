<template>
  <v-container>
    <ListWrapper>
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
import { EmailSettingsCrud } from "../../libs/emailSettings";
import ListWrapper from '../../components/ListWrapper.vue'

export default {
  components: {
    ListWrapper
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