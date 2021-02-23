<template>
  <v-container>
    <ListWrapper header="Recipients">
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
import { RecipientCrud } from "../../libs/recipient";
import ListWrapper from "../../components/ListWrapper.vue";
import List from "../../components/List.vue";

export default {
  components: {
    ListWrapper,
    List
  },
  data() {
    return {
      crudManager: new RecipientCrud(this),
      headers: [
        {
          text: "Name",
          value: "recipientName",
        },
        {
          text: "siteID",
          value: "siteID",
        },
        ,
        {
          text: "emailAddress",
          value: "emailAddress",
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