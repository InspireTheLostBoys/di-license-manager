<template>
  <v-container>
    <ListWrapper header="Sites">
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
import { SiteCrud } from "../../libs/site";
import ListWrapper from "../../components/ListWrapper.vue";
import List from "../../components/List.vue";

export default {
  components: {
    ListWrapper,
    List
  },
  data() {
    return {
      crudManager: new SiteCrud(this),
      headers: [
        {
          text: "Name",
          value: "siteName",
        },
        {
          text: "Customer ID",
          value: "customerID",
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
  }
};
</script>