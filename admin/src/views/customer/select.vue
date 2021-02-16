<template>
    <v-container>
        <h2>Select customer: </h2>
        <v-list>
            <v-list-item v-for="customer in lw.crud_customer.list" :key="customer.id" @click="lw.setCustomer(customer)">
                <v-list-item-content>{{ customer.customerName }}</v-list-item-content>
            </v-list-item>
        </v-list>
    </v-container>
</template>

<script>
export default {
  data() {
    return {
      lw: this.license_wizard(),
    };
  }
};
</script>