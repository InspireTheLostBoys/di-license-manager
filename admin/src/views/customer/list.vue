<template>
  <v-container>
    <ListWrapper header="Customer" >
      <template v-slot:search="params">      
      <List :search="params.search" :headers="headers" :crudManager="crudManager">
      </List>
      </template>
    </ListWrapper>

    <v-btn disabled @click="crudManager.onAdd()" class="mr-3">Add</v-btn>
    <v-btn class="primary" @click="$router.push('/')">Back</v-btn>
  </v-container>
</template>

<script>
import { CustomerCrud } from "../../libs/customer";
import ListWrapper from "../../components/ListWrapper.vue";
import List from "../../components/List.vue";

export default {
  components: {
    ListWrapper,
    List,
  },
  data() {
    return {
      crudManager: new CustomerCrud(this),
      headers: [
        {
          text: "Customer Name",
          value: "customerName",
        },
        {
          text: "Email Address",
          value: "emailAddress",
        },
        {
          text: "Address Line 1",
          value: "addressLine1",
        },
        {
          text: "Address Line 2",
          value: "addressLine2",
        },
        {
          text: "City",
          value: "city",
        },
        {
          text: "Province Or State",
          value: "provinceOrState",
        },
        ,
        {
          text: "Postal Code",
          value: "postalCode",
        },
        {
          text: "",
          value: "actions",
        },
      ],
    };
  },
};
</script>