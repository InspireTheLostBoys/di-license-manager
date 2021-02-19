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
            <v-btn disabled text @click="editItem(item)">edit</v-btn>
            <v-btn disabled text @click="deleteItem(item)">delete</v-btn>
          </template>
        </v-data-table>
      </template>
    </ListWrapper>

    <v-btn disabled @click="crudManager.onAdd()" class="mr-3">Add</v-btn>

    <v-btn class="primary" @click="$router.push('/')">Back</v-btn>
  </v-container>
</template>

<script>
import { CustomerCrud } from "../../libs/customer";
import ListWrapper from "../../components/ListWrapper.vue";
export default {
  components: {
    ListWrapper,
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
  created() {
    console.log(this.crudManager);
  },
  methods: {
    clicked() {
      alert("clicked from parent in child");
    },
    //     editItem(item) {
    //         this.crudManager.onEdit(item);
    //     },
    //     deleteItem(item) {
    //         this.crudManager.delete(item);
    //     }
  },
};
</script>