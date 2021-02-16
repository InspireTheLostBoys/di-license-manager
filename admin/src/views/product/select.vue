<template>
    <v-container>
        <h2>Select product: </h2>
        <v-list>
            <v-list-item v-for="product in lw.crud_product.list" :key="product.id" @click="lw.setProduct(product)">
                <v-list-item-content>{{ product.productName }}</v-list-item-content>
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